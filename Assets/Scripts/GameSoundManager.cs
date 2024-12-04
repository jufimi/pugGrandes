using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public AudioSource startSound;
    public AudioSource ambientSound;
    public AudioSource nextSound;

    void Start()
    {
        // Reproducir el sonido de inicio de partida
        if (startSound != null)
        {
            startSound.Play();
            // Invocar la reproducción del sonido ambiental después de la duración del sonido de inicio
            Invoke(nameof(PlayAmbientSound), startSound.clip.length);
        }
    }

    void PlayAmbientSound()
    {
        // Reproducir el sonido ambiental
        if (ambientSound != null)
        {
            ambientSound.Play();
            // Invocar la reproducción del siguiente sonido después de la duración del sonido ambiental
            Invoke(nameof(PlayNextSound), ambientSound.clip.length);
        }
    }

    void PlayNextSound()
    {
        // Reproducir el siguiente sonido
        if (nextSound != null)
        {
            nextSound.Play();
        }
    }
}
