using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public AudioSource jumpSound; // Referencia al AudioSource
    public float jumpHeight = 2.0f; // Altura del salto
    public float gravity = -9.8f; // Gravedad
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("No se encontró un componente CharacterController en " + gameObject.name);
        }
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Lógica para hacer que el personaje salte
            Jump();

            // Reproducir el sonido de salto
            jumpSound.Play();
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        // Lógica de salto usando CharacterController
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
