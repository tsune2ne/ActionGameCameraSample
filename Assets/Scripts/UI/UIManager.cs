using StarterAssets;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs inputs;
    [SerializeField] private CameraManager cameraManager;
    
    public void OnClickJump()
    {
        inputs.jump = true;
    }

    public void OnClickLockOn()
    {
        cameraManager.ToggleLockOnCamera();
    }
}
