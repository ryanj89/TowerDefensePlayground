using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	private GameObject selectedTurret;          // Selected turret to build

    public GameObject turretPrefab;             // Turret prefab
    public GameObject missileLauncherPrefab;    // Missile Launcher prefab

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


    // Public function to return selected turret
    public GameObject GetSelectedTurret()
    {
        return selectedTurret;
    }

    public void SetSelectedTurret(GameObject turret)
    {
        selectedTurret = turret;
    }
}
