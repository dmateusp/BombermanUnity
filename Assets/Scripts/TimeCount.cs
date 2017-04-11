using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TimeCount : MonoBehaviour {

    private Stopwatch stopWatch;
    private int timeAvailableSeconds;
    private GameController gameController;
    
    // Use this for initialization
    void Start () {
        stopWatch = new Stopwatch();
        timeAvailableSeconds = 200;
        stopWatch.Start();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!gameController.GameOver)
        {
            System.TimeSpan ts = stopWatch.Elapsed;
            GetComponent<UnityEngine.UI.Text>().text = (timeAvailableSeconds - ts.Seconds).ToString();
        }
    }
}
