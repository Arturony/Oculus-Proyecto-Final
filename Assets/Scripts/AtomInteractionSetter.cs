using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class AtomInteractionSetter : MonoBehaviour
{
    public InteractableUnityEventWrapper eventWrapper;

    private OptionsPanelSpawner optionsPanel;

    public Atom atom;

    private void OnEnable()
    {
        optionsPanel = FindObjectOfType<OptionsPanelSpawner>();

        eventWrapper.WhenHover.AddListener(delegate { DisablePanel(); });

        eventWrapper.WhenSelect.AddListener(delegate { ActivatePanel(atom); });
    }

    private void DisablePanel()
    {
        optionsPanel.DisablePanel();
        Debug.Log("Desactivando panel");
    }

    private void ActivatePanel(Atom atom)
    {
        optionsPanel.ActivatePanel(atom);
        Debug.Log("Activando Panel");
    }
}
