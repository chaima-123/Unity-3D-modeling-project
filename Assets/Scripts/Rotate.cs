
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
 private bool gyroEnabled;
 private Gyroscope gyro;

 private GameObject cameraContainer;
 private Quaternion rot;
 private Touch touch;
 private float speedModifier;

    void Start()
    {
        speedModifier = 0.03f;
    }

 public void SetGyro()
 {
  cameraContainer = new GameObject ("Camera Container");
  cameraContainer.transform.position = transform.position;
  transform.SetParent (cameraContainer.transform);
  gyroEnabled = EnableGyro ();
  
 }

 private bool EnableGyro()
 {
  if (SystemInfo.supportsGyroscope) 
  {
   gyro = Input.gyro;
   gyro.enabled = true;

   cameraContainer.transform.rotation = Quaternion.Euler (90f, 90f, 0f);
   rot = new Quaternion (0, 0, 1, 0);

   return true;
  }
  return false;
 }
 private void Update()
 {
  if (gyroEnabled)
  {
   transform.localRotation = gyro.attitude * rot;
  }

      if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y + touch.deltaPosition.y * speedModifier,
                   transform.position.z + touch.deltaPosition.y * speedModifier);
            }
        }
        if (gyroEnabled)
  {
   transform.localRotation = gyro.attitude * rot;
  }
 }





    
}


