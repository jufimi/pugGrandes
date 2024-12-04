using System.Collections; // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para SceneManager

public class EliminarJugador : MonoBehaviour
{
    private RespawnManager respawnManager;
    private RespawnManagerLuigi respawnManagerLuigi; // Declarar ambos tipos correctamente

    private string winnerName;
    private Vector3 winnerPosition;
    private Quaternion winnerRotation;

    void Start()
    {
        // Encontrar los RespawnManagers en la escena
        respawnManager = FindObjectOfType<RespawnManager>();
        respawnManagerLuigi = FindObjectOfType<RespawnManagerLuigi>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que entró en contacto tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica si el objeto es playerMario o playerLuigi
            if (collision.gameObject.name == "playerMario" && respawnManager != null)
            {
                winnerName = "playerLuigi";
                StoreWinnerPosition();
                StartCoroutine(RespawnAndDestroy(collision.gameObject, respawnManager));
            }
            else if (collision.gameObject.name == "playerLuigi" && respawnManagerLuigi != null)
            {
                winnerName = "playerMario";
                StoreWinnerPosition();
                StartCoroutine(RespawnAndDestroy(collision.gameObject, respawnManagerLuigi));
            }
        }
    }

    private void StoreWinnerPosition()
    {
        GameObject winner = GameObject.Find(winnerName);
        if (winner != null)
        {
            winnerPosition = winner.transform.position;
            winnerRotation = winner.transform.rotation;
            PlayerPrefs.SetString("WinnerName", winnerName);
            PlayerPrefsX.SetVector3("WinnerPosition", winnerPosition);
            PlayerPrefsX.SetQuaternion("WinnerRotation", winnerRotation);
        }
    }

    private IEnumerator RespawnAndDestroy(GameObject player, MonoBehaviour respawnManager)
    {
        // Destruir el objeto jugador actual
        Destroy(player);

        // Espera un frame para asegurar que el jugador ha sido eliminado
        yield return null;

        // Cargar la escena de victoria
        SceneManager.LoadScene("VictoryScene");
    }
}
