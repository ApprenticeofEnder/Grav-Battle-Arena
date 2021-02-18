using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private float horizontalSens = 200f;
    private float verticalSens = 200f;

    private float mouseSens = 5f;

    private float xRotation = 0.0f;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = this.gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSens * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSens * Time.deltaTime * mouseSens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
