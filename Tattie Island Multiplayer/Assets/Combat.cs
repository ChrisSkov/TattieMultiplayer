using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
public class Combat : MonoBehaviour
{

    public float firePower = 10f;
    public Transform firePoint;
    public GameObject crossbowBolt;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if(!view.IsMine) return;
        if(ctx.performed)
        {
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Attack");
        }
        
    }
    public void OnShootCrossbow(InputAction.CallbackContext ctx)
    {
        if (view.IsMine)
        {
            if (ctx.performed)
            {
                GameObject crossbowBoltClone = PhotonNetwork.Instantiate(crossbowBolt.name, firePoint.position, firePoint.rotation);
                crossbowBoltClone.GetComponent<Rigidbody>().AddForce(firePoint.forward * firePower, ForceMode.Impulse);
                Destroy(crossbowBoltClone, 10f);
            }
        }
    }
}
