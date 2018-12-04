/*
Name: Nick Lai
Email: lai137@mail.chapman.edu/nicklai802@gmail.com

Contains logic for a gun. (Casting raycasts from the center of the screen)

To use the script, attach it to the camera of an FPSController

Script referenced from the following YouTube video: https://www.youtube.com/watch?v=THnivyG0Mvo
*/

using UnityEngine;

public class Gun : MonoBehaviour
{
    //stores damage and range modifiers
    public float damage = 25f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update ()
    {
		    if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	  }

    //Logic for using raycasts to detect a target
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //currently only shows the name of the transform of the "shot" object. Other code will be required to add on to this.
            Debug.Log(hit.transform.name);
        }
    }
}
