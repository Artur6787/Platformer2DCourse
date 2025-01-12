using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public bool IsGrounded => _isGrounded;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2d;
    private AnimationHandler _animationHandler;
    private SpriteRenderer _sprite;
    private int _facingDirection = 1;
    private InputHandler _inputHandler;
    private Vector2 _currentMoveInput;
    private bool _jumpRequested;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animationHandler = GetComponent<AnimationHandler>();
        _sprite = GetComponent<SpriteRenderer>();
        _inputHandler = GetComponent<InputHandler>();
    }

    private void OnEnable()
    {
        _inputHandler.OnMoveInput += HandleMoveInput;
        _inputHandler.OnJumpInput += HandleJumpInput;
    }

    private void OnDisable()
    {
        _inputHandler.OnMoveInput -= HandleMoveInput;
        _inputHandler.OnJumpInput -= HandleJumpInput;
    }

    private void HandleMoveInput(Vector2 moveInput)
    {
        _currentMoveInput = moveInput;
    }

    private void HandleJumpInput()
    {
        if (_isGrounded)
        {
            _jumpRequested = true;
        }
    }

    private void Update()
    {
        Reflect();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody2d.velocity = new Vector2(_currentMoveInput.x * _speed, _rigidbody2d.velocity.y);
    }

    private void Reflect()
    {
        if (_currentMoveInput.x > 0)
        {
            _sprite.flipX = false;
            _facingDirection = 1;
        }
        else if (_currentMoveInput.x < 0)
        {
            _sprite.flipX = true;
            _facingDirection = -1;
        }
    }

    private void Jump()
    {
        if (_jumpRequested)
        {
            _rigidbody2d.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            SetGroundedState(false);
            _jumpRequested = false;
        }
    }

    private void UpdateAnimation()
    {
        bool isJumping = !_isGrounded;
        bool isRunning = _currentMoveInput.x != 0;

        _animationHandler.UpdateAnimation(isJumping, isRunning);
    }

    public void SetGroundedState(bool state)
    {
        _isGrounded = state;
    }
}