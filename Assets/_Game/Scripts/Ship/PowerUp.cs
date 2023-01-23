using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Power-Up", menuName = "ScriptableObjects/Power-Up")]
public class PowerUp : ScriptableObject
{
    public VisualTreeAsset m_UXML;
    public enum PartType
    {
        None,
        Hull,
        Gun,
        Engine
    }

    public PartType type;
    
    [Range(0, 100)] public int HullHealthChange;
    [Range(0, 5)] public float GunCooldownChange;
    [Range(0, 10)] public float ThrottleChange;
    [Range(0, 10)] public float RotationChange;

    public void ApplyEffect(ShipClass ship)
    {
        switch (type)
        {
            case PartType.Hull:
                ship.HullScript._healthObservable.ApplyChange(HullHealthChange);
                break;
            
            case PartType.Gun:
                ship.GunScript.GunCooldown -= GunCooldownChange;
                FindObjectOfType<UI.UI>().OnCooldownChanged(ship.GunScript.GunCooldown);
                break;
            
            case PartType.Engine:
                ship.EngineScript.ThrottlePower += ThrottleChange;
                ship.EngineScript.RotationPower += RotationChange;
                FindObjectOfType<UI.UI>().OnEngineChanged(ship.EngineScript.ThrottlePower, ship.EngineScript.RotationPower);
                break;
        }
    }
}
