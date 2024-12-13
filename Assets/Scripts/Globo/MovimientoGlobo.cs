using System.Collections;
using UnityEngine;

public class MovimientoConstante : MonoBehaviour
{
    public Transform spawn;
    public Transform despawn;
    public GameObject globoPrefab; // Prefab del globo
    public float velocidad = 5f;

    void Update()
    {

        // Mover el globo en la direccion deseada
        transform.Translate(-Vector3.forward * velocidad * Time.deltaTime);

        if (transform.position.x > despawn.position.x)
        {
            StartCoroutine(RespawnGlobo());
        }
    }

    IEnumerator RespawnGlobo()
    {
        // Guardar la rotacion del globo actual
        Quaternion rotacionActual = transform.rotation;

        // Esperar un tiempo antes de crear una nueva instancia del globo
        yield return new WaitForSeconds(2f);

        // Crear una nueva instancia del globo en la posicion de spawn
        GameObject nuevoGlobo = Instantiate(globoPrefab, spawn.position, rotacionActual);

        // Destruir el globo actual
        Destroy(gameObject);
    }
}
