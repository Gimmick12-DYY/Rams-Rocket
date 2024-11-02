using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Set different scroll speeds in the Inspector

    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;

        // Adjust the Y offset for vertical scrolling
        offset.y += scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
