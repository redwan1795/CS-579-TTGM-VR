using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    //0 = blank/empty
    //1 = grasslands
    //2 = desert
    //3 = firelands
    //4 = water
    //5 = lava

    int[] TileType = new int[10];
    int TileHeight;
    public GameObject AnchorPoint;
    public GameObject OccupiedBy;
    float x_Coord;
    float z_Coord;

    //walls(will allow changing or creating of outer blocking wall, while inner areas remain free)
    public GameObject NorthWall;
    public GameObject SouthWall;
    public GameObject EastWall;
    public GameObject WestWall;

    public bool OuterWall = false;
    public bool InnerWall = false;

    public bool NorthEdge = false;
    public bool SouthEdge = false;
    public bool EastEdge = false;
    public bool WestEdge = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("I Exist!!!");
    }

    public void setCoords(float x, float z)
    {
        x_Coord = x;
        z_Coord = z;
        //Debug.Log("\n SetCoords x: " + x + "\n");
        //Debug.Log("\n SetCoords z: " + z + "\n");
        //Debug.Log("\n SetCoords x_Coord: " + x_Coord + "\n");
        //Debug.Log("\n SetCoords z_Coord: " + z_Coord + "\n");

        Debug.Log(gameObject.transform.position);
    }    

    void setEdges()
    {
        if(x_Coord == 0)
        {
            EastEdge = true;
            WestEdge = false;
        }
        else if (x_Coord == 19)
        { 
            WestEdge = true;
            EastEdge = false;
        }
        else {
            EastEdge = false;
            WestEdge = false;
        }
        if (z_Coord == 0)
        {
            SouthEdge = false;
            NorthEdge = true;
        }
        else if (z_Coord == 19)
        {
            NorthEdge = false;
            SouthEdge = true;
        }
        else
        {
            NorthEdge = false;
            SouthEdge = false;
        }
    }

    void setWalls()
    {
        if (NorthEdge)
        {
            NorthWall.SetActive(true);
            SouthWall.SetActive(false);
        }
        else if (SouthEdge)
        {
            NorthWall.SetActive(false);
            SouthWall.SetActive(true);
        }
        else
        {
            NorthWall.SetActive(false);
            SouthWall.SetActive(false);
        }
        
        if(WestEdge)
        {
            WestWall.SetActive(true);
            EastWall.SetActive(false);
        }
        else if(EastEdge)
        {
            WestWall.SetActive(false);
            EastWall.SetActive(true);
        }
        else
        {
            WestWall.SetActive(false);
            EastWall.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        setEdges();
        setWalls();
    }
}
