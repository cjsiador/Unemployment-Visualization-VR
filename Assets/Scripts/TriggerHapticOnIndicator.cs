using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class TriggerHapticOnIndicator : MonoBehaviour
{
    public float duration;
    public float amplitude;
    public float frequency;
    public GrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable.WhenSelectingInteractorAdded.Action += WhenSelectingInteractorAdded_Action;
    }

    void WhenSelectingInteractorAdded_Action(GrabInteractor obj)
    {
        ControllerRef controllerRef = obj.GetComponent<ControllerRef>();
        if (controllerRef != null)
        {
            if (controllerRef.Handedness == Handedness.Right)
                TriggerHpatics(OVRInput.Controller.RTouch);
            else
                TriggerHpatics(OVRInput.Controller.LTouch);
        }
    }

    private void TriggerHpatics(OVRInput.Controller controller)
    {
        StartCoroutine(TriggerHapticsRoutine(controller));
    }

    public IEnumerator TriggerHapticsRoutine(OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
