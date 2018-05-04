using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject enemy;
    public GameObject[] Points;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0f, 2f));
            int a = Random.Range(0, Points.Length);

            print(a);
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.GetComponent<SpriteRenderer>().color = Color.black;
            newEnemy.transform.position = Points[a].transform.position;
        }
    }
}
