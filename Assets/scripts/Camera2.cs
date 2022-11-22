using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Linq;
using Cinemachine;
using System.Threading.Tasks;

public class Camera2 : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            cam.Follow = players.Where(p => p.GetComponent<NetworkObject>().IsOwner is true).First().transform;
            await Task.Delay(100);
            cam.Follow = null;
        }
    }
}
