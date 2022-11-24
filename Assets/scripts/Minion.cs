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
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("minion") && !other.CompareTag(team)||
        other.gameObject.GetComponent<Character>().gameObject.CompareTag(team))
        {
            estaPeleando = true;
            //atacar
            StartCoroutine(Pelear(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if ()
    }
    IEnumerator Pelear(GameObject enemigo)
    {
        yield break;
    }
    private void Update()
    {
        if(!estaPeleando) transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
