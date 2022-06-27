using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraReferance;
    [SerializeField]
    private float targetHeight;
    [SerializeField]
    private GameObject playerReferance;
    [SerializeField]
    private float camSpeed = 5.0f;

    private void Start()
    {
        targetHeight = cameraReferance.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(playerReferance.transform.position.x, targetHeight, playerReferance.transform.position.z);
        cameraReferance.transform.position = Vector3.Slerp(cameraReferance.transform.position, targetPos, 0.59f*Time.deltaTime * camSpeed);
    }
}
