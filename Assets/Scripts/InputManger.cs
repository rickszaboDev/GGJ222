using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour
{
    [SerializeField]
    public GameObject overIt;
    [SerializeField]
    private Transform _objectHit;

    [SerializeField]
    public LevelManager levelManager;

    // Update is called once per frame
    void Update()
    {
        if(_objectHit != null)
        {
            var go = _objectHit.gameObject;
            if(go.tag == "Tile")
            {
                go.GetComponent<Tile>().setRayOver(false);
            }
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectecHit = hit.transform;
            GameObject go = objectecHit.gameObject;
            if (go.tag == "Tile")
            {
                Tile tile = go.GetComponent<Tile>();

                if (Input.GetMouseButtonDown(0))
                {
                    tile.toggleActive();
                    if (tile.thisSelected())
                    {
                        levelManager.setTileSelected(go);
                    }
                    else
                    {
                        levelManager.setTileSelected(null);
                    }
                }
                tile.setRayOver(true);
            }

            
            _objectHit = objectecHit;


        }
    
    }
}
