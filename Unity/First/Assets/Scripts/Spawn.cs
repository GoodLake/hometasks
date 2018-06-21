using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] Points;
    float time;

    void Start()
    {
        time = 10;
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (time <= 1f)
        {
            time = 5;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            int a = Random.Range(0, Points.Length);
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.GetComponent<SpriteRenderer>().color = Color.black;
            newEnemy.transform.position = Points[a].transform.position;
            time = time - 2;
        }
    }
}
