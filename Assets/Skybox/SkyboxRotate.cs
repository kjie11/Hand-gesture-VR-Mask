using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1f;

    void Update()
    {
        RenderSettings.skybox.SetFloat(
            "_Rotation",
            Time.time * rotationSpeed
        );
    }


}
