using UnityEngine;
using UnityEngine.Events;

public class BirdHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction GameOver;

    public int Health => _health;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(Health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(Health);

        if (_health <= 0)
            GameOver?.Invoke();
    }
}