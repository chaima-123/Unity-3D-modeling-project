
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfRotate : MonoBehaviour
{
    // Start is called before the first frame update
 
 private Gyroscope gyro;

 void Start(){
       gyro = Input.gyro;
   gyro.enabled = false;   
 }

  public void TurnSpeedly()
    {

        var rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere;
    }
    // Update is called once per frame
   
}
