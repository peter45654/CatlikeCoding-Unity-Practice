using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Reference from https://catlikecoding.com/unity/tutorials/basics/game-objects-and-scripts/
//VC commit test
public class Clock : MonoBehaviour {
    #region public global variable
    public Transform tSecondArm;
    public Transform tMinuteArm;
    public Transform tHourArm;
    public bool Continuuous = true;
    #endregion
    #region private global varibal
    const float degreesPerSecond = 6f;
    const float degreesPerMinute = 6f;
    /// <summary>
    /// Degrees Per Second of Minute Arm
    /// </summary>
    const float degreesPerMinuteSecind = 0.1f;
    const float degreesPerHour = 30f;
    /// <summary>
    /// Degrees Per Minute of Hour Arm
    /// </summary>
    const float degreesPerHourMinute = 0.5f;
    #endregion
    #region Clock Finction
    void RotateArmDiscrete()
    {
        DateTime time = DateTime.Now;
        tSecondArm.localRotation =
        Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
        tMinuteArm.localRotation =
        Quaternion.Euler(0f, time.Minute * degreesPerMinute + time.Second * degreesPerMinuteSecind, 0f);
        tHourArm.localRotation =
        Quaternion.Euler(0f, time.Hour * degreesPerHour + time.Minute * degreesPerHourMinute, 0f);


    }
    void RotateArmContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        tSecondArm.localRotation =
        Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
        tMinuteArm.localRotation =
        Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute , 0f);
        tHourArm.localRotation =
        Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour , 0f);

    }
    #endregion
    #region MonoBehavior Message
    private void Awake()
    {
        if (!tSecondArm) tSecondArm = transform.Find("Second Arm").transform;
        if (!tMinuteArm) tMinuteArm = transform.Find("Minute Arm").transform;
        if (!tHourArm) tHourArm = transform.Find("Hour Arm").transform;
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second);
        if (Continuuous) {
            RotateArmContinuous();
     
        }
        else { RotateArmDiscrete(); }
    }
    #endregion
}
