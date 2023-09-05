using UnityEngine;

public class BirdBullet : Patron
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}