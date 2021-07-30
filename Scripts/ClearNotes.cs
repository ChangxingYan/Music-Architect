using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearNotes : MonoBehaviour
{
    public Instantiator instantiator;


    public void Clear()
    {
        instantiator.lineRend.SetPositions(new Vector3[7]);
        instantiator.IdCounter.Clear();
        instantiator.clickCounter = 0;
    }
}
