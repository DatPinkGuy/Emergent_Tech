using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonPress : MonoBehaviour
{
    [SerializeField] private bool m_needsIgnoring; //not working somewhy
    [SerializeField] private bool m_needsToBeHeld;
    private Button m_button;
    private bool m_ignore;
    private void Awake()
    {
        m_button = GetComponent<Button>();
        if (m_needsIgnoring) m_ignore = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Viewport")) m_ignore = false;
        if (m_ignore) return;
        m_button.onClick.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Viewport"))
        {
            if (m_ignore) m_ignore = false;
        }
        if (m_ignore) return;
        if (!m_needsToBeHeld) return;
        m_button.onClick.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Viewport")) m_ignore = true;
    }
}
