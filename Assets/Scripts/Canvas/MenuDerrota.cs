using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{

    [SerializeField] private GameObject botonReinicio;
    [SerializeField] private GameObject Salir;


    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void Cerrar()
    {
        Debug.Log("Suerte la proxima ( :");

        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
}
