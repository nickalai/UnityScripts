/*
Name: Nick Lai
Email: lai137@mail.chapman.edu/nicklai802@gmail.com

Contains logic for the rotation of a GameObject

To use this script, drag and drop it onto the object you wish to rotate. Tweak the rotationSpeed variable to your liking.
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
