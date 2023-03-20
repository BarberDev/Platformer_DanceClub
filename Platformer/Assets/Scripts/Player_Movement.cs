using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private float _speed = 3;
    private float _jumpForce = 1000;

    private bool _isGroundet = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Jump();
        if (_isGroundet != true)
        {
            IsInAir();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _animator.SetBool("isRuning", true);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -_speed * Time.deltaTime);
            _animator.SetBool("isRuning", true);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _animator.SetBool("isRuning", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isGroundet == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime);
        }
    }

    private void IsInAir()
    {
        float velocitySpeedY = _rigidbody.velocity.y;
        _animator.SetFloat("Velocity", velocitySpeedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGroundet = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGroundet = false;
        }
    }
}
