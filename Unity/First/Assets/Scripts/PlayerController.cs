using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject MyGameObject;
    private bool isFloor;
    public Rigidbody2D bullet;


    private void FixedUpdate()
    {

    }
    private void Start()
    {
        isFloor = true;
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
        if (Input.GetKey(KeyCode.UpArrow) && isFloor)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
            isFloor = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody2D BulletPrefab = (Rigidbody2D)Instantiate(bullet, transform.position, transform.rotation);
            BulletPrefab.velocity = transform.forward * 10;
            BulletPrefab.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Destroy(BulletPrefab, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Platform")
        {
            isFloor = true;
        }
    }
}
