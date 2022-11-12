using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraMOvement : MonoBehaviour
{
    public float panSpeed = 30f;
    public TMP_InputField panSpeed_IF;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        panSpeed_IF.text = panSpeed + "";
    }

    public void PanSpeedChanger()
    {
        panSpeed = int.Parse(panSpeed_IF.text);
    }

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
