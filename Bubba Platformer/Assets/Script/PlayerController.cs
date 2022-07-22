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
    private float _moveX;
    
    private bool _isJumping;
    private bool _isGrounded;
    #endregion
    /*
    #region Abilities
    private bool _unlockedDoubkeJumping;
    private bool _doubleJumping;
    #endregion
    */
    #region Player Inputs
    private PlayerControls _playerControls;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _uiActions;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    #endregion

    #endregion

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void Update()
    {

        #region Player Inputs
        //Debug.Log("Moving values:" + _move.ReadValue<Vector2>());
        #endregion

    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_speed * _moveX, _rigidbody2D.velocity.y);
    }

    #region Input Actions Enable/Disable
    private void OnEnable()
    {
        #region Player Inputs
        _moveAction = _playerControls.Player.Movement;  //Assigns 
        _moveAction.Enable();                           //
        _jumpAction = _playerControls.Player.Jump;      //
        _jumpAction.Enable();                           //
        _uiActions = _playerControls.UI.Menu;
        _uiActions.Enable();


        _moveAction.performed += DoMovement;            //Moves from side to side
        _moveAction.Enable();                           //Enables movement action from side to side - Vector2

        _jumpAction.performed += DoJump;                //Does a jump
        _jumpAction.Enable();                           //Enables jumping action from side to side - Double
        #endregion
    }

    private void OnDisable()
    {
        _moveAction.Disable();                          //
        _jumpAction.Disable();                          //
        _playerControls.Disable();                      //
        _uiActions.Disable();
    }
    #endregion


    private void DoMovement(InputAction.CallbackContext obj)
    {
        /*
        float moveX = _moveAction.ReadValue<Vector2>().x;
        _rigidbody2D.velocity = new Vector2(_speed * moveX, _rigidbody2D.velocity.y);
        */
        _moveX = obj.ReadValue<Vector2>().x;

    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!");
        _isJumping = true;
        _isGrounded = false;

        //oundCheck();

        //(obj.performed && _isGrounded

    }

    private void GroundCheck()
    {
       
    }   

}