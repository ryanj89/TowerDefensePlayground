using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 turretPositionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color nodeColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        nodeColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = nodeColor;
    }

    // Clicking a node
    void OnMouseDown()
    {
        // If turret is already placed...
        if (turret != null)
		{   
            Debug.Log("Turret Already Placed! - TODO: Display Error on Screen");
            return;     // Early return
		}

        // ...else, build turret
		// Get selectedTurret from BuildManager instance
		// Instantiate turret
        GameObject selectedTurret = BuildManager.instance.GetSelectedTurret();
        turret = (GameObject)Instantiate(selectedTurret, transform.position + turretPositionOffset, transform.rotation);
    }
}
