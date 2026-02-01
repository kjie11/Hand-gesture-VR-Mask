using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ManualVignetteController : MonoBehaviour
{
    [Header("Aperture Size")]
    [Range(0f, 1f)]
    public float currentAperture = 1f;
    [Range(0f, 1f)]
    public float targetAperture = 1f;
    public float apertureSmoothTime = 0.3f;

    [Header("Aperture Offset")]
    public float currentOffsetY = 0f;
    public float targetOffsetY = 0f;
    public float offsetSmoothTime = 0.3f;

    [Header("Shader")]
    public string apertureProperty = "_ApertureSize";

    MeshRenderer meshRenderer;
    MaterialPropertyBlock block;

    float apertureVelocity;
    float offsetVelocity;

    

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        block = new MaterialPropertyBlock();
    }
    void Start()
    {
        if (timer.instance != null)
        {
            timer.instance.completeEvent += OnComplete;
        }
        
    }
    private void OnDisable()
{
    if (timer.instance != null)
        timer.instance.completeEvent -= OnComplete;
}

    void Update()
    {
        // ① 洞大小变化
        currentAperture = Mathf.SmoothDamp(
            currentAperture,
            targetAperture,
            ref apertureVelocity,
            apertureSmoothTime
        );

        ApplyAperture(currentAperture);

        // ② 洞位置变化（移动 mesh）
        float newY = Mathf.SmoothDamp(
            transform.localPosition.y,
            targetOffsetY,
            ref offsetVelocity,
            offsetSmoothTime
        );

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            newY,
            transform.localPosition.z
        );
    }

    void ApplyAperture(float value)
    {
        meshRenderer.GetPropertyBlock(block);
        block.SetFloat(apertureProperty, value);
        meshRenderer.SetPropertyBlock(block);
    }

    // ====== 对外 API ======

    public void SetAperture(float size, float time = 0.3f)
    {
        targetAperture = Mathf.Clamp01(size);
        apertureSmoothTime = time;
    }

    public void SetOffsetY(float y, float time = 0.3f)
    {
        targetOffsetY = y;
        offsetSmoothTime = time;
    }

    //当前任务序号
    void OnComplete(int eventNum)
    {
        Debug.Log("in the onComplete");
        if (eventNum <= 2)
        {
            DecreaseAperture();
            SkyboxSwitch.instance.SwitchToCertainSkybox(2);
            
        }
        else if (eventNum >2)
        {
           
             IncreaseAperture();
             SkyboxSwitch.instance.SwitchToCertainSkybox(5);
             MusicFader.instance.ChangeMusicHappy();
        }
    }
    public void IncreaseAperture(float delta = 0.2f, float time = -1f)
    {
        targetAperture = Mathf.Clamp01(targetAperture + delta);

        if (time > 0f)
            apertureSmoothTime = time;
    }
    public void DecreaseAperture(float delta = 0.2f, float time = -1f)
    {
        targetAperture = Mathf.Clamp01(targetAperture - delta);

        if (time > 0f)
            apertureSmoothTime = time;
    }

}
