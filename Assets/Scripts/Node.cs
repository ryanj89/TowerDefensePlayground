﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
    public Color cannotPurchaseColor;
    public Vector3 turretPositionOffset;

    [Header("Optional")]
	public GameObject turret;

    private Renderer rend;
    private Color nodeColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        nodeColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetTurretPosition()
    {
        return transform.position + turretPositionOffset;
    }

	void OnMouseEnter()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
		if (!buildManager.CanBuild)
			return;

        if (buildManager.CanPurchase)
        {
			rend.material.color = hoverColor;         
        } else
        {
            rend.material.color = cannotPurchaseColor;
        }
    }

	void OnMouseExit()
	{
		rend.material.color = nodeColor;
	}

	// Clicking a node
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		// If turret is already placed...
		if (turret != null)
		{
			Debug.Log("Turret Already Placed! - TODO: Display Error on Screen");
			return;     // Early return
		}

		buildManager.BuildTurretOnNode(this);
	}

}
