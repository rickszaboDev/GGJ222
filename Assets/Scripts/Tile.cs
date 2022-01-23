using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile: MonoBehaviour
{

    bool isSelected = false;
    bool isOverIt = false;
    public GameObject selectedImg;
    public GameObject overItImg;
    int type = 0;

    void Update()
    {
        
            if (this.overItImg.activeInHierarchy)
            {
                if (this.isOverIt == false)
                {
                    this.overItImg.SetActive(false);
                }
            }
            else
            {
                if (isSelected == false)
                {
                    if (this.isOverIt == true)
                    {
                        this.overItImg.SetActive(true);
                    }
                }
            }


        if (this.selectedImg.activeInHierarchy)
        {
            if (this.isSelected == false)
            {
                this.selectedImg.SetActive(false);
            }
        }
        else
        {
            if (this.isSelected == true)
            {
                if(overItImg.activeInHierarchy == true)
                {
                    this.overItImg.SetActive(false);
                }
                if(this.selectedImg.activeInHierarchy == false)
                {
                    this.selectedImg.SetActive(true);
                }
            }
        }
    }

    public void toggleActive()
    {
        this.isSelected = !this.isSelected;
    }
    public void desactiveSelected()
    {
        if (isSelected)
        {
            isSelected = false;
        }
    }

    public bool thisSelected()
    {
        return this.isSelected;
    }

    public void setRayOver(bool value)
    {
        if (isOverIt == !value) isOverIt = value;
    }
    
    public void setType(int _type)
    {
        switch (_type)
        {
            case 1:
                this.type = _type;
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                this.type = _type;
                this.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 3:
                this.type = _type;
                this.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 4:
                this.type = _type;
                this.GetComponent<Renderer>().material.color = Color.green;
                break;

        }
    }

}
