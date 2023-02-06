using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFallingSpeed : MonoBehaviour {
   
   private Rigidbody2D rb;

    void Start() {
       rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.AddForce(Vector2.up * -5);
    }
}
