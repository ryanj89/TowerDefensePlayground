using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]           // Unity will save and load the values for us.
public class TurretBlueprint    // NOTE: NOT MONOBEHAVIOR
{
    public GameObject prefab;   // Turret prefab
    public int cost;            // Turret cost
}
