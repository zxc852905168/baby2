using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        // 2 - Movement
        // movement = new Vector2(
        //  0
        // speed.y * direction.y);
    }

    void FixedUpdate()
    {
        if (this.tag == "enemyarrow")
        {
            new Vector3(0, 0, 180);
            transform.rotation = Quaternion.Euler(0, 0, -180);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -2);
        }
        if (this.tag == "arrow")
        {
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 2);
        }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Enemywall")
        {
           GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(20);
            Destroy(this.gameObject);
        }
        if (otherCollider.tag == "mywall")
        {
            GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(20);
            Destroy(this.gameObject);
        }

    }

}