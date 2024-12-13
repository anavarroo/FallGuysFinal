using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraPalaDiscos : MonoBehaviour
{
    public float velocidadRotacion = 80.0f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto alrededor de su eje Y
        transform.Rotate(Vector3.up, velocidadRotacion * -Time.deltaTime);

    }
}
