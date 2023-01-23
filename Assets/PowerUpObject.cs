using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    public PowerUp ChosenPowerUp;
    [SerializeField] private float _aliveTime;
    [SerializeField] private float _despawnTime;

    private void Update()
    {
        _aliveTime += Time.deltaTime;

        if (_aliveTime > _despawnTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("a");
        if (other.gameObject.CompareTag("Player"))
        {
            ChosenPowerUp.ApplyEffect(other.GetComponent<ShipClass>());
            Debug.Log("player player player");
            Destroy(gameObject);
        }
    }
}
