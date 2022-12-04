using UnityEngine;

public class Background : MonoBehaviour
{
    public float animSpeed = 1f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animSpeed * Time.deltaTime, 0);
    }
}
