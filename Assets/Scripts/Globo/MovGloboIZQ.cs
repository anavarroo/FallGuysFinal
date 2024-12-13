using UnityEngine;

public class MovGloboIZQ : MonoBehaviour
{
    public float speed = 5.0f;
    public float despawnX = 10.0f;

    private void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);

        if (transform.position.x >= despawnX)
        {
            Destroy(gameObject);
        }
    }
}
