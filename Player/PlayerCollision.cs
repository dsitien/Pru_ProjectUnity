using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Color originalColor;
	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		originalColor = spriteRenderer.color;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			PlayerHeart.health--;
			if (PlayerHeart.health <= 0)
			{

			}else
			{
				StartCoroutine(GetHurt());
			}
		}
	}

	IEnumerator GetHurt()
	{
		Physics2D.IgnoreLayerCollision(6,7,true);

		for (int i = 0; i < 5; i++) // Nhấp nháy 5 lần
		{
			SetTransparency(0.5f); // Đặt độ trong suốt xuống 50%
			yield return new WaitForSeconds(0.2f);
			SetTransparency(1f); // Đặt lại độ trong suốt về 100%
			yield return new WaitForSeconds(0.2f);
		}


		Physics2D.IgnoreLayerCollision(6, 7,false);
	}
	void SetTransparency(float alpha)
	{
		Color color = spriteRenderer.color;
		color.a = alpha;
		spriteRenderer.color = color;
	}
}
