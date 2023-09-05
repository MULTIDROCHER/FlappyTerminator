using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private bool _isReadyToShoot = false;

    public bool ReadyToShoot => _isReadyToShoot;

    public void ChangeAttackStatus(bool readyOrNot)
    {
        _isReadyToShoot = readyOrNot;
    }

    public void Reset(bool deadOrAlive)
    {
        gameObject.SetActive(deadOrAlive);
        ChangeAttackStatus(false);
    }
}