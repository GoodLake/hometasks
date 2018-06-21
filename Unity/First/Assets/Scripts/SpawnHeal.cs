using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeal : MonoBehaviour {

    public GameObject heal;
    public GameObject[] Points;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            int a = Random.Range(0, Points.Length);
            GameObject newHeal = Instantiate(heal);
            newHeal.transform.position = Points[a].transform.position;
            Destroy(newHeal, 2f);
        }
    }
}
