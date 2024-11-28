using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController _player;
    private float _moveSpeed;
    private Vector3 _moveAxis;
    private Vector3 _camForward, _camRight, _moveDir;
    private Camera _camera;

    [SerializeField] private float _gravity = 60f;  // Usar SerializeField correctamente
    private float _fallVelocity;
    [SerializeField] private float _jumpForce = 15f;  // Usar SerializeField correctamente

    private Animator _animator;

    void Awake()
    {
        _player = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _moveSpeed = 20f;
        _camera = Camera.main;
    }

    private void Update()
    {
        _moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _animator.SetFloat("PosX", _moveAxis.x); // Corregir asignación incorrecta
        _animator.SetFloat("PosZ", _moveAxis.z);

        if (_moveAxis.magnitude > 1)
        {
            _moveAxis = _moveAxis.normalized * _moveSpeed;
        }
        else
        {
            _moveAxis = _moveAxis * _moveSpeed;
        }

        CameraDirection();
        _moveDir = _moveAxis.x * _camRight + _moveAxis.z * _camForward;

        if (_moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveDir);  // Usar Quaternion para rotación suave
        }

        SetGravity();
        SetJump();
        _player.Move(_moveDir * Time.deltaTime);
    }

    private void CameraDirection()
    {
        _camForward = _camera.transform.forward;
        _camRight = _camera.transform.right;
        _camForward.y = 0;
        _camRight.y = 0;
        _camForward = _camForward.normalized;
        _camRight = _camRight.normalized;
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
        _moveDir.y = _fallVelocity;
    }

    private void SetJump()
    {
        if (Input.GetButtonDown("Jump") && _player.isGrounded)  // Verifica si el jugador está en el suelo
        {
            _fallVelocity = _jumpForce;
            _moveDir.y = _fallVelocity;
        }
    }
}
