using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AODice
{

    public class GameController : MonoBehaviour
    {
        [SerializeField] private DiceRemoteController _remoteController;
        [SerializeField] private Dice _dice;
        [SerializeField] private bool _checkOnlyUp;




        private void OnEnable()
        {
            _remoteController.OnClickMove += HandleOnClickRemoteControlMove;
            _dice.OnEnterTarget += HandleOnEnterTarget;
        }

        private void OnDisable()
        {
            _remoteController.OnClickMove -= HandleOnClickRemoteControlMove;
            _dice.OnEnterTarget -= HandleOnEnterTarget;
        }

        
        private void HandleOnClickRemoteControlMove(DiceTransformHandler.eMoveDirection direction)
        {
            _dice.Rotate(direction);
        }


        private void HandleOnEnterTarget(DiceInfo otherInfo)
        {
            if (_dice.info.Equals(otherInfo, _checkOnlyUp)) 
            {
                Debug.Log("성공");
            }
            else 
            {
                Debug.Log("실패");
            }
        }


    }
}
