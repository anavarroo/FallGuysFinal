using UnityEngine;

public class CirculoJugador : MonoBehaviour 
{
    Transform movimientoOriginal; // Movimiento inicial del jugador
    void OnCollisionEnter(Collision collision) // Se ejecuta cuando se produce el contacto
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Almacena la transformada padre del jugador (movimiento original)
            movimientoOriginal = collision.transform.parent;
            // Establece este objeto como el nuevo padre del jugador
            collision.transform.SetParent(transform);
        }
    }
    void OnCollisionExit(Collision collision) // Se ejecuta cuando se deja de estar en contacto
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Restaura el padre original del jugador
            collision.transform.SetParent(movimientoOriginal);
        }
    }
}