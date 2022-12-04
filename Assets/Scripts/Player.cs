using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = -9.8f;
    public float strength = 5f;

    public int point = 1;

    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Vector3 pos = transform.position;
        pos.y = 0f;
        transform.position = pos;
        direction = Vector3.zero;
    }

    private void Start()
    {
        InvokeRepeating(nameof(Animate), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void Animate()
    {
        spriteIndex ++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore(point);
        }
    }
}
