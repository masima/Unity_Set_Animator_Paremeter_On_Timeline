using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Timeline;
#endif


[System.Serializable, DisplayName("Animator Signal Emitter")]
public class AnimatorMarker : Marker, INotification
{
    public PropertyName id => new PropertyName("method");


    public enum EValueType
    {
        Trigger,
        Bool,
        Int,
        Float,
    }


    public string ParameterName;
    public EValueType ValueType;
    public bool BoolValue;
    public int IntValue;
    public float FloatValue;


#if UNITY_EDITOR
    [CustomEditor(typeof(AnimatorMarker))]
    public class AnimatorMarkerEditor : Editor
    {
        private SerializedProperty _time;
        private SerializedProperty _parameterName;
        private SerializedProperty _valueType;
        private SerializedProperty _boolValue;
        private SerializedProperty _intValue;
        private SerializedProperty _floatValue;



        private void OnEnable()
        {
            _time = serializedObject.FindProperty("m_Time");
            _parameterName = serializedObject.FindProperty(nameof(AnimatorMarker.ParameterName));
            _valueType = serializedObject.FindProperty(nameof(AnimatorMarker.ValueType));
            _boolValue = serializedObject.FindProperty(nameof(AnimatorMarker.BoolValue));
            _intValue = serializedObject.FindProperty(nameof(AnimatorMarker.IntValue));
            _floatValue = serializedObject.FindProperty(nameof(AnimatorMarker.FloatValue));
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_time);
            EditorGUILayout.PropertyField(_parameterName);
            EditorGUILayout.PropertyField(_valueType);
            switch ((EValueType)_valueType.enumValueIndex)
            {
                case EValueType.Trigger:
                    break;
                case EValueType.Bool:
                    EditorGUILayout.PropertyField(_boolValue);
                    break;
                case EValueType.Int:
                    EditorGUILayout.PropertyField(_intValue);
                    break;
                case EValueType.Float:
                    EditorGUILayout.PropertyField(_floatValue);
                    break;
                default:
                    break;
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
#endif
}
