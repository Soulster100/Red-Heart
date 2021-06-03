using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MrXMssProduction
{
    public class CharacterControl : MonoBehaviour
    {
        public enum TransitionParameter
        {
            move,
        }

        public float Speed;
        public Animator animator; 
        void Update()
        {
            if (VirtualInputManger.Instance.MoveRight && VirtualInputManger.Instance.MoveLeft)
            {
                animator.SetBool(TransitionParameter.move.ToString(), false);
                return;
            }

            if (!VirtualInputManger.Instance.MoveRight && !VirtualInputManger.Instance.MoveLeft)
            {
                animator.SetBool(TransitionParameter.move.ToString(), false);
            }

            if (VirtualInputManger.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }

            if (VirtualInputManger.Instance.MoveLeft)
            {
                this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                animator.SetBool(TransitionParameter.move.ToString(), true);
            }
         
        }
    }
}

