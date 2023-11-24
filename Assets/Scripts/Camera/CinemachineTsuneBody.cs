using Cinemachine;
using UnityEngine;

[AddComponentMenu("")] // Don't display in add component menu
[RequireComponent(typeof(CinemachinePipeline))]
[SaveDuringPlay]
public class CinemachineTsuneBody : CinemachineComponentBase
{
    const float MinVerticalAngle = -89.9f;
    const float MaxVerticalAngle = 89.9f;

    [Header("基本設定")]
    [SerializeField, Tooltip("自機からみたカメラの位置角度。右巻きが正値。")]
    float cameraDistance = 5f;
    [SerializeField, Tooltip("自機からみたカメラの位置角度。右巻きが正値。")]
    float horizontalAngle = 0f;
    [SerializeField, Tooltip("カメラの自機に対する高さオフセット。上向きが正値。")]
    float verticalAngle = 0f;

    [SerializeField, Tooltip("中心位置のオフセット")] 
    private Vector3 centerOffset;

    public override bool IsValid => enabled && FollowTarget != null;
    public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Body;

    public override void MutateCameraState(ref CameraState curState, float deltaTime)
    {
        Validate();
        var basePos = FollowTargetPosition + centerOffset;
        var localPos = CalculateCameraPositionByAngle(horizontalAngle, verticalAngle);
        var newPos = basePos + localPos * cameraDistance;
        // カメラ操作時以外はスムーズにカメラ移動
        curState.RawPosition = newPos;
    }

    void Validate()
    {
        verticalAngle = Mathf.Clamp(verticalAngle, MinVerticalAngle, MaxVerticalAngle);
    }
    
    static Vector3 CalculateCameraPositionByAngle(float xAngle, float yAngle)
    {
        // 設定角度からカメラ座標を計算
        var xRadian = -(180 + xAngle % 360) * Mathf.PI / 180;
        var yRadian = yAngle % 360 * Mathf.PI / 180;
        return new Vector3(
            Mathf.Cos(yRadian) * Mathf.Sin(xRadian),
            Mathf.Sin(yRadian),
            Mathf.Cos(yRadian) * Mathf.Cos(xRadian)
        );
    }
}
