using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private float velocidad;

    private void Start()
    {
        velocidad = 12f;
    }

    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime, Space.Self);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Bordes")
        {
            Destroy(this.gameObject);
        }
    }

}
