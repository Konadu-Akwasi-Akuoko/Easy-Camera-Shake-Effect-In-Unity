using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires the component of Transform. It attaches a transform if none is attached.
[RequireComponent(typeof(Transform))]
public class CameraShakeScript : MonoBehaviour
{
    /*Creating a camera shake effect that uses the random.insideUnitSphere to select a point within
     * a radius which we will specify. Note the point will be selected according to the position of the
     * attached game object, in our case it is the camera.
     * 
     * Variables needed, CameraTransform, orignalPosOfCamera and shakeFrequency.
     * 
     * cameraTransform = it is the transform of the camera.
     * 
     * originalPosOfCamera = it is the origianl position of our camera,this is where the camera 
     * will return to affter shaking.
     * 
     * shakeFrequency = this will be multiplied to random.insideUnitSphere, thus the higher the number
     * the higher the shake frequency, and lower the number the lower the shake frequency. The reason this
     * will be happening is that, the random.insideUnitSphere select a point at vector(0,0,0) within the radius of one, by 
     * multiplying it by the shake frequency of a higher number the radius of the circle to choose from also expands,
     * creating a high frequency, if you want to create a  lower frequency make the shake frequency low as well.
     * 
     * NB: The Random.insideUnitSphere always have a position of Vector3(0,0,0), in oder to chose a position around
     * the camera, we add the original camera position to the value of Random.insideUinitSphere. For example, say the 
     * Transform.position of our camera is Vector3(10,5,10), when we add it to Random.insideUnitSphere it gives us the 
     * cordinates of Vector3(10,5,10), thus it choses a radius around where our camera is at.
     * Press the S key to  shake the camera.
     */

    public Transform _cameraTransform = default;
    private Vector3 _orignalPosOfCam = default;
    public float shakeFrequency = default;

    // Start is called before the first frame update
    void Start()
    { 
        //When the game starts make sure to assign the origianl possition of the camera.
        _orignalPosOfCam = _cameraTransform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //Make sure to assign the value of shakeFrequency in the inspector 
            //or uncomment the next line to assign it here.
            //shakeFrequency = 2.0f;

            CameraShake();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            StopShake();
        }
    }

    private void CameraShake()
    {
        //This moves the camera position to the random point chosen within the circle around the camera.
        //NB:Our Random.insideUnitSphere selects a random position every frame because of GetKey
        //which is called every frame, and that causes the shaking.
        _cameraTransform.position = _orignalPosOfCam + Random.insideUnitSphere * shakeFrequency;
    }

    private void StopShake()
    {
        _cameraTransform.position = _orignalPosOfCam;
    }
}
