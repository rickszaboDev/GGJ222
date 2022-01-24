using GGJ22.Variables;
using UnityEngine;

namespace GGJ22.Gameplay
{
    public class ResourceProduces : MonoBehaviour
    {
        [SerializeField] private IntValue resourceValue;
        [SerializeField] private IntValue availablePopValue;
        [SerializeField] private int resPerClock = 0;
        [SerializeField] private int timeInSecPerClock = 0;
        [SerializeField] private int popAlocd = 1;
        private float timePassed = 0;
        private bool alocd = false;

        private void Callback(int res)
        {
            if(res < 0 && alocd)
            {
                alocd = false;
                availablePopValue.Value += popAlocd;
            }
            else if(res >= popAlocd && !alocd) 
            {
                alocd = true;
                availablePopValue.Value -= popAlocd;
            }
        }

        private void Update() 
        {
            if(!alocd) return;

            timePassed += Time.deltaTime;

            if(timePassed >= timeInSecPerClock)
            {
                timePassed = 0;
                resourceValue.Value += resPerClock;
            }
        }

        private void OnEnable()
        {
            availablePopValue.Register(Callback);    

            int pop = availablePopValue.Value;
            if(pop >= popAlocd)
            {
                availablePopValue.Value -= popAlocd;
                alocd = true;
            }
        }

        private void OnDisable() 
        {
            availablePopValue.Unregister(Callback);    

            if(alocd)
            {
                availablePopValue.Value += popAlocd;
                alocd = false;
            }
        }
    }
}
