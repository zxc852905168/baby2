using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALLsoldiers : MonoBehaviour {
    public float Need;
    public float Food;
    public float Life;
    public float Distance;
    public float Speed;
    public float damageMAX;
    public float damageMIN;
    public float LV;
    // Use this for initialization
    void Start () {
        battlecontrol.gameover1 += gameover1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void gameover1() {

      //  Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
}
