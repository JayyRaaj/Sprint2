using UnityEngine;

public class JointController : MonoBehaviour
{
    public float speed = 50.0f; // Speed of rotation
    public KeyCode increaseKey = KeyCode.A; // Key to bend the arm up
    public KeyCode decreaseKey = KeyCode.D; // Key to bend the arm down
    private float currentAngle = 0f; // Track current rotation angle
    public float minAngle = -45f; // Minimum bending angle
    public float maxAngle = 45f; // Maximum bending angle

    void Update()
    {
        if (Input.GetKey(increaseKey))
        {
            BendArm(speed * Time.deltaTime);
        }
        if (Input.GetKey(decreaseKey))
        {
            BendArm(-speed * Time.deltaTime);
        }
    }

    private void BendArm(float angle)
    {
        currentAngle += angle;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(currentAngle, 0, 0); // Bend the arm around the X axis
    }
}
