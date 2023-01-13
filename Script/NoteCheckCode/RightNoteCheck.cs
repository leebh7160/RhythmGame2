using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightNoteCheck : MonoBehaviour
{
    protected static NoteManager noteManager;

    void Start()
    {
        noteManager = GameObject.Find("Node").GetComponent<NoteManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!noteManager.NotePlay())
        {
            if (collision.CompareTag("RightNote"))
                NoteNoteIn();
        }
    }

    private void NoteNoteIn()
    {
        noteManager.RightNoteIn();
    }

    private void NoteNoteOut()
    {
        noteManager.RightNoteOut();
    }

}
