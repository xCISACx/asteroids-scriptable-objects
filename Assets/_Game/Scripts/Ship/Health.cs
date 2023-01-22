using System;
using UnityEngine;
using UnityEngine.UIElements;
using Variables;
using Slider = UnityEngine.UIElements.Slider;

namespace Ship
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _currentHealth;

        private const int MIN_HEALTH = 0;

        /*private void OnValidate()
        {
            _maxHealth = (int) HealthSlider.value;
            HealthSlider.value = _maxHealth;
        }*/

        /*public void TakeDamage(int damage)
        { 
            Debug.Log("Took some damage");
            _currentHealth = (Mathf.Max(MIN_HEALTH, _currentHealth - damage));
        }*/
    }
}
