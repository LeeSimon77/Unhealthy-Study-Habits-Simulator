﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PoopButtonScript : AAction
{
    string actionTag;
    public Text tooltip;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Button btn = GameObject.Find("PoopButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        base.setButton(btn);
        tooltip.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (EventSystem.current.IsPointerOverGameObject())
            tooltip.gameObject.SetActive(true);
        else
            tooltip.gameObject.SetActive(false);
    }

    private void TaskOnClick()
    {
        base.startAction();
        Debug.Log("Pooped");
        base.incStat("bathroom", 2);

    }
}
