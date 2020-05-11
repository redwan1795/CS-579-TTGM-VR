using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayToNightScript : MonoBehaviour
{
    public Light sunLight;
    private Light L;
    public Light flashLight;
    private Light FL;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        L = (Light)Instantiate(sunLight, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
        L.transform.eulerAngles=new Vector3(50f, -30f, 0f);
        
        FL = (Light)Instantiate(flashLight, new Vector3(playerObject.transform.position.x, playerObject.transform.position.y - .8f, playerObject.transform.position.z-1), transform.rotation);
        FL.transform.SetParent(playerObject.transform);
        FL.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.N) && L.enabled)
        if(OVRInput.Get(OVRInput.Touch.Three) && L.enabled)
        {
            L.enabled = false;
            FL.enabled = true;
        }
        //else if (Input.GetKeyDown(KeyCode.N) && L.enabled==false)
        else if (OVRInput.Get(OVRInput.Touch.Three) && L.enabled == false)
        {
            L.enabled = true;
            FL.enabled = false;
        }
    }
}
