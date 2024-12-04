using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController _player;
    private float _moveSpeed = 5f; // Velocidad de movimiento ajustada
    private Vector3 _moveDirection;
    private Camera _camera;

    [SerializeField] private float _gravity = 9.81f; // Gravedad ajustada
    private float _fallVelocity;
    [SerializeField] private float _jumpForce = 5f; // Fuerza de salto ajustada
    [SerializeField] private AudioClip jumpSound; // Sonido de salto

    private Animator _animator;
    private AudioSource audioSource;

    private bool inVictoryScene;

    void Awake()
    {
        _player = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        _camera = Camera.main;

        // Verificar en qué escena estamos
        inVictoryScene = SceneManager.GetActiveScene().name == "VictoryScene";
        if (inVictoryScene)
        {
            TriggerVictoryAnimation();
        }
    }

    private void Update()
    {
        if (!inVictoryScene)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        // Dirección del movimiento basada en la cámara
        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        _moveDirection = forward * moveVertical + right * moveHorizontal;

        if (_moveDirection.magnitude > 1)
        {
            _moveDirection.Normalize();
        }

        _animator.SetFloat("PosX", moveHorizontal);
        _animator.SetFloat("PosZ", moveVertical);

        // Rotar suavemente hacia la dirección de movimiento
        if (_moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }

        SetGravity();
        SetJump();
        _player.Move(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void SetGravity()
    {
        if (_player.isGrounded)
        {
            _animator.SetFloat("Jump", 0);
            _fallVelocity = -_gravity * Time.deltaTime;
        }
        else
        {
            _animator.SetFloat("Jump", 1);
            _fallVelocity -= _gravity * Time.deltaTime;
        }
        _moveDirection.y += _fallVelocity * Time.deltaTime; // Asegurarse de que la gravedad afecte constantemente al jugador
    }

    private void SetJump()
    {
        if (Input.GetButtonDown("Jump") && _player.isGrounded) // Verifica si el jugador está en el suelo
        {
            _fallVelocity = _jumpForce;
            _moveDirection.y = _fallVelocity;
            PlayJumpSound();
        }
    }

    private void PlayJumpSound()
    {
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    public void TriggerVictoryAnimation()
    {
        if (_animator != null && AnimatorHasParameter(_animator, "VictoryTrigger"))
        {
            _animator.SetTrigger("VictoryTrigger");
        }
    }

    // Función auxiliar para verificar la existencia de un parámetro en el Animator
    private bool AnimatorHasParameter(Animator animator, string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
            {
                return true;
            }
        }
        return false;
    }
}
