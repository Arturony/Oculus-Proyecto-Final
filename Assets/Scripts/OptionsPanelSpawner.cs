using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanelSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPanel;

    private Atom currAtom;

    [SerializeField]
    private Vector3 offset;

    public void ActivatePanel(Atom atom)
    {
        currAtom = atom;

        optionsPanel.transform.position = atom.transform.position + offset;

        optionsPanel.SetActive(true);
    }

    public void DisconectAtom()
    {
        currAtom.RemoveAllBonds();
    }

    public void RemoveAtom()
    {
        currAtom.RemoveAllBonds();
        Destroy(currAtom.gameObject);
        Debug.Log("Eliminando");
    }

    public void DisablePanel()
    {
        currAtom = null;
        optionsPanel.SetActive(false);
    }
}
