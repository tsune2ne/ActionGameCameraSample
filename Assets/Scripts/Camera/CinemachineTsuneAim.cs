using Cinemachine;
using UnityEngine;

[AddComponentMenu("")] // Don't display in add component menu
[RequireComponent(typeof(CinemachinePipeline))]
[SaveDuringPlay]
public class CinemachineTsuneAim : CinemachineComponentBase
{
    [SerializeField, Tooltip("注視点オフセット")] 
    Vector3 centerOffset;

    public override bool IsValid => enabled && LookAtTarget != null;
    public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Aim;

    public override void MutateCameraState(ref CameraState curState, float deltaTime)
    {
        // 上方向を維持して向き先を変える
        var pos = LookAtTargetPosition - curState.FinalPosition + centerOffset;
        curState.RawOrientation = Quaternion.LookRotation(pos,curState.ReferenceUp);
    }
}
