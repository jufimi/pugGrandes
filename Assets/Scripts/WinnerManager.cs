using UnityEngine;

public class WinnerManager : MonoBehaviour
{
    public GameObject playerMarioPrefab;
    public GameObject playerLuigiPrefab;
    public Camera mainCamera; // Referencia a la cámara principal
    public Vector3 cameraPosition = new Vector3(0, 5, -10); // Posición fija de la cámara
    public Vector3 cameraRotation = new Vector3(20, 0, 0); // Rotación fija de la cámara

    void Start()
    {
        string winnerName = PlayerPrefs.GetString("WinnerName");
        Vector3 winnerPosition = PlayerPrefsX.GetVector3("WinnerPosition");
        Quaternion winnerRotation = PlayerPrefsX.GetQuaternion("WinnerRotation");

        // Obtener la posición del EventSystem
        GameObject eventSystem = GameObject.Find("EventSystem");
        if (eventSystem != null)
        {
            winnerPosition = eventSystem.transform.position;
        }
        else
        {
            Debug.LogError("EventSystem no encontrado en la escena.");
        }

        GameObject winner = null;

        if (winnerName == "playerMario")
        {
            winner = Instantiate(playerMarioPrefab, winnerPosition, winnerRotation);
        }
        else if (winnerName == "playerLuigi")
        {
            winner = Instantiate(playerLuigiPrefab, winnerPosition, winnerRotation);
        }

        if (winner != null)
        {
            winner.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); // Ajustar el tamaño del jugador

            // Configurar y reproducir la animación de victoria
            PlayerController playerController = winner.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TriggerVictoryAnimation();
            }
            else
            {
                Debug.LogError("No se encontró un componente PlayerController en " + winner.name);
            }

            // Ajustar la posición y rotación de la cámara a valores fijos
            mainCamera.transform.position = cameraPosition;
            mainCamera.transform.eulerAngles = cameraRotation;
        }
    }
}

