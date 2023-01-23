using System;
using DefaultNamespace.ScriptableEvents;
using TMPro;
using UnityEngine;
using Variables;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [Header("Health:")]
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private ScriptableEventIntReference _onHealthChangedEvent;
        
        [Header("Stats")]
        [SerializeField] private TextMeshProUGUI _throttleText;
        [SerializeField] private TextMeshProUGUI _rotationText;
        [SerializeField] private TextMeshProUGUI _cooldownText;
        
        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;
        
        private void Start()
        {
            //SetHealthText($"Health: {_healthVar.Value}");
            SetText(_healthText, "Health: " + _healthVar.Value);
            SetText(_throttleText, "Throttle: " + FindObjectOfType<ShipClass>().EngineScript.ThrottlePower);
            SetText(_rotationText, "Rotation: " + FindObjectOfType<ShipClass>().EngineScript.RotationPower);
            SetText(_cooldownText, "Gun Cooldown: " + FindObjectOfType<ShipClass>().GunScript.GunCooldown);
            SetText(_scoreText, "Asteroids Destroyed: 0");
        }

        public void OnHealthChanged(IntReference newValue)
        {
            //SetHealthText($"Health: {newValue.GetValue()}");
            SetText(_healthText, "Health: " + newValue.GetValue());
        }

        public void OnEngineChanged(float newThrottleValue, float newRotationValue)
        {
            SetText(_throttleText, "Throttle: " + newThrottleValue);
            SetText(_rotationText, "Rotation: " + newRotationValue);
        }
        
        public void OnCooldownChanged(float newValue)
        {
            SetText(_cooldownText, "Gun Cooldown: " + newValue.ToString("F2"));
        }

        private void SetText(TextMeshProUGUI textObject, string text)
        {
            textObject.text = text;
        }
        
        // unnecessary due to the new SetText function

        /*private void SetHealthText(string text)
        {
            _healthText.text = text;
        }
        
        private void SetScoreText(string text)
        {
            _scoreText.text = text;
        }
        
        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }
        
        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }*/
    }
}
