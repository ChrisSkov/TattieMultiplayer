using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotatePlayer : MonoBehaviour
{
    PhotonView view;
    Vector3 mouseWorldPositon = Vector3.zero;
    public Camera myCam;
    public GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            myCam.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine)
            return;
        Rotate();
    }
    private void Rotate()
    {
        //Rotation

        //Set up hit, ray and mask for raycast
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Ground");

        //execute raycast and calculate mouse position
        Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
        mouseWorldPositon = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
        //rotate the player accordingly
        playerModel.transform.rotation = Quaternion.LookRotation(mouseWorldPositon, Vector3.up);
        // player.mouseWorldPosition = mouseWorldPositon + gameObject.transform.position;

    }
}
