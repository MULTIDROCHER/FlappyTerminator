using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<Enemy> _pool = new List<Enemy>();
    
    public Transform Container => _container;

    public void ResetPool()
    {
        foreach (var enemy in _pool)
        {
            enemy.ResetEnemy();
        }
    }

    protected void Initialize(Enemy[] prefabs)
    {

        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            Enemy spawned = Instantiate(prefabs[randomIndex], _container);
            spawned.ResetEnemy();
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy result)
    {
        result = _pool.FirstOrDefault(enemy => enemy.gameObject.activeSelf == false);

        return result != null;
    }
}