using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly: MonoBehaviour
{
    [SerializeField] float velocidadDeMovimiento;
    [SerializeField] ControlCaida controlCaida;
    [SerializeField] Animator anim;
    [SerializeField] GameObject prefExplosion;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal")>0)
        {
            MoverDer();
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            MoverIzq();
        }
        if (Input.GetAxis("Horizontal")==0)
        {
            anim.SetTrigger("stop");
        }
    }

    void MoverIzq()
    {
        if (transform.position.x>controlCaida.TopeIzq.position.x)
        {
            transform.position = new Vector2(transform.position.x-(velocidadDeMovimiento*Time.deltaTime)
                ,transform.position.y);
        }
        anim.Play("MovIzq");
    }

    void MoverDer()
    {
        if (transform.position.x < controlCaida.TopeDer.position.x)
        {
            transform.position = new Vector2(transform.position.x + (velocidadDeMovimiento * Time.deltaTime)
                , transform.position.y);
        }
        anim.Play("MovDer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Daño")
        {
            GameObject explosion = Instantiate(prefExplosion);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, 16.80273f);
            Destroy(explosion, 0.5f);
        }
    }


}
