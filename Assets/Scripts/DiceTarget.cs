using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AODice
{
    public class DiceTarget : MonoBehaviour
    {
        public DiceInfo info;





        private void Awake()
        {
            info = new DiceInfo();
        }
    }
}
