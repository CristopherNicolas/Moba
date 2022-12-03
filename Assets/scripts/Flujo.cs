using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Flujo : MonoBehaviour
{

    // el jugador  al morir reaparece nuevamente de entre 2 y 15 segundos en su base.
    // establecer base
    private IEnumerator Start()
    {
        if (!NetworkManager.Singleton.IsHost) yield break;
                   
    }
}
