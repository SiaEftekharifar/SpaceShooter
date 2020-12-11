using System;
using UnityEngine;

public class Player : MonoBehaviour {

   [Tooltip("In m/s")] [SerializeField] float movemnetSpeed;
   [Tooltip("In m")] [SerializeField] float horizontalClamp;
   [Tooltip("In m")] [SerializeField] float verticalClamp;

   [SerializeField] float positionPitchFactor;
   [SerializeField] float controlPitchFactor;

   [SerializeField] float positionYawFactor;

   [SerializeField] float controlRollFactor;



    float xThrow, yThrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        SetTranslation();
        SetRotation();

    }


    private void SetTranslation() {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * movemnetSpeed * Time.deltaTime;
        float yOffset = yThrow * movemnetSpeed * Time.deltaTime;

        float xPos = transform.localPosition.x + xOffset;
        float yPos = transform.localPosition.y + yOffset;

        float xPosClamped = Mathf.Clamp(xPos, -horizontalClamp, horizontalClamp);
        float yPosClamped = Mathf.Clamp(yPos, -verticalClamp, verticalClamp);


        transform.localPosition = new Vector3(xPosClamped, yPosClamped, transform.localPosition.z);
    }

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


}
