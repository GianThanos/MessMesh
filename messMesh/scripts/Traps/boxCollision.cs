using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCollision : MonoBehaviour
{
    public GameObject spikeWo;
    public GameObject spikeW;
    public GameObject spike;

    public int vanishDelay;
    void OnTriggerEnter2D()
    {
        spikeWo.SetActive(false);
        spikeW.SetActive(true);

        StartCoroutine (Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(vanishDelay);
        
        spikeW.SetActive(false);
        Object.Destroy(spike);
    }
}
