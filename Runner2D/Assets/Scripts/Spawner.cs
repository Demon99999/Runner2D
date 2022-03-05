using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefabs; //Массив врагов
    [SerializeField] private Transform[] _spawnPoints; //Массив точек создания врагов
    [SerializeField] private float _timeBetweenSpawn; //Время между созданием врагов

    private float _elapsedTime = 0; //Прошедшее время

    private void Start()
    {
        Initialize(_enemyPrefabs); //Инициализация врагов
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
                int spawnNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnNumber].position);
            }
          
        }
    }

    //Создание врага
    private void SetEnemy(GameObject enemy,Vector3 spawnPoint)
    {
        enemy.SetActive(true); //Сделать врага активным
        enemy.transform.position = spawnPoint; // Поместить врага в точку создания
    }
}
