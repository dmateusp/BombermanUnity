using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    void onTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.isStatic)
        {
            Destroy(col.gameObject);
        }
    }
}
