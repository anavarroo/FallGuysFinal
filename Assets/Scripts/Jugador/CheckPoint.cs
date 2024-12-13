using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;
  

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < dead)
        {
            // Reinicia la posición del jugador al Ultimo checkpoint o al punto predeterminado
            player.transform.position = vectorPoint;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Almacena la posiciOn actual del jugador como checkpoint
        vectorPoint = player.transform.position;

        Destroy(other.gameObject);
    }
}

