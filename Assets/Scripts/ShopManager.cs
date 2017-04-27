using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Blueprints
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectTurret();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectMissileLauncher();
        }
    }

	public void selectTurret()
	{
		Debug.Log("Turret Selected");
        buildManager.SelectTurret(standardTurret);
	}

	public void selectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurret(missileLauncher);
	}
}
