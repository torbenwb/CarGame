using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera[] cameras;
    int cameraIndex = 0;
    
    public GameObject toggleActive;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++){
            cameras[i].gameObject.SetActive(false);
        }

        cameras[cameraIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) toggleActive.SetActive(!toggleActive.activeSelf);
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            cameras[cameraIndex].gameObject.SetActive(false);
            cameraIndex++;
            if (cameraIndex >= cameras.Length) cameraIndex = 0;

            cameras[cameraIndex].gameObject.SetActive(true);
        }   

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            cameras[cameraIndex].gameObject.SetActive(false);
            cameraIndex--;
            if (cameraIndex < 0) cameraIndex = cameras.Length - 1;

            cameras[cameraIndex].gameObject.SetActive(true);
        }
    }
}
