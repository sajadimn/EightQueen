using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SearchType
{
    BreadthSearch = 0,
    DepthSearch = 1,
}
public class GameManager : MonoBehaviour
{

    public int chessSize = 8;
    
    private void Awake()
    {
        GameData.gameManager = this;
    }
    
    void Start()
    {
        GameData.gameUiController.Init(chessSize);
        GameData.eightQueenBreadthSearch.Init(chessSize);
        GameData.eightQueenDepthSearch.Init(chessSize);
    }

    public void FoundQueens(List<Vector2> queens , SearchType searchType)
    {
        GameData.gameUiController.FoundQueens(queens, searchType);
    }
}
