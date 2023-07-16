using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	[SerializeField] private float speed;

	[SerializeField] private int bulletDamage;
	
	public void Seek (Transform _target)
	{
		target = _target;
	}


	void Update () {

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector2 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			TargetHit(target);
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

	private void TargetHit(Transform enemy)
	{
		CircleEnemy circleEnemy = enemy.GetComponent<CircleEnemy>();

		if(circleEnemy != null)
		{
			circleEnemy.TakeDamage(bulletDamage);
		}

        Destroy(gameObject);
	}


}
