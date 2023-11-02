using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPartical;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var effect = Instantiate(_bulletPartical, transform.position, Quaternion.identity);
        
        gameObject.SetActive(false);
        Destroy(effect, 1f);
    }
}