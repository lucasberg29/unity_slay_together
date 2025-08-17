using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public int swordDamage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<Enemy>().HitEnemy(swordDamage);
        }
    }
}
