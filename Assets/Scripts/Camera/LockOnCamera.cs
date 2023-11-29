using Cinemachine;
using UnityEngine;

public class LockOnCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCamera;

    private CinemachineLockOnBody body;
    private CinemachineLockOnAim aim;
    
    void Start()
    {
        body = vCamera.GetCinemachineComponent<CinemachineLockOnBody>();
        aim = vCamera.GetCinemachineComponent<CinemachineLockOnAim>();
    }

    void OnDrawGizmos()
    {
        body = vCamera.GetCinemachineComponent<CinemachineLockOnBody>();
        aim = vCamera.GetCinemachineComponent<CinemachineLockOnAim>();
        body.OnDrawGizmos();
        aim.OnDrawGizmos();
    }
}
