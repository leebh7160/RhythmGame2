using UnityEngine;

public class RightNoteOutCheck : RightNoteCheck
{
    private void Start()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RightNote"))
        {
            noteManager.RightNoteDestroy(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
