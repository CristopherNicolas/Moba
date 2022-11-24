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
     public GameObject targetFollow;
    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cam.Follow = targetFollow.transform;

            return;
        }
        cam.Follow = null;          
    }
}
