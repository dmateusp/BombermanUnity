using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosionPrefab;

    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
