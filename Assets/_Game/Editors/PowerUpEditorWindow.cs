using System;
using System.Linq;
using Ship;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editors
{
    public class PowerUpEditorWindow : EditorWindow
    {
        [MenuItem("Window/UI Toolkit/PowerUpEditor")]
        public static void CreateMenu()
        {
            var wnd = GetWindow<PowerUpEditorWindow>();
            wnd.titleContent = new GUIContent("PowerUpEditor");
        }
    }
}
