using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	[Header("Bullet Attributes")]

	public float speed = 25f;
	public float damage = 50f;
	public GameObject impactEffect;

	public void Seek(Transform turretTarget)
	{
		target = turretTarget;
	}

	void Update () 
	{
		if (target == null)
		{
			Destroy (gameObject);
			return;
		}

		Vector3 direction = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		//	If the distance the bullet moves this frame 
		//	is greater than the actual distance to the target...
		if (direction.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}

		transform.Translate (direction.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget()
	{
		GameObject particles = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
		Destroy (particles, 2f);

		Damage (target);
	}

	void Damage(Transform _enemy)
	{
		Enemy enemy = _enemy.GetComponent<Enemy> ();
		if (enemy != null) {
			enemy.TakeDamage (damage);
		}
	}
	
}
