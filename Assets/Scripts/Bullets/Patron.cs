using System.Collections;
using UnityEngine;

public class Patron : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private float _delay = 3f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out BirdHealth bird))
        {
            bird.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }
}