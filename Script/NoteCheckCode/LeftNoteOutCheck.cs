using UnityEngine;

public class LeftNoteOutCheck : LeftNoteCheck
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftNote"))
        {
            noteManager.LeftNoteDestroy(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
