using UnityEngine;

public class ShoulderJointController : MonoBehaviour
{
    public float speed = 50.0f; // Speed of rotation
    public KeyCode increaseKey = KeyCode.W; // Key to rotate the shoulder right
    public KeyCode decreaseKey = KeyCode.S; // Key to rotate the shoulder left
    private float currentAngle = 0f; // Track current rotation angle

    void Update()
    {
        if (Input.GetKey(increaseKey))
        {
            RotateShoulder(speed * Time.deltaTime);
        }
        if (Input.GetKey(decreaseKey))
        {
            RotateShoulder(-speed * Time.deltaTime);
        }
    }

    private void RotateShoulder(float angle)
    {
        currentAngle += angle;
        transform.localRotation = Quaternion.Euler(0, currentAngle, 0); // Rotate around the Y axis
    }
}
