using System;
using UnityEngine;

namespace Ship
{
    public class Gun : ShipPart
    {
        [SerializeField] private Laser _laserPrefab;
        [Range(0.01f,1.0f)][SerializeField] public float GunCooldown = 0.1f;
        [SerializeField] private float _timeSinceLastShot;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

            if (_timeSinceLastShot < GunCooldown)
            {
                _timeSinceLastShot += Time.deltaTime;
            }
        }
        
        private void Shoot()
        {
            if (_timeSinceLastShot < GunCooldown) return;

            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
            _timeSinceLastShot = 0;
        }
    }
}
