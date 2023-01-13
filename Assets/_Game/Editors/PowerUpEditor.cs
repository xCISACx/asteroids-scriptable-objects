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

        private Slider healthSlider;

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

            _gunCooldownChangeField.visible = false;
            _hullHealthChangeField.visible = false;
            _throttleChangeField.visible = false;
            
            Debug.Log("Part Field: " + _partTypeField);
            
            _partTypeField.RegisterCallback<ChangeEvent<Enum>>(OnEnumValueChangedEvent);
            
                /*evt => {
                    Debug.Log("enum value changed");
                    ve.Q("HullHealthChange").visible = (
                        evt.newValue != PowerUp.PartType.Hull);
                });*/
            //m_VisualTreeAsset.CloneTree(root);
            
            /*// Get a reference to the slider from UXML and assign it its value.
            var uxmlSlider = root.Q<Slider>(name: "HullHealth");
            uxmlSlider.value = 10f;

            // Create a new slider, disable it, and give it a style class.
            var csharpSlider = healthSlider;
            csharpSlider.SetEnabled(false);
            csharpSlider.AddToClassList("some-styled-slider");
            csharpSlider.value = uxmlSlider.value;
            root.Add(csharpSlider);

            // Mirror value of uxml slider into the C# field.
            uxmlSlider.RegisterCallback<ChangeEvent<float>>((evt) =>
            {
                csharpSlider.value = evt.newValue;
            });*/

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
                    
                    _gunCooldownChangeField.visible = false;
                    _throttleChangeField.visible = false;
                    _rotationChangeField.visible = false;
                    _hullHealthChangeField.visible = false;
                    break;
                
                case PowerUp.PartType.Hull:
                    
                    _gunCooldownChangeField.visible = false;
                    _throttleChangeField.visible = false;
                    _rotationChangeField.visible = false;
                    _hullHealthChangeField.visible = true;
                    break;
                
                case PowerUp.PartType.Gun:
                    
                    _gunCooldownChangeField.visible = true;
                    _throttleChangeField.visible = false;
                    _rotationChangeField.visible = false;
                    _hullHealthChangeField.visible = false;
                    break;
                
                case PowerUp.PartType.Engine:
                    
                    _gunCooldownChangeField.visible = false;
                    _throttleChangeField.visible = true;
                    _rotationChangeField.visible = true;
                    _hullHealthChangeField.visible = false;
                    break;
            }
        }
    }
}
