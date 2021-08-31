using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHitPlayer : MonoBehaviour
{
    Zombie_Combat combat;
    public bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponentInParent<Zombie_Combat>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasHit)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(combat.attackDamage);
            hasHit = true;
        }
    }
}
