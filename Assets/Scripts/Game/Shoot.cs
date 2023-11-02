using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPoint;
    
    [SerializeField] private float _bulletForce;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    
    private void Fire()
    {
        GameObject bullet  = Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(_bulletPoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}