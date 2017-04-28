using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Blueprints
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeam;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectTurret();
        }
		if (Input.GetKeyDown(KeyCode.E))
		{
			SelectMissileLauncher();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			SelectLaserBeam();
		}
    }

    public void SelectTurret()
	{
		Debug.Log("Turret Selected");
        buildManager.SelectTurret(standardTurret);
	}

    public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurret(missileLauncher);
	}

	public void SelectLaserBeam()
	{
		Debug.Log("Laser Beam Selected");
		buildManager.SelectTurret(laserBeam);
	}
}
