using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Windows;

public class ControladorEnemigo : MonoBehaviour
{
    private Transform objetivo;

    private float velocidad;
    private Vector3 direccion;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        objetivo = GameObject.FindGameObjectsWithTag("Jugador")[0].transform;
        velocidad = Random.Range(2f, 5f);
    }

    void Update()
    {
        direccion = objetivo.position - transform.position;
        direccion.Normalize();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direccion * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalaJugador")
        {
            Destroy(this.gameObject);
        }


    }
}
