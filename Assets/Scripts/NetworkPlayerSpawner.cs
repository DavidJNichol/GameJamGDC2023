using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] List<BillLauncher> availableLauncherList;
    private int spawnIndex;

    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("NetworkPlayer", GetRandomSpawnPoint(), Quaternion.identity);
        RemoveLauncherFromArrayRPC(spawnIndex);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        spawnIndex =  Random.Range(0, availableLauncherList.Count-1);
        Debug.Log("SpawnIndex " + spawnIndex);
        return availableLauncherList[spawnIndex].playerSpawnPosition;      
    }

    private void RemoveLauncherFromArrayRPC(int index)
    {
        photonView.RPC("RemoveLauncherFromArray", RpcTarget.All, index);
    }

    [PunRPC]
    private void RemoveLauncherFromArray(int index)
    {
        availableLauncherList.RemoveAt(index);
    }
}
