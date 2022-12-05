using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Netcode;
using Unity.Collections;
public class Coneccion : MonoBehaviour
{
    [SerializeField] List<GameObject> charactersPrefabs;
    private void Start()
    {
        if (GameManager.instance.estaSiendoServer)
            NetworkManager.Singleton.StartHost();
        else NetworkManager.Singleton.StartClient();

        InstantiatePlayerPrefabServerRpc
            (GameManager.instance.personajeSeleccionado, NetworkManager.Singleton.LocalClientId);
    }
    [ServerRpc]
    void InstantiatePlayerPrefabServerRpc(FixedString128Bytes characterName,ulong clientId)
    {
       var obj =  Instantiate(charactersPrefabs.Where(c => c.name == characterName.ConvertToString()).First());
        obj.GetComponent<NetworkObject>().SpawnWithOwnership(clientId);
    }
}
