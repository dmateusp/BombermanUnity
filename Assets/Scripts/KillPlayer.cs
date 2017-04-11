using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private GameController gameController;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            gameController.SendMessage("Touched");
        }
            
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.SendMessage("Touched");
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
            gameController.SendMessage("Touched_Enemy");
        }
    }
}
