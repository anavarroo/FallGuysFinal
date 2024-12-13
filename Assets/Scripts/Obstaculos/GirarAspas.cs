using UnityEngine;

public class GirarAspas : MonoBehaviour
{
    public float velocidadGiroX = 500f;
    public float velocidadGiroZ = 200f;

    void Update()
    {
        // Gira las aspas solo sobre los ejes locales X y Z
        transform.Rotate(Vector3.right, velocidadGiroX * Time.deltaTime);
        transform.Rotate(Vector3.forward, velocidadGiroZ * Time.deltaTime);
    }
}
