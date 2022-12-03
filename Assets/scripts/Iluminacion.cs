using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Iluminacion : MonoBehaviour
{
    private void Start()
    {
       print(NetworkManager.Singleton.ServerTime.Time) ;
    }
}
