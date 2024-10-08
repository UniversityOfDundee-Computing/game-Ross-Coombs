using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUpTriggerScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check collision is with player
        if (collision.gameObject.layer == 3)
        {
            logic.increaseAmmo();
            Destroy(gameObject);
        }

    }
}
