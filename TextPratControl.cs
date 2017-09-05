using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPratControl : MonoBehaviour {
    public Text EventText;
    public Text PromptText;
    // public Text EventDATAText;
    public GameObject DataUPDTE;
    public GameObject EventDATAText;
    public GameObject battlecontrol;
    public GameObject GameControl;
    public GameObject UiControl;
   // public GameObject TextPratControl;
    public float placeSoldiers;
    public float placemonny;
    public float placefoodstuff;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnEnable()
    {

        UIcontrol.transactionSliderData += TextTransactionSliderResponse;
    }
    public void EventDATATextUpdte(string str){
        EventDATATextShow();
        switch (str) {
        
            case "入村":

                EventDATATextVillageEvent();



               break;

            case "战败":
                EventDATATextFail();
                break;
            case "奖励":
                EventDATATextAwardEvent();
                break;

        }



    }
    public void EventTextUpdte(string str, string PlaceName)
    {
        switch (str) {
            case "战斗":
                EventTextBattle(PlaceName);
                break;
            case "交易成功":
                transactionSuccess();
                break;

        }



        }

    public void PromptTextUpdte(string str)
    {
        switch (str)
        {
            
                
           
            case "交易失败":
                TextNoMonny();
                break;

        }



    }
    //大文本显示切换
    public void EventDATATextShow()
    {
        EventDATAText.SetActive(true);
      //  EventDATAText.GetComponent<Text>().enabled = true;
        EventText.GetComponent<Text>().enabled = false;

    }
    //入村显示
    public void EventDATATextVillageEvent()
    {
        float GETplacemonny = (int)DataUPDTE.GetComponent<DataUPDTE>().GETplacemonny;
        float GETplacefoodstuff = (int)DataUPDTE.GetComponent<DataUPDTE>().GETplacefoodstuff;
        float GETplaceSoldiers = (int)DataUPDTE.GetComponent<DataUPDTE>().GETplaceSoldiers;
        EventDATAText.GetComponent<Text>().text = "\n村民们听闻是你公子扶苏的起义军队后，\n热情地将你率军队在村中休整一番\n并且不少青壮申请加入你的队列\n还献来了一些钱粮\n【士兵 + " + (int)GETplaceSoldiers + "、粮草 +" + (int)GETplacemonny + "\n钱币 +" + (int)GETplacefoodstuff + "】";


    }
    //战斗显示
    public void EventTextBattle(string PlaceName)
    {
        placeSoldiers = (int)DataUPDTE.GetComponent<DataUPDTE>().placeSoldiers;
        placefoodstuff = (int)DataUPDTE.GetComponent<DataUPDTE>().placefoodstuff;
        placemonny = (int)DataUPDTE.GetComponent<DataUPDTE>().placemonny;
       
             EventText.text = "   "+PlaceName + "\n士兵：" + placeSoldiers.ToString() + "\n粮草：" + placefoodstuff.ToString()
                             + "\n钱币：" + placemonny.ToString();
    }
    //奖励显示
    public void EventDATATextAwardEvent()
    {
        float GETplacemonny = (int)DataUPDTE.GetComponent<DataUPDTE>().GETplacemonny;
        float GETplacefoodstuff = (int)DataUPDTE.GetComponent<DataUPDTE>().GETplacefoodstuff;
        float GETplaceSoldiers = (int)DataUPDTE.GetComponent<DataUPDTE>().GETplaceSoldiers;
        float GETreputation = (int)DataUPDTE.GetComponent<DataUPDTE>().GETreputation;
        EventDATAText.GetComponent<Text>().text = "【战胜】恭喜你此次作战获得了最终的胜利\n你的实力再次壮大了\n民心也因此有所提升【\n士兵 + " + (int)GETplaceSoldiers + "、粮草 +" + (int)GETplacemonny + "\n钱币 +" + (int)GETplacefoodstuff + "、民心 + " + (int)GETreputation + "】";

    }
    //失败
    public void EventDATATextFail()
    {
        EventDATAText.GetComponent<Text>().text = "【战败】很可惜，此次作战你失败了，不过民心依旧提升了一点【民心+1】";

    }
    //
    public void TextTransactionSliderResponse(float even)
    {
        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.粮草商)
        {
            EventText.text = "    【是否确认完成购买】" + "\n购买：" + (int)even + " 总价：" + (int)even * 2.5;


            // transactionFood = even;
        }
        if (GameControl.GetComponent<Gamecontrol>().Advancestatus == EventStatus.奴隶商)
        {
            EventText.text = "    【是否确认完成购买】" + "\n购买：" + (int)even + " 总价：" + (int)even * 3;

        }
    }
         public void TextNoMonny() {
        PromptText.text = "   钱不够";
    }
    public void transactionSuccess()
    {
        EventText.text = "交易成功";
        PromptText.text = "  ";
    }



}
