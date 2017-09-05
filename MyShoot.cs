using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyShoot : Skill
{
    public Button[] ManualButton;
    public GameObject ButtonControl;
    public GameObject StrongArrow;
    public GameObject arrow;
    public GameObject Infantry;
    public GameObject cavalry;
    public GameObject Archer;
    public GameObject mauler;
    public Transform way1;
    public Transform way2;
    public Transform way3;
    public Transform way4;
    public GameObject autoToggle;
    public GameObject ManualToggleSoldier;
   
    public Text foodtext;
    //public Text ensoldtext;
   // public Text enfoodtext;
    public GameObject battlecontrol;
    public float placeSoldiers;
    // public float placemonny;
    public float placefoodstuff;
    public bool isautos=true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
    private void OnEnable()
    {
        UIcontrol.gamestrat1 += Startbatte;
    }
    //设置自动
    public void automatic(bool isauto) {
        // isautos = isauto;
        if (this.tag=="Player") {
            isautos = autoToggle.GetComponent<Toggle>().isOn;
            ButtonControl.SetActive(true);
            // print(isauto);
            if (isautos == true) {

                Startbatte();
                ButtonControl.SetActive(false);
            }
        }
    }
    public void Startbatte() {
        //
        soldiersData();
        StartCoroutine(PlayerAttack());
        // StartCoroutine(Hydraarray(0.5f, Infantry, way1));
        // Wordmatrix(Infantry);
        // StartCoroutine(ThousandArrows(0.5f, arrow));
       // strongArrows(StrongArrow);

    }
    public void stopbatte()
    {

        this.GetComponent<MyShoot>().enabled = false;
        // StartCoroutine(PlayerAttack());
       // StopCoroutine(PlayerAttack());

    }
    IEnumerator PlayerAttack()
    {

        AIchooseSoldier(chooseAttackWay());
        yield return new WaitForSeconds(Random.Range(1.4f, 1.5f));
        if (GameObject.Find("Gamecontrol").GetComponent<Gamecontrol>().Concept == ConceptStatus.战斗&& isautos == true) {
            StartCoroutine(PlayerAttack()); }
        Debug.Log("After 3s");
    }
    /* //*自动选择兵道
     public void AIchooseAttackWay()
     {
         //Instantiate(Infantry, way1.position, Quaternion.identity);

         float randomPoint = Random.value * 100;

         if (randomPoint <= 25)
         {
             AIchooseSoldier(way1);
         }
         if (randomPoint > 25 && randomPoint <= 50)
         {
             AIchooseSoldier(way2);
         }
         if (randomPoint > 50 && randomPoint <= 75)
         {
             AIchooseSoldier(way3);
         }
         if (randomPoint > 75 && randomPoint <= 100)
         {
             AIchooseSoldier(way4);
         }
     }*/
    //自动选择兵种
    public void AIchooseSoldier(Transform way)
    {
        //Instantiate(Infantry, way1.position, Quaternion.identity);

        float randomPoint = Random.value * 100;

        if (randomPoint <= 21)
        {
            if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().maulerNumber >= maulerNeed)
            {
                GameObject go = Instantiate(mauler, way.position, way.rotation) as GameObject;
                //go.GetComponent<Infantry>().Food = InfantryFood;
                //go.GetComponent<ALLsoldiers>().Speed = 2;
                soldiersADD(go, 4);
                GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(maulerFood, maulerNeed);
                go.transform.SetParent(way);
            }else
                {
                AIchooseSoldier(chooseAttackWay());
            }
        }
        if (randomPoint > 21 && randomPoint <= 45)
        {
            if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().cavalryNumber >= cavalryNeed)
              {
                GameObject go = Instantiate(cavalry, way.position, way.rotation) as GameObject;
                soldiersADD(go, 2);
                GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(cavalryFood, cavalryNeed);
                go.transform.SetParent(way);
            }
            else {

                AIchooseSoldier(chooseAttackWay());
            }
        }
        if (randomPoint > 45 && randomPoint <= 72)
        {
                if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().ArcherNumber >= ArcherNeed)
                {
                    GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;
                    soldiersADD(go, 3);
                    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(ArcherFood, ArcherNeed);
                    go.transform.SetParent(way);
                }
                else {
                AIchooseSoldier(chooseAttackWay());

            }
        }
        if (randomPoint > 72 && randomPoint <= 100)
        {
                if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().InfantryNumber >=InfantryNeed)
                {
                    GameObject go = Instantiate(Infantry, way.position, way.rotation) as GameObject;
                    soldiersADD(go, 1);
                    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(InfantryFood, InfantryNeed);
                    go.transform.SetParent(way);
                }
                else {
                AIchooseSoldier(chooseAttackWay());

            }
        }
    }
    //自动选择兵道
    public Transform chooseAttackWay()
    {
        //Instantiate(Infantry, way1.position, Quaternion.identity);

        float randomPoint = Random.value * 100;

        if (randomPoint <= 25)
        {
            return way1;
        }
        if (randomPoint > 25 && randomPoint <= 50)
        {
            return way2;
        }
        if (randomPoint > 50 && randomPoint <= 75)
        {
            return way3;
        }
        if (randomPoint > 75 && randomPoint <= 100)
        {
            return way4;
        }
        else {
            return way1;

        }

    }
    //一夫当关
    public void OneMan( GameObject soldiers)
    {
       
            Transform way = chooseAttackWay();
            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);
       
    }
    //万箭穿心
   
    IEnumerator ThousandArrows(float time, GameObject arrow)
    {
        for (int i = 0; i < 8; i++)
        {   Transform way= chooseAttackWay(); 
            yield return new WaitForSeconds(time);
            GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);
        }

    }
    //百步穿杨
    public void strongArrows(GameObject arrow) {
        Transform way = chooseAttackWay();
        
        GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
        soldier.transform.SetParent(way);

    }
    //兵道按钮
    public void Onway1() {
        ManualSoldiersShoot(way1);
    }


    public void Onway2() {
        ManualSoldiersShoot(way2);
    }
    public void Onway3() {
        ManualSoldiersShoot(way3);

    }
    public void Onway4() {
        ManualSoldiersShoot(way4);

    }
    public void ManualSoldiersShoot(Transform way)
    {
        IEnumerable<Toggle> gg = ManualToggleSoldier.GetComponent<ToggleGroup>().ActiveToggles();
        //gg.GetType().
        foreach (Toggle ff in gg)
        {
            
            Debug.Log(ff.name);
            if (ff.name == "弓")
            {
                // GameObject go = Archer;
                if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().ArcherNumber >= ArcherNeed)
                {
                    GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;
                    soldiersADD(go, 3);
                    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(ArcherFood, ArcherNeed);
                    go.transform.SetParent(way);
                }
                else
                {

                }
            }
            if (ff.name == "盾")
            {
                if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().maulerNumber >= maulerNeed)
                {
                    GameObject go = Instantiate(mauler, way.position, way.rotation) as GameObject;
                    soldiersADD(go, 4);
                    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(maulerFood, maulerNeed);
                    go.transform.SetParent(way);
                }
                else
                {

                }
            }
            if (ff.name == "步")
            {
                if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().InfantryNumber >=InfantryNeed)
                {
                    GameObject go = Instantiate(Infantry, way.position, way.rotation) as GameObject;
                    soldiersADD(go, 1);
                    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(InfantryFood, InfantryNeed);
                    go.transform.SetParent(way);
                }
                else { }
            }
            if (ff.name == "骑")
            {
                if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().cavalryNumber >= cavalryNeed)
                {
                    GameObject go = Instantiate(cavalry, way.position, way.rotation) as GameObject;
                    soldiersADD(go, 2);
                    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(cavalryFood, cavalryNeed);
                    go.transform.SetParent(way);
                }
            }
            else
            {


            }
        }
        StartCoroutine(buttonDaley());
    }
    //按钮延时
    IEnumerator buttonDaley()
    {
        ButtonControl.SetActive(false);
        yield return new WaitForSeconds(2);
        ButtonControl.SetActive(true);
    }
}
