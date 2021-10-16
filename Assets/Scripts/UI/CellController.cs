using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    public Color blackColor = new Color();
    public Color whiteColor = new Color();

    public Image cellBg = null;
    public GameObject queen = null;
    
    public void Init(CellState state)
    {
        queen.SetActive(false);
        if (state == CellState.BLACK)
        {
            cellBg.color = blackColor;
        }
        else
        {
            cellBg.color = whiteColor;
        }
    }
}
