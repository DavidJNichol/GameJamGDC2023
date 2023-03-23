using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OwnershipTransferTest : MonoBehaviour
{
    PhotonView pView;

    // Start is called before the first frame update
    void Start()
    {
        Selection.selectionChanged += OnSelectObj;
        pView = GetComponent<PhotonView>();
    }

    private void OnSelectObj()
    {
        Debug.Log("Test");
        if (Selection.activeGameObject == this)
        {
            pView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }

    }
}
