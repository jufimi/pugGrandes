using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    private Vector3 move;

    // Define los límites del terreno (declaración correcta)
    public float minX = -0.7424679f;
    public float maxX = 30.27863f;
    public float minZ = -0.05581856f;
    public float maxZ = 31.17621f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calcula el movimiento en función del input del jugador
        move = transform.right * moveX + transform.forward * moveZ;
        move = move * moveSpeed * Time.deltaTime;

        // Aplica el movimiento al CharacterController
        controller.Move(move);

        // Limita la posición del personaje dentro de los límites del terreno
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);

        // Actualiza la posición del transform del personaje
        transform.position = clampedPosition;
    }
}


