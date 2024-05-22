using System;
using UnityEngine;
using AnimationControl;

namespace PlayerSpace
{

    public class Player : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 10f;
        
        [Header("CollisionInfo")] 
        [SerializeField] private Transform _checkTransform;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayerMask; 
        internal bool _isGrounded;
        internal bool _isDoubleGround;
        
        private bool _isMoving;
        private bool _isFlip = true;
        
        
        private Rigidbody2D _rb;

        private MovementController _movementController;

        private Animator _animator;

        void Start()
        {
            _movementController = GetComponent<MovementController>();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
        
        void Update()
        {
            _isMoving = _rb.velocity.x != 0;
            _animator.SetBool("isMove", _isMoving);
            _animator.SetBool("isGrounded", _isGrounded);
            _animator.SetFloat("velocityY", _rb.velocity.y);
            Flip();
            CollisionCheck();
        }
        
        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_movementController._moveInput * _speed, _rb.velocity.y);
        }
        
        private void CollisionCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(_checkTransform.position, _groundCheckRadius, _groundLayerMask);
            if (_isGrounded)
            {
                _isDoubleGround = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkTransform.position, _groundCheckRadius);
        }

        internal void Jump()
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
            else
            {
                if (_isDoubleGround)
                {
                    _isDoubleGround = false;
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                }
            }
        }

        private void Flip()
        {
            if ((_movementController._moveInput > 0 && !_isFlip) || (_movementController._moveInput < 0 && _isFlip))
            {
                _isFlip = !_isFlip;
                transform.Rotate(0, 180, 0);
            }
        }
    }
}