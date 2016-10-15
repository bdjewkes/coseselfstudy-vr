using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : Singleton<InputManager>
{
    public enum InputMode
    {
        None,
        LocomotionTool,
        SelectionTool
    }

    public InputMode CurrentMode;

    protected InputManager() { }

    [SerializeField] Dictionary<InputMode, Material> ReticleMode = new Dictionary<InputMode, Material>();
    private Material GetReticleMaterial(InputMode mode)
    {
        if (!ReticleMode.ContainsKey(mode))
            ReticleMode.Add(mode, Resources.Load(mode.ToString()) as Material);
        return ReticleMode[mode];
    }

    [ContextMenu("Next")]
    public void NextInputMode()
    {
        var modes = (InputMode[])Enum.GetValues(typeof(InputMode));
        var current = Array.IndexOf(modes, CurrentMode);
        var next = current + 1;
        if (next >= modes.Length) next = 0;
        SetInputMode(modes[next]);
    }

    public void SetInputMode(InputMode mode)
    {
        SetReticle(mode);
        CurrentMode = mode;
    }

    private void SetReticle(InputMode mode)
    {
        Camera.main.GetComponentInChildren<GvrReticle>().GetComponent<Renderer>().material.color = GetReticleMaterial(mode).color;
    }
}
