using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class EnemyHealth : HealthAbstract
{
    public Slider hpBar;
    public float maxHealth;
    public float currentHealth;
    public bool isDead = false;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //  view = GetComponent<PhotonView>();
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        hpBar.maxValue = maxHealth;
        hpBar.value = currentHealth;
        hpBar.minValue = 0;
    }

    public override void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        CheckIfDead();
        UpDateHealthBar();
        if (!isDead)
        {
            anim.SetTrigger("isHit");
        }
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            isDead = true;
            anim.SetTrigger("isDead");
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public override void UpDateHealthBar()
    {
        hpBar.value = currentHealth;
    }
}
