using UnityEngine;

public class RobotArmController : MonoBehaviour
{
    // Reference to each joint transform
    public Transform baseJoint;
    public Transform shoulderJoint;
    public Transform armJoint;

    // Speed settings for different movements
    public float baseRotationSpeed = 100.0f;
    public float shoulderMovementSpeed = 50.0f;
    public float armMovementSpeed = 50.0f;

    // Current rotation angles
    private float baseCurrentAngle = 0f;
    private float shoulderCurrentAngle = 0f;
    private float armCurrentAngle = 0f;

    // Control mode for base link rotation
    private bool isBaseControlActive = true; // Assume option 0 is selected by default

    // Maximum and minimum angles for constraints
    private float shoulderMinAngle = -30f;
    private float shoulderMaxAngle = 90f;
    private float armMinAngle = 0f;
    private float armMaxAngle = 135f;

    void Update()
    {
        // Toggle base control with a specific key, for example, pressing 'B'
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBaseControlActive = !isBaseControlActive;
        }

        // Base rotation controlled with A and D keys only when base control is active
        if (isBaseControlActive)
        {
            if (Input.GetKey(KeyCode.A)) // Rotate left
            {
                baseCurrentAngle += baseRotationSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D)) // Rotate right
            {
                baseCurrentAngle -= baseRotationSpeed * Time.deltaTime;
            }
            baseCurrentAngle = NormalizeAngle(baseCurrentAngle);
            baseJoint.localRotation = Quaternion.Euler(0, baseCurrentAngle, 0);
        }

        // Shoulder and arm movement controlled normally with Shift and Control modifiers
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            shoulderCurrentAngle = UpdateJointAngle(shoulderJoint, shoulderCurrentAngle, KeyCode.UpArrow, KeyCode.DownArrow, shoulderMovementSpeed, shoulderMinAngle, shoulderMaxAngle);
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            armCurrentAngle = UpdateJointAngle(armJoint, armCurrentAngle, KeyCode.UpArrow, KeyCode.DownArrow, armMovementSpeed, armMinAngle, armMaxAngle);
        }
    }

    // Function to handle joint rotation and angle constraints
    float UpdateJointAngle(Transform joint, float currentAngle, KeyCode increaseKey, KeyCode decreaseKey, float speed, float minAngle, float maxAngle)
    {
        if (Input.GetKey(increaseKey))
        {
            currentAngle += speed * Time.deltaTime;
        }
        else if (Input.GetKey(decreaseKey))
        {
            currentAngle -= speed * Time.deltaTime;
        }
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);  // Clamps the angle within specified range
        joint.localRotation = Quaternion.Euler(currentAngle, 0, 0);
        return currentAngle;
    }

    // Normalizes angles to allow continuous rotation
    float NormalizeAngle(float angle)
    {
        while (angle < 0f)
            angle += 360f;
        while (angle >= 360f)
            angle -= 360f;
        return angle;
    }
}
