using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletBill : MonoBehaviour
{
    private bool isHost;


    private void Start()
    {
        isHost = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Don't react to collisions if this isn't the host.
        if (!isHost) return;

        // React to colliding with other bills.
        {
            BulletBill otherBill = collision.transform.GetComponent<BulletBill>();
            if (otherBill != null)
            {
                // Destroy both bills.
                Destroy(gameObject);
                Destroy(otherBill.gameObject);
            }
        }
        // React to colliding with other bill launchers.
        {
            BillLauncher launcher = collision.transform.GetComponent<BillLauncher>();
            if (launcher != null)
            {

            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
