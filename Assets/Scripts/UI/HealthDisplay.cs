using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _healthText; 

    private void OnEnable()
    {
        _bird.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _bird.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthText.text = health.ToString();
    }
}