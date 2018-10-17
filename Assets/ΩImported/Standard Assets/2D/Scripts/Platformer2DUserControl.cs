using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public float RunSpeed = 40f;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Shoot;
        private float m_HorizontalMove;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if(!m_Shoot){
                m_Shoot = CrossPlatformInputManager.GetButtonDown("Fire1");
            }
            m_HorizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * RunSpeed;
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            // Pass all parameters to the character control script.
            m_Character.Move(m_HorizontalMove * Time.fixedDeltaTime, crouch, m_Jump);
            m_Character.Shoot(m_Shoot);
            m_Jump = false;
            m_Shoot = false;
        }
    }
}
