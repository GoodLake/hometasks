using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    PlayerController cammo;
    public GameObject ammo;

    private void Start()
    {
        cammo = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cammo.ammo++;
            Destroy(ammo);
        }
    }

}
