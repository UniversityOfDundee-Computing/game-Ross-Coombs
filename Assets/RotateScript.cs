using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed = -0.2f;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(0, 0, speed);
    }
}
