using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public string atomName;

    public string abreviation;

    public int group;

    public List<int> oxidationStates;

    public int prefferedOxidationState;

    public int maxNumElectrons;

    public int currNumElectrons;

    public List<Bond> bonds = new List<Bond>();

    public bool CanBond(int currOxidation)
    {
        return currOxidation + currNumElectrons <= maxNumElectrons;
    }

    public void AddElectrons(int elect)
    {
        currNumElectrons += elect;
    }

    public void AddBond(Bond bond)
    {
        bonds.Add(bond);
    }

    public void RemoveBondsWithAtom(Atom other)
    {
        int count = bonds.Count;

        for(int i = 0; i < count; i++)
        {
            if (bonds[i].to == other)
            {
                currNumElectrons -= bonds[i].numBonds; 
                bonds[i].RemoveBond();
                bonds.RemoveAt(i);
                i--;
                count--;
            }
            else if (bonds[i].from == other)
            {
                currNumElectrons -= bonds[i].numBonds;
                bonds[i].RemoveBond();
                bonds.RemoveAt(i);
                i--;
                count--;
            }
        }
    }

    public void RemoveAllBonds()
    {
        int count = bonds.Count;
        for (int i = 0; i < count; i++)
        {
            if (bonds[i].to != this)
            {
                currNumElectrons -= bonds[i].numBonds;
                bonds[i].to.RemoveBondsWithAtom(this);
                bonds.RemoveAt(i);
                i--;
                count--;
            }
            else if (bonds[i].from != this)
            {
                currNumElectrons -= bonds[i].numBonds;
                bonds[i].from.RemoveBondsWithAtom(this);
                bonds.RemoveAt(i);
                i--;
                count--;
            }
        }
    }

    private void Update()
    {
        if(transform.hasChanged)
        {
            foreach(Bond b in bonds)
            {
                b.UpdatePositons(this);
            }
        }
    }
}
