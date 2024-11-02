

using System;
using UnityEngine;
using UnityEngine.UI;

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
    public double totalFuelWeight;

    [SerializeField] private Text Height;
    [SerializeField] private Text Velocity;
    [SerializeField] private Text Accelaration;

    void Start()
    {
        totalFuelWeight = 300;
        rocketManagementScript = GameObject.FindGameObjectWithTag("RocketLaunchScript").GetComponent<RocketManagerScript>();
        entireRocket = GameObject.FindGameObjectWithTag("EntireRocket");
        rocketManagementScript.UpdateRocketParameters(entireRocket.GetComponent<RocketPartManager>().GetTotalThrust() * 1000000, entireRocket.GetComponent<RocketPartManager>().GetTotalWeight() * 1000, totalFuelWeight * 1000);
        rocketManagementScript.UpdateHeight(initialHeight);
        initialPropulsion = rocketManagementScript.getInitialPropulsion();
        rocketMass = rocketManagementScript.getWeight();
        totalFuelWeight = rocketManagementScript.getFuelWeight();
    }

    void Update()
    {
        currAcceleration = rocketManagementScript.getAccelaration();
        currHeight = rocketManagementScript.getHeight();
        currGravity = rocketManagementScript.getGravity();
        currVelocity = rocketManagementScript.getVelocity();
        totalFuelWeight = rocketManagementScript.getFuelWeight();

        rocketManagementScript.CalculateNetPropulsion();
        rocketManagementScript.CalculateAcceleration();

        rocketManagementScript.UpdateHeight(Time.deltaTime);

        Debug.Log($"Height: {currHeight} m");
        Debug.Log($"Velocity: {currVelocity} m/s");
        Debug.Log($"Acceleration: {currAcceleration} m/s²");
        DisplayPartInfo();
    }


    private void DisplayPartInfo()
    {
        if (Height != null) Height.text = (currHeight / 1000).ToString("F3") + " km";
        if (Velocity != null) Velocity.text = currVelocity.ToString("F2") + " m/s";
        if (Accelaration != null) Accelaration.text = currAcceleration.ToString("F3") + " m/s^2";
    }
}
