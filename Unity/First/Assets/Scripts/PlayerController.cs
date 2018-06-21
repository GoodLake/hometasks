using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Enemy Mdmg;
    Enemy Mhl;
    public float speed;
    public GameObject MyGameObject;
    private bool isFloor;
    public GameObject bullet;
    Rigidbody2D body;
    int counter;
    public int ammo;
    public int ammo2;
    public int playerdmg;
    public int Maxplayerhp;
    public int playerhp;
    bool IsMachineGun;
    public AudioSource Machinegun;
    public AudioClip Shoot1;
    public AudioSource PistolSound;
    public AudioClip Shoot2;

    private void Start()
    {
        Mdmg = GameObject.FindObjectOfType<Enemy>();
        Mhl = GameObject.FindObjectOfType<Enemy>();
        body = GetComponent<Rigidbody2D>();
        isFloor = true;
        counter = 0;
        IsMachineGun = false;
    }

    void Dead()
    {
        playerdmg = 3;
        Maxplayerhp = 100;
        Destroy(MyGameObject);
    }

    void Pistol ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo2 > 0)
        {

            ammo2--;
            GameObject newBullet = Instantiate(bullet, transform, false);
            PistolSound.PlayOneShot(Shoot2);
            Vector2 force = new Vector2((body.velocity.x > 0) ? 10 : -10, 0);
            newBullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            newBullet.tag = "PlayerBullet";
            Destroy(newBullet, 2f);
        }
    }

    void Minigun ()
    {
            if (Input.GetKey(KeyCode.Space) && ammo > 0)
            {
                ammo--;
                GameObject newBullet = Instantiate(bullet, transform, false);
                Machinegun.PlayOneShot(Shoot1);
                Vector2 force = new Vector2((body.velocity.x > 0) ? 20 : -20, 0);
                newBullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                newBullet.tag = "PlayerBullet";
                Destroy(newBullet, 2f);
            }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            IsMachineGun = true;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            IsMachineGun = false;
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
        if(playerhp <= 0)
        {
            Application.LoadLevel(4);
        }
        if(IsMachineGun)
        {
            Minigun();
        }
        else
        {
            Pistol();
        }
    }

   void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "EnemyBullet")
        {
            playerhp = playerhp - Mdmg.MobDamage;
            if (playerhp <= 0) Dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Platform")
        {
            counter = 0;
            isFloor = true;
        }
        if(col.gameObject.tag == "Ammo1")
        {
            ammo++;
        }
    }
}
