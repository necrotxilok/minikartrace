using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic keyboard implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class KartInput : MonoBehaviour, IInput
    {
        public float tolerance = 0.2f;

        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        void Update ()
        {
            m_Acceleration = SimpleInput.GetAxis ("Vertical");
            if (m_Acceleration < -tolerance) 
                m_Acceleration = -1f;
            else if (m_Acceleration > tolerance)
                m_Acceleration = 1f;
            else
                m_Acceleration = 0f;

            m_Steering = SimpleInput.GetAxis ("Horizontal");
            /*
            if (m_Steering < -tolerance) 
                m_Steering = -1f;
            else if (m_Steering > tolerance)
                m_Steering = 1f;
            else
                m_Steering = 0f;
            */

            m_HopHeld = SimpleInput.GetButton ("Jump");

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= SimpleInput.GetButtonDown ("Jump");
            m_BoostPressed |= SimpleInput.GetKeyDown (KeyCode.RightShift);
            m_FirePressed |= SimpleInput.GetKeyDown (KeyCode.RightControl);
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
    }
}