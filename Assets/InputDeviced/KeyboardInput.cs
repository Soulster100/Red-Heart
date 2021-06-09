using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MrXMssProduction 
{

    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManger.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManger.Instance.MoveRight = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManger.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManger.Instance.MoveLeft = false;
            }
        }
    }

}