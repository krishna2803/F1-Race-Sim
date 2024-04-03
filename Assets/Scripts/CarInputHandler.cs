using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    // Components
    TopDownCarController topDownCarController;

    private void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
    }

    private void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        topDownCarController.SetInputVector(inputVector);

    }
}
