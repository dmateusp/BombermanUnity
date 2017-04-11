using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour {
    UnityEngine.UI.Text lifeUI;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        lifeUI = GetComponent<UnityEngine.UI.Text>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        lifeUI.text = gameController.Lives.ToString();
	}
}
