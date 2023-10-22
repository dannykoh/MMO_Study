using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        // Local <--> World <--> Viewport <--> Screen

        //RayCastForward();

        //Debug.Log(Input.mousePosition); // Screen coordinate

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport coordinate

        #region Ray way
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log($"Raycast Camera @{hit.collider.name}");
            }
        }
        #endregion

        #region WorldPoint way
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 mouseDir = mousePos - Camera.main.transform.position;
        //    mouseDir = mouseDir.normalized;

        //    Debug.DrawRay(Camera.main.transform.position, mouseDir * 100, Color.red, 1.0f);

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, mouseDir, out hit, 100))
        //    {
        //        Debug.Log($"Raycast Camera @{hit.collider.name}");
        //    }
        //}
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision! @{collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger! @{other.name}");
    }

    private void RayCastForward()
    {
        Vector3 lookForward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, lookForward * 10, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, lookForward, out hit, 10))
        {
            Debug.Log($"RayCast! @{hit.collider.name}");
        }
    }
}
