using System;
using UnityEngine;

public class IndexFinger : MonoBehaviour
{
    [SerializeField] private bool m_useCollider;
    [SerializeField] private float m_timeout;
    [SerializeField] private Collider m_collider;
    private float m_currentPassed;
    private bool m_collisionDetected;

    private void Start()
    {
        if (!m_useCollider) m_collider.enabled = false;
    }

    void Update()
    {
        if (!m_collisionDetected) return;
        Timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_collisionDetected) return;
        SwitchState();
        m_collisionDetected = true;
    }

    void Timer()
    {
        m_currentPassed += Time.deltaTime;
        if (m_currentPassed < m_timeout) return;
        m_currentPassed = 0;
        m_collisionDetected = false;
        SwitchState();
    }

    void SwitchState()
    {
        m_collider.enabled = !m_collider.enabled;
    }
}
