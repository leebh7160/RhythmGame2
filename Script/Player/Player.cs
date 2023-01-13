using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    //===============================Reference
    private GameManager gameManager;
    private TimingManager timingManager;
    //===============================Reference^^

    [SerializeField] private GameObject LeftEffect;
    [SerializeField] private GameObject RightEffect;

    void Start()
    {
        gameManager     = GameObject.Find("GameManager").GetComponent<GameManager>();
        timingManager   = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            LeftEffect.SetActive(true);
            RightEffect.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timingManager.LeftCheckTiming();
            LeftAnimation();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            LeftEffect.SetActive(false);
            RightEffect.SetActive(true);
            timingManager.RightCheckTiming();
            RightAnimaiton();
        }
    }

    private void LeftAnimation()
    {

    }

    private void RightAnimaiton()
    {

    }
}
