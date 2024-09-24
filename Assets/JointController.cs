using UnityEngine;

public class JointController : MonoBehaviour
{
    public float speed = 50.0f; // Speed of rotation
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation
    public KeyCode increaseKey = KeyCode.UpArrow; // Key to increase rotation
    public KeyCode decreaseKey = KeyCode.DownArrow; // Key to decrease rotation

    void Update()
    {
        if (Input.GetKey(increaseKey))
        {
            transform.Rotate(rotationAxis, speed * Time.deltaTime);
        }
        if (Input.GetKey(decreaseKey))
        {
            transform.Rotate(rotationAxis, -speed * Time.deltaTime);
        }
    }
}
