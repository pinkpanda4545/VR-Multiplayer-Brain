using Unity.Netcode;
using Unity.Netcode.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationDelay : NetworkBehaviour
{
    public GameObject narration1;
    public GameObject narration2;

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected2;
    }

    private void OnClientConnected2(ulong clientId)
    {
        if (NetworkManager.Singleton.IsHost && clientId == NetworkManager.Singleton.LocalClientId)
        {
            print("Host joined, not starting narration yet.");
        }
        else
        {
            print($"Player {clientId} joined the room. Starting narration in 3 seconds.");
            StartCoroutine(Wait3Seconds());
        }
    }

    IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(3);
        narration1.SetActive(true); 
        narration2.SetActive(true);
    }
}
