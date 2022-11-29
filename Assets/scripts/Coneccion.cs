using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class Coneccion : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.instance.estaSiendoServer)
            NetworkManager.Singleton.StartHost();
        else NetworkManager.Singleton.StartClient();
    }
    
}
