using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTime : MonoBehaviour
{
    public float startTime = 0f;
    public float destroyTime = 5f;
    public GameObject dialog;
    //public Collider activateCollider;
    public GameObject generateObjective;
    public GameObject completeObjective;
    public GameObject generateDialog;
    private Text textComponent;
    private TypewriterEffect effect;

    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
        if (generateObjective)
        {
            generateObjective.SetActive(false);
        }
        //textComponent = GetComponent<Text>();
        textComponent = dialog.GetComponent<Text>();
        textComponent.enabled = false;
        //effect = GetComponent<TypewriterEffect>();
        effect = dialog.GetComponent<TypewriterEffect>();
        effect.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterDialog()
    {
        dialog.SetActive(true);
        Invoke("ShowText", startTime);
        Invoke("DestroySelf", startTime + destroyTime);
    }

    void ShowText()
    {
        textComponent.enabled = true;
        effect.enabled = true;
    }

    void DestroySelf()
    {
        if (generateDialog)
        {
            generateDialog.SetActive(true);
        }
        if (generateObjective)
        {
            generateObjective.SetActive(true);
        }
        if (completeObjective)
        {
            completeObjective.GetComponent<Objective>().CompleteObjective(string.Empty, string.Empty, "任务完成 : " + completeObjective.GetComponent<Objective>().title);
        }

        Destroy(gameObject);
    }
}
