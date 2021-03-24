using UnityEngine;

public class FurniturePiece : MonoBehaviour
{
  
    [SerializeField] private bool m_canRotate2Axis;
    [SerializeField] private Sprite m_prefabSprite;
    [SerializeField] private LayerMask m_layerToPlaceOn;
    public bool CanRotate2Axis => m_canRotate2Axis;
    public Sprite MPrefabSprite => m_prefabSprite;
    public LayerMask LayerToPlaceOn => m_layerToPlaceOn;
    public m_furnitureType m_enum;
    public enum m_furnitureType
    {
        LivingRoom,
        Kitchen,
        Bedroom,
        Bathroom,
        Lights,
        Decor
    }
    
    public GameObject CreateObject()
    {
        return Instantiate(gameObject);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
