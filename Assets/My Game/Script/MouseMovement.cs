using UnityEngine;

[AddComponentMenu("ScaryGame/MouseMovement")]
public class MouseMovement : MonoBehaviour
{
    [Header("Mouse")]
    public float mouseSensiviy = 50f;
    private float xRotation;
    private float yRotation;

    [Header("Clamp")]
    public float topClamp = -90f;
    public float bottonClamp = 90f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensiviy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensiviy * Time.deltaTime;
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottonClamp);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
