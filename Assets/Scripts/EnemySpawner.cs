using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPref;
    private GameObject[] spawners;
    private float velocidadRotacion;

    private void Awake()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    void Start()
    {
        velocidadRotacion = 5f;
        StartCoroutine(SpawnearEnemigo(enemigoPref));
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime * -1, Space.Self);
    }

    private IEnumerator SpawnearEnemigo(GameObject enemigo)
    {
        yield return new WaitForSeconds(Random.Range(1f, 6f));
        Instantiate(enemigoPref, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
        StartCoroutine(SpawnearEnemigo(enemigo));
    }

}
