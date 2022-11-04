using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOvement : MonoBehaviour
{
    public float panSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime, Space.World);
            // Debug.Log(Input.GetAxis("Horizontal") + " is direction");
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.PageDown))
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
