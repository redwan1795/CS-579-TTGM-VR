using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TerrainCubeScript : MonoBehaviour
{
   private int mode=1;
    float speed = 10.0f;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(Vector3.left * speed / 3 * Time.deltaTime);
    }

    public int getMode()
    {
        return mode;
    }
}

