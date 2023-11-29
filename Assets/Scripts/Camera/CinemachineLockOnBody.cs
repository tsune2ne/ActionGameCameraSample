using Cinemachine;
using UnityEngine;

[AddComponentMenu("")] // Don't display in add component menu
[RequireComponent(typeof(CinemachinePipeline))]
[SaveDuringPlay]
public class CinemachineLockOnBody : CinemachineComponentBase
{
    [SerializeField, Tooltip("中心位置のオフセット")] 
    private Vector3 centerOffset;

    [SerializeField, Tooltip("タゲからみて自機のどこにカメラを置くか")]
    private Vector3 offset;
    
    LockOnTargetGroup targetGroup;
    RaycastHit hitInfo;

    public override bool IsValid => enabled && FollowTarget != null;
    public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Body;

    public override void MutateCameraState(ref CameraState curState, float deltaTime)
    {
        targetGroup = AbstractLookAtTargetGroup as LockOnTargetGroup;

        var basePos = FollowTargetPosition + centerOffset;

        // タゲから自機へのベクトル
        var dir = targetGroup.PlayerPosition - targetGroup.EnemyPosition;

        // Offsetを加味してポジション計算
        var newPos = basePos + targetGroup.PlayerPosition + Quaternion.LookRotation(-dir) * offset;
        
        curState.RawPosition = newPos;
    }

    public void OnDrawGizmos()
    {
        targetGroup = AbstractLookAtTargetGroup as LockOnTargetGroup;
        var dir = targetGroup.PlayerPosition - targetGroup.EnemyPosition;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(targetGroup.EnemyPosition, targetGroup.EnemyPosition + dir);

        var pos = targetGroup.PlayerPosition + Quaternion.LookRotation(-dir) * offset;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(targetGroup.PlayerPosition, pos);
    }
}
