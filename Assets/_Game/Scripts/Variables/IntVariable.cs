using System;
using UnityEngine;

namespace Variables
{
    // TODO Can we use generics to avoid duplication?
    [CreateAssetMenu(fileName = "new FloatVariable", menuName = "ScriptableObjects/Variables/IntVariable")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] private int _startValue;

        private int _currentValue;
        
        public int StartValue
        {
            get => _startValue;
            set => _startValue = value;
        }

        public int Value
        {
            get => _currentValue;
            set => _currentValue = value;
        }

        public virtual void ApplyChange(int change)
        {
            _currentValue += change;
        }

        public virtual void SetValue(int newValue)
        {
            _currentValue = newValue;
        }

        private void OnEnable()
        {
            _currentValue = _startValue;
        }
    }

    public class VariableBase<T> : ScriptableObject
    {
        
    }

    public class MyIntThingie : VariableBase<int>
    {
        
    }
}
