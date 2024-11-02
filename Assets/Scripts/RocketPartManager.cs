using UnityEngine;

public class RocketPartManager : MonoBehaviour
{
    // Arrays to hold the prefabs for each part, serialized for Inspector access
    [SerializeField] private GameObject[] payloadOptions;
    [SerializeField] private GameObject[] bodyOptions;
    [SerializeField] private GameObject[] propulsionOptions;

    // References to the current parts on the rocket
    private GameObject currentPayload;
    private GameObject currentBody;
    private GameObject currentPropulsion;

    // Indexes to track the currently selected option for each part
    private int payloadIndex = 0;
    private int bodyIndex = 0;
    private int propulsionIndex = 0;

    // Start method to initialize the rocket with the first parts in each array
    private void Start()
    {
        SwapPayload(payloadIndex);
        SwapBody(bodyIndex);
        SwapPropulsion(propulsionIndex);
    }

    // Methods to swap each part based on the given index
    private void SwapPayload(int index)
    {
        if (currentPayload != null) Destroy(currentPayload);
        currentPayload = Instantiate(payloadOptions[index], transform);
    }

    private void SwapBody(int index)
    {
        if (currentBody != null) Destroy(currentBody);
        currentBody = Instantiate(bodyOptions[index], transform);
    }

    private void SwapPropulsion(int index)
    {
        if (currentPropulsion != null) Destroy(currentPropulsion);
        currentPropulsion = Instantiate(propulsionOptions[index], transform);
    }

    // Button functions to cycle forward through each part option
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

    // Button functions to cycle backward through each part option
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
}
