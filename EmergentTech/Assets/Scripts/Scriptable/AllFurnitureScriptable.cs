using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "FurnitureList", menuName = "ScriptableObjects/Furniture")]
    public class AllFurnitureScriptable : ScriptableObject
    {
        [SerializeField] private List<FurniturePiece> m_allFurniture;
        [SerializeField] private List<FurniturePiece> m_livingRoomPieces;
        [SerializeField] private List<FurniturePiece> m_bathroomRoomPieces;
        [SerializeField] private List<FurniturePiece> m_bedroomRoomPieces;
        [SerializeField] private List<FurniturePiece> m_kitchenRoomPieces;
        [SerializeField] private List<FurniturePiece> m_lightPieces;
        [SerializeField] private List<FurniturePiece> m_decorPieces;
        [SerializeField] private List<Material> m_wallVariation;
        [SerializeField] private List<Material> m_floorVariation;
        public List<FurniturePiece> AllFurniture => m_allFurniture;
        public List<FurniturePiece> LivingRoomPieces => m_livingRoomPieces;
        public List<FurniturePiece> BathroomRoomPieces => m_bathroomRoomPieces;
        public List<FurniturePiece> BedroomRoomPieces => m_bedroomRoomPieces;
        public List<FurniturePiece> KitchenRoomPieces => m_kitchenRoomPieces;
        public List<FurniturePiece> LightPieces => m_lightPieces;
        public List<FurniturePiece> DecorPieces => m_decorPieces;
        public List<Material> WalLVariation => m_wallVariation;
        public List<Material> FloorVariation => m_floorVariation;
    }
}
