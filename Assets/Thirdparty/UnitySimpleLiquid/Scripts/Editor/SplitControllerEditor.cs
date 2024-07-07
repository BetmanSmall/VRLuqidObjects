using UnityEditor;
using UnityEngine;

namespace Thirdparty.UnitySimpleLiquid.Scripts.Editor
{
    [CustomEditor(typeof(SplitController))]
    public class SplitControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var split = (SplitController)target;
            GUI.enabled = false;
            EditorGUILayout.Toggle("Is Spliting", split.IsSpliting);
            GUI.enabled = true;
        }
    }
}