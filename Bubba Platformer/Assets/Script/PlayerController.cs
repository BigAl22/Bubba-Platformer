using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Inspector

    #region Player Inputs
    [Header("Components")]
    private PlayerControls _playerControls;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _uiActions;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    #endregion

    #region Movement
    [Header("Player Movement")]
    [SerializeField, Range(0f, 100f)] private float _speed;
    [SerializeField, Range(0f, 100f)] private float _maxSpeed;
    [SerializeField, Range(0f, 100f)] private float _jump;
    private float _moveX;
    private float _moveTimer = 3f;
    [SerializeField] private float _moveCurrentTimer;
    
    private bool _isJumping;
    private bool _isGrounded;
    #endregion
    /*
    #region Abilities
    private bool _unlockedDoubkeJumping;
    private bool _doubleJumping;
    #endregion
    */
    

    #endregion

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void Update()
    {

        #region Player Inputs
        //Debug.Log("Moving values:" + _move.ReadValue<Vector2>());

        _animator.SetFloat("speed", _moveX);
        #endregion

    }

    private void FixedUpdate()
    {

        _rb.velocity = new Vector2(_speed * _moveX, _rb.velocity.y);
        /*
        if(_moveCurrentTimer <= 0f)
        {
            _moveCurrentTimer = 0f;
            _moveX = 0f;

            if (Mathf.Abs(_rb.velocity.x) > 0)
                _moveCurrentTimer = _moveTimer;
        } else
        {
            _moveCurrentTimer -= Time.deltaTime;
        }
        */
    }

    #region Input Actions Enable/Disable
    private void OnEnable()
    {
        #region Player Inputs
        _moveAction = _playerControls.Player.Movement;
        _moveAction.Enable();
        _jumpAction = _playerControls.Player.Jump;
        _jumpAction.Enable();
        _uiActions = _playerControls.UI.Menu;
        _uiActions.Enable();


        _moveAction.performed += DoMovement;            //Moves from side to side
        _moveAction.canceled += StopMovement;
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
        _animator.SetBool("isMoving", true);

    }

    private void StopMovement(InputAction.CallbackContext obj)
    {
        //_animator.parameters.SetValue(isMovi);
        _moveX = 0f;
        _animator.SetBool("isMoving", false);

    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!");
        _isJumping = true;
        _isGrounded = false;

        _rb.velocity = new Vector2(_rb.velocity.x, _jump * 1);

        //oundCheck();

        //(obj.performed && _isGrounded

    }

    private void GroundCheck()
    {
       
    }   

}