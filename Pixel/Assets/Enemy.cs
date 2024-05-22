using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private Checker _checker;
    public float _speed = 2f;
    public Transform _groundCheck;
    public Rigidbody2D _rb;
    public LayerMask _groundLayers;
    private bool isFacingLeft;
    private bool _groundChecker;

    private void Start()
    {
        _checker.OnCheck += IsDead;
    }

    private void Update()
    {
        _groundChecker = Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, _groundLayers);

        if (!_groundChecker)
        {
            isFacingLeft = !isFacingLeft;
            Flip();
        }
        MovementChecker();
    }

    private void IsDead()
    {
        _checker.OnCheck -= IsDead;
        Destroy(gameObject);
    }

    private void Flip()
    {
        if (isFacingLeft)
        {
            transform.rotation = new Quaternion(0, 180, 0,0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0,0);
        }
    }

    private void MovementChecker()
    {
        if (isFacingLeft)
        {
            _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }
    }
}

