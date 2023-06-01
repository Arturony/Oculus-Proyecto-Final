using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.TubeRenderer;

public class BondMover : MonoBehaviour
{
    private Atom firstAtom;
    private Atom secondAtom;
    private float offset;

    public void SetAtoms(Atom atom1, Atom atom2, float offset)
    {
        firstAtom = atom1;
        secondAtom = atom2;
        this.offset = offset;
    }

    public void UpdatePositons(Atom atom)
    {
        TubeRenderer t = GetComponent<TubeRenderer>();
        if(atom == firstAtom)
        {
            t.positions[0] = atom.transform.position + new Vector3(0, offset, 0);
        }
        else
        {
            t.positions[1] = atom.transform.position + new Vector3(0, offset, 0);
        }
    }
}
