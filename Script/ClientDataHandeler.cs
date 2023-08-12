using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ClientDataHandeler : MonoBehaviour
{
    [SerializeField]  TMP_Text clientPoint;
    [SerializeField]  TMP_Text clientLable;
    private  int points;
    private Client myClient;
    private Data myData;
    private ClientDataUI clientDataUI;
    private int index;


    //set all data for individual client
    private void SetClintData(string lable,int points)
    {
        clientLable.text=lable;
        clientPoint.text=points.ToString();
        this.points=points;
    }


    //choose correct clint from the root and assign the values
    public void ChooseClint(Root root,int index)
    {
        //set clint and data
        myClient= root.clients[index];
        myData=root.data;
        this.index=index;

        //get lable,id,point
        string  lable=myClient.label;
            int id=myClient.id;
            int points=0;
            //set points according to the clint id
            switch (id)
            {
                case 1:
                    points=root.data._1.points;
                    break;
                case 2:
                    points=root.data._2.points;
                    break;
                case 3:
                    points=root.data._3.points;
                    break;

                default:

                    break;
            }
           
        SetClintData(lable,points);
        clientDataUI=FindObjectOfType<ClientDataUI>();
    }

    public Client GetClientInfo()
    {
        return myClient;
    }

    //on click client
    public void OnMouseEnter()
    {
        clientDataUI.SetClintInfo(index);

    }
}
