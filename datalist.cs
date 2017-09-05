using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class datalist : MonoBehaviour {
    public float value;
    public float lastvalue;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        value = this.GetComponent<Scrollbar>().value;
        if (value> lastvalue) { }
        lastvalue = value;
        //print(value);
    }
}
