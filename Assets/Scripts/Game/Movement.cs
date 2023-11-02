using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Vector2 _mousePos;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _camera;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * (_moveSpeed * Time.fixedDeltaTime));

        Vector2 lookDir = _mousePos - _rigidbody2D.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        _rigidbody2D.rotation = angle;
    }
}