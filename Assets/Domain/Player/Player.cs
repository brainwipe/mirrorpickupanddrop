using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lang.MirrorPickUpAndDrop
{
    public class Player : NetworkBehaviour
    {
        void Update()
        {
            if (isLocalPlayer)
            {
                transform.position = transform.position +
                    new Vector3(
                        Input.GetAxis("Horizontal"),
                        Input.GetAxis("Vertical"),
                        0)
                    * 0.1f;
            }
        }
    }
}