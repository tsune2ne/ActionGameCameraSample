using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private ThirdPersonCamera thirdPersonCamera;
    [SerializeField] private LockOnCamera lockOnCamera;

    public void ActiveThirdPersonCamera()
    {
        thirdPersonCamera.gameObject.SetActive(true);
        lockOnCamera.gameObject.SetActive(false);
    }

    public void ActiveLockOnCamera()
    {
        thirdPersonCamera.gameObject.SetActive(false);
        lockOnCamera.gameObject.SetActive(true);
    }
}
