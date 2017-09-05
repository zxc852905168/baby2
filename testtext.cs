using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testtext : MonoBehaviour {
    public GameObject uicontrol;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   /* void OnEnable()
    {
        UIcontrol.doOne += DoOnething;
        UIcontrol.doTwo += DoTwothing;
    }

    void OnDisable()
    {
        UIcontrol.doOne -= DoOnething;
        UIcontrol.doTwo -= DoTwothing;
    }

    public void DoOnething(string str)
    {
        Debug.Log("DoOnething " + str);
    }

    public void DoTwothing(string str)
    {
        Debug.Log("DoTwothing " + str);
    }*/
    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // this.GetComponent<Text>().enabled=false;
            this.gameObject.SetActive(false);
          //  this.GetComponent<Text>().text = "";
           // this.GetComponent<Text>().enabled = false;
            uicontrol.GetComponent<UIcontrol>() .OnOUT();
        }

    }
   /* public void test() {

        this.GetComponent<Text>().enabled = false;
    }*/
}
