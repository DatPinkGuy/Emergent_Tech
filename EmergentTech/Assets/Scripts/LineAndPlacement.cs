using UnityEngine;
using UnityEngine.XR;

public class LineAndPlacement : MonoBehaviour
{
    private Ray m_ray;
    private RaycastHit m_hit;
    private Manager m_manager;
    private Transform m_transform => gameObject.transform;
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private float m_maxLineDistance;
    [Tooltip("Unchangeable size, 3 colors")]
    [SerializeField] private Color[] m_placementColors;
    private InputDevice m_leftHand;
    private InputDevice m_rightHand;
    private bool m_isPressedDelete;
    private bool m_isPressedPlace;
    private bool m_isPressedRotateLeft;
    private bool m_isPressedRotateRight;
    private bool m_pressedOnce;
    private LayerMask m_uiLayerMask = 5;
    private LayerMask m_roofLayerMask = 10;
    private LayerMask m_wallLayerMask = 9;
    private LayerMask m_floorLayerMask = 8;


    private void OnValidate()
    {
        if (m_placementColors.Length != 3)
        {
            m_placementColors = new Color[3];
        }
    }

    void Start()
    {
        m_lineRenderer.enabled = false;
        m_manager = FindObjectOfType<Manager>();
        m_leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        m_rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
       ManageRays();
    }

    private void ManageRays()
    {
        m_ray = new Ray(m_transform.position, m_transform.forward);
        m_lineRenderer.endColor = m_placementColors[0];
        if (!Physics.Raycast(m_ray, out m_hit, m_maxLineDistance))
        {
            if(!m_manager.SelectedObject) m_lineRenderer.enabled = false;
            else
            {
                var endPoint = m_transform.position + m_maxLineDistance * m_transform.forward;
                ManageMovementLine(endPoint);
                m_manager.SelectedObject.transform.position = endPoint;
            }
        }
        else
        {
            var hitLayer = m_hit.transform.gameObject.layer;
            if(!m_manager.SelectedObject)
            {
                if (hitLayer == m_uiLayerMask) ManageUILine();
                else m_lineRenderer.enabled = false;
            }
            else
            {
                var layerMaskToHit = m_manager.SelectedObjScript.LayerToPlaceOn;
                var layer = Mathf.RoundToInt(Mathf.Log(layerMaskToHit.value, 2));
                if (hitLayer == layer)
                {
                    ManageMovementLine(m_hit.point);
                    m_lineRenderer.endColor = m_placementColors[2];
                    m_manager.SelectedObject.transform.position = m_hit.point;
                    Rotate();
                    PlaceObject();
                }
                else
                {
                    ManageMovementLine(m_hit.point);
                    m_lineRenderer.endColor = m_placementColors[1];
                    m_manager.SelectedObject.transform.position = m_hit.point;
                }
            }
            CheckForRemoval();
        }
    }

    private void ManageUILine()
    {
        SetLinePosition(m_hit.point);
        m_lineRenderer.enabled = true;
    }

    private void ManageMovementLine(Vector3 _position)
    {
        SetLinePosition(_position);
        m_lineRenderer.enabled = true;
    }

    private void SetLinePosition(Vector3 _whereToPlace)
    {
        m_lineRenderer.SetPosition(0, m_transform.position);
        m_lineRenderer.SetPosition(1, _whereToPlace);
    }

    private void CheckForRemoval()
    {
        if(m_rightHand.TryGetFeatureValue(CommonUsages.secondaryButton,out m_isPressedDelete) && m_isPressedDelete)
            m_manager.RemoveObject();
    }

    private void PlaceObject()
    {
        if(m_rightHand.TryGetFeatureValue(CommonUsages.triggerButton,out m_isPressedPlace) && m_isPressedPlace)
            m_manager.SelectedObject = null;
    }

    private void Rotate()
    {
        if (m_leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out m_isPressedRotateLeft) &&
            m_isPressedRotateLeft && !m_pressedOnce)
        {
            m_manager.SelectedObject.transform.Rotate(0,0, 15);
            m_pressedOnce = true;
        }
        if (m_leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out m_isPressedRotateRight) &&
            m_isPressedRotateRight && !m_pressedOnce)
        {
            m_manager.SelectedObject.transform.Rotate(0,0, -15);
            m_pressedOnce = true;
        }
        if (!m_isPressedRotateLeft && !m_isPressedRotateRight) m_pressedOnce = false;
    }
}
