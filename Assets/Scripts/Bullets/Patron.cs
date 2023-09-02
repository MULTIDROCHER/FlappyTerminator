using UnityEngine;

public class Patron : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private float _delay = 3f;

    private void Start()
    {
        Destroy(gameObject, _delay);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bird bird))
        {
            bird.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }
}