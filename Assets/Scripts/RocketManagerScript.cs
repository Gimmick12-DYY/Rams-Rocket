using UnityEngine;

public class RocketManagerScript : MonoBehaviour
{
    public double totalWeight;       // Rocket mass in kg
    private double totalPropulsion;  // Thrust in newtons
    private double netPropulsion;    // Net force after accounting for gravity
    private double currHeight;       // Current height above the Earth's surface
    private double acceleration;     // Current acceleration in m/s^2
    private double velocity;         // Current velocity in m/s
    private double totalFuelWeight;
    private double fuelConsumptionRate;
    private const int spaceDis = 110000;

    void Start()
    {
        // Optional: Initialize height, velocity, etc., if needed
        currHeight = 0;
        velocity = 0;
        acceleration = 0;
    }

    void Update()
    {
        // Calculate net propulsion and acceleration based on the current parameters
        CalculateNetPropulsion();
        CalculateAcceleration();

        // Update height based on current acceleration and velocity
        ConsumeFuel(Time.deltaTime);
        UpdateHeight(Time.deltaTime);

        // Optional: Log values for debugging
        Debug.Log($"Height: {currHeight} m, Velocity: {velocity} m/s, Acceleration: {acceleration} m/s²");
    }

    public double CalculateNetPropulsion()
    {
        netPropulsion = totalPropulsion - getGravity();
        return netPropulsion;
    }

    public void CalculateAcceleration()
    {
        if (getWeight() > 0)
        {
            acceleration = netPropulsion / getWeight();
        }
        else
        {
            acceleration = 0;
        }
    }

    public void UpdateRocketParameters(double newPropulsion, double newWeight, double totalFuelWeight)
    {
        this.totalPropulsion = newPropulsion;
        this.totalWeight = newWeight;
        this.totalFuelWeight = totalFuelWeight;
        fuelConsumptionRate = 5000.0;
    }

    public void UpdateHeight(double deltaTime)
    {
        // Update velocity with the current acceleration
        velocity += acceleration * deltaTime;

        // Update height based on the new velocity and acceleration
        currHeight += velocity * deltaTime + 0.5 * acceleration * deltaTime * deltaTime;
    }

    public double getHeight()
    {
        return currHeight;
    }

    public double getVelocity()
    {
        if (currHeight > spaceDis && getFuelWeight() == 0)
        {
            velocity *= 0.999;
        }
        if (velocity < 0.1)
        {
            velocity = 0;
        }
        return velocity;
    }

    public double getAccelaration()
    {
        return acceleration;
    }

    public double getGravity()
    {
        if (currHeight > spaceDis)
        {
            return 0.0;
        }
        double G = 6.674 * Mathf.Pow(10, -11);
        double EarthMass = 5.972 * Mathf.Pow(10, 24);
        double EarthRadius = 6.371 * Mathf.Pow(10, 6);

        double gravityForce = (G * EarthMass * getWeight()) / Mathf.Pow((float)(EarthRadius + currHeight), 2);

        return gravityForce;
    }

    public double getInitialPropulsion()
    {
        return totalPropulsion;
    }

    public double getWeight()
    {
        return this.totalWeight + totalFuelWeight;
    }

    public void ConsumeFuel(double deltaTime)
    {
        // Calculate the amount of fuel to consume over this time period
        double fuelUsed = fuelConsumptionRate * deltaTime;

        // Ensure fuel does not go below zero
        if (totalFuelWeight > fuelUsed)
        {
            totalFuelWeight -= fuelUsed;
        }
        else
        {
            totalFuelWeight = 0;
            totalPropulsion = 0; // No more thrust if fuel is depleted
        }
    }

    public double getFuelWeight()
    {
        return this.totalFuelWeight;
    }
}
