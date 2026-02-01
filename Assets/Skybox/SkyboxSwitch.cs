using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSwitch : MonoBehaviour
{
    public static SkyboxSwitch instance;
    public Texture[] skyboxTextures;
    private int currentIndex = 0;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        ApplySkybox(0);
    }

    void Update()
    {

    }

    public void SwitchToCertainSkybox(int index)
    {
        ApplySkybox(index);
    }
    
    public void NextSkybox()
    {
        currentIndex = (currentIndex + 1) % skyboxTextures.Length;
        ApplySkybox(currentIndex);
    }


    void ApplySkybox(int index)
    {
        RenderSettings.skybox.SetTexture("_MainTex", skyboxTextures[index]);
        DynamicGI.UpdateEnvironment(); // ?�ǳ���Ҫ
    }
}
