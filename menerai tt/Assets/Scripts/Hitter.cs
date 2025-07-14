using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private GameObject _body;
    [SerializeField] private Collider _collider;
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        ParticleSystem particle = other.gameObject.GetComponent<ParticleSystem>();
        particle.Play();
        TakeDamage(_damage);
    }

    private void TakeDamage(int damage)
    {
        _audioSource.Play();
        Debug.Log(_health);
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _audioSource.clip = _deathSound;
        _audioSource.Play();
        _particleSystem.Play();
        _collider.enabled = false;
        Destroy(_body);
    }
}
