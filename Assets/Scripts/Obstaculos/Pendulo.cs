using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{
	public float velocidad = 1.5f; // Oscilacion
	public float limite = 75f; 
	


    void Update()
    {
		// Calcular el angulo de oscilacion basado en el tiempo y la velocidad
		float angle = limite * Mathf.Sin(Time.time * velocidad);
		// Establece la rotacion local del objeto utilizando cuaternion
		transform.localRotation = Quaternion.Euler(0, 0, -angle);
	}
}
