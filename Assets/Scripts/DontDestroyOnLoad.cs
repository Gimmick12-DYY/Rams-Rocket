using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // Prevent this GameObject from being destroyed on scene load
        DontDestroyOnLoad(gameObject);
    }
}
