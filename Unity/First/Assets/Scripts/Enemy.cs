using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    Transform player;
    Rigidbody2D body;
    public static int MobHealth;
    public static int MobDamage;
    public static int kills;

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start ()
    {
        StartCoroutine(Logic());
        body = GetComponent<Rigidbody2D>();
        FindPlayer();
        MobHealth = 35;
        MobDamage = 10;
        kills = 0;
    }
	
    IEnumerator Logic()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 3f));
                Vector2 force = new Vector2(body.velocity.x > 0 ? 15f : -15f, body.velocity.y > 0 ? 15f : -15f);
                GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                if (transform.position.y < player.transform.position.y) Shoot();
        }
    }
    void Shoot ()
    {
        GameObject BulletPrefab = Instantiate(bullet, transform, false);
        Vector2 force = new Vector2((body.velocity.x > 0) ? 15f : -15f, 0);
        BulletPrefab.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        BulletPrefab.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        BulletPrefab.tag = "EnemyBullet";
        Destroy(BulletPrefab, 1f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PlayerBullet" && MobHealth <= 0)
        {
            PlayerController.ammo = PlayerController.ammo + 5;
            kills++;
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Player" && MobHealth < PlayerController.playerhp)
        {
            Destroy(this.gameObject);
        }
    }
}
