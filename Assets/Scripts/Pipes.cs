using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;

    private float leftEgde;

    private void Start()
    {
        leftEgde = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftEgde)
        {
            Destroy(gameObject);
        }
    }
}
