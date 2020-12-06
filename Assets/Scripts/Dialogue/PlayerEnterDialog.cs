using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dialog"))
        {
            other.GetComponent<DialogTime>().EnterDialog();
        } else if (other.CompareTag("Selection"))
        {
            other.GetComponent<Selection>().EnterSelection();
        }
    }
}
