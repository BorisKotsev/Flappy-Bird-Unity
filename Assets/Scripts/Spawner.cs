using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;
    public float minHeight = -1f, maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }

    private void spawn()
    {
        GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);

        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
