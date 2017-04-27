using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour 
{
	private Transform target;				// Current target

	[Header("Turret Attributes")]

	public float range = 15f;				// Turret range
	public float fireRate = 1f;
	private float rechargeTimer = 0f;

	[Header("Unity Fields")]

	public Transform rotationPoint;			// Turret rotation point
	public float rotationSpeed = 10f;		// Turret rotation speed
	public string enemyTag = "Enemy";		

	public GameObject bulletPrefab;
	public Transform firePoint;			// Position/Rotation of bullet fire point


	void Start () 
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject closestEnemy = null;

		// Search all objects marked enemy
		foreach (GameObject enemy in enemies)
		{
			// Find closest one
			float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

			if (enemyDistance < shortestDistance)
			{
				shortestDistance = enemyDistance;
				closestEnemy = enemy;
			}
		}
		// Check if within range
		if (closestEnemy != null && shortestDistance <= range)
		{
			target = closestEnemy.transform;
		} else {
			target = null;
		}
	}


	void Update () 
	{
		// If no target, do nothing
		if (target == null) return;

		// Get direction of target
		Vector3 direction = target.position - transform.position;

		// Get rotation to target
		Quaternion lookRotation = Quaternion.LookRotation(direction);

		// Smooth the rotation
		Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;

		// Rotate turret on y-axis toward target
		rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (rechargeTimer <= 0f)
		{
			Shoot ();
			rechargeTimer = fireRate;
		}

		rechargeTimer -= Time.deltaTime;
	}

	void Shoot()
	{	
		//Instantiate a bullet GameObject
		GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bulletGO != null)
			bullet.Seek (target);
	}


	/// Callback to draw gizmos only if the object is selected.
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, range);
	}
}
