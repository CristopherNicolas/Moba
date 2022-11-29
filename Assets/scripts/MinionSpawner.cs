using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class MinionSpawner : NetworkBehaviour
{
    public GameObject minionPrefab;
    public Transform[] positionsRed,positionsBlue;
    public string team;
    
    public IEnumerator Start()
    {
        GameManager.instance.haComenzado = true;
        if (!IsHost) yield break;
        yield return new WaitUntil(() => GameManager.instance.haComenzado);
        while (true)
        {
            yield return new WaitForSeconds(15);
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(.7f);
                SpawnServerRpc();
                Debug.Log("FLAG");
            }
        }
    }
    [ServerRpc]
    void SpawnServerRpc()
    {
        var minion = Instantiate(minionPrefab, team is "red" ? positionsRed[Random.Range(0, positionsRed.Length)] :
            positionsBlue[Random.Range(0, positionsBlue.Length)]
            ) ;
        minion.GetComponent<NetworkObject>().Spawn();
        minion.tag = team == "blue" ? "blue" : "red"; 
    }
}
