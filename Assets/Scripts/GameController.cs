using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool GameOver = false;
    public int Lives = 3;
    // public int EnenemyCount = 4;
    public int Score = 4;
    private GameObject player;
    private PlayerMove playerScript;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMove>();
    } 
    public void Touched()
    {

        Lives--;
        GameOver = true;
    }
    public void Touched_Enemy()
    {
        // Score needs to change
        Debug.Log("Enemy_killed");
        Score--;

    }
    private void FixedUpdate()
    {
        if (GameOver)
        {
            playerScript.Die();
            if (Lives > 0)
            {
                if(!playerScript.isRespawning)
                    StartCoroutine(playerScript.Respawn(2));
            }
        }

    }
}
