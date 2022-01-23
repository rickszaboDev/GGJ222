using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Tile;

    public void setTileSelected(GameObject value)
    {
        if(Tile != value)
        {
            if(Tile != null)
            {
                Tile.GetComponent<Tile>().desactiveSelected();
            }
            Tile = value;
        }
    }

}
