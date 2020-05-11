using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    //Grid will contain references to plane objects, as well as terrain type
    //We will start our grid at 0,0
    int maxDimensionX = 20;
    int maxDimensionZ = 20;

    LinkedList<GameObject> dynamicGrid = new LinkedList<GameObject>();

    public GameObject[] tilePrefabs = new GameObject[1];
    public GameObject[,] Grid = new GameObject[20,20];
    Vector3 NextTilePosition = new Vector3(0, 0, 0);
    Vector3 FirstTileSpawn = new Vector3(0, 0, 0);
    int TileSize = 10;
    
    public TileScript tileScript;

    int next_x = 0;
    int next_y = 0;
    int next_z = 0;

    int x = 0;
    int y = 0;
    int z = 0;

    int init = 0;

    // Start is called before the first frame update
    void Start()
    {
        tileScript = FindObjectOfType<TileScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (init == 0)
        {
            EmptyDynamicBoardSpawn();
            init = 1;
        }
    }

    void EmptyDynamicBoardSpawn()
    {
        while (x < maxDimensionX)
        {

            while (z < maxDimensionZ)
            {
                next_x = x * TileSize;
                next_y = y * TileSize;
                next_z = z * TileSize;

                dynamicGrid.AddLast(SpawnTile(new Vector3(next_x, 0, next_z)));
                dynamicGrid.Last.Value.GetComponent<TileScript>().setCoords(x, z);

                z++;
            }
            z = 0;
            x++;
        }
        x = 0;
    }

    private GameObject SpawnTile(Vector3 pos)
    {
        GameObject Tile = Instantiate(tilePrefabs[0], pos, new Quaternion(0, 0, 0, 0)) as GameObject;

        return Tile;
    }

    private static Quaternion change(float x, float y, float z)
    {
        //Return the new Quaternion
        return new Quaternion(x, y, z, 1);
    }
}