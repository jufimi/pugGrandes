using UnityEngine;

public class SpinishellBounceSound : MonoBehaviour
{
    public AudioSource bounceSound; // Referencia al AudioSource

    void Start()
    {
        bounceSound = GetComponent<AudioSource>();
        if (bounceSound == null)
        {
            Debug.LogError("No se encontró un componente AudioSource en " + gameObject.name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reproducir el sonido de rebote al colisionar con otro objeto
        if (collision.relativeVelocity.magnitude > 1) // Puedes ajustar este valor según sea necesario
        {
            bounceSound.Play();
        }
    }
}
