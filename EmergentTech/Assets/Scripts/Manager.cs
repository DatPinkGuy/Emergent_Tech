using System.Collections.Generic;
using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Button[] m_livingRoomButtons;
    [SerializeField] private Button[] m_kitchenRoomButtons;
    [SerializeField] private Button[] m_bedroomRoomButtons;
    [SerializeField] private Button[] m_bathroomRoomButtons;
    [SerializeField] private Button[] m_lightsButton;
    [SerializeField] private Button[] m_decorButton;
    [SerializeField] private Button[] m_floorButton;
    [SerializeField] private Button[] m_wallButton;
    [SerializeField] private AllFurnitureScriptable m_scriptableObj;
    private List<MeshRenderer> m_wallList = new List<MeshRenderer>();
    private List<MeshRenderer> m_floorList = new List<MeshRenderer>();
    private int m_currentArrayPlace;
    private GameObject m_selectedObject;
    private Ray m_ray;
    private RaycastHit m_hit;
    public GameObject SelectedObject
    {
        get => m_selectedObject;
        set => m_selectedObject = value;
    }
    public FurniturePiece SelectedObjScript => m_selectedObject.GetComponent<FurniturePiece>();

    // Start is called before the first frame update
    void Start()
    {
        var walls = GameObject.FindGameObjectsWithTag("Wall");
        Debug.Log(walls.Length);
        foreach (var wall in walls)
        {
            m_wallList.Add(wall.GetComponent<MeshRenderer>());
        }
        var floors = GameObject.FindGameObjectsWithTag("Floor");
        foreach (var floor in floors)
        {
            m_floorList.Add(floor.GetComponent<MeshRenderer>());
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.LivingRoomPieces)
        {
            m_livingRoomButtons[m_currentArrayPlace].image.sprite = piece.MPrefabSprite;
            m_livingRoomButtons[m_currentArrayPlace].onClick.AddListener(()=>ManageObjects(piece));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.KitchenRoomPieces)
        {
            m_kitchenRoomButtons[m_currentArrayPlace].image.sprite = piece.MPrefabSprite;
            m_kitchenRoomButtons[m_currentArrayPlace].onClick.AddListener(()=>ManageObjects(piece));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.BedroomRoomPieces)
        {
            m_bedroomRoomButtons[m_currentArrayPlace].image.sprite = piece.MPrefabSprite;
            m_bedroomRoomButtons[m_currentArrayPlace].onClick.AddListener(()=>ManageObjects(piece));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.BathroomRoomPieces)
        {
            m_bathroomRoomButtons[m_currentArrayPlace].image.sprite = piece.MPrefabSprite;
            m_bathroomRoomButtons[m_currentArrayPlace].onClick.AddListener(()=>ManageObjects(piece));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.LightPieces)
        {
            m_lightsButton[m_currentArrayPlace].image.sprite = piece.MPrefabSprite;
            m_lightsButton[m_currentArrayPlace].onClick.AddListener(()=>ManageObjects(piece));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.DecorPieces)
        {
            m_decorButton[m_currentArrayPlace].image.sprite = piece.MPrefabSprite;
            m_decorButton[m_currentArrayPlace].onClick.AddListener(()=>ManageObjects(piece));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.WalLVariation)
        {
            var texture2d = (Texture2D) piece.mainTexture;
            var sprite = Sprite.Create(texture2d , new Rect(0, 0, 300, 300), Vector2.zero);
            if (texture2d != null) m_wallButton[m_currentArrayPlace].image.sprite = sprite;
            else m_wallButton[m_currentArrayPlace].image.color = piece.color;
            m_wallButton[m_currentArrayPlace].onClick.AddListener(()=>ManageMaterials(piece, 0));
            m_currentArrayPlace++;
        }
        ResetInt();
        foreach (var piece in m_scriptableObj.FloorVariation)
        {
            var texture2d = (Texture2D) piece.mainTexture;
            var sprite = Sprite.Create(texture2d , new Rect(0, 0, 300, 300), Vector2.zero);
            m_floorButton[m_currentArrayPlace].image.sprite = sprite;
            m_floorButton[m_currentArrayPlace].onClick.AddListener(()=>ManageMaterials(piece, 1));
            m_currentArrayPlace++;
        }
    }

    void ResetInt()
    {
        m_currentArrayPlace = 0;
    }

    private void ManageObjects(FurniturePiece _piece)
    {
        m_selectedObject = _piece.CreateObject();;
    }

    private void ManageMaterials(Material _material, int _id)
    {
        switch (_id)
        {
            case 0:
            {
                foreach (var wall in m_wallList)
                {
                    wall.material = _material;
                }

                break;
            }
            case 1:
            {
                foreach (var floor in m_floorList)
                {
                    floor.material = _material;
                }

                break;
            }
        }
    }

    public void RemoveObject()
    {
        if (!m_selectedObject) return;
        SelectedObjScript.DestroyObject();
    }
}
