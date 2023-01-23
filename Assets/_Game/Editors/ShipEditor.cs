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
        private Button _loadConfigButton;
        private Button _saveConfigButton;

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

            _loadConfigButton = ve.Q<Button>("LoadConfigButton");
            _saveConfigButton = ve.Q<Button>("SaveConfigButton");

            _loadConfigButton.clicked += LoadConfiguration;
            _saveConfigButton.clicked += SaveConfiguration;

            _configField.RegisterValueChangedCallback(OnObjectFieldChangedEvent);

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
    }
}
