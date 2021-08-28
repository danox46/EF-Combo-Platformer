using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        protected PlatformerCharacter2D m_Character;
        protected bool m_Jump;
        protected bool m_attack1;
        protected bool m_attack2;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        protected virtual void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_attack2 && m_Character.IsComboTime())
            {
                m_attack2 = CrossPlatformInputManager.GetButtonDown("Fire1");
            }

            if (!m_attack1)
            {
                m_attack1 = CrossPlatformInputManager.GetButtonDown("Fire1");
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

                if (m_attack1)
                    m_Character.TriggerAttacking();

                if (m_attack2)
                {
                    m_Character.TriggerCombo();
                }

                m_Character.Move(h, crouch, m_Jump);
                m_attack1 = false;
                m_attack2 = false;
                m_Jump = false;
            }

            
        }
    }
}
