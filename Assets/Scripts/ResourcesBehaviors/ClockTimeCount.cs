using UnityEngine;
using GGJ22.Events;
using GGJ22.Variables;

namespace GGJ22.Gameplay
{
    public class ClockTimeCount : MonoBehaviour
    {
        [SerializeField] private float todayTimePassed;
        [SerializeField] private IntValue nextDayTimeSeconds;
        [SerializeField] private BoolValue isDay;

        private void Update()
        {
            todayTimePassed += Time.deltaTime;

            if(todayTimePassed >= nextDayTimeSeconds.Value)
            {
                isDay.Value = !isDay.Value;
                todayTimePassed = 0;
            }
        }
    }
}