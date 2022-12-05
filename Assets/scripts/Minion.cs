using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Netcode;
public class Minion : NetworkBehaviour
{
    public float speed = 2,hp=300,atack=9;
    bool estaPeleando=false;
    string team;
    GameObject enemigoPeleando;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (estaPeleando) return;
        if (other.gameObject.name.Contains("minion") && !other.CompareTag(team)||
        !other.gameObject.GetComponent<Character>().gameObject.CompareTag(team))
        {
            estaPeleando = true;
            estaPeleando = other.gameObject;
            StartCoroutine(Pelear());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Minion>())
        {
            estaPeleando = false;
            enemigoPeleando = null;
        }
    }
    IEnumerator Pelear()
    {
        
        if (enemigoPeleando.GetComponent<Character>())
        {
            while (enemigoPeleando.GetComponent<Character>().hp>=0 )// || estaEnRango
            {
              enemigoPeleando.GetComponent<Character>().hp -= atack;
               yield return new WaitForSecondsRealtime(2);
            }
        }
        yield break;
    }
    private void Update()
    {
        if(!estaPeleando) transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
