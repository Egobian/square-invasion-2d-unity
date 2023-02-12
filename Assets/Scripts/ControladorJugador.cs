using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform arma;
    private float ejeVertical;
    private float ejeHorizontal;

    private bool estaAcelerando;

    [SerializeField]
    private float fuerza = 10f;
    [SerializeField]
    private float velocidadMaxima = 40f;
    [SerializeField]
    private float velocidadDeGiro = 6.5f;
    [SerializeField]
    private GameObject balaPref;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        arma = transform.Find("Arma");
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

        if (Input.GetKeyDown("space"))
        {
            GameObject bala = Instantiate(balaPref, arma.position, arma.rotation);
            
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bordes" || collision.gameObject.tag == "Enemigo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
    }

}
