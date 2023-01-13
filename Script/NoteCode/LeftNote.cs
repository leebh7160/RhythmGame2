using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LeftNote : MonoBehaviour
{
    private float noteSpeed = 5f;
    
    private float noteintervel = 0f;
    private UnityEngine.UI.Image noteImage;

    private void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
        StartCoroutine(LeftNoteMoveCorutine());
    }

    internal void IntervalData(float interval)
    {
        noteintervel = interval;
    }

    internal void HideNote()
    {
        noteImage.enabled = false;
    }

    private IEnumerator LeftNoteMoveCorutine()
    {
        while (true)
        {
            this.transform.localPosition -= Vector3.left * noteSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
