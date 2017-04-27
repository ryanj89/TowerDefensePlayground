using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	[Header("Bullet Attributes")]

	public float speed = 25f;
	public float damage = 50f;
    public float explosionRadius = 0;
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

        // Move and rotate towards target
		transform.Translate (direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

	void HitTarget()
	{
		GameObject particles = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy (particles, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy (gameObject);   // Destroy projectile
	}

    // Retrieve all colliders in explosion radius, check for enemies, and damage
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Enemy"))
            {
				Damage(c.transform);
			}
        }
    }

	void Damage(Transform enemy)
	{
        Destroy(enemy.gameObject);
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
	
}
