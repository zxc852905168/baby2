using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersCollier : MonoBehaviour {

    // Use this for initialization
    public Vector2 speed = new Vector2(10, 10);
    public float life;
    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(1000, 1000);

    private Vector2 movement;

    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
      this.GetComponent<Rigidbody2D>().velocity += movement;
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag== "Infantry") {
            print("ss");
        }
    }
    }
