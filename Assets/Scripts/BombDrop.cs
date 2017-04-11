using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{

    public GameObject bombPrefab;
    private GameObject player;
    private BoxCollider2D[] playerCollider;

    private void Start()
    {
        playerCollider = gameObject.GetComponentsInChildren<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector2 pos = player.transform.position;
            Vector2 pos = (Vector2)playerCollider[0].bounds.center;
            Instantiate(bombPrefab, pos, Quaternion.identity);
        }
    }
}
