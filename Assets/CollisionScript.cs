using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public int chosenLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if not specifed then check if colliding with player
        if (chosenLayer == 0) {
            chosenLayer = 3;
        }
        //check collision is with correct laye
        if (collision.gameObject.layer == chosenLayer)
        {
            //if player collides with obstacle, decrease lives
            if (chosenLayer == 3 && (gameObject.layer == 5 || gameObject.layer == 6 || gameObject.layer == 7))
            {
                LogicScript.instance.decreaseLives();
            }
            //if the gameobject has a destruction particle affect, activate it
            if (GetComponent<ParticleSystem>() != null && GetComponent<ParticleSystem>().main.loop != true)
            {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.EmissionModule emit = GetComponent<ParticleSystem>().emission;
                emit.enabled = true;
                //hide the gameobject & prevent collisions
                try
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                    
                }
                catch (Exception)
                {
                }
                try
                {
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                catch (Exception)
                {
                }
            }
            else
            {
                //if no destruction affect then destroy gameobject
                Destroy(gameObject);
            }
        }
    }
}
