using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AODice
{
    public class DiceTransformHandler : MonoBehaviour
    {
        public enum eMoveDirection
        {
            Zero,
            Right,
            Left,
            Back,
            Foward

        }



        [SerializeField] private Transform _diceTransform;






        public void Rotate(eMoveDirection direction, bool doTrasnlate)
        {

            _diceTransform.Rotate(GetEulerWithDirection(direction),Space.World );
            
            if (doTrasnlate)
            {
                _diceTransform.Translate(GetTranlateWithDirection(direction), Space.World);
            }

        }







        private Vector3 GetEulerWithDirection(eMoveDirection direction) => direction switch
        {
            eMoveDirection.Right => Vector3.back * 90f,
            eMoveDirection.Left => Vector3.forward * 90f,
            eMoveDirection.Back => Vector3.right * 90f,
            eMoveDirection.Foward => Vector3.left * 90f,
            _ => Vector3.zero
        };


        private Vector3 GetTranlateWithDirection(eMoveDirection direction) => direction switch
        {
            eMoveDirection.Right => Vector3.right,
            eMoveDirection.Left => Vector3.left,
            eMoveDirection.Back => Vector3.forward,
            eMoveDirection.Foward => Vector3.back,
            _ => Vector3.zero
        };

    }


}
