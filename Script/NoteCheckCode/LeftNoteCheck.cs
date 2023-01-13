using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftNoteCheck : MonoBehaviour
{
    protected static NoteManager noteManager;

    private void Start()
    {
        noteManager = GameObject.Find("Node").GetComponent<NoteManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!noteManager.NotePlay())
        {
            if (collision.CompareTag("LeftNote"))
                NoteNoteIn();
        }
    }

    private void NoteNoteIn()
    {
        noteManager.LeftNoteIn();
    }

    private void NoteNoteOut()
    {
        noteManager.LeftNoteOut();
    }
}
