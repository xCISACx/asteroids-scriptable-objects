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
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [MenuItem("Window/UI Toolkit/PowerUpEditor")]
        public static void ShowExample()
        {
            var wnd = GetWindow<PowerUpEditorWindow>();
            wnd.titleContent = new GUIContent("PowerUpEditor");
        }
        
        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            //VisualElement label = new Label("Hello World! From C#");
            //root.Add(label);

            // Instantiate UXML
            VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
            root.Add(labelFromUXML);
        }
    }
}
