using UnityEngine;

public class SpinishellCollisionSound : MonoBehaviour
{
    private GameEndManager gameEndManager;

    void Start()
    {
        gameEndManager = FindObjectOfType<GameEndManager>();
        if (gameEndManager == null)
        {
            Debug.LogError("No se encontró un componente GameEndManager en la escena.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado es playerMario o playerLuigi
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar al método EndGame para reproducir el sonido y cambiar de escena
            gameEndManager.EndGame();
            Debug.Log("Fin del juego: " + collision.gameObject.name + " fue tocado por SPINYSHELL");
        }
    }
}
