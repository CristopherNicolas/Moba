using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class AsignTeam : NetworkBehaviour  
{
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        base.OnNetworkSpawn();
        if (OwnerClientId > 0) gameObject.tag = "red";
        else gameObject.tag = "blue";
        Debug.Log($"client id = {OwnerClientId} , tag = {tag}");
    }
}
