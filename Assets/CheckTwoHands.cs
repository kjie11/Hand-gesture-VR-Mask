using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CheckTwoHands : MonoBehaviour
{
    //  public ImageControl notifier;
     public bool  leftHandOK=false;
     public bool rightHandOK=false;
     
     float duration = 2f;
     public Image eventImg;
     public Image gesImg;

    //    public event Action<int> completeEvent;
     

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckBothHands())
        {
            Success();
            
        }
    }

    public void Success()
    {
            FadeOut(eventImg);
            FadeOut(gesImg);
    }
    bool CheckBothHands()
    {
        return leftHandOK&&rightHandOK;
    }

     public void FadeOut(Image img)
    {
        StartCoroutine(FadeOutCoroutine(img, duration));
    }

    private IEnumerator FadeOutCoroutine(Image img, float duration)
    {
        Color color = img.color;
        float startAlpha = color.a;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0f, time / duration);
            img.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // 保证最终完全透明
        img.color = new Color(color.r, color.g, color.b, 0f);
        // timer.instance.SetEventFalse();
        timer.instance.ChangeEvent();
        


    }
    public void SetLeftHandOk(bool input)
    {
        leftHandOK = input;
    }

    public void SetRightHandOk(bool input)
    {
        rightHandOK = input;
    }
}
