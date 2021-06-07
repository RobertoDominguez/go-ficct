using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorTerreno : MonoBehaviour
{
    [SerializeField] Transform posicionPisoInicial;
    [SerializeField] Transform posicionFondoInicial;
    [SerializeField] float distanciaEntrePisos;
    [SerializeField] float distanciaEntreFondos;

    [SerializeField] GameObject prefabPiso;
    [SerializeField] GameObject prefabFondo;
    [SerializeField] List<GameObject> listaDePrefabRampas;

    float posicionPisoActual;
    float posicionFondoActual;
    List<GameObject> listaDeTerrenos = new List<GameObject>();
    List<GameObject> listaDeFondos = new List<GameObject>();
    List<GameObject> listaDeRampas = new List<GameObject>();

    public float DistanciaEntrePisos { get => distanciaEntrePisos; set => distanciaEntrePisos = value; }
    public float DistanciaEntreFondos { get => distanciaEntreFondos; set => distanciaEntreFondos = value; }
    public Transform PosicionPisoInicial { get => posicionPisoInicial; set => posicionPisoInicial = value; }
    public Transform PosicionFondoInicial { get => posicionFondoInicial; set => posicionFondoInicial = value; }
    public float PosicionPisoActual { get => posicionPisoActual; set => posicionPisoActual = value; }
    public float PosicionFondoActual { get => posicionFondoActual; set => posicionFondoActual = value; }

    private void Start()
    {
        PosicionPisoActual = PosicionPisoInicial.position.x;
        PosicionFondoActual = PosicionFondoInicial.position.x;
    }

    public void GenerarPiso()
    {
        PosicionPisoActual += DistanciaEntrePisos;
        GameObject piso=Instantiate(prefabPiso);
        piso.transform.position = new Vector2(PosicionPisoActual,PosicionPisoInicial.position.y);
        listaDeTerrenos.Add(piso);
        if (listaDeTerrenos.Count>2)
        {
            Destroy(listaDeTerrenos[0]);
            listaDeTerrenos.RemoveAt(0);
        }

        //genera rampas aleatorias
        GameObject rampa = Instantiate(listaDePrefabRampas[Random.Range(0,listaDePrefabRampas.Count)]);
        rampa.transform.position = new Vector2(PosicionPisoActual, PosicionPisoInicial.position.y+3);
        listaDeRampas.Add(rampa);
        if (listaDeRampas.Count > 2)
        {
            Destroy(listaDeRampas[0]);
            listaDeRampas.RemoveAt(0);
        }
    }

    public void GenerarFondo()
    {
        PosicionFondoActual += DistanciaEntreFondos;
        GameObject fondo = Instantiate(prefabFondo);
        fondo.transform.position = new Vector2(PosicionFondoActual, PosicionFondoInicial.position.y);
        listaDeFondos.Add(fondo);
        if (listaDeFondos.Count > 2)
        {
            Destroy(listaDeFondos[0]);
            listaDeFondos.RemoveAt(0);
        }
    }
}
