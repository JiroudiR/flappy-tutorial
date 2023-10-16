using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
	private SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	private int spriteIndex;
    private float leftEdge;
	
	private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
		InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
	
	private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
