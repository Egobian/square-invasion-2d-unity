using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    private float ejeVertical;
    private float ejeHorizontal;

    private bool estaAcelerando;

    [SerializeField]
    private float fuerza = 10f;
    [SerializeField]
    private float velocidadMaxima = 30f;
    [SerializeField]
    private float velocidadDeGiro = 6.5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ejeVertical = Input.GetAxisRaw("Vertical");
        ejeHorizontal = Input.GetAxisRaw("Horizontal");

        if (ejeVertical > 0)
        {
            estaAcelerando = true;
        }
        else
        {
            estaAcelerando = false;
        }
    }

    private void FixedUpdate()
    {
        if (estaAcelerando)
        {
            if (rb.velocity.sqrMagnitude <= velocidadMaxima)
            {
                rb.AddForce(transform.up * fuerza, ForceMode2D.Force);
            }
        }

        rb.rotation += ejeHorizontal * velocidadDeGiro * -1;
    }

}
