using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    void OnTriggerEnter(Collider other)
    {
    }
}
