using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCaida : MonoBehaviour
{
    [SerializeField] float velocidadCaida;
    float velocidadCaidaDinamica = 0;
    [SerializeField] List<GameObject> listaDeNubes;
    [SerializeField] List<GameObject> listaDePrefabs;
    [SerializeField] List<GameObject> listaDeElementos;
    [SerializeField] Transform topeIzq,topeDer,topeInf;
    [SerializeField] GameObject fondoParent;

    public Transform TopeIzq { get => topeIzq; set => topeIzq = value; }
    public Transform TopeDer { get => topeDer; set => topeDer = value; }
    public Transform TopeInf { get => topeInf; set => topeInf = value; }

    void Update()
    {
        ControlElementos();
        ControlVelocidad();
    }

    void ControlElementos()
    {
        fondoParent.transform.position= new Vector3(fondoParent.transform.position.x,
                fondoParent.transform.position.y + (velocidadCaidaDinamica * Time.deltaTime), 10);

        if (listaDeElementos[listaDeElementos.Count-1].transform.position.y>
            TopeInf.transform.position.y)
        {

            InvocarNube();
            InvocarElemento();
            InvocarElemento();
        }
        if (listaDeElementos.Count > 20)
        {
            Destroy(listaDeElementos[0]);
            listaDeElementos.RemoveAt(0);
        }
    }

    void InvocarNube() 
    {
        GameObject nube = Instantiate(listaDeNubes[Random.Range(0, listaDeNubes.Count)]);
        nube.transform.position = new Vector3(
            Random.Range(topeIzq.transform.position.x, TopeDer.transform.position.x),
            -20
            , 10);
        nube.transform.parent = fondoParent.transform;

        listaDeElementos.Add(nube);
    }


    void InvocarElemento()
    {
        GameObject elem = Instantiate(listaDePrefabs[Random.Range(0, listaDePrefabs.Count)]);
        elem.transform.position = new Vector3(
            Random.Range(topeIzq.transform.position.x, TopeDer.transform.position.x),
            -20, 16.80273f);
        elem.transform.parent = fondoParent.transform;

        listaDeElementos.Add(elem);
    }


    void ControlVelocidad()
    {
        //Debug.Log(Mathf.Log10(1+Time.time/60));
        velocidadCaidaDinamica = velocidadCaida + (1 + Time.time / 30);
    }

}
