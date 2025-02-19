using Unity.Netcode;
using Unity.Netcode.Components; 
using UnityEngine;
using System.Collections;

public class SpawnScript : NetworkBehaviour
{
    public Transform SpawnPoint1;
    public Transform SpawnPoint2; 

    void Start()
    {
        print("hi"); 
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnClientConnected(ulong clientId)
    {
        GameObject hostPlayer = GetPlayer(clientId);
        if (hostPlayer == null) print("host null");
        var spawnPoint = SpawnPoint1;
        if (NetworkManager.Singleton.IsHost && clientId == NetworkManager.Singleton.LocalClientId)
        {
            print("I created the room and am the host.");
        }
        else
        {
            print($"Player {clientId} joined the room.");
            spawnPoint = SpawnPoint2;
        }
        StartCoroutine(WaitOneSecond(hostPlayer, spawnPoint));
    }

    private IEnumerator WaitOneSecond(GameObject hostPlayer, Transform spawnPoint)
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("XR Origin Hands (XR Rig) MP Template Variant").transform.position = spawnPoint.position;
    }

    private void OnClientDisconnected(ulong clientId)
    {
        print($"Player {clientId} disconnected.");
    }

    private GameObject GetPlayer(ulong clientId)
    {
        return NetworkManager.Singleton.ConnectedClients.TryGetValue(clientId, out var hostClient) ?
               hostClient.PlayerObject.gameObject : null;
    }
}
