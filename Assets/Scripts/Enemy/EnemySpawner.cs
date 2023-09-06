using System.Collections;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private Enemy[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private void Start()
    {
        Initialize(_prefabs);
        StartCoroutine(SpawnEnemie());
    }

    private IEnumerator SpawnEnemie()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);

            if (TryGetObject(out Enemy enemy))
            {
                int randomPointNumber = Random.Range(0, _spawnPoints.Length);
                SetObject(enemy, _spawnPoints[randomPointNumber].position);
            }
        }
    }

    private void SetObject(Enemy prefab, Vector3 spawnPoint)
    {
        prefab.transform.position = spawnPoint;
        prefab.Reset(true);
    }
}