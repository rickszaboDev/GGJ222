using GGJ22.Variables;
using UnityEngine;

namespace GGJ22.Gameplay
{
    public class PopulationController : MonoBehaviour
    {
        [SerializeField] private IntValue availablePopulationValue;
        [SerializeField] private IntValue totalPopulationValue;
        [SerializeField] private IntValue foodResourceValue;
        [SerializeField] private BoolValue isDayValue;

        [SerializeField] private int foodPerPopulationPerDay = 5;

        private int totalPopulation = 0;
        
        private void Start() 
        {
            Callback(totalPopulationValue.Value);
        }

        private void Callback(int res)
        {
            var diff = res - totalPopulation;
            availablePopulationValue.Value += diff;
            totalPopulation = res;
        }

        private void OnEnable() 
        {
            totalPopulationValue.Register(Callback);   
            isDayValue.Register(OnDayPassed); 
        }

        private void OnDisable()
        {
            totalPopulationValue.Unregister(Callback);
            isDayValue.Unregister(OnDayPassed);
        }

        public void OnDayPassed(bool _)
        {
            var foodConsumed = totalPopulation * foodPerPopulationPerDay;
            var foodLeftOver = foodResourceValue.Value - foodConsumed;
            foodResourceValue.Value = foodLeftOver >= 0 ? foodLeftOver : 0;
        }
    }
}
