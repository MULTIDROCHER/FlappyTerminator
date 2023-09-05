using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _reward;

    private BirdScore _birdScore;
    private Enemy _enemy;
    private int _health;

    private void Awake() {
        _enemy = GetComponent<Enemy>();
        _birdScore = FindObjectOfType<BirdScore>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _birdScore.AddScorePoint(_reward);
        _enemy.Reset(false);
        _health = _maxHealth;
    }
}