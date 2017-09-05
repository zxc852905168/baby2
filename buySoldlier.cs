using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buySoldlier : MonoBehaviour
{
   // public float Infantry;
    public float InfantryNumber;
    public float cavalryNumber;
    public float ArcherNumber;
    public float maulerNumber;
    public float monny;
    public string InfantryNumberstr;
    public string cavalryNumberstr;
    public string ArcherNumberstr;
    public string maulerNumberstr;
    public InputField Infantryin;
    public InputField Archerin;
    public InputField cavalryin;
    public InputField maulerin;
    public GameObject uicontrol;
    public Text monnytext;
    //步兵加
    public void Infantryadd()
    {
        float InfantryNumber1;
        float monny1;
        InfantryNumberstr = Infantryin.textComponent.text;
      if(  isnumeric(InfantryNumberstr)) {
            InfantryNumber1 = int.Parse(InfantryNumberstr);
            monny1 = InfantryNumber1 * 3;
            print(InfantryNumber1);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") + InfantryNumber1;
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
           monny = PlayerPrefs.GetFloat("monny") ;
           // PlayerPrefs.SetFloat("monny", monny);
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    //步兵减
    public void Infantryreduce()
    {
        float InfantryNumber1;
        float monny1;
        InfantryNumberstr = Infantryin.textComponent.text;
        if (isnumeric(InfantryNumberstr))
        {
            InfantryNumber1 = int.Parse(InfantryNumberstr);
            monny1 = InfantryNumber1 * 4;
            print(InfantryNumber1);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") - InfantryNumber1;
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }
    }
    //步兵输入结束
    public void Infantrytext(string str)
    {
        int InfantryNumber1;
        // print(str);
        InfantryNumberstr = Infantryin.textComponent.text;
        //float monny1;
        if (isnumeric(InfantryNumberstr))
        {
            int.TryParse(InfantryNumberstr, out InfantryNumber1);
         //   print(InfantryNumber1);
            //InfantryNumber1 = float.Parse(str);
            monnytext .text= "【步兵】" + "\n征召/裁军：" + (int)InfantryNumber1 + "\n征召总价/裁军总价：" + (int)InfantryNumber1 * 3+"/"+ (int)InfantryNumber1 * 4;
        }
        else {

            monnytext.text = "请输入数字";
        }
       
    }
    public void Archeradd()
    {

        float ArcherNumber1;
        float monny1;
        ArcherNumberstr = Archerin.textComponent.text;
        if (isnumeric(ArcherNumberstr))
        {
            ArcherNumber1 = int.Parse(ArcherNumberstr);
            monny1 = ArcherNumber1 * 3;
           // print(InfantryNumber1);
            ArcherNumber = PlayerPrefs.GetFloat("ArcherNum") + ArcherNumber1;
            PlayerPrefs.SetFloat("ArcherNum", ArcherNumber);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") - ArcherNumber1;//减少步兵
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            // PlayerPrefs.SetFloat("monny", monny);
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }
    }
    public void Archerreduce()
    {
        float ArcherNumber1;
        float monny1;
        ArcherNumberstr = Archerin.textComponent.text;
        if (isnumeric(ArcherNumberstr))
        {
            ArcherNumber1 = int.Parse(ArcherNumberstr);
            monny1 = ArcherNumber1 * 4;
            print(ArcherNumber1);
            ArcherNumber = PlayerPrefs.GetFloat("ArcherNum") - ArcherNumber1;
            PlayerPrefs.SetFloat("ArcherNum", ArcherNumber);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum")+ ArcherNumber1;//增加步兵
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void Archertext(string str)
    {
        int ArcherNumber1;
        // print(str);
        ArcherNumberstr = Archerin.textComponent.text;
        //float monny1;
        if (isnumeric(ArcherNumberstr))
        {
            int.TryParse(ArcherNumberstr, out ArcherNumber1);
            //   print(InfantryNumber1);
            //InfantryNumber1 = float.Parse(str);
            monnytext.text = "【弓兵】" + "\n征召/裁军：" + (int)ArcherNumber1 + "\n征召总价/裁军总价：" + (int)ArcherNumber1 * 3 + "/" + (int)ArcherNumber1 * 4;
        }
        else
        {

            monnytext.text = "请输入数字";
        }

    }
    public void mauleradd()
    {

        float maulerNumber1;
        float monny1;
        maulerNumberstr = maulerin.textComponent.text;
        if (isnumeric(maulerNumberstr))
        {
            maulerNumber1 = int.Parse(maulerNumberstr);
            monny1 = maulerNumber1 * 3;
            print(maulerNumber1);
            cavalryNumber = PlayerPrefs.GetFloat("maulerNum") + maulerNumber1;
            PlayerPrefs.SetFloat("mauleryNum", maulerNumber);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") - maulerNumber1;//减少步兵
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            // PlayerPrefs.SetFloat("monny", monny);
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void maulerreduce()
    {
        float maulerNumber1;
        float monny1;
        maulerNumberstr = maulerin.textComponent.text;
        if (isnumeric(maulerNumberstr))
        {
            maulerNumber1 = int.Parse(maulerNumberstr);
            monny1 = maulerNumber1 * 4;
            print(maulerNumber1);
            maulerNumber = PlayerPrefs.GetFloat("maulerNum") - maulerNumber1;
            PlayerPrefs.SetFloat("maulerNum", maulerNumber);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") + maulerNumber1;//增加步兵
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }
    }
    public void maulertext(string str)
    {
        int maulerNumber1;
        // print(str);
        maulerNumberstr = maulerin.textComponent.text;
        //float monny1;
        if (isnumeric(maulerNumberstr))
        {
            int.TryParse(maulerNumberstr, out maulerNumber1);
            //   print(InfantryNumber1);
            //InfantryNumber1 = float.Parse(str);
            monnytext.text = "【盾兵】" + "\n征召/裁军：" + (int)maulerNumber1 + "\n征召总价/裁军总价：" + (int)maulerNumber1 * 3 + "/" + (int)maulerNumber1 * 4;
        }
        else
        {

            monnytext.text = "请输入数字";
        }

    }
    public void cavalryadd()
    {

        float cavalryNumber1;
        float monny1;
        cavalryNumberstr = cavalryin.textComponent.text;
        if (isnumeric(cavalryNumberstr))
        {
            cavalryNumber1 = int.Parse(cavalryNumberstr);
            monny1 = cavalryNumber1 * 3;
            //print(InfantryNumber1);
            cavalryNumber = PlayerPrefs.GetFloat("cavalryNum") + cavalryNumber1;
            PlayerPrefs.SetFloat("cavalryNum", cavalryNumber);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") - cavalryNumber1;//减少步兵
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            // PlayerPrefs.SetFloat("monny", monny);
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void cavalryreduce()
    {
        float cavalryNumber1;
        float monny1;
        cavalryNumberstr = cavalryin.textComponent.text;
        if (isnumeric(cavalryNumberstr))
        {
            cavalryNumber1 = int.Parse(cavalryNumberstr);
            monny1 = cavalryNumber1 * 4;
            print(cavalryNumber1);
            cavalryNumber = PlayerPrefs.GetFloat("cavalryNum") - cavalryNumber1;
            PlayerPrefs.SetFloat("cavalryNum", cavalryNumber);
            InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") + cavalryNumber1;//减少步兵
            PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
            monny = PlayerPrefs.GetFloat("monny");
            if (monny < monny1)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                monny = PlayerPrefs.GetFloat("monny") - monny1;
                PlayerPrefs.SetFloat("monny", monny);
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void cavalrytext(string str)
    {
        int cavalryNumber1;
        // print(str);
        cavalryNumberstr = cavalryin.textComponent.text;
        //float monny1;
        if (isnumeric(cavalryNumberstr))
        {
            int.TryParse(cavalryNumberstr, out cavalryNumber1);
            //   print(InfantryNumber1);
            //InfantryNumber1 = float.Parse(str);
            monnytext.text = "【骑兵】" + "\n征召/裁军：" + (int)cavalryNumber1 + "\n征召总价/裁军总价：" + (int)cavalryNumber1 * 3 + "/" + (int)cavalryNumber1 * 4;
        }
        else
        {

            monnytext.text = "请输入数字";
        }

    }
    public bool isnumeric(string str)
    {
        char[] ch = new char[str.Length];
        ch = str.ToCharArray();
        for (int i = 0; i< str.Length; i++ ) {
            if (ch[i] < 48 || ch[i] > 57)
                return false;
        }
        return true;
    }
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
