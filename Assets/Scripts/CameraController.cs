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
    [SerializeField]
    private float camHeight = 15.0f;
    [SerializeField, Range(0f, 1.0f)]
    public float slerper = 0.5f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetPos = new(
            playerReferance.transform.position.x,
            playerReferance.transform.position.y + camHeight,
            playerReferance.transform.position.z);
        cameraReferance.transform.position = Vector3.Lerp(cameraReferance.transform.position, targetPos, slerper * Time.deltaTime * camSpeed);
    }
}
