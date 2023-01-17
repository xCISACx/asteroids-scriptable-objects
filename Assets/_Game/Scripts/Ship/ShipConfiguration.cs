using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ship
{
    [CreateAssetMenu(fileName = "Ship Configuration", menuName = "ScriptableObjects/Ship Configuration")]
    public class ShipConfiguration : ScriptableObject
    {
        [Header("Engine")]
        [SerializeField] public float ThrottlePower;
        [SerializeField] public float RotationPower;
        [Header("Hull")]
        [SerializeField] public int MaxHealth = 10;
        [Header("Gun")]
        [Range(0.01f,1.0f)][SerializeField] public float GunCooldown = 0.1f;

    }
}