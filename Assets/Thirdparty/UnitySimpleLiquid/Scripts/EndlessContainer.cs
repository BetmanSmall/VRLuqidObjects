using UnityEngine;

namespace Thirdparty.UnitySimpleLiquid.Scripts
{
    public class EndlessContainer : MonoBehaviour
    {
        private LiquidContainer _liquidContainer;

        private void Awake()
        {
            _liquidContainer = GetComponent<LiquidContainer>();
        }

        private void Update()
        {
            _liquidContainer.FillAmountPercent = 1f;
        }
    }
}