using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private EnemyMover _mover;
    private Enemy _enemy;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyStopLine>() != null)
        {
            _mover.enabled = false;
            _enemy.ChangeAttackStatus(true);
        }
    }
}