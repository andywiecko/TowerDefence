using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

	private Transform target;


	[Header("General")]
	public float range = 10f;

	[Header("Use Bullets(default)")]
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPrefab;

	[Header("Use Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;

	[Header("Setup")]
	public string enemyTag = "enemy";
	public float rotspeed = 10f;
	public Transform partToRotate;
	public Transform firePoint;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("UpdateTarget",0f,0.5f);
	}
	
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortest_dist = Mathf.Infinity;
		GameObject nearest_enemy = null;		
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(enemy.transform.position,transform.position);
			if (distanceToEnemy < shortest_dist)
			{
				nearest_enemy = enemy;
				shortest_dist = distanceToEnemy;
			}
		}
		
		if (nearest_enemy != null && shortest_dist <= range)
		{
			target = nearest_enemy.transform;
		}
		else target = null;

	}

	// Update is called once per frame
	void Update ()
	{
		if (target == null)
		{
			if (useLaser)
			{ 
				if (lineRenderer.enabled)
				{ 
					lineRenderer.enabled = false;
					impactEffect.Stop();
					impactLight.enabled = false;
				}
			}
			return;
		}
		LockOnTarget();

		if (useLaser)
		{
			Laser();
		}else
		{

			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}
		
			fireCountdown -= Time.deltaTime;
		}
	}
	void Laser()
	{

		if (!lineRenderer.enabled)
		{
		 	lineRenderer.enabled = true;
			impactEffect.Play();
			impactLight.enabled = true;
		}
		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1,target.position);

		Vector3 dir = firePoint.position - target.position;
		impactEffect.transform.rotation = Quaternion.LookRotation(dir);
		impactEffect.transform.position = target.position + 0.25f * dir.normalized;

	}

	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		// LERP -- smooth transitions from one state to the other
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*rotspeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}

	void Shoot()
	{
		GameObject bulletGameObject = (GameObject) Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
		Bullet bullet = bulletGameObject.GetComponent<Bullet>();
		if (bullet != null) bullet.Seek(target);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position,range);
	}

}
