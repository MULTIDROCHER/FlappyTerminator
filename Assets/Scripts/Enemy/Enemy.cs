using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _shootRage;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Patron _patron;

    private Bird _player;
    private EnemyMover _mover;
    private float _elapsedTime;
    private bool _isReadyToShoot = false;

    private void Awake()
    {
        _player = FindObjectOfType<Bird>();
        _mover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _shootRage && _isReadyToShoot)
        {
            _elapsedTime = 0;
            Attack();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void ChangeAttackStatus(bool readyOrNot)
    {
        _isReadyToShoot = readyOrNot;
    }

    public void ResetEnemy()
    {
        ChangeAttackStatus(false);
        gameObject.SetActive(false);
        _mover.enabled = true;
    }

    private void Die()
    {
        _player.AddScorePoint(_reward);
        ResetEnemy();
    }

    private void Attack()
    {
        Patron patron = Instantiate(_patron, _shootPoint);
        patron.SetDirection(Vector3.left);
    }
}