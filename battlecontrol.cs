using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class battlecontrol : MonoBehaviour {
    public Text CavalryNumberText;
    public Text InfantryNumberText;
    public Text ArcherNumberText;
    public Text maulerNumberText;
    public float InfantryNumber;
    public float cavalryNumber;
    public float ArcherNumber;
    public float maulerNumber;
    public float soldiersNumber;
    public float myfood;
    public float reputation;
    public GameObject Gamecontrol;
    public GameObject myshoot;
    public GameObject enemyshoot;
    public GameObject enemyshoot2;
    public GameObject DataUPDTE;
    public GameObject DataHandle;
    public float DayTime;
    public Text mysoldtext;
    public Text myfoodtext;
    public Text ensoldtext;
    public Text enfoodtext;
    //place
    public float  gain;
    public float AIsoldiers;
    public float AIsoldiersQuality;
    public float AIequip;
    public float AICombatEffectiveness;
    public float AICivilian;
    public float AIfoodstuff;
    public float AImonny;
    public float placeSoldiers;
    public float placemonny;
    public float placefoodstuff;
    public float placeCombatEffectiveness;
    public float placeCivilian;
    public delegate void gameover();
    public static event gameover gameover1;
    // Use this for initialization
    void Start () {
    //    UIcontrol.doOne += DoOnething;

    }
    public void fff(string str) {

        Debug.Log("Do" + str);
    }
    // Update is called once per frame
    void Update () {
		
	}
   public void getBattle()
    {
        getMYdate();
       getPlaceDATE();

    }
    public void getMYdate() {
        DayTime = PlayerPrefs.GetFloat("DayTime");
        print(DayTime);
      /*  AIsoldiers = 0.45f * DayTime * (600 - DayTime);
        AIsoldiersQuality = 0.997f + 0.003f * DayTime;
        AIequip = 1.047f + 0.003f * DayTime;
        AICombatEffectiveness = AIsoldiers * AIsoldiersQuality * AIequip;
        AICivilian = AIsoldiers/2.33f;
        AImonny = AIsoldiers * 1.65f;
        AIfoodstuff = AIsoldiers * 1.35f;*/
       reputation= PlayerPrefs.GetFloat("reputation");
        myfood = PlayerPrefs.GetFloat("foodstuff");
        soldiersNumber = PlayerPrefs.GetFloat("soldiers");
        InfantryNumber = PlayerPrefs.GetFloat("InfantryNum");
        cavalryNumber = PlayerPrefs.GetFloat("cavalryNum") ;
        ArcherNumber = PlayerPrefs.GetFloat("ArcherNum");
        maulerNumber = PlayerPrefs.GetFloat("maulerNum");
        CavalryNumberText.text = cavalryNumber.ToString();
        InfantryNumberText.text = InfantryNumber.ToString();
        ArcherNumberText.text = ArcherNumber.ToString();
        maulerNumberText.text = maulerNumber.ToString();
        myshoot.GetComponent<MyShoot>().InfantryName = PlayerPrefs.GetString("InfantryName");
        myshoot.GetComponent<MyShoot>().cavalryName = PlayerPrefs.GetString("cavalryName");
        myshoot.GetComponent<MyShoot>().ArcherName = PlayerPrefs.GetString("ArcherName");
        myshoot.GetComponent<MyShoot>().maulerName = PlayerPrefs.GetString("maulerName");
        enemyshoot.GetComponent<EnemyShoot>().InfantryName = PlayerPrefs.GetString("InfantryName");
        enemyshoot.GetComponent<EnemyShoot>().cavalryName = PlayerPrefs.GetString("cavalryName");
        enemyshoot.GetComponent<EnemyShoot>().ArcherName = PlayerPrefs.GetString("ArcherName");
        enemyshoot.GetComponent<EnemyShoot>().maulerName = PlayerPrefs.GetString("maulerName");
    }
    public void getPlaceDATE()
    {
        /* if(Gamecontrol.GetComponent<Gamecontrol>().Advancestatus== EventStatus.郡治||Gamecontrol.GetComponent<Gamecontrol>().Advancestatus == EventStatus.起义军)
         {
             //gain = 500;
             placeSoldiers =(Random.Range(0.7f,0.8f) + gain) *AIsoldiers ;
             placemonny =( Random.Range(0.7f, 0.8f) + gain) * AImonny ;
             placefoodstuff = (Random.Range(0.75f, 0.85f) + gain) * AIfoodstuff;
             placeCombatEffectiveness = (Random.Range(0.7f, 0.8f) + gain) * AICombatEffectiveness;
             placeCivilian = (Random.Range(0.65f, 0.75f) + gain) * AICivilian;
             print(placeSoldiers);

         }
         if (Gamecontrol.GetComponent<Gamecontrol>().Advancestatus == EventStatus.县城)
         {

            // gain = 300;
             placeSoldiers = (Random.Range(0.6f, 0.7f) + gain) * AIsoldiers;
             placemonny = (Random.Range(0.6f, 0.7f) + gain) * AImonny;
             placefoodstuff = (Random.Range(0.65f, 0.75f) + gain) * AIfoodstuff;
             placeCombatEffectiveness = (Random.Range(0.6f, 0.7f) + gain) * AICombatEffectiveness;
             placeCivilian = (Random.Range(0.55f, 0.65f) + gain) * AICivilian;
             print(placeSoldiers);
         }
         if (Gamecontrol.GetComponent<Gamecontrol>().Advancestatus == EventStatus.山寨)
         {
            // gain = 150;
             placeSoldiers = (Random.Range(0.5f, 0.6f) + gain) * AIsoldiers;
             placemonny = (Random.Range(0.5f, 0.6f) + gain) * AImonny;
             placefoodstuff = (Random.Range(0.55f, 0.65f) + gain) * AIfoodstuff;
             placeCombatEffectiveness = (Random.Range(0.5f, 0.6f) + gain) * AICombatEffectiveness;
             placeCivilian = (Random.Range(0.55f, 0.65f) + gain) * AICivilian;
             print(placeSoldiers);
         }
        /* if (Gamecontrol.GetComponent<Gamecontrol>().Advancestatus == EventStatus.起义军)
         {
             placeSoldiers = (Random.Range(0.6f, 0.7f) + gain) * AIsoldiers;
             placemonny = (Random.Range(0.6f, 0.7f) + gain) * AImonny;
             placefoodstuff = (Random.Range(0.65f, 0.75f) + gain) * AIfoodstuff;
             placeCombatEffectiveness = (Random.Range(0.6f, 0.7f) + gain) * AICombatEffectiveness;
             placeCivilian = (Random.Range(0.55f, 0.65f) + gain) * AICivilian;


         }*/
        // 这个placeSoldiers是会变的DataUPDTE里的不会，重新起名
        placeSoldiers = DataUPDTE.GetComponent<DataUPDTE>().placeSoldiers;
        placefoodstuff = DataUPDTE.GetComponent<DataUPDTE>().placefoodstuff;
        mysoldtext.text=soldiersNumber.ToString();
        mysoldtext.text =( InfantryNumber + cavalryNumber + ArcherNumber + maulerNumber).ToString();
     myfoodtext.text = PlayerPrefs.GetFloat("foodstuff").ToString(); 
     ensoldtext.text = ((int)placeSoldiers).ToString(); 
     enfoodtext.text = ((int)placefoodstuff).ToString(); 

}
    public void soldiersdamage(float damage)
    {
        soldiersNumber -= damage;
        mysoldtext.text = (InfantryNumber + cavalryNumber + ArcherNumber + maulerNumber).ToString();
        if (soldiersNumber<=0&& Gamecontrol.GetComponent<Gamecontrol>().Concept == ConceptStatus.战斗)
        {
            Gamecontrol.GetComponent<Gamecontrol>().Concept = ConceptStatus.无事件;
            Gamecontrol.GetComponent<Gamecontrol>().AIwin();
            gameover1();
            myshoot.GetComponent<MyShoot>().stopbatte();
            enemyshoot.GetComponent<EnemyShoot>().stopbatte();
        }
    }
    public void AIsoldiersdamage(float damage)
    {
        placeSoldiers -= damage;
        ensoldtext.text = ((int)placeSoldiers).ToString();

        if (placeSoldiers <= 0 && Gamecontrol.GetComponent<Gamecontrol>().Concept == ConceptStatus.战斗)
        {
            Gamecontrol.GetComponent<Gamecontrol>().Concept = ConceptStatus.无事件;
            Gamecontrol.GetComponent<Gamecontrol>().mywin();
            gameover1();
            myshoot.GetComponent<MyShoot>().stopbatte();
            enemyshoot.GetComponent<EnemyShoot>().stopbatte();

        }
    }
    public void AIfooddamage(float fooddamage , float damage) {
        if (placefoodstuff > 0) {

            placefoodstuff -= fooddamage;
            enfoodtext.text = ((int)placefoodstuff).ToString(); }
        if (placeSoldiers > 0)
        {
            placeSoldiers -= damage;
            ensoldtext.text = ((int)placeSoldiers).ToString();
        }
    }
    public void MYfooddamage(float fooddamage, float damage)
    {
        if (myfood > 0)
        {

            myfood -= fooddamage;
        }
        myfoodtext.text = ((int)myfood).ToString();
        if (soldiersNumber > 0) {
            soldiersNumber -= damage;
            mysoldtext.text = (InfantryNumber + cavalryNumber + ArcherNumber + maulerNumber).ToString();
        }
    }

}
