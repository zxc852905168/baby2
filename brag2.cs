using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class brag2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject downlist;
    public GameObject triggerlist;
    enum slideVector { nullVector, left, right };

    private Vector2 lastPos;//上一个位置  

    private Vector2 currentPos;//下一个位置  

    private slideVector currentVector = slideVector.nullVector;//当前滑动方向  

    private float timer;//时间计数器  
    public float lasty;
    public float currenty;
    public float offsetTime = 0.01f;//判断的时间间隔  
    public Camera canvasCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)//拖拽过程中  
    {
        // transform.position = canvasCamera.ScreenToWorldPoint(Input.mousePosition);//鼠标左键按住拖拽的时候，物体跟着鼠标移动  
        //transform.position = Input.mousePosition;//鼠标左键按住拖拽物体的时候不显示物体  

    }


    public void OnBeginDrag(PointerEventData date)
    {
        lasty = date.position.y;///
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
        if (currenty > lasty )
        {
            triggerlist.GetComponent<brag>().isPULL = false;
                
            downlist.transform.DOMoveY(300, 1f).SetEase(Ease.OutBack).SetRelative();
            //print(downlist.transform.position.y);
        }
    }
    // public void OnUpDrag(PointerEventData date) { }

    // public void IMoveHandler()
    //{


    //}
}
