using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class AvatarControlScript : MonoBehaviour
{
    public float jumpStrength = 13;
    public GameObject missile;

    // Update is called once per frame
    void Update()
    {
        //if player falls off the bottom, remove a life and reset them to the centre
        if (GetComponent<Transform>().position.y < -13 && LogicScript.instance.lives > 0)
        {
            LogicScript.instance.decreaseLives();
            GetComponent<Transform>().position = new Vector3(0, 0, 0);
        }

        //jump when space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) == true && LogicScript.instance.lives > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpStrength;
        }
        //spawn missle when x key is pressed and decrease ammo count
        if (Input.GetKeyDown(KeyCode.LeftShift) && LogicScript.instance.ammo > 0)
        {
            Instantiate(missile, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0f, 0f, 0f));
            LogicScript.instance.decreaseAmmo();
        }

        //change colouring when low on lives
        if(LogicScript.instance.lives > 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.85f);
        }
    }
}
