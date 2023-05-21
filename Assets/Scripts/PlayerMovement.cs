using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private Animator _anim;
    private SpriteRenderer _sprite;

    private float _dirX = 0f;

    [SerializeField] private LayerMask _jumpGround;
    [SerializeField] private float _jumpForce = 13f;
    [SerializeField] private float _moveForce = 7f;

    private enum MovementState { idle, runn, jump, fall }

    [SerializeField] private AudioSource _jumpSoundEffect;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_dirX * _moveForce, _rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _jumpSoundEffect.Play();
        }

        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        MovementState state;

        if (_dirX > 0f)
        {
            state = MovementState.runn;
            _sprite.flipX = false;
        }
        else if (_dirX < 0f)
        {
            state = MovementState.runn;
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (_rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (_rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

            _anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, 0.1f, _jumpGround);
    }
}
