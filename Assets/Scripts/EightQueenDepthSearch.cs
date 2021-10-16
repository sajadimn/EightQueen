using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EightQueenDepthSearch : MonoBehaviour
{
    public List<Vector2> listOfQueens = new List<Vector2>();
    private Stack<Queue<Vector2>> canQueens = new Stack<Queue<Vector2>>();
    private Stack<Vector2> queens = new Stack<Vector2>();
    private int _queenNumbers = 0;

    private void Awake()
    {
        GameData.eightQueenDepthSearch = this;
    }

    public void Init(int chessSize)
    {
        _queenNumbers = chessSize;
        Enumerate(0);
    }

    private void Enumerate(int index)
    {
        Vector2 firstQueenOfNewRow = new Vector2(-1 , -1);
        Queue<Vector2> canQueensOfNewRow = new Queue<Vector2>();
        for (int i = 0; i < _queenNumbers; i++)
        {
            Vector2 newQueen = new Vector2(index, i);
            queens.Push(newQueen);
            if (IsConsistent(queens, index))
            {
                if (int.Parse(firstQueenOfNewRow.x.ToString()) == -1)
                {
                    firstQueenOfNewRow = queens.Pop();
                }
                else
                {
                    canQueensOfNewRow.Enqueue(queens.Pop());
                }
            }
            else
            {
                queens.Pop();
            }
        }

        if(canQueensOfNewRow.Count > 0)
            canQueens.Push(canQueensOfNewRow);
        
        CheckNewQueenState(index ,firstQueenOfNewRow);
    }

    public void CheckNewQueenState(int index , Vector2 queen)
    {
        
        if (int.Parse(queen.x.ToString()) == -1)
        {
            var newQueen = canQueens.Peek().Dequeue();
            if (canQueens.Peek().Count == 0)
                canQueens.Pop();
            var lastQueen = queens.Pop();
            while (lastQueen.x > newQueen.x)
            {
                lastQueen = queens.Pop();
            }
            queens.Push(newQueen);
            Enumerate(int.Parse((newQueen.x +1).ToString()));
        }
        else
        {
            queens.Push(queen);
            if (queens.Count == _queenNumbers)
            {
                Vector2[] queensArray = new Vector2[queens.Count];
                queens.CopyTo(queensArray, 0);
                Array.Reverse(queensArray ,0 , queensArray.Length);
                listOfQueens = new List<Vector2>(queensArray);
                GameData.gameManager.FoundQueens(listOfQueens , SearchType.DepthSearch);
            }
            else
            {
                Enumerate(index+1);
            }
        }
    }

    private bool IsConsistent(Stack<Vector2> queens, int indexOfNewQueen)
    {
        Vector2[] queensArray = new Vector2[queens.Count];
        queens.CopyTo(queensArray, 0);
        Array.Reverse(queensArray ,0 , queensArray.Length);
        for (int i =  0; i < queensArray.Length -1 ; i++)
        {
            if (int.Parse(queensArray[i].y.ToString()) == queensArray[indexOfNewQueen].y)
                return false; // same column
            if (int.Parse((queensArray[i].y - queensArray[indexOfNewQueen].y).ToString()) == (indexOfNewQueen - i))
                return false; // same major diagonal
            if (int.Parse((queensArray[indexOfNewQueen].y - queensArray[i].y).ToString()) == (indexOfNewQueen - i))
                return false; // same minor diagonal
        }

        return true;
    }
}