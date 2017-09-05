using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mauler : ALLsoldiers
{

    // Use this for initialization
    public Vector2 speed;
    public float life=2;
    public float damage;
    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction;

    private Vector2 movement;

    void Update()
    {
        // 2 - Movement
       
        movement = new Vector2(
       0,
        Speed * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
    }
    //public 
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (this.tag == "Enemymauler")
        {
            if (otherCollider.tag == "mywall")
            {
                GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                this.gameObject.SetActive(false);
               // Destroy(this.gameObject);
            }
            if (otherCollider.tag == "Infantry")
            {
                //print("ss");
                //Destroy(this.gameObject);
                life -= 1;
                if (life==0) { Destroy(this.gameObject); }
            }
            if (otherCollider.tag == "Archer")
            {
                //print("ss");
            }
            if (otherCollider.tag == "mauler")
            {
                Destroy(this.gameObject);
                // print("ss");
            }
            if (otherCollider.tag == "cavalry")
            {
                Destroy(otherCollider.gameObject);
                life -= 1;
                if (life <= 0) { Destroy(this.gameObject); }
                // Destroy(this.gameObject);
                // print("ss");
            }
        }

        if (this.tag == "mauler")
        {
            if (otherCollider.tag == "Enemywall")
            {
                GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(damage);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
            if (otherCollider.tag == "EnemyInfantry")
            {
                //print("ss");
                //Destroy(this.gameObject);
                life -= 1;
                if (life == 0) { Destroy(this.gameObject); }
            }
            if (otherCollider.tag == "EnemyArcher")
            {
                //print("ss");
            }
            if (otherCollider.tag == "Enemymauler")
            {
                Destroy(this.gameObject);
                // print("ss");
            }
            if (otherCollider.tag == "Enemycavalry")
            {
                Destroy(otherCollider.gameObject);
                life -= 1;
                if (life <= 0) { Destroy(this.gameObject); }
                // Destroy(this.gameObject);
                // print("ss");
            }
        }
    }
}
