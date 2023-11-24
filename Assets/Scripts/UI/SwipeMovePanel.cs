using StarterAssets;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMovePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;

    private bool isDragging;
    private Vector2 start;
    private Vector2 move;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        start = eventData.position;
        move = Vector2.zero;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            starterAssetsInputs.move = eventData.position - start;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        starterAssetsInputs.move = Vector2.zero;
    }
}
