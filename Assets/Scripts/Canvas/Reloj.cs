using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
   
    public float timer = 0;
    public Text texoTimer;

    void Update()
    {
        timer -= Time.deltaTime; // Ir disminuyendo el tiempo

        texoTimer.text = "" + timer.ToString("f0"); // "f0" para los decimales 
        
    }
}
