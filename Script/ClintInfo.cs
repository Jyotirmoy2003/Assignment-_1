using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ClintInfo : MonoBehaviour
{
     [SerializeField] float fadeTime=10f;
    [SerializeField] RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        panelDropIn();
    }

   
     public void panelDropIn()
    {
        rectTransform.transform.localPosition=new Vector3(0,0,1000f);
        rectTransform.DOAnchorPos(new Vector3(0.5f,0.5f,2),fadeTime,false).SetEase(Ease.OutElastic);
    }
}
