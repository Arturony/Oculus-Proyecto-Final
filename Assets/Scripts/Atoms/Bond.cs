using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond : MonoBehaviour
{
    public Atom to;
    public Atom from;
    public int numBonds;
    private BondMover bm;

    public void SetBond(Atom to, Atom from, int numBonds, BondMover bm)
    {
        this.to = to;
        this.from = from;
        this.numBonds = numBonds;
        this.bm = bm;
    }

    public void UpdatePositons(Atom atom)
    {
        bm.UpdatePositons(atom);
    }

    public void RemoveBond()
    {
        Destroy(gameObject);
    }
}
