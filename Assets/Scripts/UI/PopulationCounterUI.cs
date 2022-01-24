using System.Collections;
using System.Collections.Generic;
using GGJ22.Variables;
using UnityEngine;

namespace GGJ22.UI
{
    public class PopulationCounterUI : MonoBehaviour
    {
        [SerializeField] private IntValue availablePopValue;       
        [SerializeField] private IntValue totalPopValue;
        [SerializeField] private TMPro.TextMeshProUGUI TMP;

        private int alocdPop
        {
            get => totalPopValue.Value - availablePopValue.Value;
            set
            {
                var alocd = totalPopValue.Value - value;
                ChangeText(alocd, totalPop);
            }
        }
        private int totalPop
        {
            get => totalPopValue.Value;
            set
            {
                ChangeText(alocdPop, value);
            }
        }

        private void Start() 
        {
            availablePopValue.Register((res) => alocdPop = res);
            totalPopValue.Register((res) => totalPop = res);
            ChangeText(alocdPop, totalPop);
        }

        private void ChangeText(int alocd, int total)
        {
            var newText = $"{alocd}/{total}";
            TMP.text = newText;
        }
    }
}
