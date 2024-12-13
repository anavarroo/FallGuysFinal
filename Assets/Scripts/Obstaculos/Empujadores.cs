using UnityEngine;

public class Empujadores : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento en el eje X
    public float distancia = 2.0f; // Distancia total de movimiento en el eje X

    private Vector3 posicionInicial;

    void Start()
    {
        // Guarda la posición inicial del objeto
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en el eje X usando la función seno para crear un movimiento oscilante
        float desplazamientoX = Mathf.Sin(Time.time * velocidad) * distancia;

        // Actualiza la posición del objeto solo en el eje X
        transform.position = new Vector3(posicionInicial.x + desplazamientoX, transform.position.y, transform.position.z);
    }
}
