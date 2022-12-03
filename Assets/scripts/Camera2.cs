using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Linq;
using Cinemachine;
using System.Threading.Tasks;
using System;
public class Camera2 : MonoBehaviour
{
    public float scrollSpeed,topBarrier,botBarrier,leftBarrier,rightBarrier;
    CinemachineVirtualCamera cam;
     public GameObject targetFollow;
    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if(Input.mousePosition.y >= Screen.height* topBarrier)transform.Translate(Vector3.left* Time.deltaTime * scrollSpeed, Space.World);
        if(Input.mousePosition.y <= Screen.height* botBarrier)transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        if(Input.mousePosition.x >= Screen.width* rightBarrier)transform.Translate(Vector3.forward* Time.deltaTime * scrollSpeed, Space.World);
        if(Input.mousePosition.x <= Screen.width* leftBarrier)transform.Translate(Vector3.back* Time.deltaTime * scrollSpeed, Space.World);

        cam.m_Lens.FieldOfView -= Input.mouseScrollDelta.y;
        Math.Clamp(Camera.main.fieldOfView,15,85);
        
        if (Input.GetKey(KeyCode.Space))
        {
            //cam.Follow = targetFollow.transform;
            transform.position = new Vector3(targetFollow.transform.position.x, transform.position.y, targetFollow.transform.position.z);
            return;
        }
        cam.Follow = null;          
    }
}
