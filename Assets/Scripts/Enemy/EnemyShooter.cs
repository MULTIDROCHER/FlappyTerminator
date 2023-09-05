using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Patron _patron;
    [SerializeField] private Transform _shootPoint;

    private Enemy _enemy;
    private float _elapsedTime;
    private float _shootRage = 2f;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _shootRage && _enemy.ReadyToShoot)
        {
            _elapsedTime = 0;
            Attack();
            _enemy.ChangeAttackStatus(false);
        }
    }

    private void Attack()
    {
        Patron patron = Instantiate(_patron, _shootPoint);
        patron.SetDirection(Vector3.left);
    }
}