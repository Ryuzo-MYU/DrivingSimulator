using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    //車軸ごとの情報を格納
    public List<AxleInfo> axleInfos;
    //駆動輪(自分で回転する方の車軸)の回転速度(これトルクとかいうらしい)
    public float maxMotorTorque;
    // Horizontal系の入力を受けて車輪が対応する方向を向く時の、最大角
    public float maxSteeringAngle;

    public void FixedUpdate()
    {
        // Unityお決まりのInput.GetAxis
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        //登録してある車軸ごとの処理
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //もしこの車軸がステアリングなら、車輪の向きを変化させる
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            //もしこの車軸がモーターなら車輪を回転させる
            //どうやら新colliderのwheelColliderにはmotorTorqueとかいう、回転速度のパラメータがあるよう
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            //車輪の回転を見た目に反映させる処理。今回のデバッグ対象
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
        }
    }

    /// <summary>
    /// WheelColliderの回転を対応する車輪の視覚的な回転に適用する
    /// </summary>
    /// <param name="collider"></param>
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        var visualWheel = collider.transform.GetChild(0);
        Debug.Log(visualWheel.name);
        var visualAngle = visualWheel.transform.localEulerAngles;
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.SetLocalPositionAndRotation(position, rotation);
    }
}

// 車軸の情報を格納するクラス。こんな使い方あるんだね
[System.Serializable]
public class AxleInfo
{
    public WheelCollider rightWheel;
    public WheelCollider leftWheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}
