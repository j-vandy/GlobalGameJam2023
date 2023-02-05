using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    // Private Variables
    private float nextTime;

    // Public Variables 
    [HideInInspector]
    public int numberOfMeters;
    public float updateTimeInSeconds = 1f;
    public TMP_Text milesText;

    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time + updateTimeInSeconds;
        // Pick a random number between 200 - 400
        numberOfMeters = (int) Random.Range(75f, 125f);
        // Set the number of miles to TMP_Text
        milesText.text = numberOfMeters.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            nextTime += updateTimeInSeconds;
            UpdateNumberOfMeters();
        }
    }

    private void UpdateNumberOfMeters()
    {
        numberOfMeters--;
        if (numberOfMeters <= 0)
        {
            ScenesManager.instance.LoadScene(ScenesManager.Scene.GotToRoots);
        }
        milesText.text = numberOfMeters.ToString();
    }
}
