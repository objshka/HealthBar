using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _damageInstance;
    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    private float _health;

    public event Action<float> HealthChanged;

    public float Health => _health;

    private void Start()
    {
        _health = 50;
        HealthChanged?.Invoke(Health);
    }

    public void Heal()
    {
        _health = Math.Clamp(_health += _damageInstance, _minHealth, _maxHealth);
        HealthChanged?.Invoke(Health);
    }

    public void Damage()
    {
        _health = Math.Clamp(_health -= _damageInstance, _minHealth, _maxHealth);
        HealthChanged?.Invoke(Health);
    }
}