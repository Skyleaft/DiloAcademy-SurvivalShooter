using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    //buat trigger ke parent
    void OnTriggerEnter(Collider c)
    {
        gameObject.GetComponentInParent<Adrenaline>().PullTrigger(c);
    }
}
