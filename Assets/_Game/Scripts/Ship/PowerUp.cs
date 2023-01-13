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

    //public Slider HealthSlider;
    [Range(0, 100)] public int HullHealthChange;
    [Range(0, 5)] public float GunCooldownChange;
    [Range(0, 10)] public float ThrottleChange;
    [Range(0, 10)] public float RotationChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }
}
