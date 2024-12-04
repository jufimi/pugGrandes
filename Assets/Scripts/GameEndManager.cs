using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    public AudioSource endGameSound; // Referencia al AudioSource
    public float delayBeforeSceneLoad = 3.0f; // Tiempo de espera antes de cambiar de escena

    void Start()
    {
        if (endGameSound == null)
        {
            endGameSound = GetComponent<AudioSource>();
            if (endGameSound == null)
            {
                Debug.LogError("No se encontró un componente AudioSource en " + gameObject.name);
            }
        }
    }

    public void EndGame()
    {
        // Reproducir el sonido de fin del juego
        if (endGameSound != null)
        {
            endGameSound.Play();
        }

        // Esperar a que termine el sonido antes de cambiar de escena
        Invoke(nameof(LoadVictoryScene), endGameSound.clip.length);
    }

    void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
