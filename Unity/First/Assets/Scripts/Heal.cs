using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    PlayerController hp;
    public GameObject heal;

    private void Start()
    {
        hp = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hp.playerhp < hp.Maxplayerhp - 20)
        {
            hp.playerhp = hp.playerhp + 20;
            Destroy(heal);
        }
    }
}
