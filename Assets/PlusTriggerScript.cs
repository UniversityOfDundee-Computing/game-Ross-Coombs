using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check collision is with player
        if (collision.gameObject.layer == 3)
        {
            LogicScript.instance.increaseScore();
        }

    }
}
