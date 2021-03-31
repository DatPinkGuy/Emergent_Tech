using System;
using UnityEngine;

public class FurniturePiece : MonoBehaviour
{
  
    [SerializeField] private bool m_canRotate2Axis;
    [SerializeField] private Sprite m_prefabSprite;
    [SerializeField] private LayerMask m_layerToPlaceOn;
    [SerializeField] private Collider m_collider;
    public bool CanRotate2Axis => m_canRotate2Axis;
    public Sprite MPrefabSprite => m_prefabSprite;
    public LayerMask LayerToPlaceOn => m_layerToPlaceOn;
    public m_furnitureType m_enum;
    public Collider Collider => m_collider;
    public enum m_furnitureType
    {
        LivingRoom,
        Kitchen,
        Bedroom,
        Bathroom,
        Lights,
        Decor
    }

    public void OnValidate()
    {
        m_collider = GetComponent<Collider>() != null ? GetComponent<Collider>() : GetComponentInChildren<Collider>();
    }

    public GameObject CreateObject()
    {
        if(m_collider) m_collider.enabled = false;
        return Instantiate(gameObject);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
