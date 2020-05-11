using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTile : MonoBehaviour
{
    int selectMode = 0;
    string targetName;
    string targetType;
    private GameObject CubeSummoner;
    private GameObject UISelectedTile;
    private GameObject UITileCoords;
    private GameObject UITileType;
    private GameObject UITileHeight;
    public GameObject stabGuy;
    public GameObject snowMan;
    public GameObject forest;
    private GameObject tileAddition;
    private void Start()
    {
        CubeSummoner = GameObject.FindGameObjectWithTag("CubeSummoner");
        UISelectedTile = GameObject.FindGameObjectWithTag("UITileName");
        UITileCoords = GameObject.FindGameObjectWithTag("UITileCoords");
        UITileType = GameObject.FindGameObjectWithTag("UITileType");
        UITileHeight = GameObject.FindGameObjectWithTag("UITileHeight");
    }   
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) // Change this
        //if (Input.GetKeyDown(KeyCode.F))
        // returns true if the “Right Index” button was Pressed this frame.
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))//redwan
        {
            // left click = 0
            Vector3 clickPos = -Vector3.one;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray = Camera.main.ScreenPointToRay(OVRInput.);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // 'out' works like a pass by ref.
            {
                clickPos = hit.point;
                GameObject target = hit.collider.gameObject;
                targetName = target.name;
                targetType = target.tag;
                Debug.Log(targetName + " targeted.");
                UISelectedTile.GetComponent<Text>().text= targetName;
                UITileCoords.GetComponent<Text>().text = ""+(int)clickPos.x+","+(int)clickPos.y+","+(int)clickPos.z;
                UITileType.GetComponent<Text>().text = "Type: " + targetType;
                UITileHeight.GetComponent<Text>().text = "Height: "+0;


                /*if (selectMode == 1)
                {
                    tree = (GameObject)GameObject.Instantiate(treePreefab);
                    //tBlock.transform.SetParent(transform);
                    tree.transform.localPosition = clickPos;
                }*/
                if (targetType=="Cube")
                {
                    selectMode = target.GetComponent<CubeScript>().getMode();
                    CubeSummoner.GetComponent<CubeSummonerScript>().upDateMode(selectMode);
                }
                else if (targetType == "Tile")
                {
                    if (selectMode == 11) // Add foresty
                    {
                        tileAddition = (GameObject)Instantiate(forest, new Vector3(clickPos.x, clickPos.y + .1f, clickPos.z), transform.rotation);
                        tileAddition.transform.SetParent(target.transform);
                    }
                    else if (selectMode == 21) // Add SNOWMAN!!!
                    {
                        tileAddition = (GameObject)Instantiate(snowMan, new Vector3(clickPos.x, clickPos.y+.37f, clickPos.z), transform.rotation);
                        tileAddition.transform.SetParent(target.transform);
                    }
                    else if (selectMode == 22) // Add StabGuy!!!
                    {
                        tileAddition = (GameObject)Instantiate(stabGuy, new Vector3(clickPos.x, clickPos.y + .5f, clickPos.z), transform.rotation);
                        tileAddition.transform.SetParent(target.transform);
                    }
                }
                Debug.Log("Select Mode: "+selectMode);
            }

            // Output coords
            Debug.Log(clickPos);
        }
    }
}
