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

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isFloor = true;
        counter = 0;
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
            Debug.Log(counter);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bullet, transform, false);
            Vector2 force = new Vector2((body.velocity.x > 0) ? 10 : -10, 0);
            newBullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            newBullet.tag = "Playerbullet";
            Destroy(newBullet, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Enemybullet")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        if (col.collider.tag == "Platform")
        {
            counter = 0;
            isFloor = true;
        }
        if(col.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
        }
    }
}
