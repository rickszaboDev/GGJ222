using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject tilePrefab;
    public CameraTrack cameraTrack;
    int type;
    [SerializeField]private List<GameObject> tiles;

    [SerializeField]int mapHeight = 4;
    [SerializeField]int mapWidth = 4;
    [SerializeField]float tileOffset = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        CreateQuadTileMap();
    }

    void CreateQuadTileMap()
    {
        for(int x = 1;x <= mapWidth; x++)
        {
            for (int z = 1; z <= mapHeight; z++)
            {
                int tempType =  Random.Range(1,5);               
                GameObject tempObj = Instantiate(tilePrefab);
                tempObj.transform.position = new Vector3(x * tileOffset, 0, z * tileOffset);
                tempObj.gameObject.GetComponent<Tile>().setType(tempType);
                configTile(tempObj, x, z);
            }
        }

        cameraTrack.SetPosition(GenerateCameraOffSet());
    }

    void configTile(GameObject GO, int x, int z)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString() + "," + z.ToString();
        this.updateTiles(GO);
    }

    void updateTiles(GameObject GO)
    {
        if (!tiles.Contains(GO))
        {
            this.tiles.Add(GO);
        }
        
    }

    private Vector3 GenerateCameraOffSet()
    {
        float tWidth = (mapWidth * tileOffset) / 1.9f;
        float tHeight = 8;
        float tDepp = 0;
        Vector3 offset = new Vector3(tWidth, tHeight, tDepp);
        print(offset);
        return offset;
    }

}
