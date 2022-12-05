 using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Networking.Transport;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Unity.Netcode;
using System.Threading.Tasks;
using Cinemachine;
public abstract class Character : NetworkBehaviour
{
    public GameObject vcam;
    NavMeshAgent agent;
    public Animator characterAnimator;
    public NetworkAnimatorAutoritative networkAnimator;
    public bool isDead;
    public float hp=600,maxHP=600,AADamage=60,alcanceAA=1;
    public float cdQ=7, cdW=12, cdE=20, cdR=90, //cds de habilidades en partida
                 _cdQ,_cdW,_cdE,_cdR;           //cds de habilidades por personaje
    public void Start()
    {
        if(!IsOwner) return;
        networkAnimator = GetComponent<NetworkAnimatorAutoritative>();
        agent = transform.root.GetComponent<NavMeshAgent>();
        var cam = GameObject.Find("cam").GetComponent<CinemachineVirtualCamera>();
        cam.LookAt = transform;
        cam.GetComponent<Camera2>().targetFollow = gameObject;

        cam.LookAt = null;
       // cam.GetComponent<Camera2>().targetFollow = gameObject;
        UIManager.Instance.StartUISystem(this);

        StartCoroutine(Cds());
    }
    IEnumerator Cds()
    {
        Pasiva();

        while (true)
        {
          cdQ-=.1f; cdE -= .1f; cdW -= .1f; cdR -= .1f;
          if (cdQ <= 0) cdQ = 0;
           if (cdW <= 0) cdW = 0;
           if (cdE <= 0) cdE = 0;
           if (cdR <= 0) cdR = 0;
           //Debug.Log($"cooldowns q: {cdQ},w = {cdW}, e = {cdE}, r = {cdR}");
           yield return new WaitForSecondsRealtime(.1f);
        }
    }
    private void Update()
    {
      if (!IsOwner) return;
        if (hp<=0) MorirServerRpc();
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Q) && cdQ <= 0) Q();
        else if (Input.GetKeyDown(KeyCode.W) && cdW <= 0) W();
        else if (Input.GetKeyDown(KeyCode.E) && cdE <= 0) E();
        else if (Input.GetKeyDown(KeyCode.R) && cdR <= 0) R();
        if ( Input.GetMouseButtonDown(1) &&Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.CompareTag("plataforma"))
                {
                 agent.isStopped = true;
                transform.root.LookAt(hit.point);
                    Debug.Log("plataforma colicionada");
                     agent.destination = hit.point;
                       agent.isStopped = false;                }
            characterAnimator.SetFloat("speed", 1);
            }
        //implementar AA aqui
        else if (agent.remainingDistance<=0.2f) characterAnimator.SetFloat("speed", 0);
        else characterAnimator.SetFloat("speed", 1);
        

    }
    int cdMuerte=5;
    [ServerRpc]
    public virtual  void MorirServerRpc()
    {
        characterAnimator.SetBool("death",true);
        //desactivar movimiento, desactivar habilidades hasta que se complete un  
        Invoke("SetPos", cdMuerte); 
    }
    void SetPos()
    {
        hp = maxHP;
        characterAnimator.SetBool("death", false);
        transform.root.transform.position = CompareTag("red") ?
            new Vector3(-0.600000024f, 7.5999999f, -58.7299995f)
            : new Vector3(-0.600000024f, 7.5999999f, 58.7299995f);
    }
    protected virtual async void Pasiva()
    {
       while(hp>0)
       {
            hp+=.5F;
            await Task.Delay(1000);
       } 
    }
    protected virtual void AA(Character character=null, Minion minion=null)
    {

        if (minion is not null && minion.transform.position.x - transform.root.position.x <= alcanceAA)
        {
            minion.hp -= AADamage;
        }
        else if (character is not null && character.transform.root.position.x - transform.root.position.x <= alcanceAA)
        {
            //añadir a la ecuacion la reduccion de la armadura
            character.hp -= AADamage;
        }
        else return;
        networkAnimator.SetTrigger("AA");
    }
    protected virtual void Q()
    {
        if (!IsOwner||isDead) return;
        print("q");
        networkAnimator.SetTrigger("Q");
        cdQ = _cdQ;
    }
    protected virtual void W()
    {
        if (!IsOwner||isDead) return;
        print("w");
        networkAnimator.SetTrigger("W");
        cdW = _cdW;
    }
    protected virtual void E()
    {
        if (!IsOwner|| isDead) return;
        print("e");
        networkAnimator.SetTrigger("E");
        cdE = _cdE;
    }
    protected virtual void R()
    { 
        if (!IsOwner|| isDead) return;
        print("r");
        networkAnimator.SetTrigger("R");
        cdR = _cdR;
    }


}
