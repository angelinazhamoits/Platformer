using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _position;

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<Player>().transform;
        }
    }
    
    void Update()
    {
        _position = _player.position;
        _position.z = -10f;
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}
