using UnityEngine;
using System.Collections;

public class ChangeInput : MonoBehaviour, IGvrGazeResponder {
    public void OnGazeEnter()
    {
        InputManager.Instance.NextInputMode();
    }

    public void OnGazeExit()
    {
    }

    public void OnGazeTrigger()
    {
    }
}
