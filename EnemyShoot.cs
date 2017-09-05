using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


    public class EnemyShoot : Skill
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
       // public Text soldtext;
        public Text foodtext;
        //public Text ensoldtext;
        // public Text enfoodtext;
        public GameObject battlecontrol;
        public float placeSoldiers;
        // public float placemonny;
        public float placefoodstuff;
        public bool isautos = true;
        // Use this for initialization
        void Start()
        {

        }
    private void OnEnable()
    {
        UIcontrol.gamestrat1 += Startbatte;
    }
    // Update is called once per frame
    void Update()
        {

        }

        //设置自动
      
        public void Startbatte()
        {
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

            this.GetComponent<EnemyShoot>().enabled = false;
            // StartCoroutine(PlayerAttack());
            StopCoroutine(PlayerAttack());

        }
        IEnumerator PlayerAttack()
        {

            AIchooseSoldier(chooseAttackWay());
            yield return new WaitForSeconds(Random.Range(1.4f, 1.5f));
            if (GameObject.Find("Gamecontrol").GetComponent<Gamecontrol>().Concept == ConceptStatus.战斗 && isautos == true)
            {
                StartCoroutine(PlayerAttack());
            }
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
                GameObject go = Instantiate(mauler, way.position, way.rotation) as GameObject;
                soldiersADD(go, 4);
            GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(InfantryFood, InfantryNeed);
            go.transform.SetParent(way);
            }
            if (randomPoint > 21 && randomPoint <= 45)
            {
                GameObject go = Instantiate(cavalry, way.position, way.rotation) as GameObject;
                 soldiersADD(go, 2);
            GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(cavalryFood, cavalryNeed);
            go.transform.SetParent(way);
            }
            if (randomPoint > 45 && randomPoint <= 72)
            {
                GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;
                soldiersADD(go, 3);
            GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(ArcherFood, ArcherNeed);
            go.transform.SetParent(way);
            }
            if (randomPoint > 72 && randomPoint <= 100)
            {
                GameObject go = Instantiate(Infantry, way.position, way.rotation) as GameObject;
                soldiersADD(go, 1);
            GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(InfantryFood, InfantryNeed);
            go.transform.SetParent(way);
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
            else
            {
                return way1;

            }

        }
        //一夫当关
        public void OneMan(GameObject soldiers)
        {

            Transform way = chooseAttackWay();
            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
       // soldiersADD(soldier, 4);
        soldier.transform.SetParent(way);

        }
        //万箭穿心

        IEnumerator ThousandArrows(float time, GameObject arrow)
        {
            for (int i = 0; i < 8; i++)
            {
                Transform way = chooseAttackWay();
                yield return new WaitForSeconds(time);
                GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
                soldier.transform.SetParent(way);
            }

        }
        //百步穿杨
        public void strongArrows(GameObject arrow)
        {
            Transform way = chooseAttackWay();

            GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);

        }
    }

