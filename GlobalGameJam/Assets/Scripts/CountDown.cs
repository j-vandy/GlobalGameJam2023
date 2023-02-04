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
    public int numberOfMiles;
    public float updateTimeInSeconds = 0.5f;
    public TMP_Text milesText;

    // Start is called before the first frame update
    void Start()
    {
        nextTime = updateTimeInSeconds;
        // Pick a random number between 200 - 400
        numberOfMiles = (int) Random.Range(175f, 375f);
        // Set the number of miles to TMP_Text
        milesText.text = numberOfMiles.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            nextTime += updateTimeInSeconds;
            UpdateNumberOfMiles();
        }
    }

    private void UpdateNumberOfMiles()
    {
        numberOfMiles--;
        if (numberOfMiles <= 0)
        {
            ScenesManager.instance.LoadScene(ScenesManager.Scene.GotToRoots);
        }
        milesText.text = numberOfMiles.ToString();
    }
}
