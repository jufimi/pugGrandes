using UnityEngine;

public class EliminarJugador : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que entró en contacto tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruir el objeto jugador
            Destroy(collision.gameObject);
        }
    }
}
