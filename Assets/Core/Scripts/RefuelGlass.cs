using System.Collections;
using Thirdparty.UnitySimpleLiquid.Scripts;
using UnityEngine;
using Zelude;

namespace Core.Scripts
{
    [RequireComponent(typeof(LiquidContainer))]
    public class RefuelGlass : MonoBehaviour
    {
        [SerializeField] private LiquidContainer liquidContainer;
        [SerializeField, MinMaxSlider(0f, 1f)] private Vector2 refuelRange = new(0.01f, 0.8f);
        [SerializeField] private float deltaRefuel = 0.0001f;

        private void Start()
        {
            liquidContainer = GetComponent<LiquidContainer>();
        }

        private void Update()
        {
            if (liquidContainer.FillAmountPercent <= refuelRange.x)
            {
                StartCoroutine(Refuel());
            }
        }

        private IEnumerator Refuel()
        {
            while (liquidContainer.FillAmountPercent <= refuelRange.y)
            {
                liquidContainer.FillAmountPercent += deltaRefuel;
                yield return null;
            }
        }
    }
}