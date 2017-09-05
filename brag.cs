using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class brag : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IMoveHandler, IDragHandler
{
    public GameObject downlist;
    enum slideVector { nullVector, left, right };
    public bool isPULL=false;//是否下拉
    private Vector2 lastPos;//上一个位置  

    private Vector2 currentPos;//下一个位置  

    private slideVector currentVector = slideVector.nullVector;//当前滑动方向  

    private float timer;//时间计数器  
    public float lasty;
    public float currenty;
    public float offsetTime = 0.01f;//判断的时间间隔  
    public Camera canvasCamera ;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        }

    public void OnDrag(PointerEventData eventData)//拖拽过程中  
    {
       // transform.position = canvasCamera.ScreenToWorldPoint(Input.mousePosition);//鼠标左键按住拖拽的时候，物体跟着鼠标移动  
                                                                                  //transform.position = Input.mousePosition;//鼠标左键按住拖拽物体的时候不显示物体  

    }


    public void OnBeginDrag(PointerEventData date)
    {
        lasty = date.position.y;
       // print(lasty);
    }
    public void OnEndDrag(PointerEventData date)
    {
        // print("aaq");
        //downlist.transform.DOMoveY(700, 1).SetEase(Ease.OutBack).SetRelative();
        // currenty = canvasCamera.ScreenToWorldPoint(Input.mousePosition).y;
        // print(date.position);
        currenty = date.position.y;
        //print(currenty);
        if (currenty < lasty)
        {
            if(isPULL==false){
                downlist.transform.DOMoveY(-300, 1).SetEase(Ease.OutBack).SetRelative();
                isPULL = true;
                //print(downlist.transform.position.y);
            }
        }
    }
    // public void OnUpDrag(PointerEventData date) { }

   // public void IMoveHandler()
    //{


    //}

    public void OnMove(AxisEventData eventData)
    {
        //throw new NotImplementedException();
       // print(eventData);
        
    }
/*private void OnGUI()
{
    if (Event.current.type == EventType.MouseDown)
    {//滑动开始  
        lastPos = Event.current.mousePosition;
        currentPos = Event.current.mousePosition;
        timer = 0;

        //TODO click event  
        Debug.Log("Click begin && Drag begin");
    }

    if (Event.current.type == EventType.MouseDrag)
    {//滑动过程  
        currentPos = Event.current.mousePosition;
        timer += Time.deltaTime;
        if (timer > offsetTime)
            {
                
                if (lastPos.y<=200&& lastPos.y >= 0) {
                    if (currentPos.y > lastPos.y)
                    {
                        //if (currentVector == slideVector.left)
                        //{
                            //return;
                       // }
                        //TODO trun Left event  

                        //currentVector = slideVector.left;
                        Debug.Log("Turn left");
                    } }
                if (lastPos.y <= 400 && lastPos.y >= 0)
                {
                    if (currentPos.y < lastPos.y)
                    {
                      
                        Debug.Log("Turn right");
                    }
                }

            lastPos = currentPos;
            timer = 0;
        }
    }
        if (Event.current.type == EventType.MouseUp)
        {//滑动结束  
            currentVector = slideVector.nullVector;
            Debug.Log("Click over && Drag over");
        }
    }*/
}
