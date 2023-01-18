using UnityEditor.VersionControl;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : ShipPart
    {
        [SerializeField] public ShipClass Ship;
        [SerializeField] public float ThrottlePower = 3;
        [SerializeField] public float RotationPower = 6;
        
        //[SerializeField] private float _throttlePowerSimple;
        //[SerializeField] private float _rotationPowerSimple;

        private Rigidbody2D _rigidbody;
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Ship = GetComponent<ShipClass>();
            LoadConfiguration();

        }
    
        public void Throttle()
        {
            _rigidbody.AddForce(transform.up * ThrottlePower, ForceMode2D.Force);
        }

        public void SteerLeft()
        {
            _rigidbody.AddTorque(RotationPower, ForceMode2D.Force);
        }

        public void SteerRight()
        {
            _rigidbody.AddTorque(-RotationPower, ForceMode2D.Force);
        }

        public void LoadConfiguration()
        {
            ThrottlePower = Ship.ShipConfigSO.ThrottlePower;
            RotationPower = Ship.ShipConfigSO.RotationPower;
        }
    }
}
