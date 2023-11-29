using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private ThirdPersonCamera thirdPersonCamera;
    [SerializeField] private LockOnCamera lockOnCamera;

    public void ToggleLockOnCamera()
    {
        if (lockOnCamera.gameObject.activeSelf)
        {
            thirdPersonCamera.gameObject.SetActive(true);
            lockOnCamera.gameObject.SetActive(false);
        }
        else
        {
            thirdPersonCamera.gameObject.SetActive(false);
            lockOnCamera.gameObject.SetActive(true);
        }
    }
}
