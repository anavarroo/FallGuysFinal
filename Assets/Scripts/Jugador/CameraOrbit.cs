using Unity.VisualScripting;
using UnityEngine;

public class SeguirObjetoConCamara : MonoBehaviour
{
    public Transform objetoASeguir; // Referencia al objeto que se debe seguir
    public float offsetX = 0.3f;  // Ajusta la posici�n en X de la c�mara
    public float offsetY = 5.0f;  // Ajusta la posici�n en Y de la c�mara
    public float offsetZ = 6.0f;  // Ajusta la posici�n en Z de la c�mara
    public float velocidadRotacionX = 2.0f; // Velocidad de rotaci�n en el eje X con el mouse
    public float velocidadRotacionY = 2.0f; // Velocidad de rotaci�n en el eje Y con el mouse
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
            // Movimiento de la c�mara
            MoverCamara();

            // Verifica si la tecla Shift est� presionada y el jugador no est� saltando
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                // Rotaci�n de la c�mara con el mouse
                RotarCamaraConMouse();
            }
            
        }
    }

    void MoverCamara()
    {
        // Obtiene la posici�n actual del objeto a seguir
        Vector3 posicionObjeto = objetoASeguir.position;

        // Calcula la nueva posici�n de la c�mara
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
        // Obtiene la rotaci�n actual de la c�mara
        float rotacionX = Input.GetAxis("Mouse Y") * velocidadRotacionX; // Rotaci�n en el eje Y
        float rotacionY = Input.GetAxis("Mouse X") * velocidadRotacionY; // Rotaci�n en el eje X

        // Rota la c�mara en funci�n del movimiento del mouse
        transform.Rotate(-rotacionX, rotacionY, 0);
    }
}
