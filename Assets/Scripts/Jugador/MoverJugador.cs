using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MoverJugdor : MonoBehaviour
{

     // JUGADOR 
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody rb;
    private Animator anim;

    public int numeroSaltos = 0; // Número de saltos realizados
    public bool enSuelo = true;
    public float currentheight;

    [SerializeField] Rigidbody player;
    
    [SerializeField] float dead; // Punto el cual si sobrepasa, MUERE

    public int vidas = 3;

    // CHECK POINTS
    [SerializeField] List<GameObject> checkPoints;
    private Transform puntoDeReaparicion; // Punto de reaparición dinámico

    // MENU DERROTA/VICTORIA
    public GameObject Derrota;
    public GameObject Victoria;


    // CORAZONES
    public GameObject v1;
    public GameObject v2;
    public GameObject v3;

    // CANVAS
    public Text Resultado;
    public Text Vidas;
    public float timer = 0;
    public Text texoTimer;

    // AUDIO
    private AudioSource audioSource;
    [SerializeField] private AudioClip salto;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Bloqueo el EJE para que no se caiga hacia los lados
        anim = GetComponent<Animator>();
        puntoDeReaparicion = transform; // Establece el punto de reaparición inicial como la posición del jugador
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = salto;
    }


    void Update()
    {
        
        MoverJugador();
        Saltar();

        // Si la Y del jugador es menor al valor de DEAD, el jugador muere
        if (player.transform.position.y < dead) 
        {
            RespawnPlayer();
        }

        UpdateVidas();



        // Abrir menu si se pulsa "Esc" 
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }


        // Ir disminuyendo el tiempo
        timer -= Time.deltaTime;

        texoTimer.text = "" + timer.ToString("f0"); // "f0" para los decimales 

        if (timer < 0)
        {
            Derrota.SetActive(true); 
            Debug.Log("Se te acabo el tiempo!");
        }
    }

    // Va actualizando las vidas constamente ante cualquier suceso
     void UpdateVidas()
    {
        if(vidas == 3)
        {
            v1.SetActive(true);
            v2.SetActive(true);
            v3.SetActive(true);
        }

        if (vidas == 2)
        {
            v1.SetActive(false);
            v2.SetActive(true);
            v3.SetActive(true);
        }

        if (vidas == 1)
        {
            v1.SetActive(false);
            v2.SetActive(false);
            v3.SetActive(true);
        }


        Vidas.text = vidas.ToString() + "/3";
       if (vidas == 0)
       {
            v1.SetActive(false);
            v2.SetActive(false);
            v3.SetActive(false);
            Derrota.SetActive(true);
            Debug.Log("Perdiste!");
       }

    }

    void RespawnPlayer()
    {
        player.transform.position = puntoDeReaparicion.position;

        enSuelo = true;
        vidas = vidas - 1;
        Debug.Log("Perdiste una vida. Vidas restantes: " + vidas);
    }

    void MoverJugador()
    {
        // Se ponen negativos los Inputs porque el mapa esta rotado
        float movimientoHorizontal = -Input.GetAxis("Horizontal");
        float movimientoVertical = -Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento, Space.World);

        // Rotar el personaje de manera suave para que mire en la dirección del movimiento.
        if (movimiento != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f); // Ajusta el valor de interpolación (0.1f) según lo desees.
        }

        // Si no se está ingresando ninguna entrada de movimiento, establece la animación en 0.
        if (movimientoHorizontal == 0 && movimientoVertical == 0)
        {
            anim.SetFloat("Movimientos", 0, 0.1f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Movimientos", 0.5f, 0.1f, Time.deltaTime);
        }
    }
    
    void Saltar()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
            if (enSuelo || numeroSaltos < 2)
            {
                currentheight = transform.position.y;
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                anim.SetBool("salto", true); // salto (Parametro del animator) = TRUE para que realice la animacion
               
                ReproducirSonidoSalto();

                enSuelo = false;
                         
                if (!enSuelo)
                {
                    if (numeroSaltos == 1) // Transicion a doble salto solo después del primer salto
                    {
                        anim.SetBool("dobleSalto", true); // dobleSalto (Parametro del animator) = TRUE para que realice la animacion
                    }

                    numeroSaltos++;
                }
            }
        }
        else
        {
            anim.SetBool("dobleSalto", false);

            // Reinicia numeroSaltos a 0 si toca el suelo. 
            if (enSuelo)
            {
                numeroSaltos = 0;
            }

            anim.SetBool("salto", false);
        }
    }

    void ReproducirSonidoSalto()
    {
        if (audioSource != null && salto != null)
        {
            audioSource.PlayOneShot(salto);
        }
    }

     void OnCollisionEnter(Collision collision)
    {

        // Colision para detectar si el personaje esta en el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {

            enSuelo = true; // El personaje está en el suelo.
            anim.SetBool("salto", false);
            anim.SetBool("dobleSalto", false); 
            
        }

        // Colision para detectar si el personaje llega a meta
        if (collision.gameObject.CompareTag("Meta"))
        {
            Debug.Log("Victoria!! ( :");
            Victoria.SetActive(true);
        }

        // Colision para detectar si el personaje es tocado por el Objeto con el tag "Pala"
        if (collision.gameObject.CompareTag("Pala"))
        {
            RespawnPlayer();
            UpdateVidas();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Debug.Log("Has llegado a un CheckPoint");
            puntoDeReaparicion = other.transform;
           
        }

    }
}
