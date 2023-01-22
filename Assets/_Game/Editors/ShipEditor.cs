using System;
using System.Linq;
using Ship;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Variables;
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
        //private ObjectField _healthField;
        private Button _loadConfigButton;
        private Button _saveConfigButton;

        //private VisualElement _partTypeField;
        //private VisualElement _gunCooldownChangeField;
        //private VisualElement _hullHealthChangeField;
        //private VisualElement _throttleChangeField;
        //private VisualElement _rotationChangeField;

        private UnityEngine.UIElements.FloatField _throttleChangeField;
        private UnityEngine.UIElements.FloatField _rotationChangeField;
        private UnityEngine.UIElements.IntegerField _hullHealthChangeField;
        private UnityEngine.UIElements.FloatField _gunCooldownChangeField;

        public override VisualElement CreateInspectorGUI()
        {
            m_VisualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/_Game/Editors/ShipEditorWindow.uxml");
            // Each editor window contains a root VisualElement object
            var ve = m_VisualTreeAsset.CloneTree();

            ShipClass = FindObjectOfType<ShipClass>();
            
            _gunCooldownChangeField = ve.Q<FloatField>("GunCooldownChangeCustom");
            _hullHealthChangeField = ve.Q<IntegerField>("HullHealthChangeCustom");
            _throttleChangeField = ve.Q<FloatField>("ThrottleChangeCustom");
            _rotationChangeField = ve.Q<FloatField>("RotationChangeCustom");
            
            _configField = ve.Q<ObjectField>("ConfigFieldCustom");
            _configField.objectType = typeof(ShipConfiguration);
            //_healthField = ve.Q<ObjectField>("HealthFieldCustom");
            //_healthField.objectType = typeof(IntVariable);
            _loadConfigButton = ve.Q<Button>("LoadConfigButton");
            _saveConfigButton = ve.Q<Button>("SaveConfigButton");

            _loadConfigButton.clicked += LoadConfiguration;
            _saveConfigButton.clicked += SaveConfiguration;

            Debug.Log("Config Field: " + _configField);
            Debug.Log("Config Button: " + _loadConfigButton);
            
            //_configField.RegisterCallback<ChangeEvent<ObjectField>>(OnObjectFieldChangedEvent);
            _configField.RegisterValueChangedCallback(OnObjectFieldChangedEvent);
            //_healthField.RegisterValueChangedCallback(OnHealthFieldChangedEvent);

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            VisualElement label = new Label("Hello World! From C#");
            ve.Add(label);

            // Instantiate UXML
            return ve;
        }

        public void LoadConfiguration()
        {
            Undo.RecordObject(ShipClass.HullScript._healthRef._intVariable, "health int");
            Undo.RecordObject(ShipClass.HullScript._healthObservable, "obs health int");
            ShipClass.LoadConfiguration();
            EditorUtility.SetDirty(ShipClass);
            EditorUtility.SetDirty(ShipClass.EngineScript);
            EditorUtility.SetDirty(ShipClass.HealthScript);
            EditorUtility.SetDirty(ShipClass.HullScript);
            EditorUtility.SetDirty(ShipClass.GunScript);
            ScriptableObject target = ShipClass.HullScript._healthRef._intVariable;
            SerializedObject so = new SerializedObject(target);
            /*so.ApplyModifiedProperties();
            so.Update();*/
            EditorUtility.SetDirty(target);
            EditorUtility.SetDirty(so.targetObject);
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public void SaveConfiguration()
        {
            ShipClass.SaveConfiguration();
        }

        public void OnObjectFieldChangedEvent(ChangeEvent<Object> evt)
        {
            Debug.Log($"Value changed. Old value: {evt.previousValue}, new value: {evt.newValue}");

            if (!ShipClass.ShipConfigSO) return;
            
            ShipClass.ShipConfigSO = (ShipConfiguration) _configField.value;
            _throttleChangeField.value = ShipClass.ShipConfigSO.ThrottlePower;
            _rotationChangeField.value = ShipClass.ShipConfigSO.RotationPower;
            _hullHealthChangeField.value = ShipClass.ShipConfigSO.MaxHealth;
            _gunCooldownChangeField.value = ShipClass.ShipConfigSO.GunCooldown;
            
            EditorUtility.SetDirty(ShipClass);
            EditorUtility.SetDirty(ShipClass.EngineScript);
            EditorUtility.SetDirty(ShipClass.HealthScript);
            EditorUtility.SetDirty(ShipClass.HullScript);
            EditorUtility.SetDirty(ShipClass.GunScript);
        }

        /*public void OnHealthFieldChangedEvent(ChangeEvent<Object> evt)
        {
            Debug.Log($"Value changed. Old value: {evt.previousValue}, new value: {evt.newValue}");
            
            //if (!ShipClass.HealthSO) return;
            
            ShipClass.HealthSO = (IntVariable) _healthField.value;
            
            ShipClass.HealthSO.Value = ShipClass.ShipConfigSO.MaxHealth;
            ShipClass.HealthSO.SetValue(ShipClass.ShipConfigSO.MaxHealth);
            
            EditorUtility.SetDirty(ShipClass.HealthSO);
        }*/
    }
}
