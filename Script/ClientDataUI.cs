using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using DG.Tweening;

public class ClientDataUI : MonoBehaviour
{
    [SerializeField] TMP_Text clientName;
    [SerializeField] TMP_Text clientAddress;
    [SerializeField] TMP_Text clientPoints;
    [SerializeField] TMP_Text clientLable;
    [SerializeField] float fadeTime=2f;
    [SerializeField] RectTransform rectTransformClintName,rectTransformClintAddress,rectTransformClintPoints;
    [SerializeField] GameObject clientNameObj,clientAddressObj,clientPointsObj;
    public Root root;
    public static ClientDataUI instance;

    void Awake()
    {
        instance=this;
    }

    void Start()
    {  
        ObjectActivate(false);
       
    }

    //set clint name,address,points
    public void SetClintInfo(int index)
    {
        //animation
        ObjectActivate(false);
        StopAllCoroutines();
        //get the client id
        int id=root.clients[index].id;
        clientLable.text=root.clients[index].label;
        //set etxt field accordingly
        switch (id)
        {
            case 1:
                clientName.text=root.data._1.name;
                clientAddress.text=root.data._1.address;
                clientPoints.text=root.data._1.points.ToString();
                break;
            case 2:
               clientName.text=root.data._2.name;
                clientAddress.text=root.data._2.address;
                clientPoints.text=root.data._2.points.ToString();
                break;
            case 3:
                clientName.text=root.data._3.name;
                clientAddress.text=root.data._3.address;
                clientPoints.text=root.data._3.points.ToString();
                break;

            default:
                clientName.text="Null value";
                clientAddress.text="Null value";
                clientPoints.text="Null vlaue";
                break;
            }
        StartCoroutine(panelDropIn());
    }

    //ui animation
    IEnumerator panelDropIn()
    {
        yield return new WaitForSeconds(1f);
        clientNameObj.SetActive(true);
        Vector3 pos=rectTransformClintName.transform.localPosition;
        rectTransformClintName.transform.localPosition=new Vector3(pos.x,pos.y+200f,pos.z);
        rectTransformClintName.DOAnchorPos(new Vector3(0f,196f,0f),fadeTime,false).SetEase(Ease.OutElastic);
        yield return null;


        clientAddressObj.SetActive(true);
        pos=rectTransformClintAddress.transform.localPosition;
        rectTransformClintAddress.transform.localPosition=new Vector3(pos.x,pos.y+200f,pos.z);
        rectTransformClintAddress.DOAnchorPos(new Vector3(0f,0f,0f),fadeTime,false).SetEase(Ease.OutElastic);
        yield return null;

        clientPointsObj.SetActive(true);
        pos=rectTransformClintPoints.transform.localPosition;
        rectTransformClintPoints.transform.localPosition=new Vector3(pos.x,pos.y+200f,pos.z);
        rectTransformClintPoints.DOAnchorPos(new Vector3(0f,-226f,0f),fadeTime,false).SetEase(Ease.OutElastic);
        yield return  null;
    }

    void ObjectActivate(bool toggle)
    {
        clientNameObj.SetActive(toggle);
        clientAddressObj.SetActive(toggle);
        clientPointsObj.SetActive(toggle);
    }

    public void SetRoot(Component sender,object data)
    {
        if(sender is APIHandler)
            this.root=(Root)data;
    }

   
}
