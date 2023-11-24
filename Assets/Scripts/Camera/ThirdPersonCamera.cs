using Cinemachine;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCamera;
    [SerializeField] private GameObject bodyTarget;
    [SerializeField] private GameObject aimTarget;

    [SerializeField] public GameObject cameraTarget;

}
