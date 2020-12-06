using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnding : MonoBehaviour
{
    public GameObject[] endings;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = GameFlowManager.ending;
        foreach (var ending in endings)
        {
            ending.SetActive(false);
        }
        endings[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
