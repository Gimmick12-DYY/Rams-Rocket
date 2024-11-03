using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public float parallaxFactor = 0.1f; // Controls sensitivity of parallax effect
    public RocketLaunchScript rocketStatsInterface; // Reference to access rocket velocity

    private MeshRenderer mr;
    private Material mat;

    void Start()
    {
        // Get the RocketLaunchScript component with the specified tag
        rocketStatsInterface = GameObject.FindGameObjectWithTag("RocketStatistics").GetComponent<RocketLaunchScript>();

        // Get the MeshRenderer and its material
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    void Update()
    {
        if (rocketStatsInterface != null)
        {
            // Get the rocket's current vertical velocity
            float rocketVelocity = (float)rocketStatsInterface.currVelocity;

            // Calculate scroll speed based on velocity and parallax factor
            float scrollSpeed = rocketVelocity * parallaxFactor;

            // Update texture offset if the rocket is moving
            if (rocketVelocity != 0)
            {
                Vector2 offset = mat.mainTextureOffset;
                offset.y += scrollSpeed * Time.deltaTime;
                mat.mainTextureOffset = offset;
            }
        }
    }
}
