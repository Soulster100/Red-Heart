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
            
        }
        float Speed = 3f;
        public Animator animator;

        void Update()
        {            
                             
                /////// NO MOVE A&D SAME TIME BABEE
                if (VirtualInputManger.Instance.MoveRight && VirtualInputManger.Instance.MoveLeft)
                {
                    animator.SetBool(TransitionParameter.Move.ToString(), false);
                    
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
    }
}

