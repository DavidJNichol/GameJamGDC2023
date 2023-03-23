using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BillLauncher : MonoBehaviour
{
    [Tooltip("The view that controls this launcher.")]
    [SerializeField] private PhotonView photonView = null;

    [Tooltip("The name of the bullet bill prefab.")]
    [SerializeField] private string billPrefabName = string.Empty;


    [Tooltip("The position that the bullet bill will be spawned in.")]
    [SerializeField] private Transform billSpawnLocation = null;

    [Tooltip("The cooldown period after shooting a bill.")]
    [SerializeField][Min(0.0F)] private float firingCooldown = 1.0F;



    [SerializeField] private AnimationCurve accelerationCurve = null;

    public void SetPhotonView(PhotonView photonView)
    {

        if (photonView is null)
            RemovePhotonView();
        else
        {
            this.photonView = photonView;
        }

    }
    public void RemovePhotonView()
    {
        photonView = null;
    }


    public bool IsBulletInVulnerableZone(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    private int launcherHitpointsLeft;
    private float lastShootTime;

    private void Start()
    {
        lastShootTime = Time.time - firingCooldown;
    }

    private void FixedUpdate()
    {
        // Don't process input events if we aren't the owner.
        if (!photonView.IsMine) return;

        if (Time.time - lastShootTime > firingCooldown &&
            Input.GetKeyDown(KeyCode.Space))
        {
            // Reset cooldown time.
            lastShootTime = Time.time;
            // Create the bill.
            GameObject newBill = PhotonNetwork.Instantiate(billPrefabName,
                billSpawnLocation.position,
                billSpawnLocation.rotation);
            newBill.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
