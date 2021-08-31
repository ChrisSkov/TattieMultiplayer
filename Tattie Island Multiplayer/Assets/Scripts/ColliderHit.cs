using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHit : MonoBehaviour
{
    public bool hasHit = false;

    public float damage;

    public int layerToHit;

    public float GetDamage()
    {
        return damage;
    }
    public void SetDamage(float damageValue)
    {
        damage = damageValue;
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.layer == layerToHit && !hasHit)
        {
            other.gameObject.GetComponent<HealthAbstract>().TakeDamage(damage);
            hasHit = true;
        }
    }
}
