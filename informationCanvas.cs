using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class informationCanvas : MonoBehaviour {
    public GameObject UIControl;
    public Text miantext;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UIControl.GetComponent<UIcontrol>().Endbattle();
        }

        }
    public void miantextconect(string whattext) {
        miantext.text = whattext;
    }
}
