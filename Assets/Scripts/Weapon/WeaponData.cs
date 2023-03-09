using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public int WeaponID = 0;
    public float AttackCooldown = 0.5f;
    public float TimeForReload = 1f;
    public bool isUnlocked;
}
