using UnityEngine;

public class FireScript : MonoBehaviour
{
    public RocketLaunchScript rocketStatsInterface; // Reference to access rocket velocity
    private ParticleSystem fireEffect; // Reference to the Particle System for fire

    void Start()
    {
        rocketStatsInterface = GameObject.FindGameObjectWithTag("RocketStatistics").GetComponent<RocketLaunchScript>();

        // Get the Particle System attached to the fire effect
        fireEffect = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (rocketStatsInterface != null && fireEffect != null)
        {
            // Get the rocket's current fuel level
            float fuel = (float)rocketStatsInterface.getFuel();

            // Check fuel level and stop the fire effect if fuel is less than 1
            if (fuel <= 1.0f && fireEffect.isPlaying)
            {
                fireEffect.Stop(); // Stops the particle emission
            }
            else if (fuel > 1.0f && !fireEffect.isPlaying)
            {
                fireEffect.Play(); // Restarts the particle emission if fuel is above 1
            }
        }
    }
}
