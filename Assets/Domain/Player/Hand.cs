using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lang.MirrorPickUpAndDrop
{
    public class Hand : NetworkBehaviour
    {
        public GameObject PickUp;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PickUp")) return;

            CmdPickUp(other.gameObject);
        }

        [Command]
        public void CmdPickUp(GameObject cube)
        {
            PickUp = cube;
            PickUp.GetComponent<NetworkIdentity>().RemoveClientAuthority();
            PickUp.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
            PickUp.GetComponent<Cube>().Parent = gameObject;
        }

        [Command]
        public void CmdDropOff()
        {
            PickUp.GetComponent<Cube>().Parent = null;
        }
    }
}