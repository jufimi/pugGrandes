using UnityEngine;

public class SpinishellFallSound : MonoBehaviour
{
    public AudioSource fallSound; // Referencia al AudioSource

    void Start()
    {
        fallSound = GetComponent<AudioSource>();
        if (fallSound == null)
        {
            Debug.LogError("No se encontró un componente AudioSource en " + gameObject.name);
        }
        else
        {
            // Reproducir el sonido de caída al iniciar el juego
            fallSound.Play();
        }
    }
}
