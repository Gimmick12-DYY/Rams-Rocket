using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public float parallaxFactor = 0.1f; // Controls sensitivity of parallax effect
    public RocketStatisticInterface rocketStatsInterface; // Reference to access rocket velocity

    private MeshRenderer mr;
    private Material mat;

    void Start()
    {
        // Get the MeshRenderer and its material
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    void Update()
    {
        // Access the current velocity from RocketStatisticInterface
        if (rocketStatsInterface != null)
        {
            float rocketVelocity = (float)rocketStatsInterface.GetVerticalVelocity(); // Adjust if necessary

            // Adjust scroll speed based on the rocket's velocity and parallax factor
            float scrollSpeed = rocketVelocity * parallaxFactor;

            // Only scroll if the rocket is moving (i.e., velocity is not zero)
            if (rocketVelocity != 0)
            {
                Vector2 offset = mat.mainTextureOffset;
                offset.y += scrollSpeed * Time.deltaTime;
                mat.mainTextureOffset = offset;
            }
        }
    }
}
