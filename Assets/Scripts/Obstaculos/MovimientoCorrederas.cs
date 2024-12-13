using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;  // Velocidad de movimiento
    public float distanciaMaxima = 5.0f;      // Distancia máxima que recorrerá la caja

    private Vector3 posicionInicial;
    private int direccion = 1;  // 1 para mover hacia la derecha, -1 para mover hacia la izquierda

    void Start()
    {
        // Guarda la posición inicial de la caja
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula la nueva posición de la caja
        Vector3 nuevaPosicion = transform.position + Vector3.right * direccion * velocidadMovimiento * Time.deltaTime;

        // Comprueba si la caja ha alcanzado su distancia máxima
        if (Vector3.Distance(posicionInicial, nuevaPosicion) >= distanciaMaxima)
        {
            // Cambia la dirección de movimiento
            direccion *= -1;
        }

        // Aplica la nueva posición a la caja
        transform.position = nuevaPosicion;
    }
}
