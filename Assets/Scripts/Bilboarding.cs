using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboarding : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private bool useStatic;


    // Update is called once per frame
    private void LateUpdate()
    {
        if (!useStatic)
        {
            transform.LookAt(cam.transform);
        }
        else
        {
            transform.rotation = cam.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
