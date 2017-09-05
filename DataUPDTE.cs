using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataUPDTE : MonoBehaviour {
    // float aa;
    public float gain;
    public float myfood;
    public float DayTime;
    public float foodstuff;
    public float population;
    public float Getplace;
    public float soldiers;
    public float reputation;
    public float AIsoldiers;
    public float AIsoldiersQuality;
    public float AIequip;
    public float AICombatEffectiveness;
    public float AICivilian;
    public float AIfoodstuff;
    public float AImonny;
    public float placeSoldiers;//ai本地士兵
    public float placemonny;
    public float placefoodstuff;
    public float placeCombatEffectiveness;
    public float placeCivilian;
   public float GETplaceSoldiers ;//得到的奖励士兵
    public float GETplacemonny ;
    public float GETreputation;
    public float GETplacefoodstuff;
    public float transactionmonny;
    public float transactionsolder;
    public float transactionFood;
    public GameObject battlecontrol;
    public GameObject GameControl;
    public GameObject UiControl;
    public GameObject TextPratControl;
    //ArrayList sb = new ArrayList() {aa };
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnEnable()
    {
        UIcontrol.TimeUp += TimeUpData;
        UIcontrol.BattleDataStar1 += BattleDataUpData;
        UIcontrol.transactionSliderData += transactionEvenResponse;
    }
    //更新时间
    public void TimeUpData()
    {

        DayTime = PlayerPrefs.GetFloat("DayTime");
        DayTime += 1;
        PlayerPrefs.SetFloat("DayTime", DayTime);
        foodstuff = PlayerPrefs.GetFloat("foodstuff");
        soldiers = PlayerPrefs.GetFloat("soldiers");
        foodstuff -= soldiers / 10;
        PlayerPrefs.SetFloat("foodstuff", foodstuff);
        AIUpData();
    }
    //更新ai
    public void AIUpData() {
        AIsoldiers = 0.45f * DayTime / 3 * (600 - DayTime / 3);
        AIsoldiersQuality = 0.997f + 0.003f * DayTime / 3;
        AIequip = 1.047f + 0.003f * DayTime / 3;
        AICombatEffectiveness = AIsoldiers * AIsoldiersQuality * AIequip;
        AICivilian = AIsoldiers / 2.33f;
        AImonny = AIsoldiers * 1.65f;
        AIfoodstuff = AIsoldiers * 1.35f;


    }
    //更新战斗数据
    public void BattleDataUpData()
    {

        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.郡治 || GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.起义军)
        {
            //gain = 500;
            placeSoldiers = (Random.Range(0.7f, 0.8f) + gain) * AIsoldiers;
            placemonny = (Random.Range(0.7f, 0.8f) + gain) * AImonny;
            placefoodstuff = (Random.Range(0.75f, 0.85f) + gain) * AIfoodstuff;
            placeCombatEffectiveness = (Random.Range(0.7f, 0.8f) + gain) * AICombatEffectiveness;
            placeCivilian = (Random.Range(0.65f, 0.75f) + gain) * AICivilian;
            print(placeSoldiers);

        }
        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.县城)
        {

            // gain = 300;
            placeSoldiers = (Random.Range(0.6f, 0.7f) + gain) * AIsoldiers;
            placemonny = (Random.Range(0.6f, 0.7f) + gain) * AImonny;
            placefoodstuff = (Random.Range(0.65f, 0.75f) + gain) * AIfoodstuff;
            placeCombatEffectiveness = (Random.Range(0.6f, 0.7f) + gain) * AICombatEffectiveness;
            placeCivilian = (Random.Range(0.55f, 0.65f) + gain) * AICivilian;
            print(placeSoldiers);
        }
        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.山寨)
        {
            // gain = 150;
            placeSoldiers = (Random.Range(0.5f, 0.6f) + gain) * AIsoldiers;
            placemonny = (Random.Range(0.5f, 0.6f) + gain) * AImonny;
            placefoodstuff = (Random.Range(0.55f, 0.65f) + gain) * AIfoodstuff;
            placeCombatEffectiveness = (Random.Range(0.5f, 0.6f) + gain) * AICombatEffectiveness;
            placeCivilian = (Random.Range(0.55f, 0.65f) + gain) * AICivilian;
            print(placeSoldiers);
        }


    }
    //入村数据处理
    public void VillageDataHandle(){
        print("sss");
        //GameControl.GetComponent<Gamecontrol>().Advancestatus = EventStatus.起义军;
        //battlecontrol.GetComponent<battlecontrol>().getBattle();
        GETplaceSoldiers = (Random.Range(0.7f, 0.8f) ) * AIsoldiers * Random.Range(0.4F, 0.5F);
        GETplacemonny = (Random.Range(0.7f, 0.8f) ) * AImonny * Random.Range(0.5F, 0.6F);
        GETplacefoodstuff = (Random.Range(0.75f, 0.85f) ) * AIfoodstuff * Random.Range(0.45F, 0.55F);
        float soldiersNumber1 = (int)battlecontrol.GetComponent<battlecontrol>().soldiersNumber + GETplaceSoldiers;
        float myfood1 = (int)battlecontrol.GetComponent<battlecontrol>().myfood + GETplacefoodstuff;
        float monny = PlayerPrefs.GetFloat("monny") + GETplacemonny;
        soldiersNumber1 += GETplaceSoldiers;
        float InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") + GETplaceSoldiers;//步兵
        PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
        //简化储存
        PlayerPrefs.SetFloat("monny", monny);
        PlayerPrefs.SetFloat("foodstuff", myfood1);
        PlayerPrefs.SetFloat("soldiers", soldiersNumber1);
        //text
    }
    //奖励处理
    public void awardHandle()
    {
         GETplaceSoldiers = placeSoldiers * 0.7f;
         GETplacemonny = placeSoldiers * 1.1f + (int)battlecontrol.GetComponent<battlecontrol>().reputation * 30;
         GETplacefoodstuff = placeSoldiers * 1.32f;
         GETreputation = Random.Range(1, 3);
        float soldiersNumber1 = (int)battlecontrol.GetComponent<battlecontrol>().soldiersNumber;
        float myfood1 = (int)battlecontrol.GetComponent<battlecontrol>().myfood;
        float monny = PlayerPrefs.GetFloat("monny");
        print(soldiersNumber1);
        monny += GETplacemonny;
        myfood1 += GETplacemonny;
        soldiersNumber1 += GETplaceSoldiers;
      float  InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") + GETplaceSoldiers;//步兵
        PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
        PlayerPrefs.SetFloat("monny", monny);
        PlayerPrefs.SetFloat("foodstuff", myfood1);
        PlayerPrefs.SetFloat("soldiers", soldiersNumber1);
        PlayerPrefs.SetFloat("reputation", (int)battlecontrol.GetComponent<battlecontrol>().reputation + GETreputation);
       
    }
    //交易处理
    public bool TransactionHandle()
    {

        float monny = PlayerPrefs.GetFloat("monny");//判断钱够不够
                                                    // float transactionsolder;
        if (transactionmonny < monny)
        {
            float monny2 = monny - transactionmonny;
            PlayerPrefs.SetFloat("monny", monny2);
            if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.粮草商)
            {
                float food = PlayerPrefs.GetFloat("foodstuff");
                food += transactionFood;
                print(food);
                PlayerPrefs.SetFloat("foodstuff", food);
                // transactionFood = even;

            }
            if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.奴隶商)
            {
                float soldier = PlayerPrefs.GetFloat("InfantryNum");
                
                soldier += transactionsolder;
                print(soldier);
                PlayerPrefs.SetFloat("InfantryNum", soldier);
                // PlayerPrefs.SetFloat("soldiers", soldier);
                float soldier2= PlayerPrefs.GetFloat("soldiers");
                soldier2 += transactionsolder;
                PlayerPrefs.SetFloat("soldiers", soldier);

            }
            return true;
        }
        else
        {
            //TextPratControl.GetComponent<TextPratControl>().TextNoMonny();
            return false;
        }
    }
    public void transactionEvenResponse(float even)
    {
        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.粮草商)
        {
         
            transactionmonny = even * 2.5f;

           transactionFood = even;
        }
        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.奴隶商)
        {
          
            transactionmonny = even * 3;
            transactionsolder = even;
        }

    }
}
