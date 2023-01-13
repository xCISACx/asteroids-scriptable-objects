using System;
using UnityEngine;

namespace Ship
{
    public class Gun : ShipPart
    {
        [SerializeField] private Laser _laserPrefab;
        [Range(0.01f,1.0f)][SerializeField] private float _gunCooldown = 0.1f;
        [SerializeField] private float _timeSinceLastShot;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

            if (_timeSinceLastShot < _gunCooldown)
            {
                _timeSinceLastShot += Time.deltaTime;
            }
        }
        
        private void Shoot()
        {
            if (_timeSinceLastShot < _gunCooldown) return;

            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
            _timeSinceLastShot = 0;
        }
    }
}
