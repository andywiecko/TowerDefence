using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 60f;
	public GameObject impactEffect;
	public float explosionRadius = 0f;
	public int damage = 50;
	public void Seek(Transform _target)
	{
		target = _target;
	}


	// Update is called once per frame
	void Update () 
	{
		if (target == null)
		{
			Destroy(gameObject);
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}		

		transform.Translate(dir.normalized * distanceThisFrame,Space.World);

		// missle rotation
		transform.LookAt(target);
		


	}

	void HitTarget()
	{
		GameObject effect = (GameObject) Instantiate(impactEffect,transform.position,transform.rotation);
		Destroy(effect,2f); // Destroy after 2 sec

		if (explosionRadius > 0f)
		{
			Explode();
		}

		else
		{
			Damage(target);
		}


		Destroy(gameObject);
	}

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage(Transform enemyToDamage)
	{
		enemy e = enemyToDamage.GetComponent<enemy>();
		if (e != null) e.TakeDamage(damage);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,explosionRadius);
	}

}
