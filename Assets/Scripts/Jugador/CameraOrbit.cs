using Unity.VisualScripting;
using UnityEngine;

public class SeguirObjetoConCamara : MonoBehaviour
{
    public Transform objetoASeguir; // Referencia al objeto que se debe seguir
    public float offsetX = 0.3f;  // Ajusta la posición en X de la cámara
    public float offsetY = 5.0f;  // Ajusta la posición en Y de la cámara
    public float offsetZ = 6.0f;  // Ajusta la posición en Z de la cámara
    public float velocidadRotacionX = 2.0f; // Velocidad de rotación en el eje X con el mouse
    public float velocidadRotacionY = 2.0f; // Velocidad de rotación en el eje Y con el mouse
    public MoverJugdor mover;

    float currentheight;
    Vector3 targetCameraPos = new Vector3();
    public float FollowSpeed = 4;

    void Start()
    {
       
    }

    void Update()
    {

        // Verifica si el objeto de referencia (objetoASeguir)
        if (objetoASeguir != null)
        {
            // Movimiento de la cámara
            MoverCamara();

            // Verifica si la tecla Shift está presionada y el jugador no está saltando
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                // Rotación de la cámara con el mouse
                RotarCamaraConMouse();
            }
            
        }
    }

    void MoverCamara()
    {
        // Obtiene la posición actual del objeto a seguir
        Vector3 posicionObjeto = objetoASeguir.position;

        // Calcula la nueva posición de la cámara
        if (mover.enSuelo) // Le paso el booleano del Script de movimiento del jugador. Si es TRUE, la poscion de la camara simpre esta en su respectiva
                           // altura"posicionObjeto.y + offsetY"
        {
                    targetCameraPos = new Vector3(
                    posicionObjeto.x + offsetX,
                    posicionObjeto.y + offsetY,
                    posicionObjeto.z + offsetZ
                );
        } else // Si enSuelo es FALSE, la camara en el eje Y se queda en su posicion fija.
        {
            targetCameraPos = new Vector3(
                    posicionObjeto.x + offsetX,
                    transform.position.y,
                    posicionObjeto.z + offsetZ
                );
        }
        

        // Cambio la posicion de la camara hacia su nueva posicion de una manera suave usando LERP y MOVETOWARS
        transform.position = Vector3.Lerp(transform.position,targetCameraPos,Time.deltaTime * FollowSpeed);
        transform.position = Vector3.MoveTowards(transform.position, targetCameraPos, Time.deltaTime * FollowSpeed);
    }

    void RotarCamaraConMouse()
    {
        // Obtiene la rotación actual de la cámara
        float rotacionX = Input.GetAxis("Mouse Y") * velocidadRotacionX; // Rotación en el eje Y
        float rotacionY = Input.GetAxis("Mouse X") * velocidadRotacionY; // Rotación en el eje X

        // Rota la cámara en función del movimiento del mouse
        transform.Rotate(-rotacionX, rotacionY, 0);
    }
}
