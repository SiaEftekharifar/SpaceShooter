using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   [Header("General")] 
   [Tooltip("In m/s")] [SerializeField] float movemnetSpeed;
   [Tooltip("In m")] [SerializeField] float horizontalClamp;
   [Tooltip("In m")] [SerializeField] float verticalClamp;

   [SerializeField] GameObject[] guns;

   [Header("Screen-Position based")]
   [SerializeField] float positionPitchFactor;
   [SerializeField] float positionYawFactor;

   [Header("Control-throw based")]
   [SerializeField] float controlPitchFactor;
   [SerializeField] float controlRollFactor;




   float xThrow, yThrow;

   bool isDead = false;

// Update is called once per frame
 void Update() {

    if (!isDead) {
        SetTranslation();
        SetRotation();
        SetShooting();
    }
}

 private void OnPlayerDeath() //called by string reference!(not so good). Think about Delegates later on!
{
    isDead = true;
}

//Translation of the player jet vertically and horizontally!

 private void SetTranslation() {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * movemnetSpeed * Time.deltaTime;
        float yOffset = yThrow * movemnetSpeed * Time.deltaTime;

        float xPos = transform.localPosition.x + xOffset;
        float yPos = transform.localPosition.y + yOffset;

        //Clamping the translation so that the jet can stay in the screen!
        float xPosClamped = Mathf.Clamp(xPos, -horizontalClamp, horizontalClamp);
        float yPosClamped = Mathf.Clamp(yPos, -verticalClamp, verticalClamp);

        transform.localPosition = new Vector3(xPosClamped, yPosClamped, transform.localPosition.z);
    }

 //Rotations of the plane (pitch, yaw, roll) based one the position and the amount of input by the player!
 private void SetRotation() {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pithDuetoControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pithDuetoControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToThrow = xThrow * controlRollFactor;
        float roll = rollDueToThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }

 //Shooting based on player input! 
 private void SetShooting() {

     if (Input.GetButton("Fire")) {

         ActivateGun(true);
     }
     else {

         ActivateGun(false);
     }
 }

 private void ActivateGun(bool isActive) {

     foreach (GameObject gun in guns) {

         var emissionMudule = gun.GetComponent<ParticleSystem>().emission;
         emissionMudule.enabled = isActive;
     }
 }
    }



