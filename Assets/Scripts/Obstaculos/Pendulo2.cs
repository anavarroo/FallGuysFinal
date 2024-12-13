using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo2 : MonoBehaviour
{

    // Todo lo mismo que el Script pendulo pero cambiando la direccion. 
    public float velocidad = 1.5f;
    public float limite = 75f;



    void Update()
    {
        float angle = limite * Mathf.Sin(Time.time * velocidad);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
