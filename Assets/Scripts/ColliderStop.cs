using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStop : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
