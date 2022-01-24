using GGJ22.Variables;
using UnityEngine;

namespace GGJ22.UI
{
    public class BaseResourceCounterUI : MonoBehaviour
    {
        [SerializeField] private string resourceName = "";
        [SerializeField] private IntValue resourceValue;
        [SerializeField] private TMPro.TextMeshProUGUI TMP;

        private int total
        {
            get => resourceValue.Value;
            set
            {
                ChangeText(resourceName, value);
            }
        }

        private void Start() 
        {
            resourceValue.Register((res) => total = res);
            ChangeText(resourceName, total);
        }

        private void ChangeText(string res, int total)
        {
            var newText = $"{res}: {total}";
            TMP.text = newText;
        }
    }
}
