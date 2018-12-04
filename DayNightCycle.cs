/*
Name: Nick Lai
Student ID#: 2282417
Chapman email: lai137@mail.chapman.edu

Contains logic for a day/night cycle in the world. Also toggles any GameObjects that will want to be turned on at night (i.e. spotlights)

To use the script, attach it to the Main Camera of your scene (be it an actual camera or the camera of the FPSController) and assign a
Text Object and a Directional Light to both "sun" and "SunTransform". Then, tinker with the speed variable to how you see fit. To assign
GameObjects to turn on and off when it reaches night time, drag and drop the objects into the "lanterns" array.

Script referenced from the following YouTube video: https://www.youtube.com/watch?v=PSEZgB2x7ds
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DayNightCycle : MonoBehaviour
{
    public float time;
    public TimeSpan currentTime;
    public Transform SunTransform;
    public Light sun;
    public Text timeText;
    public int days;

    public float intensity;
    public Color fogDay = Color.gray;
    public Color fogNight = Color.black;

    public int speed;

    public GameObject[] lanterns;
	
	// Update is called once per frame
	void Update ()
    {
        ChangeTime();
	}

    public void ChangeTime()
    {
        //updates the time
        time += Time.deltaTime * speed;
        //checks for a new day
        if(time > 60000)
        {
            days += 1;
            time = 0;
        }
        //displays a time to the screen
        currentTime = TimeSpan.FromSeconds(time);
        string[] tempTime = currentTime.ToString().Split(":"[0]);

        timeText.text = tempTime[0] + ":" + tempTime[1];

        //moves the sun in the world
        SunTransform.rotation = Quaternion.Euler(new Vector3((time - 2160) / 64000 * 360, 0, 0));
        //changes the intensity based on the time
        if (time < 43200)
            intensity = 1 - (43200 - time) / 43200;
        
        else
            intensity = 1 - ((43200 - time) / 43200* -1);

        //changes fog rendering settings
        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);
        sun.intensity = intensity;

        //checks if it is dark out and toggles all objects that must be toggled when this happens.
        if (time > 35000 || time < 1000)
        {
            ToggleAllObjectsOn();
        }

        else
        {
            ToggleAllObjectsOff();
        }
    }
    
    public void ToggleAllObjectsOn()
    {
   	for(int i = 0; i < lanterns.Length; i++)
                lanterns[i].SetActive(true);
    }
    
    public void ToggleAllObjectsOff()
    {
    	for (int i = 0; i < lanterns.Length; i++)
                lanterns[i].SetActive(false);
    }
}
