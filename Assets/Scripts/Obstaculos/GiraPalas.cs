using System.Collections;
using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
    public float velocidadRotacion = 80.0f; 
    public float tiempoMinimo = 4.0f; 
    public float tiempoMaximo = 10.0f;

    void Start()
    {
        // Iniciar la corutina para cambiar la dirección cada ciertos segundos
        StartCoroutine(CambiarDireccionPeriodico());
    }

    void Update()
    {
        // Rotar el objeto alrededor de su eje Y
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    IEnumerator CambiarDireccionPeriodico()
    {
        while (true)
        {
            // Generar un tiempo aleatorio entre tiempoMinimo y tiempoMaximo
            float tiempoAleatorio = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(tiempoAleatorio);

            // Cambiar la dirección de rotación invirtiendo la velocidad
            velocidadRotacion = -velocidadRotacion;
        }
    }
}
