

using UnityEngine;

public class RocketLaunchScript : MonoBehaviour
{
    public RocketManagerScript rocketManagementScript;
    private GameObject entireRocket;

    public double initialPropulsion;
    public double rocketMass;
    public double initialHeight = 0;
    public double currAcceleration;
    public double currHeight;
    public double currGravity;
    public double currVelocity;

    void Start()
    {
        rocketManagementScript = GameObject.FindGameObjectWithTag("RocketLaunchScript").GetComponent<RocketManagerScript>();
        entireRocket = GameObject.FindGameObjectWithTag("EntireRocket");
        rocketManagementScript.UpdateRocketParameters(entireRocket.GetComponent<RocketPartManager>().GetTotalThrust() * 1000000, entireRocket.GetComponent<RocketPartManager>().GetTotalWeight() * 1000);
        rocketManagementScript.UpdateHeight(initialHeight);
        initialPropulsion = rocketManagementScript.getInitialPropulsion();
        rocketMass = rocketManagementScript.getWeight();
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