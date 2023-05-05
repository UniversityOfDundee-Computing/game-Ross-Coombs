using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check collision is with player
        if (collision.gameObject.layer == 3)
        {
            LogicScript.instance.increaseLives();
            Destroy(gameObject);
        }

    }
}
