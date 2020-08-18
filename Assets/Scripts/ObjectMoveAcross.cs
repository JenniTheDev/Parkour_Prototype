﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveAcross : MonoBehaviour {

    [SerializeField] private float speed = 0.01f;
    private Rigidbody rb;


    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update() {
        // transform.Translate(Vector3.left * Time.deltaTime * speed);
       // rb.AddForce(-transform.right * speed);
    }

    private void FixedUpdate() {
        rb.AddForce(-transform.right * speed);
    }
}
