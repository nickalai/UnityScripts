/*
Name: Nick Lai
Student ID#: 2282417
Chapman email: lai137@mail.chapman.edu
Course Number and Section: vrSensory ~ Dance Module
Contains logic for the rotation of the disco ball
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int rotationSpeed = 25;
	
	// Update is called once per frame
	void Update ()
    {
        //rotates the object
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}
}
