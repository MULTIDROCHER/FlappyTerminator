using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private BirdHealth _birdHealth;
    [SerializeField] private TMP_Text _healthText; 

    private void OnEnable()
    {
        _birdHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _birdHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthText.text = health.ToString();
    }
}