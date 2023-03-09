using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/BaseData")]
public class D_Entity : ScriptableObject
{
    public float minAgroDistance = 3f;
    public int maxHealth = 100;
}
