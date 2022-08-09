using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AODice
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private DiceTransformHandler _transformHandler;
        [SerializeField] private DiceTriggerCheck _diceTriggerCheck;


        public DiceInfo info;




       


        public event Action<DiceInfo> OnEnterTarget;




        private void Awake()
        {
            info = new DiceInfo();
        }

        private void OnEnable()
        {
            _diceTriggerCheck.OnEnterTarget += HandleOnEnterTarget;


        }

        private void OnDisable()
        {
            _diceTriggerCheck.OnEnterTarget -= HandleOnEnterTarget;


        }










        public void Rotate(DiceTransformHandler.eMoveDirection direction)
        {
            info.Rotate(direction);
            _transformHandler.Rotate(direction, true);
        }




        private void HandleOnEnterTarget(DiceInfo otherInfo)
        {
            OnEnterTarget?.Invoke(otherInfo);
        }
    }


    public enum eDiceDirection
    {
        Up,
        Right,
        Down,
        Left,
        Foward,
        Back
    }

    


    public enum eDiceNumber
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six
    }


    [System.Serializable]
    public class DiceInfo
    {
        public Dictionary<eDiceDirection, eDiceNumber> diceInfos;



        public DiceInfo()
        {
            diceInfos = new Dictionary<eDiceDirection, eDiceNumber>()
        {
            {eDiceDirection.Up, eDiceNumber.One },
            {eDiceDirection.Right, eDiceNumber.Three },
            {eDiceDirection.Down, eDiceNumber.Six},
            {eDiceDirection.Left, eDiceNumber.Four },
            {eDiceDirection.Foward, eDiceNumber.Two },
            {eDiceDirection.Back, eDiceNumber.Five },
        };


            /*
            //Right 한번
            diceInfos = new Dictionary<eDiceDirection, eDiceNumber>()
        {
            {eDiceDirection.Up, eDiceNumber.Four},
            {eDiceDirection.Right, eDiceNumber.One },
            {eDiceDirection.Down, eDiceNumber.Three},
            {eDiceDirection.Left, eDiceNumber.Six },
            {eDiceDirection.Foward, eDiceNumber.Two },//
            {eDiceDirection.Back, eDiceNumber.Five },//
        };

            //Left 한번
            diceInfos = new Dictionary<eDiceDirection, eDiceNumber>()
        {
            {eDiceDirection.Up, eDiceNumber.Three},
            {eDiceDirection.Right, eDiceNumber.Six,
            {eDiceDirection.Down, eDiceNumber.Four},
            {eDiceDirection.Left, eDiceNumber.One},
            {eDiceDirection.Foward, eDiceNumber.Two },//
            {eDiceDirection.Back, eDiceNumber.Five },//
        };

            //Back 한번
            diceInfos = new Dictionary<eDiceDirection, eDiceNumber>()
        {
            {eDiceDirection.Up, eDiceNumber.Two },
            {eDiceDirection.Right, eDiceNumber.Three },//
            {eDiceDirection.Down, eDiceNumber.Five},
            {eDiceDirection.Left, eDiceNumber.Four },//
            {eDiceDirection.Foward, eDiceNumber.Six },
            {eDiceDirection.Back, eDiceNumber.One },
        };

            //Foward 한번
            diceInfos = new Dictionary<eDiceDirection, eDiceNumber>()
        {
            {eDiceDirection.Up, eDiceNumber.Five },
            {eDiceDirection.Right, eDiceNumber.Three },//
            {eDiceDirection.Down, eDiceNumber.Two},
            {eDiceDirection.Left, eDiceNumber.Four },//
            {eDiceDirection.Foward, eDiceNumber.One },
            {eDiceDirection.Back, eDiceNumber.Six },
        };*/
        }


        public void Rotate(DiceTransformHandler.eMoveDirection direction)
        {

            var copyDiceInfos = diceInfos.ToDictionary(info => info.Key, info => info.Value);
            switch (direction)
            {
                case DiceTransformHandler.eMoveDirection.Right:
                    diceInfos[eDiceDirection.Up] = copyDiceInfos[eDiceDirection.Left];
                    diceInfos[eDiceDirection.Right] = copyDiceInfos[eDiceDirection.Up];
                    diceInfos[eDiceDirection.Down] = copyDiceInfos[eDiceDirection.Right];
                    diceInfos[eDiceDirection.Left] = copyDiceInfos[eDiceDirection.Down];
                    break;

                case DiceTransformHandler.eMoveDirection.Left:
                    diceInfos[eDiceDirection.Up] = copyDiceInfos[eDiceDirection.Right];
                    diceInfos[eDiceDirection.Right] = copyDiceInfos[eDiceDirection.Down];
                    diceInfos[eDiceDirection.Down] = copyDiceInfos[eDiceDirection.Left];
                    diceInfos[eDiceDirection.Left] = copyDiceInfos[eDiceDirection.Up];
                    break;

                case DiceTransformHandler.eMoveDirection.Back:
                    diceInfos[eDiceDirection.Up] = copyDiceInfos[eDiceDirection.Foward];
                    diceInfos[eDiceDirection.Down] = copyDiceInfos[eDiceDirection.Back];
                    diceInfos[eDiceDirection.Foward] = copyDiceInfos[eDiceDirection.Down];
                    diceInfos[eDiceDirection.Back] = copyDiceInfos[eDiceDirection.Up];
                    break;

                case DiceTransformHandler.eMoveDirection.Foward:
                    diceInfos[eDiceDirection.Up] = copyDiceInfos[eDiceDirection.Back];
                    diceInfos[eDiceDirection.Down] = copyDiceInfos[eDiceDirection.Foward];
                    diceInfos[eDiceDirection.Foward] = copyDiceInfos[eDiceDirection.Up];
                    diceInfos[eDiceDirection.Back] = copyDiceInfos[eDiceDirection.Down];
                    break;


            }
            
        }

        public bool Equals(DiceInfo diceInfo, bool isCheckOnlyUp)
        {
            if (isCheckOnlyUp)
            {
                return diceInfo.diceInfos[eDiceDirection.Up] == diceInfos[eDiceDirection.Up];
            }
            else
            {
                return diceInfo.diceInfos.OrderBy(info => info.Key).SequenceEqual(diceInfos.OrderBy(info => info.Key));
            }            
        }
    }
}
