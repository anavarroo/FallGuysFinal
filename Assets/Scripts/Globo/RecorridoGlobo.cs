using UnityEngine;

public class RotacionCircular : MonoBehaviour
{
    public Transform centroDeRotacion;
    public float velocidadRotacion = 50f;

    void Update()
    {
        // Calcula la posición en un círculo alrededor del centro de rotación
        float angulo = velocidadRotacion * Time.deltaTime;
        Vector3 posicionCircular = Quaternion.Euler(0, angulo, 0) * (transform.position - centroDeRotacion.position);

        // Actualiza la posición del objeto alrededor del centro de rotación
        transform.position = centroDeRotacion.position + posicionCircular;
    }
}
