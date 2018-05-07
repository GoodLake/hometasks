using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatrons : MonoBehaviour
{

    public GameObject ammo;
    public GameObject[] Points;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            int a = Random.Range(0, Points.Length);
            GameObject newAmmo = Instantiate(ammo);
            newAmmo.transform.position = Points[a].transform.position;
            Destroy(newAmmo, 2f);
        }
    }
}
