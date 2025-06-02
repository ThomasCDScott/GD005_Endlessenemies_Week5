using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 10f; //How sensitive the mouse will be when moving the mouse.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; //Makes the cursor invisiable
        Cursor.lockState = CursorLockMode.Locked; //This will lock the cursor in the middle of the screen.
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime); //This is to allow for us to move the camera around on the Y axis while moving the mouse.
    }
}
