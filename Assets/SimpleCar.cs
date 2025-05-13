using UnityEngine;

public class SimpleCar : MonoBehaviour
{
    private PrometeoCarController carController;

    void Start()
    {
        carController = GetComponent<PrometeoCarController>();
        if (carController == null)
            Debug.LogError("No s'ha trobat PrometeoCarController!");
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        if (carController != null)
        {
            if (moveInput > 0) carController.GoForward();
            else if (moveInput < 0) carController.GoReverse();
            else carController.ThrottleOff();

            if (turnInput < 0) carController.TurnLeft();
            else if (turnInput > 0) carController.TurnRight();
            else carController.ResetSteeringAngle();
        }
    }
}
