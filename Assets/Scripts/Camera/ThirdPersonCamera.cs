using Cinemachine;
using StarterAssets;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCamera;

    [SerializeField] private StarterAssetsInputs input;
    [SerializeField] private Vector2 inputRate = Vector2.one;
    [SerializeField] private bool lockY;
    
    private CinemachineTsuneBody body;
    private CinemachineTsuneAim aim;
    
    void Start()
    {
        body = vCamera.GetCinemachineComponent<CinemachineTsuneBody>();
        aim = vCamera.GetCinemachineComponent<CinemachineTsuneAim>();
    }

    void Update()
    {
        body.horizontalAngle += input.look.x * inputRate.x;
        if (!lockY)
        {
            body.verticalAngle += input.look.y * inputRate.y;
        }
    }
}
