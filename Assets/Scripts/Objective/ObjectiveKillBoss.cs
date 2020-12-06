using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKillBoss : MonoBehaviour
{
    public GameObject boss;
    Objective m_objective;

    // Start is called before the first frame update
    void Start()
    {
        if (!boss)
        {
            Debug.LogError("No boss assigned");
        }
        m_objective = GetComponent<Objective>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss)
        {
            m_objective.CompleteObjective(string.Empty, string.Empty, "任务完成 : " + m_objective.title);
        }
    }
}
