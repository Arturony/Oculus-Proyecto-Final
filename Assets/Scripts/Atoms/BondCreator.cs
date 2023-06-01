using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.TubeRenderer;

public class BondCreator : MonoBehaviour
{

    [SerializeField]
    private float width;

    [SerializeField]
    private Material material;

    [SerializeField]
    private GameObject bondInstance;

    [SerializeField]
    private float radius;

    public void CreateMeshBond(Atom firstAtom, Atom secondAtom, int numBonds)
    {
        int[] list = {1, 1, 0};

        for(int i = 0; i < numBonds; i++)
        {

            GameObject g = Instantiate(bondInstance);

            TubeRenderer t = g.GetComponent<TubeRenderer>();
            t.startWidth = width;
            t.endWidth = width;

            g.GetComponent<MeshRenderer>().material = material;
            float offsetRadius = (radius / 2) * (Mathf.Pow(-1, i + 2)) * list[i];
            t.positions = new Vector3[2];
            t.positions[0] = firstAtom.transform.position + new Vector3(0, offsetRadius, 0);
            t.positions[1] = secondAtom.transform.position + new Vector3(0, offsetRadius, 0);
            BondMover bm = g.GetComponent<BondMover>();
            bm.SetAtoms(firstAtom, secondAtom, offsetRadius);
            t.enabled = true;
            Bond b = g.GetComponent<Bond>();
            b.SetBond(firstAtom, secondAtom, numBonds, bm);

            firstAtom.AddBond(b);
            secondAtom.AddBond(b);
        }
    }
}
