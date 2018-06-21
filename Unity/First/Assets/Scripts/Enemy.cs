using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController cntrl;
    public GameObject bullet;
    Transform player;
    Rigidbody2D body;
    public float MobHealth;
    public int MobDamage;
    bool isLife;
    float spawntime;
    int ran;

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start ()
    {

        StartCoroutine(Logic());
        cntrl = GameObject.FindObjectOfType<PlayerController>();
        body = GetComponent<Rigidbody2D>();
        isLife = true;
        FindPlayer();
        ran = Random.Range(0, 1);
        MobHealth = 35;
        MobDamage = 10;
        spawntime = 5f;
    }
	IEnumerator LvlUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawntime);
            MobDamage = MobDamage + 1;
            MobHealth = MobHealth + 10;
            if (spawntime <= 0.0000001f)
                spawntime = spawntime / 2;
            else
                spawntime = 20f;
        }
    }
    IEnumerator Logic()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
                Vector2 force = new Vector2(body.velocity.x > 0 ? 15f : -15f, body.velocity.y > 0 ? 15f : -15f);
                GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                if (Mathf.CeilToInt(transform.position.y) == Mathf.CeilToInt(player.transform.position.y)) Shoot();
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
        if(col.gameObject.tag == "PlayerBullet")
        {
            MobHealth = MobHealth - cntrl.playerdmg;
            if(MobHealth <= 0 && isLife)
            {
                isLife = false;
                cntrl.ammo2 = cntrl.ammo2 + 10;
                cntrl.ammo = cntrl.ammo + 5;
                if(cntrl.playerhp < cntrl.Maxplayerhp) cntrl.playerhp++;
                Destroy(gameObject);
                Destroy(col.gameObject);
                FindObjectOfType<info>().AddKill();

            }
        }
        if(col.gameObject.tag == "Player")
        {
            cntrl.playerhp = cntrl.playerhp - 5;
        }
    }
}
