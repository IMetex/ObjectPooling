using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPartical;

    private void OnCollisionEnter(Collision other)
    {
        var effect = Instantiate(_bulletPartical, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
}