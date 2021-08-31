using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthAbstract
{
    PhotonView view;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isDead = false;
    public Slider mySlider;

    void Start()
    {
        currentHealth = maxHealth;
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            mySlider.maxValue = maxHealth;
            mySlider.value = currentHealth;
        }
    }
    public override void TakeDamage(float dmg)
    {
        Debug.LogWarning("TakeDamagePlayer");
        view.RPC("TakeDamageRPC", RpcTarget.All, dmg);
        UpDateHealthBar();
    }

    [PunRPC]
    void TakeDamageRPC(float dmg)
    {
        currentHealth -= dmg;
    }

    [PunRPC]
    public override void UpDateHealthBar()
    {
        mySlider.value = currentHealth;
    }
}
