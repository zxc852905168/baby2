using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISliderControl : MonoBehaviour {
    public Text CavalryRateText;
    public Text InfantryRateText;
    public Text ArcherRateText;
    public Text maulerRateText;
    public Slider Infantry;
    public Slider cavalry;
    public Slider Archer;
    public Slider mauler;
    public float InfantryRate;
    public float cavalryRate;
    public float ArcherRate;
    public float maulerRate;
    public float InfantryNumber;
    public float cavalryNumber;
    public float ArcherNumber;
    public float maulerNumber;
    public float soldiersNumber;
    public float cavalrylastvalue;
    public float Archerlastvalue;
    public float maulerlastvalue;//储存初值
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //骑兵滑动条
    public void cavalrySlider(float even)
    {   
        CavalryRateText.text = ((int)(even)).ToString() + "%";
        // print(even);
        // print(Infantry.value );
        if (cavalrylastvalue > 0)
        {
            float i = (int)even- cavalrylastvalue;//上一次拉的位置减去这次拉的位置
            Infantry.value -= i;
            InfantryRateText.text = ((int)Infantry.value).ToString() + "%";
            //Debug.LogError("您的血量=" + even);
        }
        cavalrylastvalue = (int)even;
    }
    public void ArcherSlider(float even)
    {
        ArcherRateText.text = ((int)(even)).ToString() + "%";
        // print(even);
        // print(Infantry.value );
        if (Archerlastvalue > 0)
        {
            float i = (int)even - Archerlastvalue;
            Infantry.value -= i;
            InfantryRateText.text = ((int)Infantry.value).ToString() + "%";
            //Debug.LogError("您的血量=" + even);
        }
        Archerlastvalue = (int)even;
    }
    public void maulerSlider(float even)
    {
        maulerRateText.text = ((int)(even)).ToString() + "%";
        // print(even);
        // print(Infantry.value );
        if (maulerlastvalue > 0)
        {
            float i = (int)even - maulerlastvalue;
            Infantry.value -= i;
            InfantryRateText.text = ((int)Infantry.value).ToString() + "%";
            //Debug.LogError("您的血量=" + even);
        }
        maulerlastvalue = (int)even;
    }

    public void getRate()
    {
        //读取数据
        InfantryRate= PlayerPrefs.GetFloat("InfantryRate" );
        cavalryRate= PlayerPrefs.GetFloat("cavalryRate");
        ArcherRate= PlayerPrefs.GetFloat("ArcherRate" );
        maulerRate=PlayerPrefs.GetFloat("maulerRate" );
        soldiersNumber = PlayerPrefs.GetFloat("soldiers");
        InfantryNumber = PlayerPrefs.GetFloat("InfantryRate") / 100 * soldiersNumber;
        cavalryNumber = PlayerPrefs.GetFloat("cavalryRate") / 100 * soldiersNumber;
        ArcherNumber = PlayerPrefs.GetFloat("ArcherRate") / 100 * soldiersNumber;
        maulerNumber = PlayerPrefs.GetFloat("maulerRate") / 100 * soldiersNumber;
        //改变字符
        CavalryRateText.text = cavalryRate.ToString() + "%";
     InfantryRateText.text = InfantryRate.ToString() + "%";
     ArcherRateText.text = ArcherRate.ToString() + "%";
     maulerRateText.text = maulerRate.ToString() + "%";
        //改变滑动条
        Infantry.value = InfantryRate ;
        Archer.value = ArcherRate ;
        mauler.value = maulerRate;
        cavalry.value = cavalryRate ;
        //print(InfantryRate);
    }
    public void setRate()
    {
        PlayerPrefs.SetFloat("InfantryRate", Infantry.value);
        PlayerPrefs.SetFloat("cavalryRate", cavalry.value);
        PlayerPrefs.SetFloat("ArcherRate", Archer.value);
        PlayerPrefs.SetFloat("maulerRate", mauler.value);

    }
    }
