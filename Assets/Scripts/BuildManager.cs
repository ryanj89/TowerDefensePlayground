using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	private GameObject selectedTurret;  // Selected turret to build

    public GameObject turretPrefab;     // Turret prefab

    // SINGLETON PATTERN
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("WARNING: ANOTHER INSTANCE OF GAME MANAGER ALREADY EXISTS");
            return;
        }
        instance = this;    // Reference to self
    }

    void Start()
    {
        selectedTurret = turretPrefab;
    }

    // Public function to return selected turret
    public GameObject GetSelectedTurret()
    {
        return selectedTurret;
    }
}
