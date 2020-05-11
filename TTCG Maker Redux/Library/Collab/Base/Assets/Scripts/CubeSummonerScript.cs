using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSummonerScript : MonoBehaviour
{
    public GameObject terrainCube;
    private GameObject tCube;
    public GameObject heroCube;
    private GameObject hCube;
    public GameObject forestCube;
    private GameObject fCube;
    public GameObject snowmanCube;
    private GameObject sCube;
    public GameObject stabGuyCube;
    private GameObject stabCube;
    public GameObject effectsCube;
    private GameObject eCube;

    private int editorMode=0;
    /*
     * 0 = No explore mode -> must choose one of intitial cubes to change (hit the autokill button to reset to 0 and destroy all cubes)
     * 1 = Terrain Editing Mode -> must choose one of the terrain types to change
     * 2 = Hero Placement Mode -> must choose a hero model to change
     * 3 = Effect Placement Mode -> must choose an effect to change
     * 11 = Terrain 1 -> Target tiles to apply terrain or kill command.
     * 12 = Terrain 2
     * 13 = Terrain 3
     * 21 = Hero 1 -> Target tile to place hero model in center
     * 22 = Hero 2
     * 23 = Hero 3
     * 31 = Effects 1 - > Target tiles to apply the effect (Dust, leaves, fireflies)
     */

    // Update is called once per frame

    private GameObject CubeSummoner;


    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.T))
        {
            CubeSummoner = GameObject.FindGameObjectWithTag("CubeSummoner");
            CubeSummoner.GetComponent<CubeSummonerScript>().upDateMode(1);
        }
        */
        // returns true if the “A” button was released this frame.
        if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode < 1 || editorMode > 10))
        //if (Input.GetKeyDown(KeyCode.H) && (editorMode<1 || editorMode > 10))
        {
            upDateMode(0);

        }
        // returns true if the “A” button was released this frame.
        if (OVRInput.GetDown(OVRInput.Button.Two))
        //if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(tCube);
            Destroy(hCube);
            Destroy(sCube);
            Destroy(fCube);
            Destroy(stabCube);
            Destroy(eCube);
            editorMode = 0;
        }
    }

    public void upDateMode(int newMode)
    {
        editorMode = newMode;
        if (editorMode == 0)
        {
            editorMode = 1;

            tCube = (GameObject)Instantiate(terrainCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            tCube.transform.SetParent(transform);
            hCube = (GameObject)Instantiate(heroCube, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            hCube.transform.SetParent(transform);
            eCube = (GameObject)Instantiate(effectsCube, new Vector3(this.transform.position.x, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            eCube.transform.SetParent(transform);
        }
        else if (editorMode == 1)
        {
            //editorMode = 2;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            // Destroy(dCube);
            fCube = (GameObject)Instantiate(forestCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            fCube.transform.SetParent(transform);
        }
        else if (editorMode == 2)
        {
            //editorMode = 3;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            sCube = (GameObject)Instantiate(snowmanCube, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            sCube.transform.SetParent(transform);
            stabCube = (GameObject)Instantiate(stabGuyCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            stabCube.transform.SetParent(transform);
        }
        else if (editorMode == 3)
        {
            //editorMode = 4;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            
        }
        else if (editorMode == 11)
        {
            
            Destroy(fCube);
        }
        else if (editorMode == 21)
        {
            Destroy(stabCube);
            Destroy(sCube);
        }
        else if (editorMode == 22)
        {
            Destroy(sCube);
            Destroy(stabCube);
        }
    }
}
