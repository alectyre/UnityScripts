using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

// [System.Flags]
// public enum MyMaskedEnum { ON = 1, OFF = 2, FISH = 4, STEVE = 8, BANANA = 16 }
//
// [EnumMaskAttribute] MyMaskedEnum m_flags;

public class EnumMaskAttribute : PropertyAttribute { }


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(EnumMaskAttribute))]
public class EnumMaskAttributeDrawer : PropertyDrawer {

    //public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    //{
    //    EditorGUI.showMixedValue = _property.hasMultipleDifferentValues;
    //    _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
    //}

    public override void OnGUI(Rect _position, UnityEditor.SerializedProperty _property, GUIContent _label)
    {
        EditorGUI.showMixedValue = _property.hasMultipleDifferentValues;
        // Change check is needed to prevent values being overwritten during multiple-selection
        UnityEditor.EditorGUI.BeginChangeCheck();
        int newValue = UnityEditor.EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        if (UnityEditor.EditorGUI.EndChangeCheck())
        {
            _property.intValue = newValue;
        }
    }
}

#endif