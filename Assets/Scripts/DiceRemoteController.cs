using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AODice
{
    public class DiceRemoteController : MonoBehaviour
    {
        [SerializeField] private Button _buttonRight;
        [SerializeField] private Button _buttonLeft;
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonFoward;
        [SerializeField] private Button _buttonReset;




        public event Action<DiceTransformHandler.eMoveDirection> OnClickMove;


        private void OnEnable()
        {
            _buttonRight.onClick.AddListener(HandleOnClickRight);
            _buttonLeft.onClick.AddListener(HandleOnClickLeft);
            _buttonBack.onClick.AddListener(HandleOnClickBack);
            _buttonFoward.onClick.AddListener(HandleOnClickFoward);
            _buttonReset.onClick.AddListener(HandleOnClickFoward);
        }


        private void OnDisable()
        {
            _buttonRight.onClick.RemoveListener(HandleOnClickRight);
            _buttonLeft.onClick.RemoveListener(HandleOnClickLeft);
            _buttonBack.onClick.RemoveListener(HandleOnClickBack);
            _buttonReset.onClick.RemoveListener(HandleOnClickReset);
        }

        private void HandleOnClickRight()
        {
            OnClickMove?.Invoke(DiceTransformHandler.eMoveDirection.Right);
        }

        private void HandleOnClickLeft()
        {
            OnClickMove?.Invoke(DiceTransformHandler.eMoveDirection.Left);
        }

        private void HandleOnClickBack()
        {
            OnClickMove?.Invoke(DiceTransformHandler.eMoveDirection.Back);
        }

        private void HandleOnClickFoward()
        {
            OnClickMove?.Invoke(DiceTransformHandler.eMoveDirection.Foward);
        }

        private void HandleOnClickReset()
        {
            OnClickMove?.Invoke(DiceTransformHandler.eMoveDirection.Zero);
        }
    }

}
