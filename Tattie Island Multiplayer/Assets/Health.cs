using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviour
{

    PhotonView view;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isDead = false;

    public Slider mySlider;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

     //   view.RPC("UpdateSlider", RpcTarget.All);
    }

    [PunRPC]
    void UpdateSlider()
    {
        mySlider.value = currentHealth;
    }
    [PunRPC]
    void TakeDamageRPC(float dmg)
    {
        currentHealth -= dmg;
        // if (currentHealth <= 0)
        // {
        //     currentHealth = 0f;
        // }
        // if (view.IsMine)
        // {
        // }

    }
    public void TakeDamage(float dmg)
    {
        //TakeDamageRPC(dmg);
        view.RPC("TakeDamageRPC", RpcTarget.All, dmg);
    }
}
