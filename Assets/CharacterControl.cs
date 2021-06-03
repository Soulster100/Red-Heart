using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MrXMssProduction
{
    public class CharacterControl : MonoBehaviour
    {
        public enum TransitionParameter
        {
            Move,
            Sprint
        }
        float Speed = 3f;
        public Animator animator;
        public float maxStamina = 200f;
        public float currentStamina;

        bool _tired = false;

        private void Start()
        {
            currentStamina = maxStamina;
        }

        void Update()
        {
            /////// Sprint START-----------
            if (currentStamina > maxStamina)
            {
                _tired = false;
                currentStamina = maxStamina;
            }

            if (_tired == false)
            {
                Speed = 3;
                if (VirtualInputManger.Instance.Sprint)
                {

                    if (currentStamina <= 0)
                    {
                        VirtualInputManger.Instance.Sprint = false;
                        animator.SetBool(TransitionParameter.Move.ToString(), true);
                        _tired = true;
                        return;
                    }

                    if (currentStamina <= maxStamina)
                    {
                        Speed = 9;
                        currentStamina = currentStamina - 1f;
                        animator.SetBool(TransitionParameter.Sprint.ToString(), true);
                        Debug.Log(currentStamina);
                    }
                }

                /////// Sprint End-----------

                /////// NO MOVE A&D SAME TIME BABEE
                if (VirtualInputManger.Instance.MoveRight && VirtualInputManger.Instance.MoveLeft)
                {
                    animator.SetBool(TransitionParameter.Move.ToString(), false);
                    animator.SetBool(TransitionParameter.Sprint.ToString(), false);
                    return;
                }
                /////// NO MOVE GENERAL PELOTUDO
                if (!VirtualInputManger.Instance.MoveRight && !VirtualInputManger.Instance.MoveLeft)
                {
                    animator.SetBool(TransitionParameter.Move.ToString(), false);
                }
                /////ADELANTE Y ATRAS START

                if (VirtualInputManger.Instance.MoveRight)
                {
                    this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    animator.SetBool(TransitionParameter.Move.ToString(), true);
                }

                if (VirtualInputManger.Instance.MoveLeft)
                {
                    this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    animator.SetBool(TransitionParameter.Move.ToString(), true);
                }

            }
            else if (_tired == true)
            {
                Speed = 0.0f;
                currentStamina = currentStamina + 1f;
                animator.SetBool(TransitionParameter.Sprint.ToString(), false);
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            Debug.Log(_tired);
            /////ADELANTE Y ATRAS END          

        }
    }
}

