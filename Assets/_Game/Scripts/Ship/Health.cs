using System;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UIElements.Slider;

namespace Ship
{
    public class Health : MonoBehaviour
    {
        private int _currentHealth = 10;
        [SerializeField] public int MaxHealth = 10;
        
        private const int MIN_HEALTH = 0;

        /*private void OnValidate()
        {
            _maxHealth = (int) HealthSlider.value;
            HealthSlider.value = _maxHealth;
        }*/

        public void TakeDamage(int damage)
        { 
            Debug.Log("Took some damage");
            _currentHealth = Mathf.Max(MIN_HEALTH, _currentHealth - damage);
        }
    }
}
