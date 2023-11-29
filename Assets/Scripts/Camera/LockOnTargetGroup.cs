using System;
using Cinemachine;
using UnityEngine;

public class LockOnTargetGroup : MonoBehaviour, ICinemachineTargetGroup
{
    [NoSaveDuringPlay]
    [SerializeField] public Target playerTarget;

    [NoSaveDuringPlay]
    [SerializeField] public Target enemyTarget;

    [Tooltip("注視点の高さオフセット")]
    [SerializeField, Min(0f)] float cameraYOffset = 1f;

    [DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
    [Serializable] public struct Target
    {
        public Transform target;
        public float weight;
        public float radius;
    }

    Target[] m_Targets = Array.Empty<Target>();

    public Vector3 PlayerPosition => playerTarget.target.position;
    public Vector3 EnemyPosition => enemyTarget.target.position;

    void OnValidate()
    {
        var count = m_Targets?.Length ?? 0;
        for (var i = 0; i < count; ++i)
        {
            m_Targets[i].weight = Mathf.Max(0, m_Targets[i].weight);
            m_Targets[i].radius = Mathf.Max(0, m_Targets[i].radius);
        }
    }

    void Reset()
    {
        m_Targets = new[]{ playerTarget, enemyTarget};
    }

    public Bounds GetViewSpaceBoundingBox(Matrix4x4 observer)
    {
        // nop
        return default;
    }

    public void GetViewSpaceAngularBounds(
        Matrix4x4 observer, out Vector2 minAngles, out Vector2 maxAngles, out Vector2 zRange)
    {
        // nop
        minAngles = default;
        maxAngles = default;
        zRange = default;
    }

    public Transform Transform => transform;
    public Bounds BoundingBox => default;
    public BoundingSphere Sphere => default;
    public bool IsEmpty => m_Targets.Length == 0;
}
