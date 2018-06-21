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

    private void Update()
    {
        Destroy(ammo, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cammo.ammo2 = cammo.ammo2 + 10;
            cammo.ammo = cammo.ammo + 5;
            Destroy(ammo);
        }
    }

}
