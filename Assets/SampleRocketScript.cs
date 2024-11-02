

using UnityEngine;

public class RocketLaunchScript : MonoBehaviour
{
    public RocketManagerScript rocketManagementScript;

    public double initialPropulsion = 5000;
    public double rocketMass = 1000;
    public double initialHeight = 0;
    public double currAcceleration;
    public double currHeight;
    public double currGravity;
    public double currVelocity;

    void Start()
    {
        rocketManagementScript = GameObject.FindGameObjectWithTag("RocketLaunchScript").GetComponent<RocketManagerScript>();

        rocketManagementScript.UpdateRocketParameters(initialPropulsion, rocketMass);
        rocketManagementScript.UpdateHeight(initialHeight);
    }

    void Update()
    {
        currAcceleration = rocketManagementScript.getAccelaration();
        currHeight = rocketManagementScript.getHeight();
        currGravity = rocketManagementScript.getGravity();
        currVelocity = rocketManagementScript.getVelocity();

        rocketManagementScript.CalculateNetPropulsion();
        rocketManagementScript.CalculateAcceleration();

        rocketManagementScript.UpdateHeight(Time.deltaTime);

        Debug.Log($"Height: {currHeight} m");
        Debug.Log($"Velocity: {currVelocity} m/s");
        Debug.Log($"Acceleration: {currAcceleration} m/s²");
    }
}

