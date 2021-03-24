using System;
using Scriptable;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(AllFurnitureScriptable))]
    public class SortFurnitureEditor : UnityEditor.Editor
    {
        private AllFurnitureScriptable m_scriptableObj;
        private SerializedProperty m_allFurniture;
        private SerializedProperty m_livingRoom;
        private SerializedProperty m_bathroom;
        private SerializedProperty m_bedroom;
        private SerializedProperty m_kitchen;
        private SerializedProperty m_lights;
        private SerializedProperty m_decor;
        private SerializedProperty m_wall;
        private SerializedProperty m_floor;
        private void OnEnable()
        {
            m_scriptableObj = (AllFurnitureScriptable) target;
            m_allFurniture = serializedObject.FindProperty("m_allFurniture");
            m_livingRoom = serializedObject.FindProperty("m_livingRoomPieces");
            m_bathroom = serializedObject.FindProperty("m_bathroomRoomPieces");
            m_bedroom = serializedObject.FindProperty("m_bedroomRoomPieces");
            m_kitchen = serializedObject.FindProperty("m_kitchenRoomPieces");
            m_lights = serializedObject.FindProperty("m_lightPieces");
            m_decor = serializedObject.FindProperty("m_decorPieces");
            m_wall = serializedObject.FindProperty("m_wallVariation");
            m_floor = serializedObject.FindProperty("m_floorVariation");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_allFurniture);
            if (GUILayout.Button("Sort Furniture", GUILayout.Width(150f))) Sort();
            EditorGUILayout.LabelField("Sorted Furniture", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_livingRoom);
            EditorGUILayout.PropertyField(m_bathroom);
            EditorGUILayout.PropertyField(m_bedroom);
            EditorGUILayout.PropertyField(m_kitchen);
            EditorGUILayout.PropertyField(m_lights);
            EditorGUILayout.PropertyField(m_decor);
            EditorGUILayout.LabelField("Materials", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(m_wall);
            EditorGUILayout.PropertyField(m_floor);
            serializedObject.ApplyModifiedProperties();
        }

        private void Sort()
        {
            m_scriptableObj.LivingRoomPieces.Clear();
            m_scriptableObj.BedroomRoomPieces.Clear();
            m_scriptableObj.BathroomRoomPieces.Clear();
            m_scriptableObj.KitchenRoomPieces.Clear();
            m_scriptableObj.LightPieces.Clear();
            m_scriptableObj.DecorPieces.Clear();
            foreach (var furniture in m_scriptableObj.AllFurniture)
            {
                switch (furniture.m_enum)
                {
                    case FurniturePiece.m_furnitureType.LivingRoom:
                        m_scriptableObj.LivingRoomPieces.Add(furniture);
                        break;
                    case FurniturePiece.m_furnitureType.Bathroom:
                        m_scriptableObj.BathroomRoomPieces.Add(furniture);
                        break;
                    case FurniturePiece.m_furnitureType.Bedroom:
                        m_scriptableObj.BedroomRoomPieces.Add(furniture);
                        break;
                    case FurniturePiece.m_furnitureType.Kitchen:
                        m_scriptableObj.KitchenRoomPieces.Add(furniture);
                        break;
                    case FurniturePiece.m_furnitureType.Lights:
                        m_scriptableObj.LightPieces.Add(furniture);
                        break;
                    case FurniturePiece.m_furnitureType.Decor:
                        m_scriptableObj.DecorPieces.Add(furniture);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
