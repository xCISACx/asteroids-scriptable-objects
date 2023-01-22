using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ship;
using UnityEditor;
using UnityEngine;
using Variables;

public class ShipClass : MonoBehaviour
{
    [SerializeField] public ShipConfiguration ShipConfigSO;
    [SerializeField] public Engine EngineScript;
    public float EngineThrottlePower;
    public float EngineRotationPower;
    [SerializeField] public Health HealthScript;
    [SerializeField] public Hull HullScript;
    public int MaxHealth;
    [SerializeField] public Gun GunScript;
    public float GunCooldown;
    public string SavePath = "Assets/_Game/Scripts/Ship";
    public string FileName = "NewShipConfig.asset";
    
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
        HullScript = GetComponent<Hull>();
        GunScript = GetComponentInChildren<Gun>();

        EngineScript.ThrottlePower = ShipConfigSO.ThrottlePower;
        EngineScript.RotationPower = ShipConfigSO.RotationPower;

        Debug.Log("new health: " + HullScript._healthRef._intVariable.Value);

        HullScript._healthObservable.StartValue = ShipConfigSO.MaxHealth;

        EditorUtility.SetDirty(HullScript._healthRef._intVariable);
        EditorUtility.SetDirty(HullScript._healthObservable);

        GunScript.GunCooldown = ShipConfigSO.GunCooldown;
    }

    public void SaveConfiguration()
    {
        ShipConfiguration newConfig = ScriptableObject.CreateInstance<ShipConfiguration>();
        newConfig.ThrottlePower = EngineThrottlePower;
        newConfig.RotationPower = EngineRotationPower;
        newConfig.MaxHealth = MaxHealth;
        newConfig.GunCooldown = GunCooldown;
        AssetDatabase.CreateAsset(newConfig, SavePath + FileName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newConfig;
    }
}
