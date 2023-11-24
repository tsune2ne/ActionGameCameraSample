using StarterAssets;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCameraPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;

    private bool isDragging;
    private Vector2 prev;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        prev = eventData.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            starterAssetsInputs.look = eventData.delta;
            prev = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        prev = Vector2.zero;
        starterAssetsInputs.look = prev;
    }
}
