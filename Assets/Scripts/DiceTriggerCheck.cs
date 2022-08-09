using System;
using System.Collections.Generic;
using UnityEngine;

namespace AODice
{
    public class DiceTriggerCheck : MonoBehaviour
    {
        [SerializeField] private string _tagOfTarget = "Dice_Target";


        public event Action<DiceInfo> OnEnterTarget;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals(_tagOfTarget))
            {
                OnEnterTarget?.Invoke(other.GetComponentInParent<DiceTarget>().info);
            }
        }
    }
}
