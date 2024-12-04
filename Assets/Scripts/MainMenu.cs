using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Cargar la siguiente escena del juego
        SceneManager.LoadScene(1); // Asegúrate de que el índice de la escena sea correcto
    }

    public void QuitGame()
    {
        // Salir del juego
        Debug.Log("Quit");
        Application.Quit();
    }
}
