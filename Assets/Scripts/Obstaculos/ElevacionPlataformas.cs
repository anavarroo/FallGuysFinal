using UnityEngine;

public class PlataformaSubeBaja : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento
    public float distancia = 2.0f; // Distancia total de movimiento

    private Vector3 posicionInicial;

    void Start()
    {
        // Guarda la posición inicial del objeto
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en el eje Y usando la función seno para crear un movimiento oscilante
        float desplazamientoY = Mathf.Sin(Time.time * velocidad) * distancia;

        // Actualiza la posición del objeto con respecto a la posición inicial y el desplazamiento en el eje Y
        transform.position = new Vector3(transform.position.x, posicionInicial.y + desplazamientoY, transform.position.z);
    }
}
