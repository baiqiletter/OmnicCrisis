using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    private bool onChoosing = false;
    public float startTime = 0f;
    public GameObject[] selections;
    public GameObject completeObjective;
    public GameObject[] generateObjectives;
    public GameObject[] generateDialogs;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 150);
        foreach (GameObject selection in selections)
        {
            selection.SetActive(false);
        }
        foreach (GameObject objective in generateObjectives)
        {
            objective.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!onChoosing)
            return;
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("left: Human");
            Choose(0);
        } else if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("right: Red Queen");
            Choose(1);
        }
    }

    public void EnterSelection()
    {
        Invoke("SetActive", startTime);
    }

    private void SetActive()
    {
        foreach (GameObject selection in selections)
        {
            selection.SetActive(true);
        }
        onChoosing = true;
    }

    public void Choose(int choice)
    {
        completeObjective.GetComponent<Objective>().CompleteObjective(string.Empty, string.Empty, "任务完成 : " + completeObjective.GetComponent<Objective>().title);

        switch (choice)
        {
            case 0:
                Debug.Log("人类阵营");
                if (generateObjectives[0])
                {
                    generateObjectives[0].SetActive(true);
                }
                if (generateDialogs[0])
                {
                    generateDialogs[0].SetActive(true);
                }
                GameFlowManager.ending = 0;
                break;
            case 1:
                Debug.Log("红后阵营");
                if (generateObjectives[1])
                {
                    generateObjectives[1].SetActive(true);
                }
                if (generateDialogs[1])
                {
                    generateDialogs[1].SetActive(true);
                }
                GameFlowManager.ending = 1;
                break;
        }

        Destroy(gameObject);
    }
}
