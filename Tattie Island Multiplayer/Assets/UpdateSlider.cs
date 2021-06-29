using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class UpdateSlider : MonoBehaviour
{
    PhotonView view;
    Slider slider;
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<Health>();
        view = GetComponent<PhotonView>();
        slider = GetComponent<Slider>();

        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;

    }

    // Update is called once per frame
    void Update()
    {

        slider.value = health.currentHealth;

    }
}
