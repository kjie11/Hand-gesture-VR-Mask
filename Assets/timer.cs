using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour
{
    public static timer instance;
    public float CurrentTime = 0f;
    public float EventReactTimeLimit;

    public List<float> EventsStartTime;
    public List<bool> EventsHasTriggered;
    public List<GameObject> EventGameObjects;
    public int currentEvent = 0;

    public event Action<int> completeEvent;

    private void Awake()
    {
        instance = this;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // ChangeEvent();
    }

    // Update is called once per frame
    void Update()
    {
        // CurrentTime += Time.deltaTime;

        // if (CurrentTime >= EventsStartTime[currentEvent] && EventsHasTriggered[currentEvent] == false)
        // {
        //     //success
        //     Debug.Log("EventStart! num:"+ currentEvent.ToString() );
        //     EventGameObjects[currentEvent].SetActive(true);

        //     EventsHasTriggered[currentEvent] = true;

        //     currentEvent++;


        //     StartCoroutine(DelayCoroutine(EventReactTimeLimit));

        // }



    }

        
    //成功后才切换到下一个任务
    public void ChangeEvent()
    {
         if (currentEvent >= EventGameObjects.Count)
    {
        Debug.Log("All events completed");
        return;
    }

        Debug.Log("EventStart! num: " + currentEvent);
        EventGameObjects[currentEvent+1].SetActive(true);

        StartCoroutine(DelayCoroutine(EventReactTimeLimit));
    
    }

    IEnumerator DelayCoroutine(float delaySeconds)
    {
       
        //
        SetEventFalse();
         yield return new WaitForSeconds(delaySeconds);
    }

    // public void SetEventFalse()
    // {
    //      EventGameObjects[currentEvent-1].SetActive(false);//当前时间段内event false
    //      completeEvent?.Invoke(currentEvent);
    //      ChangeEvent();
    // }
    public void SetEventFalse()
{
    int finishedEvent = currentEvent;

    EventGameObjects[finishedEvent].SetActive(false);
    completeEvent?.Invoke(finishedEvent);

    currentEvent++;
    // ChangeEvent();
}



}
