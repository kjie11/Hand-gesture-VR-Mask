using UnityEngine;
using System.Collections;

public class MusicFader : MonoBehaviour
{
    public static MusicFader instance;
    public AudioSource audioSource;
    public float fadeDuration = 1.5f;
    public AudioClip AngryClip;
    public AudioClip HappyClip;
    public bool changeToHappy;
    bool isHappy;

    void Awake()
    {
        instance=this;
    }

    private void Update()
    {
        if (changeToHappy&&!isHappy)
        {
            ChangeMusicHappy();
            
        }
        
    }
   
    public void ChangeMusicHappy()
    {
        if (isHappy)
        {
            return;
        }
        isHappy=true;
        StartCoroutine(FadeAndSwitch(HappyClip));
    }

    IEnumerator FadeAndSwitch(AudioClip newClip)
    {
        // Fade Out
        float startVolume = audioSource.volume;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade In
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, startVolume, t / fadeDuration);
            yield return null;
        }
    }
}
