using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject MyGameObject;
    private bool isFloor;
    public GameObject bullet;
    Rigidbody2D body;
    int counter;
    public static int ammo;
    public static int playerdmg;
    public static int playerhp;

    private void Start()
    {
        ammo = 200;
        body = GetComponent<Rigidbody2D>();
        isFloor = true;
        counter = 0;
        playerdmg = 5;
        playerhp = 100;
    }

    void Dead(Collision2D col)
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isFloor)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            counter++;
            if(counter >= 2)
            {
                isFloor = false;
            }
        }
        if (Input.GetKey(KeyCode.Space) && ammo > 0)
        {
            ammo--;
            Enemy.MobHealth = Enemy.MobHealth - playerdmg;
            Debug.Log(ammo);
            GameObject newBullet = Instantiate(bullet, transform, false);
            Vector2 force = new Vector2((body.velocity.x > 0) ? 10 : -10, 0);
            newBullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            newBullet.tag = "PlayerBullet";
            Destroy(newBullet, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "EnemyBullet")
        {
            playerhp = playerhp - 10;
            if (playerhp <= 0) Dead(col);
        }
        if (col.collider.tag == "Platform")
        {
            counter = 0;
            isFloor = true;
        }
        if(col.collider.tag == "Enemy" && Enemy.MobHealth > playerhp)
        { 
            Destroy(gameObject);
            Application.LoadLevel(0);
        }
        if(Enemy.MobHealth < playerhp)
        {
            playerhp = playerhp - Enemy.MobDamage;
        }
        if(col.gameObject.tag == "Ammo1")
        {
            ammo++;
        }
    }
}
