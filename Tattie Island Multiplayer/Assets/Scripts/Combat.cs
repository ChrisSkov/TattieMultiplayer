using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
public class Combat : MonoBehaviour
{

    public float damage = 10f;
    public Transform firePoint;
    public GameObject crossbowBolt;
    PhotonView view;

    ColliderHit hitBox;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponentInChildren<ColliderHit>();
        hitBox.SetDamage(damage);
        view = GetComponent<PhotonView>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (!view.IsMine) return;
        if (ctx.performed)
        {
            anim.SetTrigger("Attack");
        }
    }


    public void OnShootCrossbow(InputAction.CallbackContext ctx)
    {
        if (!view.IsMine) return;

        if (ctx.performed)
        {
            FireBolt();
        }

    }

    private void FireBolt()
    {
        GameObject crossbowBoltClone = PhotonNetwork.Instantiate(crossbowBolt.name, firePoint.position, firePoint.rotation);
        crossbowBoltClone.GetComponent<Rigidbody>().AddForce(firePoint.forward * damage, ForceMode.Impulse);
        Destroy(crossbowBoltClone, 10f);
    }
}
