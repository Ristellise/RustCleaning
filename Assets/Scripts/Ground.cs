using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    /// <summary>
    /// Returns true if the player is on considered "On the ground"
    /// </summary>
    public bool isGrounded { get; private set; }
    Ray raybeans = new Ray();
    private void FixedUpdate()
    {
        raybeans = new Ray(transform.position, (-transform.up)*10.0f);

        //Physics.Raycast(raybeans);
    }
    private void Start()
    {
        isGrounded = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raybeans);
    }
}
