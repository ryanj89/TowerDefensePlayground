using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	private TurretBlueprint selectedTurret;          // Selected turret to build

	// Reference for if a turret is selected
	public bool CanBuild { get { return selectedTurret != null; }}
    public bool CanPurchase { get { return PlayerStats.Currency >= selectedTurret.cost; }}

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

    public void BuildTurretOnNode(Node node)
    {
        if (PlayerStats.Currency < selectedTurret.cost)
        {
            Debug.Log("Not enough money to puchase turret.");
            return;
        }

        PlayerStats.Currency -= selectedTurret.cost;

        GameObject turret = (GameObject)Instantiate(selectedTurret.prefab, node.GetTurretPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Purchased! Money: " + PlayerStats.Currency);
    }

    public void SelectTurret(TurretBlueprint turret)
    {
        selectedTurret = turret;
    }
}
