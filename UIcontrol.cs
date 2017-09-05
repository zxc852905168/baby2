using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIcontrol : MonoBehaviour {
    public Canvas MianCanvas;//背景
    public Canvas DisarmamentCanvas;//裁军层
    public Canvas menuCanvas;
    public GameObject informationCanvas;
    public Canvas battleCanvas;//战斗层
    public Canvas SoldierAdjustmentCanvas;//调兵层
    public RectTransform targetUI;
    public Button[] movebutton;//行军按钮
    public Button[] mainbutton;//主按钮
    public Button[] YesOrNobutton;//是否按钮
    public Button[] YesOrNobattle;
    public Button[] mainbuttondisarmament;//裁军按钮
    public GameObject[] Masks;//地图遮罩
    public GameObject Gamecontrol;
    public GameObject battlecontrol;
    public GameObject UISliderControl;
    public GameObject MYbattleControl;
    public GameObject AIbattleControl;
    public GameObject TextPratControl;
    public GameObject DataUPDTE;
    public float transactionmonny;
    public float transactionsolder;
    public float transactionFood;
    public float placeSoldiers1;
  public  float placemonny2;
    public float transactionvalue;
    public GameObject transactionSlider;
    public float placefoodstuff3;
    public delegate void DoOnething(string str);
    public static event DoOnething doOne;
    public delegate void gamestrat();
    public static event gamestrat gamestrat1;
    public GameObject EventDATAText;
    public Text EventText;
    public delegate void DoTwothing(float even);
    public static event DoTwothing transactionSliderData;
    public delegate void TimeUpdate();
    public static event TimeUpdate TimeUp;
    public delegate void BattleDataStar();
    public static event BattleDataStar BattleDataStar1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    
    public void OnMyButtonClickAdvance2()

    {
        TimeUp();//时间更新

       
        Gamecontrol.GetComponent<Gamecontrol>().AdvanceEvent();//随机事件
        Gamecontrol.GetComponent<Gamecontrol>().Highest();

    }
    //休整按钮
    public void OnMyButtonClickRest()
    {
     
        MianCanvas.GetComponent<Canvas>().enabled = false;
        SoldierAdjustmentCanvas.GetComponent<Canvas>().enabled = false;
        // /. UISliderControl.GetComponent<UISliderControl>().setRate();
        DisarmamentCanvas.GetComponent<Canvas>().enabled = true;

    }
   
    public void OnMyButtonClickOUT2()
    {   //裁军返回
        foreach (Button go in mainbutton)
        {
            go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
          

        }
        foreach (Button go in mainbuttondisarmament)
        {
            go.transform.DOMoveY(-550, 1).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
    }
    // 否按钮
    public void OnMyButtonClickNO()
    {  //否按钮
        
            foreach (Button go in YesOrNobutton)
            {
                go.transform.DOMoveY(-550, 1).SetEase(Ease.OutBack).SetRelative();
                // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

            }
            OnOUT();
            //Gamecontrol.GetComponent<Gamecontrol>().Concept = ConceptStatus.无事件;

       
    }   
    //是  按钮
         public void OnMyButtonClickYES() { 
            if(Gamecontrol.GetComponent<Gamecontrol>().Concept==ConceptStatus.裁军) { 


          //裁军确定
                DisarmamentCanvas.GetComponent<Canvas>().enabled = true;
            }
        if (Gamecontrol.GetComponent<Gamecontrol>().Concept == ConceptStatus.战斗)
        {//先生成ai数据
            BattleDataStar1();//数据更新
            battlecontrol.GetComponent<battlecontrol>().getBattle();
            TextPratControl.GetComponent<TextPratControl>().EventTextUpdte("战斗", "起义军");
            foreach (Button go in YesOrNobattle)
            {
                go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
            }

            foreach (Button go in YesOrNobutton)
            {
                go.transform.DOMoveY(-550, 1).SetEase(Ease.OutBack).SetRelative();
                // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

            }
        }
        if (Gamecontrol.GetComponent<Gamecontrol>().Concept == ConceptStatus.村落)
        {
            VillageEvent();

            
        }
       
        if (Gamecontrol.GetComponent<Gamecontrol>().Concept == ConceptStatus.交易中)
        {
            //  VillageEvent();
           // DataUPDTE.GetComponent<DataUPDTE>().TransactionHandle();
            transactionIsSuccess();
           
            }

         
        if (Gamecontrol.GetComponent<Gamecontrol>().Concept == ConceptStatus.交易)
        {
            transactionEvent();


        }
    }


  
    public void OnYes()
    { }
    public void OnNo()
    { }
    //东南西北
    public void OnMyButtonClickEast()
    {
        Gamecontrol.GetComponent<Gamecontrol>().East();
        print("qq");

    }
    public void OnMyButtonClickWest()
    {
        Gamecontrol.GetComponent<Gamecontrol>().West();
    }
    public void OnMyButtonClickSouth()
    {
        Gamecontrol.GetComponent<Gamecontrol>().South();

    }
    public void OnMyButtonClickNorth()
    {
        Gamecontrol.GetComponent<Gamecontrol>().North();
    }
    //点击返回
    public void OnOUT()
    {   
        foreach (Button go in mainbutton)
        {
            go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
        transactionSlider.SetActive(false);
        EventText.GetComponent<Text>().enabled = true;
        EventText.text = "         接下来该做什么呢？";
  
    }
   
   //新游戏
    public void OnMyButtonNewGame()
    {
        Gamecontrol.GetComponent<Gamecontrol>().NewGame();
        menuCanvas.GetComponent<Canvas>().enabled = false;
        MianCanvas.GetComponent<Canvas>().enabled = true;

    }

    public void YesOrNobuttonEvent() {
        foreach (Button go in YesOrNobutton)
        {//.SetEase(Ease.OutBack).SetRelative();
            go.transform.DOMoveY(550, 1).SetEase(Ease.OutBack).SetRelative(); ;
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
       
        foreach (Button go in mainbutton)
        {
            go.transform.DOMoveY(-700, 1).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }

    }
    //调整士兵
    public void OnSoldierAdjustment() {
        MianCanvas.GetComponent<Canvas>().enabled = false;
        SoldierAdjustmentCanvas.GetComponent<Canvas>().enabled = true;
        UISliderControl.GetComponent<UISliderControl>().getRate();
    }
    //调整士兵的返回
    public void OnSoldierAdjustmentReturn()
    {
        MianCanvas.GetComponent<Canvas>().enabled = true;
        SoldierAdjustmentCanvas.GetComponent<Canvas>().enabled = false;
        // /. UISliderControl.GetComponent<UISliderControl>().setRate();
        DisarmamentCanvas.GetComponent<Canvas>().enabled = false;
    }
    //进攻
    public void OnbattleYes() {
        battleCanvas.GetComponent<Canvas>().enabled = true;
        MianCanvas.GetComponent<Canvas>().enabled = false;
        EventText.GetComponent<Text>().enabled = false;
        //  battlecontrol.GetComponent<battlecontrol>().getBattle();//先读数据
        
        gamestrat1();
       
       // MYbattleControl.GetComponent<MyShoot>().Startbatte();
       // AIbattleControl.GetComponent<EnemyShoot>().Startbatte();
        foreach (Button go in YesOrNobattle)
        {
            go.transform.DOMoveY(-700, 1).SetEase(Ease.OutBack).SetRelative(); ;
        }
    }
    //撤离
    public void OnEvacuate()
    {
       // Gamecontrol.GetComponent<Gamecontrol>().Evacuate();

        float randomPoint = Random.value * 100;

        if (randomPoint <= 30)
        {

        }
        else
        {
            myEvacuate();

        }
    }
    public void Endbattle()
    {
       
      
        battleCanvas.GetComponent<Canvas>().enabled = false;
        MianCanvas.GetComponent<Canvas>().enabled = true;
        //行军返回
        foreach (GameObject go in Masks)
        {
            go.GetComponent<CanvasGroup>().DOFade(0, 2);
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }

        foreach (Button go in mainbutton)
        {
            go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative(); ;
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }

    }
    public void mywin() {
       
        MianCanvas.GetComponent<Canvas>().enabled = true;

        award();
        battleCanvas.GetComponent<Canvas>().enabled = false;
        battleCanvas.GetComponent<battlecontrol>().enabled = false;
    }

    public void AIwin() {
      
        // informationCanvas.GetComponent<informationCanvas>().miantextconect("你输了");
      
        PlayerPrefs.SetFloat("reputation", (int)battlecontrol.GetComponent<battlecontrol>().reputation +1);
        TextPratControl.GetComponent<TextPratControl>().EventDATATextUpdte("战败");
       // EventDATAText.GetComponent<Text>().text = "【战败】很可惜，此次作战你失败了，不过民心依旧提升了一点【民心+1】";
       // EventDATAText.SetActive(true);
        battleCanvas.GetComponent<Canvas>().enabled = false;
        battleCanvas.GetComponent<battlecontrol>().enabled = false;
    }
    //撤离2
    public void myEvacuate()
    {
        foreach (Button go in YesOrNobattle)
        {
            go.transform.DOMoveY(-700, 1).SetEase(Ease.OutBack).SetRelative(); ;
        }
        foreach (Button go in mainbutton)
        {
            go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
        EventText.text = "撤离成功\n接下来该做什么呢？";
    }
    //战胜奖励
    public void award()
    {
        print("kkk");
        DataUPDTE.GetComponent<DataUPDTE>().awardHandle();//奖励处理
        TextPratControl.GetComponent<TextPratControl>().EventDATATextUpdte("奖励");
     

    }
    //入村
    public void VillageEvent()
    {
        float randomPoint = Random.value * 100;
        print(randomPoint);
        if (randomPoint <= 30)
        {
         
            Gamecontrol.GetComponent<Gamecontrol>().Concept = ConceptStatus.战斗;
           /* foreach (Button go in YesOrNobattle)
            {
                go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
            }

            foreach (Button go in YesOrNobutton)
            {
                go.transform.DOMoveY(-550, 1).SetEase(Ease.OutBack).SetRelative();
                // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

            }*/

            TextPratControl.GetComponent<TextPratControl>().EventTextUpdte("战斗","起义军");
        }
        else {
            
            DataUPDTE.GetComponent<DataUPDTE>().VillageDataHandle();
          
            foreach (Button go in YesOrNobutton)
            {
                go.transform.DOMoveY(-550, 1).SetEase(Ease.OutBack).SetRelative();
                // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

            }
           // EventText.GetComponent<Text>().enabled = false;
         // EventDATAText.GetComponent<Text>().text = "无\n村民们听闻是你公子扶苏的起义军队后，\n热情地将你率军队在村中休整一番\n并且不少青壮申请加入你的队列\n还献来了一些钱粮\n【士兵 ";
          
        // EventDATAText.SetActive(true);
            TextPratControl.GetComponent<TextPratControl>().EventDATATextUpdte("入村");

        }



        }
    //交易
    public void transactionEvent()
    {
        transactionSlider.SetActive(true);
        transactionSliderValue();
        Gamecontrol.GetComponent<Gamecontrol>().Concept = ConceptStatus.交易中;
    }
    //滑动条值设置
    public void transactionSliderValue()
    {
        if (Gamecontrol.GetComponent<Gamecontrol>().Advancestatus == EventStatus.粮草商)
        {
            transactionSlider.GetComponent<Slider>().maxValue = 1000 + Gamecontrol.GetComponent<Gamecontrol>().Highestfoodstuff * 1.1f;
            transactionSlider.GetComponent<Slider>().minValue = 1000;
            if (transactionSlider.GetComponent<Slider>().maxValue >= 2000) { transactionSlider.GetComponent<Slider>().maxValue = 2000; }
        }
        if (Gamecontrol.GetComponent<Gamecontrol>().Advancestatus == EventStatus.奴隶商)
        {
            transactionSlider.GetComponent<Slider>().maxValue = 1000 + Gamecontrol.GetComponent<Gamecontrol>().Highestsoldiers * 1.25f;
            transactionSlider.GetComponent<Slider>().minValue = 1000;
            if (transactionSlider.GetComponent<Slider>().maxValue >= 2000) { transactionSlider.GetComponent<Slider>().maxValue = 2000; }
        }

    }
    public void transactionIsSuccess()
    {
       bool IsSuccess =DataUPDTE.GetComponent<DataUPDTE>().TransactionHandle();
        if (IsSuccess) {
            transactionSlider.SetActive(false);
            foreach (Button go in YesOrNobutton)
            {
                go.transform.DOMoveY(-550, 1).SetEase(Ease.OutBack).SetRelative();
                // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

            }
            foreach (Button go in mainbutton)
            {
                go.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
                // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

            }
            TextPratControl.GetComponent<TextPratControl>().EventTextUpdte("交易成功", "交易成功");
        } else {


            TextPratControl.GetComponent<TextPratControl>().PromptTextUpdte("交易失败");


        }

    }
    //交易滑动条事件
public void transactionSliderevent(float even) {


       
        transactionSliderData(even);//滑动条事件
    
       
    }
}
