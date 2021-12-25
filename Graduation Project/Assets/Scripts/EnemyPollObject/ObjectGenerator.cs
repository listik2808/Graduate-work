using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : ObjectPoll
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialized(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject prefab))
            {
                _elapsedTime = 0;

                float spawnPointPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPointPositionY, transform.position.z);
                prefab.SetActive(true);
                prefab.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }
}
