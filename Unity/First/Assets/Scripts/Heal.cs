using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerController.playerhp < 100)
        {
            PlayerController.playerhp = PlayerController.playerhp + 20;
            Destroy(heal);
        }
    }
}
