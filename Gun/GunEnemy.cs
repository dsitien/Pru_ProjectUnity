using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
	
	public BulletEnemy bullet;
	Vector2 direction;
	public float shootEverySecond;
	bool canShoot = true;


	void Start()
	{
		direction = (transform.localRotation * Vector2.up).normalized;
	}

	void Update()
	{	
		direction = (transform.localRotation * Vector2.up).normalized;
		if(bullet == null) return;
		if (canShoot)
		{	
			StartCoroutine(EnemyShooting());
		}
	}

	private IEnumerator EnemyShooting()
	{
		canShoot = false;
		if (bullet != null)
		{
			GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
			BulletEnemy goBullet = go.GetComponent<BulletEnemy>();
			goBullet.direction = direction;
		}
		yield return new WaitForSeconds(shootEverySecond);
		canShoot = true;
	}
}
