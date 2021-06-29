using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBolt : MonoBehaviour
{
    public float dmg = 10f;
    public bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !hasHit)
        {
            hasHit = true;
            other.gameObject.GetComponent<Health>().TakeDamage(dmg);
        }
    }
}
