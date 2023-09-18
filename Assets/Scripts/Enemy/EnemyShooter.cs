using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Patron _patron;
    [SerializeField] private Transform _shootPoint;

    private Enemy _enemy;
    private WaitForSeconds _waitForSeconds;
    private float _shootRate = 2f;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _waitForSeconds = new WaitForSeconds(_shootRate);
    }

    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }

    private void OnDisable()
    {
        StopCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        yield return _waitForSeconds;

        if (_enemy.ReadyToShoot)
            Attack();
    }

    private void Attack()
    {
        Patron patron = Instantiate(_patron, _shootPoint);
        patron.SetDirection(Vector3.left);
    }
}