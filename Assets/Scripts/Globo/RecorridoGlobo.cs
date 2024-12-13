using UnityEngine;

public class RotacionCircular : MonoBehaviour
{
    public Transform centroDeRotacion;
    public float velocidadRotacion = 50f;

    void Update()
    {
        // Calcula la posici�n en un c�rculo alrededor del centro de rotaci�n
        float angulo = velocidadRotacion * Time.deltaTime;
        Vector3 posicionCircular = Quaternion.Euler(0, angulo, 0) * (transform.position - centroDeRotacion.position);

        // Actualiza la posici�n del objeto alrededor del centro de rotaci�n
        transform.position = centroDeRotacion.position + posicionCircular;
    }
}
