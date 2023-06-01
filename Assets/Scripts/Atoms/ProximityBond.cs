using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityBond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Atom atom = other.GetComponent<Atom>();
        if(atom)
        {
            Atom thisAtom = this.GetComponentInParent<Atom>();

            int oxState = 0;
            if (atom.prefferedOxidationState < thisAtom.prefferedOxidationState)
                oxState = atom.prefferedOxidationState;
            else
                oxState = thisAtom.prefferedOxidationState;

            if(atom.CanBond(oxState) && thisAtom.CanBond(oxState))
            {
                atom.AddElectrons(oxState);
                thisAtom.AddElectrons(oxState);
                BondCreator bc = FindObjectOfType<BondCreator>();
                bc.CreateMeshBond(atom, thisAtom, oxState);
            }
        }
    }
}
