using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    private float _minHealth = 0f;
    private float _health;

    public event Action<float> HealthChanged;

    public float Health => _health;

    private void Start()
    {
        _health = _currentHealth;
        HealthChanged?.Invoke(Health);
    }

    public void Heal(int damageInstance)
    {
        _health = Math.Clamp(_health + damageInstance, _minHealth, _maxHealth);
        HealthChanged?.Invoke(Health);
    }

    public void Damage(int damageInstance)
    {
        _health = Math.Clamp(_health - damageInstance, _minHealth, _maxHealth);
        HealthChanged?.Invoke(Health);
    }
}