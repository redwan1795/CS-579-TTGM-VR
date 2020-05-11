using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject tileCube;
    private GameObject tiCube;
    // Key input objects
    public GameObject stabGuy;
    public GameObject snowMan;
    public GameObject forest;
    private GameObject tileAddition;

    //Show status text
    public Text leftControllerOverlayText;

    private int editorMode=0;
    /*
     * 0 = No explore mode -> must choose one of intitial cubes to change (hit the autokill button to reset to 0 and destroy all cubes)
     * 1 = Terrain Editing Mode -> must choose one of the terrain types to change
     * 2 = Hero Placement Mode -> must choose a hero model to change
     * 3 = Effect Placement Mode -> must choose an effect to change
     * 11 = Terrain 1 (Tree) -> Target tiles to apply terrain or kill command.
     * 12 = Terrain 2 (Cactus)
     * 13 = Terrain 3 (Bush)
     * 21 = Hero 1 (Snowman) -> Target tile to place hero model in center
     * 22 = Hero 2 (StabGuy)
     * 23 = Hero 3 (Dogg0)
     * 31 = Effects 1 (Leaves) - > Target tiles to apply the effect
     * 32 = Effects 2 (Fireflies)
     * 33 = Effects 3 (Fire)
     * 34 = Effects 4 (Meteors)
     * 41 = Grass tile
     * 42 = Desert tile
     * 43 = Hot Coals tile
     */


    private bool isEnabledByButtonA, isEnabledByButtonRightIndex;

    private void Start()
    {
        leftControllerOverlayText.text = "RHS Index for tile/hero selction";
        isEnabledByButtonRightIndex = true;
        //isEnabledByButtonA = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && isEnabledByButtonRightIndex == true && (editorMode < 1 || editorMode > 10))
        //if (Input.GetKeyDown(KeyCode.H) && (editorMode<1 || editorMode > 10))
        {
            isEnabledByButtonRightIndex = false;
            upDateMode(0);
            
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 1))
        //else if (Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 1)) // mode 0 = initial
        {
            //isEnabledByButtonA = false;
            // pressing 1 gives left side cube
            editorMode = 3;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            Destroy(tiCube);
            sCube = (GameObject)Instantiate(snowmanCube, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            sCube.transform.SetParent(transform);
            stabCube = (GameObject)Instantiate(stabGuyCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            stabCube.transform.SetParent(transform);
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && (editorMode == 1))
        //else if (Input.GetKeyDown(KeyCode.Alpha2) && (editorMode == 1))
        {
            // pressing 2 gives right side cube
            editorMode = 2;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            Destroy(tiCube);
            // Destroy(dCube);
            fCube = (GameObject)Instantiate(forestCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            fCube.transform.SetParent(transform);
        }

        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 2))
        //else if (Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 2)) // mode 2 = terrain
        {
            // Nothing here yet
            editorMode = 12;
            Destroy(fCube);
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && (editorMode == 2))
        //else if (Input.GetKeyDown(KeyCode.Alpha2) && (editorMode == 2))
        {
            editorMode = 11;
            Destroy(fCube);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 3))
        //else if (Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 3)) // mode 3 = hero
        {
            editorMode = 21;
            Destroy(sCube);
            Destroy(stabCube);
            // Summon snowman in front of player
            sCube = (GameObject)Instantiate(snowmanCube, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            stabCube = (GameObject)Instantiate(stabGuyCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && (editorMode == 3))
        //else if (Input.GetKeyDown(KeyCode.Alpha2) && (editorMode == 3))
        {
            editorMode = 22;
            Destroy(sCube);
            Destroy(stabCube);
            // Summon stabman in front of player
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 11))
        //else if(Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 11))
        {
            tileAddition = (GameObject)Instantiate(forest, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .6f, this.transform.position.z + .7f), transform.rotation);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 12))
        //else if (Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 12))
        {

        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 21))
        //else if (Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 21))
        {
            //tileAddition = (GameObject)Instantiate(forest, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .6f, this.transform.position.z + .7f), transform.rotation);
            tileAddition = (GameObject)Instantiate(snowMan, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .6f, this.transform.position.z + .7f), transform.rotation);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && (editorMode == 22))
        //else if (Input.GetKeyDown(KeyCode.Alpha1) && (editorMode == 22))
        {
            tileAddition = (GameObject)Instantiate(stabGuy, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .6f, this.transform.position.z + .7f), transform.rotation);
        }
        //if (Input.GetKeyDown(KeyCode.P))
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && isEnabledByButtonRightIndex == false)
        {
            isEnabledByButtonRightIndex = true;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(sCube);
            Destroy(fCube);
            Destroy(stabCube);
            Destroy(eCube);
            Destroy(tiCube);
            editorMode = 0;
        }
    }

    public void upDateMode(int newMode)
    {
        editorMode = newMode;
        if (editorMode == 0)
        {
            leftControllerOverlayText.text = "ABA: STAB, AAA: SNOW, BBA: TREE";
            editorMode = 1;

            tCube = (GameObject)Instantiate(terrainCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            tCube.transform.SetParent(transform);
            hCube = (GameObject)Instantiate(heroCube, new Vector3(this.transform.position.x - .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            hCube.transform.SetParent(transform);
            eCube = (GameObject)Instantiate(effectsCube, new Vector3(this.transform.position.x, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            eCube.transform.SetParent(transform);
            tiCube = (GameObject)Instantiate(tileCube, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + .7f), transform.rotation);
            tiCube.transform.SetParent(transform);
        }
        else if (editorMode == 1)
        {
            editorMode = 2;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            // Destroy(dCube);
            fCube = (GameObject)Instantiate(forestCube, new Vector3(this.transform.position.x + .7f, this.transform.position.y - .8f, this.transform.position.z + .7f), transform.rotation);
            fCube.transform.SetParent(transform);
        }
        else if (editorMode == 2)
        {
            editorMode = 3;
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
            editorMode = 4;
            Destroy(tCube);
            Destroy(hCube);
            Destroy(eCube);
            
        }
        else if (editorMode == 11)
        {
            
            Destroy(fCube);
        }
        else if (editorMode == 12)
        {

            Destroy(fCube);
        }
        else if (editorMode == 13)
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
        else if (editorMode == 23)
        {
            Destroy(sCube);
            Destroy(stabCube);
        }
        else if (editorMode == 31)
        {
            
        }
        else if (editorMode == 32)
        {
            
        }
        else if (editorMode == 33)
        {
            
        }
        else if (editorMode == 34)
        {
            
        }
    }
}
