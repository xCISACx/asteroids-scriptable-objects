using System;
using System.Linq;
using Ship;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editors
{
    [CustomEditor(typeof(PowerUp))]
    public class PowerUpEditor : Editor
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        private VisualElement _partTypeField;
        private VisualElement _gunCooldownChangeField;
        private VisualElement _hullHealthChangeField;
        private VisualElement _throttleChangeField;
        private VisualElement _rotationChangeField;

        public override VisualElement CreateInspectorGUI()
        {
            // Each editor window contains a root VisualElement object
            var ve = m_VisualTreeAsset.CloneTree();
            
            _partTypeField = ve.Q("PartTypeCustom");
            _gunCooldownChangeField = ve.Q("GunCooldownChangeCustom");
            _hullHealthChangeField = ve.Q("HullHealthChangeCustom");
            _throttleChangeField = ve.Q("ThrottleChangeCustom");
            _rotationChangeField = ve.Q("RotationChangeCustom");

            _gunCooldownChangeField.style.display = DisplayStyle.None;
            _hullHealthChangeField.style.display = DisplayStyle.None;
            _throttleChangeField.style.display = DisplayStyle.None;
            _rotationChangeField.style.display = DisplayStyle.None;
            
            Debug.Log("Part Field: " + _partTypeField);
            
            _partTypeField.RegisterCallback<ChangeEvent<Enum>>(OnEnumValueChangedEvent);

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            VisualElement label = new Label("Hello World! From C#");
            ve.Add(label);

            // Instantiate UXML
            return ve;
        }

        public void OnEnumValueChangedEvent(ChangeEvent<Enum> evt)
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
        }
    }
}
