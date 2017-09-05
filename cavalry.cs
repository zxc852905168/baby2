using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavalry : ALLsoldiers
{

    // Use this for initialization
    public Vector2 speed;
    public float life;
    public float damage;
    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction;

    private Vector2 movement;

    void Update()
    {
        // 2 - Movement
        int i;
        movement = new Vector2(
         0,
          Speed * direction.y);
    }
    
    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (this.tag == "Enemycavalry")
        {
            if (otherCollider.tag == "mywall")
            {
                GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
               // Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
            if (otherCollider.tag == "Infantry")
            {
                //print("ss");
                Destroy(this.gameObject);
            }
            if (otherCollider.tag == "Archer")
            {
                Destroy(otherCollider.gameObject);
                //print("ss");
            }
            if (otherCollider.tag == "mauler")
            {
                Destroy(this.gameObject);
                // print("ss");
            }
            if (otherCollider.tag == "cavalry")
            {
                Destroy(this.gameObject);
                // print("ss");
            }
        }
        if (this.tag == "cavalry")
        {
            if (otherCollider.tag == "Enemywall")
            {
                GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(damage);
                this.gameObject.SetActive(false);
               // Destroy(this.gameObject);
            }
            if (otherCollider.tag == "EnemyInfantry")
            {
                //print("ss");
                Destroy(this.gameObject);
            }
            if (otherCollider.tag == "EnemyArcher")
            {
                Destroy(otherCollider.gameObject);
                //print("ss");
            }
            if (otherCollider.tag == "Enemymauler")
            {
                Destroy(this.gameObject);
                // print("ss");
            }
            if (otherCollider.tag == "Enemycavalry")
            {
                Destroy(this.gameObject);
                // print("ss");
            }
        }
    }
}
