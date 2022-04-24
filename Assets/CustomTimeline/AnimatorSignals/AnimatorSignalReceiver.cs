using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace CustomTimeline.AnimatorSignals
{
    public class AnimatorSignalReceiver : MonoBehaviour, INotificationReceiver
    {
        private Animator _animator;


        void Awake()
        {
            _animator = GetComponent<Animator>();
            if (!_animator)
            {
                Debug.LogError("Animator not found.");
            }
        }


        public void OnNotify(Playable origin, INotification notification, object context)
        {
            var animatorSignal = notification as AnimatorMarker;
            if (null == animatorSignal)
            {
                return;
            }

            Debug.Log($"{animatorSignal.ParameterName} {notification.id}");
            switch (animatorSignal.ValueType)
            {
                case AnimatorMarker.EValueType.Trigger:
                    _animator.SetTrigger(animatorSignal.ParameterName);
                    break;
                case AnimatorMarker.EValueType.Bool:
                    _animator.SetBool(animatorSignal.ParameterName, animatorSignal.BoolValue);
                    break;
                case AnimatorMarker.EValueType.Int:
                    _animator.SetInteger(animatorSignal.ParameterName, animatorSignal.IntValue);
                    break;
                case AnimatorMarker.EValueType.Float:
                    _animator.SetFloat(animatorSignal.ParameterName, animatorSignal.FloatValue);
                    break;

                default:
                    break;
            }
        }
    }
}
