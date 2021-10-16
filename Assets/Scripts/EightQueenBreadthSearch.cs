using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightQueenBreadthSearch : MonoBehaviour
{

    private bool foundQueens = false;
    public List<Vector2> listOfQueens = new List<Vector2>();
    
    private void Awake()
    {
        GameData.eightQueenBreadthSearch = this;
    }
    
    public void Init (int chessSize)
    {
        Enumerate(chessSize);
    }
    
    private void Enumerate(int queenCount)
    {
        int[] queens = new int[queenCount];
        Enumerate(queens,0);
    }
    
    private void Enumerate(int[] queens, int index)
    {
        if(foundQueens)
            return;
        
        int queenCount = queens.Length;
        if (index == queenCount)
        {
            foundQueens = true;
            for (int i = 0; i < queens.Length; i++)
            {
                listOfQueens.Add(new Vector2(i , queens[i]));
            }
            GameData.gameManager.FoundQueens(listOfQueens , SearchType.BreadthSearch);
            // PrintQueens(queens);
        }
        else
        {
            for (int i = 0; i < queenCount; i++)
            {
                queens[index] = i;
                if (IsConsistent(queens, index))
                    Enumerate(queens, index + 1);
            }
        }
    }
    
    private bool IsConsistent(int[] queens, int indexOfNewQueen)
    {
        for (int i = 0; i < indexOfNewQueen; i++)
        {
            if (queens[i] == queens[indexOfNewQueen])
                return false; // same column
            if ((queens[i] - queens[indexOfNewQueen]) == (indexOfNewQueen - i))
                return false; // same major diagonal
            if ((queens[indexOfNewQueen] - queens[i]) == (indexOfNewQueen - i))
                return false; // same minor diagonal
        }

        return true;
    }

    // private void PrintQueens(int[] queens)
    // {
    //     int queenCount = queens.Length;
    //     for (int i = 0; i < queenCount; i++)
    //     {
    //         for (int j = 0; j < queenCount; j++)
    //         {
    //             if (queens[i] == j)
    //                 Debug.Log("Q ");
    //             else
    //                 Debug.Log("* ");
    //         }
    //
    //         Debug.Log("-------------------");
    //     }
    //
    //     Debug.Log("=========================");
    // }
    
}