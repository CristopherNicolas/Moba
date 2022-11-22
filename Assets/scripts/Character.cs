 using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Networking.Transport;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Unity.Netcode;
using System.Threading.Tasks;

public abstract class Character : NetworkBehaviour
{
    public GameObject vcam;
    RaycastHit hit;
    NavMeshAgent agent;
    public float cdQ=7, cdW=12, cdE=20, cdR=90, //cds de habilidades en partida
                 _cdQ,_cdW,_cdE,_cdR;           //cds de habilidades por personaje
    public void Start()
    {
        base.OnNetworkSpawn();
        if(!IsOwner)
        {
            vcam.SetActive(false);
            return;
        }
        agent = transform.root.GetComponent<NavMeshAgent>();   
        StartCoroutine(Cds());
    }
    IEnumerator Cds()
    {
        while (true)
        {
          cdQ--; cdE--; cdW--; cdR--;
          if (cdQ <= 0) cdQ = 0;
           if (cdW <= 0) cdW = 0;
           if (cdE <= 0) cdE = 0;
           if (cdR <= 0) cdR = 0;
           Debug.Log($"cooldowns q: {cdQ},w = {cdW}, e = {cdE}, r = {cdR}");
           yield return new WaitForSecondsRealtime(1);
        }
    }
    private void Update()
    {
      if (!IsOwner) return;
        if (Input.GetKeyDown(KeyCode.Q) && cdQ <= 0) Q();
        else if (Input.GetKeyDown(KeyCode.W) && cdW <= 0) W();
        else if (Input.GetKeyDown(KeyCode.E) && cdE <= 0) E();
        else if (Input.GetKeyDown(KeyCode.R) && cdR <= 0) R();
        if ( Input.GetMouseButtonDown(1) &&Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.CompareTag("plataforma"))
                {
                 agent.isStopped = true;
                    Debug.Log("plataforma colicionada");
                     agent.destination = hit.point;
                       agent.isStopped = false;

                }
            }
    }
    protected virtual void Q()
    {
        
        print("q");
        cdQ = _cdQ;
    }
    protected virtual void W()
    {
        print("w");
        cdW = _cdW;
    }
    protected virtual void E()
    {
        print("e");
        cdE = _cdE;
    }
    protected virtual void R()
    { 
        print("r");
        cdR = _cdR;
    }


}
