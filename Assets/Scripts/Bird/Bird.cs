using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private BirdMover _mover;
    private int _score;
    private int _health;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;
    public event UnityAction GameOver;
    public event UnityAction Shooting;

    public int Score => _score;
    public int Health => _health;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        ResetPlayer();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shooting?.Invoke();
    }

    public void ResetPlayer()
    {
        _score = 0;
        _health = _maxHealth;

        HealthChanged?.Invoke(Health);
        ScoreChanged?.Invoke(Score);
        
        _mover.ResetBird();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void AddScorePoint(int reward)
    {
        _score += reward;
        ScoreChanged?.Invoke(Score);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }
}