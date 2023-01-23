using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PowerUpManager : MonoBehaviour
{
    public PowerUpObject PowerUpPrefab;
    public List<PowerUp> PowerUps;
    [SerializeField] private float _timer = 0;
    [SerializeField] private int _timeUntilPowerUpSpawn;
    [SerializeField] [Range(3, 15)] private float _minTime;
    [SerializeField] [Range(3, 15)] private float _maxTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeUntilPowerUpSpawn = Random.Range((int) _minTime, (int) _maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeUntilPowerUpSpawn)
        {
            SpawnRandomPowerUp();
        }
    }

    void SpawnRandomPowerUp()
    {
        Random.InitState(Random.Range(0, Int32.MaxValue));
        var randomNumber = Random.Range(0, PowerUps.Count);
        var randomPosition = new Vector2(Random.Range(-17, 17), Random.Range(-5, 5));
        var newPowerUp = Instantiate(PowerUpPrefab, randomPosition, Quaternion.identity);
        newPowerUp.ChosenPowerUp = PowerUps[randomNumber];
        _timer = 0;
        _timeUntilPowerUpSpawn = Random.Range((int) _minTime, (int) _maxTime);
    }
}
