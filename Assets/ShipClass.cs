using System.Collections;
using System.Collections.Generic;
using Ship;
using UnityEngine;

public class ShipClass : MonoBehaviour
{
    [SerializeField] public ShipConfiguration ShipConfigSO;
    [SerializeField] private Engine EngineScript;
    [SerializeField] private Health HealthScript;
    [SerializeField] private Gun GunScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadConfiguration()
    {
        EngineScript = GetComponent<Engine>();
        HealthScript = GetComponent<Health>();
        GunScript = GetComponentInChildren<Gun>();
        
        EngineScript.ThrottlePower = ShipConfigSO.ThrottlePower;
        EngineScript.RotationPower = ShipConfigSO.RotationPower;
        HealthScript.MaxHealth = ShipConfigSO.MaxHealth;
        GunScript.GunCooldown = ShipConfigSO.GunCooldown;
    }

    /*public void SaveConfiguration()
    {
        ShipConfiguration newConfig = ScriptableObject.CreateInstance<ShipConfiguration>();
    }*/
}
