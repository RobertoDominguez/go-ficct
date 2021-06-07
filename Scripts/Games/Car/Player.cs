using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GeneradorTerreno generador;
    [SerializeField] Transform camara;

    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float velocidad;
    [SerializeField] float maxVelocidad;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            MoverseDerecha();
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            MoverseIzquierda();
        }
        ActualizarTerreno();
        SeguirPlayer();
        Animaciones();
    }

    void SeguirPlayer()
    {
        camara.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+2, -10);
    }

    void ActualizarTerreno()
    {
        if (this.transform.position.x>generador.PosicionPisoActual+(generador.DistanciaEntrePisos/2))
        {
            generador.GenerarPiso();
        }
        if (this.transform.position.x > generador.PosicionFondoActual)
        {
            generador.GenerarFondo();
        }
    }

    void MoverseDerecha()
    {
        if (rb.velocity.x<velocidad)
        {
            rb.velocity = new Vector2(rb.velocity.x + (velocidad*Time.deltaTime), rb.velocity.y);
        }

        transform.RotateAround(this.transform.position, new Vector3(0, 0, -1), 200 * Time.deltaTime);
    }

    void MoverseIzquierda()
    {
        if (rb.velocity.x < velocidad)
        {
            rb.velocity = new Vector2(rb.velocity.x + (velocidad * Time.deltaTime), rb.velocity.y);
        }
        transform.RotateAround(this.transform.position, new Vector3(0, 0, -1), -200 * Time.deltaTime);
    }

    void Animaciones()
    {
        if (Mathf.Abs(rb.velocity.x)>0)
        {
            anim.Play("Run");
        }
        else
        {
            anim.Play("Idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="Piso")
        {
            if (Mathf.Abs(transform.eulerAngles.z) >= 175 && Mathf.Abs(transform.eulerAngles.z) <= 185)
            {
                Debug.Log("perdiste");
            }
        }
    }
}
