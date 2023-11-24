using Cinemachine;
using UnityEngine;

[AddComponentMenu("")] // Don't display in add component menu
[RequireComponent(typeof(CinemachinePipeline))]
[SaveDuringPlay]
public class CinemachineTsuneBody : CinemachineComponentBase
{
    const float MinVerticalAngle = -89.9f;
    const float MaxVerticalAngle = 89.9f;

    /// <summary>障害物にあたった判定にするカメラの大きさ</summary>
    const float CameraCollisionRadius = 0.1f;

    [Header("基本設定")]
    [SerializeField, Tooltip("自機からみたカメラの位置角度。右巻きが正値。")]
    float cameraDistance = 5f;
    [SerializeField, Tooltip("自機からみたカメラの位置角度。右巻きが正値。")]
    public float horizontalAngle = 0f;
    [SerializeField, Tooltip("カメラの自機に対する高さオフセット。上向きが正値。")]
    public float verticalAngle = 0f;

    [SerializeField, Tooltip("中心位置のオフセット")] 
    private Vector3 centerOffset;

    //// 障害物情報 ////
    RaycastHit hitInfo;

    public override bool IsValid => enabled && FollowTarget != null;
    public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Body;

    public override void MutateCameraState(ref CameraState curState, float deltaTime)
    {
        Validate();
        var basePos = FollowTargetPosition + centerOffset;
        var localPos = CalculateCameraPositionByAngle(horizontalAngle, verticalAngle);
        var newPos = basePos + localPos * cameraDistance;
        
        // raycastで障害物チェック
        newPos = CheckRaycast(basePos, newPos, cameraDistance);
        
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
    
    Vector3 CheckRaycast(Vector3 basePos, Vector3 cameraPosition, float rayDistance)
    {
        // 被写体からRayを飛ばして障害物チェック
        var rayDirection = cameraPosition - basePos;
        if (Physics.SphereCast(basePos, CameraCollisionRadius, rayDirection,
            out hitInfo, rayDistance))
        {
            // 障害物にぶつかった場所をカメラの位置にする
            return hitInfo.point + hitInfo.normal * CameraCollisionRadius;
        }

        // 即座に移動
        return cameraPosition;
    }
}
