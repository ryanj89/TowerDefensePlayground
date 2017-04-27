using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 turretPositionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color nodeColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        nodeColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    // Clicking a node
    void OnMouseDown()
    {
        if (buildManager.GetSelectedTurret() == null || EventSystem.current.IsPointerOverGameObject())
            return;
        
        // If turret is already placed...
        if (turret != null)
            {
                Debug.Log("Turret Already Placed! - TODO: Display Error on Screen");
                return;     // Early return
            }

        // ...else, build turret
		// Get selectedTurret from BuildManager instance
		// Instantiate turret
        GameObject selectedTurret = buildManager.GetSelectedTurret();
        turret = (GameObject)Instantiate(selectedTurret, transform.position + turretPositionOffset, transform.rotation);
    }

	void OnMouseEnter()
	{
        if (buildManager.GetSelectedTurret() == null || EventSystem.current.IsPointerOverGameObject())
            return;

		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = nodeColor;
	}
}
