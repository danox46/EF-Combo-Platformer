using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterCodeController : MonoBehaviour
{
    protected CharacterCodePowers m_Character;
    protected bool m_Jump;
    protected int m_attack;
    protected bool m_Pause;


    private void Awake()
    {
        m_Character = GetComponent<CharacterCodePowers>();
    }


    protected virtual void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        if(!m_Pause)
            m_Pause = CrossPlatformInputManager.GetButtonDown("Pause");

        if (!m_Character.changingColor)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                m_attack = 1;
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire2"))
            {
                m_attack = 2;
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire3"))
            {
                m_attack = 3;
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire4"))
            {
                m_attack = 4;
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire5"))
            {
                m_attack = 5;
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire6"))
            {
                m_attack = 6;
            }
        }

        

    }


    protected virtual void FixedUpdate()
    {
        if (m_Character.gameObject.layer == 6)
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.

            if (m_attack > 0)
                m_Character.SetAttackCodeInput(m_attack);

            m_Character.Move(h, crouch, m_Jump);
            m_attack = 0;
            m_Jump = false;
        }

        if (m_Pause)
        {

            m_Character.uI.SetActive(!m_Character.uI.activeSelf);
        }

        m_Pause = false;

    }
}
