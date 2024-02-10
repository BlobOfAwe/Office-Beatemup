using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointText : MonoBehaviour
{
    [SerializeField] float displaySeconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisplayForSeconds");    
    }

    private IEnumerator DisplayForSeconds()
    {
        yield return new WaitForSeconds(displaySeconds);
        Destroy(gameObject);
    }
}
