using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputSettings;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;
    private PlayerInput _playerInput;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    Coroutine MovementRoutine { get; set; }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Move"].ReadValue<Vector2>();
    }


    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.started += StopMove;
    }

    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.started -= StopMove;
    }

    private void StartMove(InputAction.CallbackContext context)
    {
        OnStartMove?.Invoke();
    }
    private void UpdateMove(InputAction.CallbackContext context)
    {

    }
    private void StopMove(InputAction.CallbackContext context)
    {

    }
}
