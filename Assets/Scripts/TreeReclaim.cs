using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeReclaim : MonoBehaviour
{
    public Transform paddle;
    public float distanceToDestroy = 5f;
    public float distanceCheck;

    void Start() {
        paddle = GameObject.FindWithTag("Player").GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y < (paddle.position.y - distanceToDestroy)) {
            Destroy(gameObject);
        }
    }
}
