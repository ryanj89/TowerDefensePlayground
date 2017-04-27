using UnityEngine;

public class ShopManager : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void selectTurret()
	{
		Debug.Log("Turret Selected");
        buildManager.SetSelectedTurret(buildManager.turretPrefab);
	}

	public void selectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
        buildManager.SetSelectedTurret(buildManager.missileLauncherPrefab);
	}
}
