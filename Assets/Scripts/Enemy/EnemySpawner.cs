using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private Enemy[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_prefabs);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnRate)
        {
            if (TryGetObject(out Enemy enemy))
            {
                _elapsedTime = 0;

                int randomPointNumber = Random.Range(0, _spawnPoints.Length);

                SetObject(enemy, _spawnPoints[randomPointNumber].position);
            }
        }
    }

    private void SetObject(Enemy prefab, Vector3 spawnPoint)
    {
        prefab.gameObject.SetActive(true);
        prefab.transform.position = spawnPoint;
    }
}