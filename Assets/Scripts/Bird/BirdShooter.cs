using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Patron _patron;
    [SerializeField] private Bird _bird;
    [SerializeField] private Transform _shootPoint;

    private void OnEnable()
    {
        _bird.Shooting += OnShooting;
    }

    private void OnDisable()
    {
        _bird.Shooting -= OnShooting;
    }

    private void OnShooting()
    {
        Patron patron = Instantiate(_patron,_shootPoint.position, _shootPoint.rotation);
        patron.SetDirection(_shootPoint.transform.right);
    }
}