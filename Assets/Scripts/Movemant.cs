using UnityEngine;

public class Movemant : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public bool isGrounded;
    private Rigidbody2D _rigidbody2d;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private int _facingDirection = 1;
    private Vector2 moveVector;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Reflect();
        Jump();
        UpdateAnimation();
    }

    private void Move()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        _rigidbody2d.velocity = new Vector2(moveVector.x * _speed, _rigidbody2d.velocity.y);
    }

    private void Reflect()
    {
        if (moveVector.x > 0)
        {
            _sprite.flipX = false;
            _facingDirection = 1;
        }

        else if (moveVector.x < 0)
        {
            _sprite.flipX = true;
            _facingDirection = -1;
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2d.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void UpdateAnimation()
    {
        if (!isGrounded)
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isJumping", false);

            if (moveVector.x != 0)
            {
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }
    }
}