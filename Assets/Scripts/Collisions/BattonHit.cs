using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattonHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Player>().DamagePlayer(20);
        }
    }
}
