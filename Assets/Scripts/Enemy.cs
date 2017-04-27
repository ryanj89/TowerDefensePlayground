using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public float startingHealth = 100f;
	public float speed = 10f;

	public float health;
	private Transform nextWaypoint;
	private int waypointIndex = 0;

	void Start()
	{
		health = startingHealth;
		nextWaypoint = Waypoints.waypoints[0];
	}


	void Update()
	{
		// Get direction toward waypoint
		Vector3 direction = nextWaypoint.position - transform.position;

		// Move toward direction at the normalized 'speed'
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, nextWaypoint.position)<= 0.2f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (waypointIndex >= Waypoints.waypoints.Length - 1)
		{
			Destroy(gameObject);
			return;
		} else
		{
			waypointIndex++;
			nextWaypoint = Waypoints.waypoints[waypointIndex];
		}
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0f) {
			Destroy (gameObject);
		}
	}
}
