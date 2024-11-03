using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // Prevent this GameObject from being destroyed on scene load
        DontDestroyOnLoad(gameObject);

        // Slightly shrink the object’s scale
        Vector3 newScale = transform.localScale * 0.9f; // Adjust the factor to control shrink amount
        transform.localScale = newScale;
    }
}
