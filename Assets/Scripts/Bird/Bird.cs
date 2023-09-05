using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    
    public event UnityAction Shooting;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _mover.Reset();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shooting?.Invoke();
    }
}