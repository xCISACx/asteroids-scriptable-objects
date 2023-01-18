using System;
using System.Linq;
using Ship;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Editors
{
    [CustomEditor(typeof(ShipClass))]
    public class ShipEditor : Editor
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        public ShipClass ShipClass;

        private ObjectField _configField;
        private Button _loadConfigButton;

        /*private VisualElement _partTypeField;
        private VisualElement _gunCooldownChangeField;
        private VisualElement _hullHealthChangeField;
        private VisualElement _throttleChangeField;
        private VisualElement _rotationChangeField;*/

        public override VisualElement CreateInspectorGUI()
        {
            m_VisualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/_Game/Editors/ShipEditorWindow.uxml");
            // Each editor window contains a root VisualElement object
            var ve = m_VisualTreeAsset.CloneTree();

            ShipClass = FindObjectOfType<ShipClass>();
            
            _configField = ve.Q<ObjectField>("ConfigFieldCustom");
            _loadConfigButton = ve.Q<Button>("LoadConfigButton");

            _loadConfigButton.clicked += LoadConfiguration;
            
            /*_partTypeField = ve.Q("PartTypeCustom");
            _gunCooldownChangeField = ve.Q("GunCooldownChangeCustom");
            _hullHealthChangeField = ve.Q("HullHealthChangeCustom");
            _throttleChangeField = ve.Q("ThrottleChangeCustom");
            _rotationChangeField = ve.Q("RotationChangeCustom");

            _gunCooldownChangeField.style.display = DisplayStyle.None;
            _hullHealthChangeField.style.display = DisplayStyle.None;
            _throttleChangeField.style.display = DisplayStyle.None;
            _rotationChangeField.style.display = DisplayStyle.None;*/
            
            Debug.Log("Config Field: " + _configField);
            Debug.Log("Config Button: " + _loadConfigButton);
            
            //_configField.RegisterCallback<ChangeEvent<ObjectField>>(OnObjectFieldChangedEvent);
            _configField.RegisterValueChangedCallback(OnObjectFieldChangedEvent);

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            VisualElement label = new Label("Hello World! From C#");
            ve.Add(label);

            // Instantiate UXML
            return ve;
        }

        public void LoadConfiguration()
        {
            ShipClass.LoadConfiguration();
            EditorUtility.SetDirty(ShipClass.ShipConfigSO);
        }

        /*public void SaveConfiguration()
        {
            ShipClass.SaveConfiguration();
        }*/

        public void OnObjectFieldChangedEvent(ChangeEvent<Object> evt)
        {
            Debug.Log($"Value changed. Old value: {evt.previousValue}, new value: {evt.newValue}");

            if (!ShipClass.ShipConfigSO) return;
            
            ShipClass.ShipConfigSO = (ShipConfiguration) _configField.value;
        }

        /*public void OnEnumValueChangedEvent(ChangeEvent<Enum> evt)
        {
            Debug.Log($"Enum changed. Old value: {evt.previousValue}, new value: {evt.newValue}");

            switch (evt.newValue)
            {
                case PowerUp.PartType.None:
                    
                    _gunCooldownChangeField.style.display = DisplayStyle.None;
                    _throttleChangeField.style.display = DisplayStyle.None;
                    _rotationChangeField.style.display = DisplayStyle.None;
                    _hullHealthChangeField.style.display = DisplayStyle.None;
                    break;
                
                case PowerUp.PartType.Hull:
                    
                    _gunCooldownChangeField.style.display = DisplayStyle.None;
                    _throttleChangeField.style.display = DisplayStyle.None;
                    _rotationChangeField.style.display = DisplayStyle.None;
                    _hullHealthChangeField.style.display = DisplayStyle.Flex;
                    break;
                
                case PowerUp.PartType.Gun:
                    
                    _gunCooldownChangeField.style.display = DisplayStyle.Flex;
                    _throttleChangeField.style.display = DisplayStyle.None;
                    _rotationChangeField.style.display = DisplayStyle.None;
                    _hullHealthChangeField.style.display = DisplayStyle.None;
                    break;
                
                case PowerUp.PartType.Engine:
                    
                    _gunCooldownChangeField.style.display = DisplayStyle.None;
                    _throttleChangeField.style.display = DisplayStyle.Flex;
                    _rotationChangeField.style.display = DisplayStyle.Flex;
                    _hullHealthChangeField.style.display = DisplayStyle.None;
                    break;
            }
        }*/
    }
}
