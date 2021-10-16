using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellState
{
    NONE = 0,
    BLACK =1,
    WHITE = 2,
}

public class Cell
{
    public List<CellController> cells = new List<CellController>();
}

public class CellRow
{
    public List<Cell> cellRows = new List<Cell>();
}

public class GameUiController : MonoBehaviour
{
    
    public GameObject cell;
    public GameObject row;
    
    public GameObject breadthFirstSearchContent;
    public CellRow cellsInBreadthFirstSearch = new CellRow();
    
    public GameObject depthFirstSearchContent;
    public CellRow cellsInDepthFirstSearch = new CellRow();

    private void Awake()
    {
        GameData.gameUiController = this;
    }

    public void Init(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var newRow = Instantiate(row, breadthFirstSearchContent.transform);
            var listOfCell = new Cell(); 
            for (int j = 0; j < size; j++)
            {
                var newCell = Instantiate(cell, newRow.transform);
                var newCellComponent = newCell.GetComponent<CellController>();
                listOfCell.cells.Add(newCellComponent);
                if ((i + j) % 2 == 0)
                {
                    newCellComponent.Init(CellState.WHITE);
                }
                else
                {
                    newCellComponent.Init(CellState.BLACK);
                }
            }
            cellsInBreadthFirstSearch.cellRows.Add(listOfCell);
        }
        
        for (int i = 0; i < size; i++)
        {
            var newRow = Instantiate(row, depthFirstSearchContent.transform);
            var listOfCell = new Cell(); 
            for (int j = 0; j < size; j++)
            {
                var newCell = Instantiate(cell, newRow.transform);
                var newCellComponent = newCell.GetComponent<CellController>();
                listOfCell.cells.Add(newCellComponent);
                if ((i + j) % 2 == 0)
                {
                    newCellComponent.Init(CellState.WHITE);
                }
                else
                {
                    newCellComponent.Init(CellState.BLACK);
                }
            }
            cellsInDepthFirstSearch.cellRows.Add(listOfCell);
        }
    }

    public void FoundQueens(List<Vector2> queens , SearchType searchType)
    {
        if (searchType == SearchType.BreadthSearch)
        {
            for (int i = 0; i < queens.Count; i++)
            {
                cellsInBreadthFirstSearch.cellRows[int.Parse(queens[i].x.ToString())]
                    .cells[int.Parse(queens[i].y.ToString())].queen.SetActive(true);
            }
        }else if (searchType == SearchType.DepthSearch)
        {
            for (int i = 0; i < queens.Count; i++)
            {
                cellsInDepthFirstSearch.cellRows[int.Parse(queens[i].x.ToString())]
                    .cells[int.Parse(queens[i].y.ToString())].queen.SetActive(true);
            }
        }
    }
}
