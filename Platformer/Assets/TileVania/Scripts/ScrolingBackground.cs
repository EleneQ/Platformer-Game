using UnityEngine;

public class ScrolingBackground : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [Range(-1f, 1f)]
    [SerializeField] float scrollSpeed = 0.5f;
    Vector2 scrollVector;

    private void Start()
    {
        scrollVector = new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }

    private void Update()
    {
        rend.material.mainTextureOffset += scrollVector;
    }
}
