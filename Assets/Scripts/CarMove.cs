using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    //�Ԏ����Ƃ̏����i�[
    public List<AxleInfo> axleInfos;
    //�쓮��(�����ŉ�]������̎Ԏ�)�̉�]���x(����g���N�Ƃ������炵��)
    public float maxMotorTorque;
    // Horizontal�n�̓��͂��󂯂Ďԗւ��Ή�����������������́A�ő�p
    public float maxSteeringAngle;

    public void FixedUpdate()
    {
        // Unity�����܂��Input.GetAxis
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        //�o�^���Ă���Ԏ����Ƃ̏���
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //�������̎Ԏ����X�e�A�����O�Ȃ�A�ԗւ̌�����ω�������
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            //�������̎Ԏ������[�^�[�Ȃ�ԗւ���]������
            //�ǂ����Vcollider��wheelCollider�ɂ�motorTorque�Ƃ������A��]���x�̃p�����[�^������悤
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            //�ԗւ̉�]�������ڂɔ��f�����鏈���B����̃f�o�b�O�Ώ�
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
        }
    }

    /// <summary>
    /// WheelCollider�̉�]��Ή�����ԗւ̎��o�I�ȉ�]�ɓK�p����
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

// �Ԏ��̏����i�[����N���X�B����Ȏg��������񂾂�
[System.Serializable]
public class AxleInfo
{
    public WheelCollider rightWheel;
    public WheelCollider leftWheel;
    public bool motor; //�쓮�ւ�?
    public bool steering; //�n���h������������Ƃ��Ɋp�x���ς�邩�H
}
