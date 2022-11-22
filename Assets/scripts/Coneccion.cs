using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class Coneccion : MonoBehaviour
{
    public Button join, host;
    private void Start()
    {
        join.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            CerrarBotones();
        });
        host.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            CerrarBotones();
        });
    }
    void CerrarBotones()
    {
        join.transform.localScale = Vector3.zero;
        host.transform.localScale = Vector3.zero;
    }
}
