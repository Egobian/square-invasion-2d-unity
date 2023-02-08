using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    public Transform objetivoCamara;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objetivoCamara.transform.position.x, objetivoCamara.transform.position.y, transform.position.z);
    }
}
