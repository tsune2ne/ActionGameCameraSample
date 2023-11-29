using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[AddComponentMenu("")] // Don't display in add component menu
[RequireComponent(typeof(CinemachinePipeline))]
[SaveDuringPlay]
public class CinemachineLockOnAim : CinemachineComponentBase
{
    [SerializeField, Tooltip("タゲと自機のどこを注視点にするか")]
    private float rate = 0.5f;

    [SerializeField, Tooltip("注視点オフセット")]
    private Vector3 offset;
    
    LockOnTargetGroup targetGroup;

    public override bool IsValid => enabled && LookAtTarget != null;
    public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Aim;

    public override void MutateCameraState(ref CameraState curState, float deltaTime)
    {
        targetGroup = AbstractLookAtTargetGroup as LockOnTargetGroup;
        var point = Vector3.Lerp(targetGroup.PlayerPosition, targetGroup.EnemyPosition, rate);
        curState.RawOrientation = Quaternion.LookRotation(point + offset - curState.FinalPosition,
            curState.ReferenceUp);
    }
    
    public void OnDrawGizmos()
    {
        
    }
}
