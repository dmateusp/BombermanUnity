using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum Directions { Horizontal, Vertical };

public class MoveEnnemy : MonoBehaviour {

    public float SPEED = 0.015f;
    private bool binaryDirection = true;
    public Directions Direction = Directions.Horizontal;
    private Stopwatch stopWatch = new Stopwatch();
    public int FrequencyTurnSecs = 3;
    private GameController gameController;

    void Start()
    {
        stopWatch.Start();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (!gameController.GameOver)
        {
            stopWatch.Start();
            System.TimeSpan ts = stopWatch.Elapsed;
            int currentNextTurn = FrequencyTurnSecs - ts.Seconds;

            if (currentNextTurn == 0)
            {
                binaryDirection = !binaryDirection;
                stopWatch.Reset();
                stopWatch.Start();
            }

            if (Direction == Directions.Horizontal)
                transform.position += binaryDirection ? new Vector3(0.5f, 0, 0) * SPEED : new Vector3(-0.5f, 0, 0) * SPEED;
            else
                transform.position += binaryDirection ? new Vector3(0, 0.5f, 0) * SPEED : new Vector3(0, -0.5f, 0) * SPEED;

        } else
        {
            stopWatch.Stop();
            
        }
    }
}
