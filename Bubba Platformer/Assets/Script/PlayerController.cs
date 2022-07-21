using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Inspector

    #region Movement
    [Header("Player Movement")]
    [SerializeField, Range(0f, 100f)] private float _speed;
    [SerializeField, Range(0f, 100f)] private float _maxSpeed;
    [SerializeField, Range(0f, 100f)] private float _jump;
    
    private bool _isJumping;
    private bool _isGrounded;
    #endregion

    #region Abilities
    private bool _unlockedDoubkeJumping;
    private bool _doubleJumping;
    #endregion

    #region Player Inputs
    private InputAction _action;
    private InputAction _move;
    private PlayerControls _playerControls;
    private Rigidbody2D _rigidbody2D;
    #endregion

    #endregion

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void Update()
    {

        #region Player Inputs
        Debug.Log("Moving values:" + _move.ReadValue<Vector2>());
        #endregion

    }
    private void DoMovement(InputAction.CallbackContext obj)
    {
        float moveX = _move.ReadValue<Vector2>().x;
        _rigidbody2D.velocity = new Vector2(_speed * moveX, _rigidbody2D.velocity.y);
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!");
    }

    private void DoLanded(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }



    private void OnEnable()
    {
        #region Player Inputs
        _move = _playerControls.Player.Movement;
        _action.Enable();
        _move.Enable();
        var _player = _playerControls.Player;

        _player.Movement.Enable();                   //Enables movement action from side to side - Vector2
        _player.Movement.performed += DoMovement;    //Moves from side to side

        _player.Jump.Enable();                       //Enables jumping action from side to side - Double
        _player.Jump.performed += DoJump;            //Does a jump
        _player.Jump.canceled += DoLanded;           //Lands from a jump
        #endregion
    }

    private void OnDisable()
    {
        _action.Disable();
        _move.Disable();
        _playerControls.Disable();
    }

}