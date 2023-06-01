using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomSpawner : MonoBehaviour
{
    public Transform spawn;

    public List<GameObject> atomPrefabs;

    public LayerMask mask;

    public void SpawnAtom(int pos)
    {
        RaycastHit hit;

        if(!Physics.SphereCast(spawn.transform.position - transform.forward, 0.05f, transform.forward, out hit, 1, mask, QueryTriggerInteraction.Collide))
        {
            GameObject g = Instantiate(atomPrefabs[pos]);
            g.transform.position = spawn.position;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawn.transform.position, 0.05f);
    }
}
