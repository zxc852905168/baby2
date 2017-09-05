using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum EventStatus
{
    None,
    Poison,
    Slow,
    Mute,
    郡治,
    县城,
    山寨,
    村落,
    粮草商,
    奴隶商,
    疫病感染,
    起义军,
    无
}
public enum ConceptStatus
{
    无事件,
    战斗,
     裁军,
    村落,
    交易,
        交易中
}

public class Gamecontrol : MonoBehaviour {
        public float AIsoldiers;
    public float AIsoldiersQuality;
    public float AIequip;
    public float AICombatEffectiveness;
        public float AICivilian;
    public float AIfoodstuff;
        public float AImonny;
    public string yearTime;
    public float DayTime;
    public float CombatEffectiveness;
    public float reputation;
    public float Weight;
    public float monny;
    public float foodstuff;
    public float population;
    public float Getplace;
    public float soldiers ;
    public float Civilian ;
    public float Highestsoldiers;
    public float Highestmonny;
    public float Highestfoodstuff;
    public float Highestreputation;
    public float InfantryRate;
    public float cavalryRate;
    public float ArcherRate;
    public float maulerRate;
    public float InfantryNeed;
    public float cavalryNeed;
    public float ArcherNeed;
    public float maulerNeed;
    public float InfantryNum;
    public float cavalryNum;
    public float ArcherNum;
    public float maulerNum;
    public float InfantryFood;
    public float cavalryFood;
    public float ArcherFood;
    public float maulerFood;
    public string InfantryName;
    public string cavalryName;
    public string ArcherName;
    public string maulerName;
    public string place;
    public float morale;
    public Text EventText;
    public Text EventDATAText;
    public EventStatus Advancestatus;
    public GameObject uicontrol;
    public ConceptStatus Concept= ConceptStatus.无事件;
     // Use this for initialization
     void Start () {
        UIcontrol.doOne += fff;
    }
    public void fff(string str)
    {

        Debug.Log("Do" + str);
    }
    private void OnEnable()
    {
        //UIcontrol.TimeUp += TimeUpData;
    }
    // Update is called once per frame
    void Update () {
       // PlayerPrefs.SetFloat("TIME", Time);
       
    }
    //新的游戏
    public void NewGame() {
        //PlayerPrefs.SetFloat();
        //AI士兵数 = 0.45 * 天数 * (600 - 天数);
       // AI士兵素养 = 0.997 + 0.003 * 天数;
        //AI装备加成 = 1.047 + 0.003 * 天数;
       // AI战斗力 = AI士兵数 * AI士兵素养 * AI装备加成;
       // AI平民数 = AI士兵数 / 2.33;
       // AI粮草 = AI士兵数 * 1.35;
       // AI钱币 = AI士兵数 * 1.65;
         AIsoldiers=0.45f * DayTime/3 * (600 - DayTime/3);
         AIsoldiersQuality = 0.997f + 0.003f * DayTime/3;
         AIequip = 1.047f + 0.003f * DayTime/3;
         AICombatEffectiveness = AIsoldiers * AIsoldiersQuality * AIequip;
         AICivilian = AIsoldiers * 1.35f;
         AImonny= AIsoldiers * 1.65f;
        DayTime = 0;
        yearTime ="";
        reputation = 10;//民心
        monny = 4000;
        Weight = 3400;
        foodstuff = 2000;
        CombatEffectiveness = 600;
        Civilian = 300;
        soldiers = 500;
        Getplace = 0;
        place = "";
        InfantryRate=35;
        cavalryRate=20;
        ArcherRate=30;
        maulerRate=15;
        InfantryNum = 175;
        cavalryNum = 100;
        ArcherNum = 150;
        maulerNum = 75;
        morale = 1000;
        Highestsoldiers = soldiers;
      Highestmonny= monny;
    Highestfoodstuff= foodstuff;
     Highestreputation= reputation;
    /* InfantryNeed;
     cavalryNeed;
     ArcherNeed;
     maulerNeed;
     InfantryFood;
     cavalryFood;
     ArcherFood;
     maulerFood;*/
    InfantryName="轻步兵";
     cavalryName= "轻骑兵";
     ArcherName= "弓兵";
     maulerName= "盾兵";
        PlayerPrefs.SetFloat("InfantryNum", InfantryNum);
        PlayerPrefs.SetFloat("cavalryNum", cavalryNum);
        PlayerPrefs.SetFloat("ArcherNum", ArcherNum);
        PlayerPrefs.SetFloat("maulerNum", maulerNum);
        PlayerPrefs.SetString("InfantryName", InfantryName);
        PlayerPrefs.SetString("cavalryName", cavalryName);
        PlayerPrefs.SetString("ArcherName", ArcherName);
        PlayerPrefs.SetString("maulerName", maulerName);
        PlayerPrefs.SetFloat("morale", morale);
        PlayerPrefs.SetFloat("AIsoldiers", AIsoldiers);
        PlayerPrefs.SetFloat("AIsoldiersQuality", AIsoldiersQuality);
        PlayerPrefs.SetFloat("AIequip", AIequip);
        PlayerPrefs.SetFloat("Highestsoldiers", Highestsoldiers);
        PlayerPrefs.SetFloat("Highestmonny", Highestmonny);
        PlayerPrefs.SetFloat("Highestfoodstuff", Highestfoodstuff);
        PlayerPrefs.SetFloat("Highestreputation", Highestreputation);
        PlayerPrefs.SetFloat("AICombatEffectiveness", AICombatEffectiveness);
        PlayerPrefs.SetFloat("AICivilian", AICivilian);
        PlayerPrefs.SetFloat("AImonny", AImonny);
        PlayerPrefs.SetFloat("DayTime", DayTime);
        PlayerPrefs.SetFloat("InfantryRate", InfantryRate);
        PlayerPrefs.SetFloat("cavalryRate", cavalryRate);
        PlayerPrefs.SetFloat("ArcherRate", ArcherRate);
        PlayerPrefs.SetFloat("maulerRate", maulerRate);
        PlayerPrefs.SetFloat("reputation", reputation);
        PlayerPrefs.SetFloat("soldiers", soldiers);
        PlayerPrefs.SetFloat("monny", monny);
        PlayerPrefs.SetFloat("Weight", Weight);
        PlayerPrefs.SetFloat("foodstuff", foodstuff);
        PlayerPrefs.SetFloat("CombatEffectiveness", CombatEffectiveness);
        PlayerPrefs.SetFloat("Civilian", Civilian);
        PlayerPrefs.SetFloat("Getplace", Getplace);
        PlayerPrefs.SetString("place", place);
        PlayerPrefs.SetString("yearTime", yearTime );
        //Weight = PlayerPrefs.GetFloat("TIME", Time);
        //print(Weight);
    }
   public void East() {
        AdvanceEvent();
    }
    public void West()
    {
        AdvanceEvent();
    }
    public void South()
    {
        AdvanceEvent();
    }
    public void North()
    {
        AdvanceEvent();
    }
    public void TimeUpData() {

        DayTime = PlayerPrefs.GetFloat("DayTime");
        DayTime += 1 ;
        PlayerPrefs.SetFloat("DayTime", DayTime);
       foodstuff  =PlayerPrefs.GetFloat("foodstuff");
       soldiers =PlayerPrefs.GetFloat("soldiers");
        foodstuff -= soldiers / 10;
        PlayerPrefs.SetFloat("foodstuff", foodstuff);

    }
    public void AdvanceEvent()
    {

        //消耗
     //   DayTime += 1;
     //   foodstuff -= soldiers * 0.15f + Civilian * 0.05f;
     //   PlayerPrefs.SetFloat("DayTime", DayTime);
      //  PlayerPrefs.SetFloat("foodstuff", foodstuff);
        //随机事件
        float randomPoint = Random.value * 100;
        print(randomPoint);
        if (randomPoint<=2.5)
        {
            Advancestatus = EventStatus.郡治;
            Concept = ConceptStatus.战斗;
            EventText.text = "抵达郡治\n你来到了本郡的郡治" + place + "附近"+ "\n是否要率军攻打该城池？";
            uicontrol.GetComponent<UIcontrol>().YesOrNobuttonEvent();
        }
        if (randomPoint>2.5&& randomPoint <=15)
        {
            Advancestatus = EventStatus.县城;
            Concept = ConceptStatus.战斗;
            EventText.text = "抵达县城\n你来到了本郡的县城" + place + "附近"+ "\n是否要率军攻打该县城";
            uicontrol.GetComponent<UIcontrol>().YesOrNobuttonEvent();
        }
        if (randomPoint > 15 && randomPoint <= 35)
        {
            Advancestatus = EventStatus.山寨;
            Concept = ConceptStatus.战斗;
            EventText.text = "抵达山寨\n你来到了本郡某山寨" + place + "附近"+ "\n是否要率军攻打该山寨？";
            uicontrol.GetComponent<UIcontrol>().YesOrNobuttonEvent();
        }
        if (randomPoint > 35 && randomPoint <= 47.5)
        {
            Advancestatus = EventStatus.起义军;
            Concept = ConceptStatus.村落;
            EventText.text = "抵达村落\n你来到了本郡的某村落附近，是否要率军入驻该村落？";
            uicontrol.GetComponent<UIcontrol>().YesOrNobuttonEvent();
        }
        if (randomPoint > 47.5 && randomPoint <= 53.75)
        {
            Advancestatus = EventStatus.奴隶商;
            Concept = ConceptStatus.交易;
           EventText.text = "商队交易\n支奴隶商队携带着人口*XXXX来到了附近\n是否与之交易？";
            uicontrol.GetComponent<UIcontrol>().YesOrNobuttonEvent();
        }
        if (randomPoint > 53.75 && randomPoint <= 60)
        {
            Advancestatus = EventStatus.粮草商;
            Concept = ConceptStatus.交易;
            EventText.text ="商队交易\n支粮草商队携带着粮草*XXXX来到了附近\n是否与之交易？";
            uicontrol.GetComponent<UIcontrol>().YesOrNobuttonEvent();
        }
        if (randomPoint > 60 && randomPoint <= 65)
        {
            Advancestatus = EventStatus.疫病感染;
            EventText.text = "疫病感染\n流感突发\n不少士兵因此病逝了【士兵-XXX】";
        }
        if (randomPoint > 60)
        {
            Advancestatus = EventStatus.None;
            EventText.text = "  无事件\n行进了几个时辰之后\n斥候也没在附近发现有人口聚集之地";
        }

    }
   public void Evacuate()
    {
        float randomPoint = Random.value * 100;

        if (randomPoint <= 30)
        {

        }
        else {
            

        }

        }
    public void mywin()
    {
        uicontrol.GetComponent<UIcontrol>().mywin();

    }
    public void AIwin()
    {

        uicontrol.GetComponent<UIcontrol>().AIwin();
    }
    //最高分替换
    public void Highest() {
       if( Highestsoldiers < soldiers) {
            Highestsoldiers = soldiers;
            PlayerPrefs.SetFloat("Highestsoldiers", soldiers); }
        if (Highestmonny < monny) {
            Highestmonny = monny;
            PlayerPrefs.SetFloat("Highestmonny", monny); }
        if (Highestfoodstuff < foodstuff) {
            Highestfoodstuff = foodstuff;
            PlayerPrefs.SetFloat("Highestfoodstuff", foodstuff); }
        if (Highestreputation < reputation) {
            Highestreputation = reputation;
            PlayerPrefs.SetFloat("Highestreputation", reputation); }
       /* Highestmonny = monny;
        Highestfoodstuff = foodstuff;
        Highestreputation = reputation;
       
        PlayerPrefs.SetFloat("Highestmonny", Highestmonny);
        PlayerPrefs.SetFloat("Highestfoodstuff", Highestfoodstuff);
        PlayerPrefs.SetFloat("Highestreputation", Highestreputation);*/

    }
}
