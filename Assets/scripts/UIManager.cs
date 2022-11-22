using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.Netcode;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public bool actualizarUI;
    public Image imgQ, imgW, imgE, imgR;
    public TMP_Text tq, tw, te, tr;
    Character inScene;
    private IEnumerator Start()
    {
        if (Instance == null) Instance = this;
      yield return new WaitUntil(() => actualizarUI);
        while (true)
        {
            imgQ.fillAmount = inScene.cdQ / inScene._cdQ;
            imgW.fillAmount = inScene.cdW / inScene._cdW;
            imgE.fillAmount = inScene.cdE / inScene._cdE;
            imgR.fillAmount = inScene.cdR / inScene._cdR;

            tq.text =  Math.Round(inScene.cdQ,1).ToString();
            tw.text = Math.Round(inScene.cdW, 1).ToString();
            te.text = Math.Round(inScene.cdE, 1).ToString();
            tr.text = Math.Round(inScene.cdR, 1).ToString();
            
            yield return new WaitForEndOfFrame();
                         
        }
    }
    public void StartUISystem(Character chara)
    {
        inScene = chara;
        actualizarUI = true;
    }
    
}
