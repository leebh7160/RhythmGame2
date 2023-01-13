using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RightNote : MonoBehaviour
{
    private float noteSpeed = 5f;

    private float noteintervel = 0f;
    private UnityEngine.UI.Image noteImage;

    private void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
        StartCoroutine(RightNoteMoveCorutine());
    }

    internal void IntervalData(float interval)
    {
        noteintervel = interval;
    }

    internal void HideNote()
    {
        noteImage.enabled = false;
    }

    private IEnumerator RightNoteMoveCorutine()
    {
        while (true)
        {
            this.transform.localPosition -= Vector3.right * noteSpeed * noteintervel * Time.deltaTime;
            yield return null;
        }
    }


}
