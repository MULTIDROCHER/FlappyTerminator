using System.Collections;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private Enemy[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        Initialize(_prefabs);
        StartCoroutine(SpawnEnemie());
        _waitForSeconds = new WaitForSeconds(_spawnRate);
    }

    private IEnumerator SpawnEnemie()
    {
        while (true)
        {
            yield return _waitForSeconds;

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