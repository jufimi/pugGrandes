using UnityEngine;

public class StartGameSound : MonoBehaviour
{
    public AudioSource startSound;

    void Start()
    {
        startSound = GetComponent<AudioSource>();
        // Reproducir el sonido de inicio al comenzar la partida
        startSound.Play();
    }
}
