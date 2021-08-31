using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHitEnemy : MonoBehaviour
{
    public bool hasHit = false;
    public float weaponDamage = 35f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger enter");
        if (other.gameObject.CompareTag("Enemy") && !hasHit)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(weaponDamage);
            print("hasHit");
            hasHit = true;
        }
    }
}
