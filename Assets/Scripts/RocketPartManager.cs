using UnityEngine;
using UnityEngine.UI;

public class RocketPartManager : MonoBehaviour
{
    [SerializeField] private RocketPartData[] payloadOptions;
    [SerializeField] private RocketPartData[] bodyOptions;
    [SerializeField] private RocketPartData[] propulsionOptions;

    private GameObject currentPayload;
    private GameObject currentBody;
    private GameObject currentPropulsion;

    private int payloadIndex = 0;
    private int bodyIndex = 0;
    private int propulsionIndex = 0;

    // Optional: UI elements to display part information and total weight
    [SerializeField] private Text partNameText;
    [SerializeField] private Text partDescriptionText;
    [SerializeField] private Text partWeightText;
    [SerializeField] private Text partThrustText;
    [SerializeField] private Text totalWeightText;
    [SerializeField] private Text totalThrustText;

    private void Start()
    {
        SwapPayload(payloadIndex);
        SwapBody(bodyIndex);
        SwapPropulsion(propulsionIndex);
        UpdateTotalWeight();
        UpdateTotalThrust();
    }

    private void DisplayPartInfo(RocketPartData partData)
    {
        if (partNameText != null) partNameText.text = "Name: " + partData.partName;
        if (partDescriptionText != null) partDescriptionText.text = "Description: " + partData.description;
        if (partWeightText != null) partWeightText.text = "Weight: " + partData.weight.ToString();
        if (partThrustText != null) partThrustText.text = partData.thrust.ToString() + "MN";
    }

    private void UpdateTotalWeight()
    {
        float totalWeight = payloadOptions[payloadIndex].weight +
                            bodyOptions[bodyIndex].weight +
                            propulsionOptions[propulsionIndex].weight;

        if (totalWeightText != null)
        {
            totalWeightText.text = totalWeight.ToString("F2") + "t";
        }
    }
    private void UpdateTotalThrust()
    {
        float totalThrust = propulsionOptions[propulsionIndex].thrust;

        if (totalThrustText != null)
        {
            totalThrustText.text = totalThrust.ToString("F2") + "MN";
        }
    }

    private void SwapPayload(int index)
    {
        if (currentPayload != null) Destroy(currentPayload);
        currentPayload = Instantiate(payloadOptions[index].partPrefab, transform);
        DisplayPartInfo(payloadOptions[index]);
        UpdateTotalWeight(); // Update total weight whenever the payload is changed
    }

    private void SwapBody(int index)
    {
        if (currentBody != null) Destroy(currentBody);
        currentBody = Instantiate(bodyOptions[index].partPrefab, transform);
        DisplayPartInfo(bodyOptions[index]);
        UpdateTotalWeight(); // Update total weight whenever the body is changed
    }

    private void SwapPropulsion(int index)
    {
        if (currentPropulsion != null) Destroy(currentPropulsion);
        currentPropulsion = Instantiate(propulsionOptions[index].partPrefab, transform);
        DisplayPartInfo(propulsionOptions[index]);
        UpdateTotalWeight(); // Update total weight whenever the propulsion is changed
        UpdateTotalThrust();
    }

    public void NextPayload()
    {
        payloadIndex = (payloadIndex + 1) % payloadOptions.Length;
        SwapPayload(payloadIndex);
    }

    public void NextBody()
    {
        bodyIndex = (bodyIndex + 1) % bodyOptions.Length;
        SwapBody(bodyIndex);
    }

    public void NextPropulsion()
    {
        propulsionIndex = (propulsionIndex + 1) % propulsionOptions.Length;
        SwapPropulsion(propulsionIndex);
    }

    public void PreviousPayload()
    {
        payloadIndex = (payloadIndex - 1 + payloadOptions.Length) % payloadOptions.Length;
        SwapPayload(payloadIndex);
    }

    public void PreviousBody()
    {
        bodyIndex = (bodyIndex - 1 + bodyOptions.Length) % bodyOptions.Length;
        SwapBody(bodyIndex);
    }

    public void PreviousPropulsion()
    {
        propulsionIndex = (propulsionIndex - 1 + propulsionOptions.Length) % propulsionOptions.Length;
        SwapPropulsion(propulsionIndex);
    }

    public float GetTotalWeight()
    {
        return payloadOptions[payloadIndex].weight +
               bodyOptions[bodyIndex].weight +
               propulsionOptions[propulsionIndex].weight;
    }

    // Method to return the total thrust of the selected propulsion part
    public float GetTotalThrust()
    {
        return propulsionOptions[propulsionIndex].thrust;
    }
}

