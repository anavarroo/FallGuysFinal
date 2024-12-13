using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void Empezar(string NombreNivel)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(NombreNivel);
    }
    public void Salir()
    {

        Application.Quit();
        
        Debug.Log("Cierre");
    }
}
