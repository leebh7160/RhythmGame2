using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private bool RecordCheck = false;

    [SerializeField] private double[] RightMusicRecordTime;
    [SerializeField] private double[] LeftMusicRecordTime;

    //==========================RightBPMValue
    private double currentTime_right = 0d;
    [SerializeField] private int bpm_right = 0;
    //==========================RightBPMValue^^


    //==========================LeftBPMValue
    private double currentTime_left = 0d;
    [SerializeField] private int bpm_left = 0;
    //==========================LeftBPMValue^^


    //==========================AudioValue
    private bool isMusicPlay = false;
    private AudioSource myAudio;
    //==========================AudioValue^^


    //==========================NoteCheckValue
    [SerializeField] Transform RightNoteAppear = null;
    [SerializeField] Transform LeftNoteAppear = null;

    [SerializeField] GameObject RightNote = null;
    [SerializeField] GameObject LeftNote = null;
    //==========================NoteCheckValue^^

    //==========================Reference
    private TimingManager timingManager;
    //==========================Reference^^


    private void Start()
    {
        myAudio         = this.gameObject.GetComponent<AudioSource>();
        timingManager   = this.gameObject.GetComponent<TimingManager>();
        timingManager.SetNoteParentPosition(LeftNoteAppear.localPosition, RightNoteAppear.localPosition);
        if (RecordCheck == true)
        {
            //record Script
        }
        else
            GamePlay();
    }


    void Update()
    {
        /*currentTime_right += Time.deltaTime;
        currentTime_left += Time.deltaTime;*/
        Debug.Log("AudioTime = " + myAudio.time * 1000);
        NoteCreate();
    }


    private void GamePlay()
    {
        StartNote();
        //StartCoroutine(NoteCreate());
    }

    #region 노트 제작
    private void NoteCreate()
    {
        int right_t_record = 0;
        int Left_t_record = 0;
            if (myAudio.time * 1000 == RightMusicRecordTime[right_t_record])
            {
                GameObject t_note_Right = Instantiate(RightNote, RightNoteAppear.position, Quaternion.identity, RightNoteAppear);

                RightNote right_note = t_note_Right.GetComponent<RightNote>();
                right_note.IntervalData(400f);

                timingManager.Right_NoteList.Add(t_note_Right);
                right_t_record++;
                //yield return null;
            }

            if (myAudio.time * 1000 == LeftMusicRecordTime[Left_t_record])
            {
                GameObject t_note_Left = Instantiate(LeftNote, LeftNoteAppear.position, Quaternion.identity, LeftNoteAppear);

                LeftNote left_note = t_note_Left.GetComponent<LeftNote>();
                left_note.IntervalData(400f);

                timingManager.Left_NoteList.Add(t_note_Left);
                Left_t_record++;
                //yield return null;
            }
    }


    private void StartNote()
    {
        GameObject t_note_Right = Instantiate(RightNote, RightNoteAppear.position, Quaternion.identity, RightNoteAppear);

        RightNote right_note = t_note_Right.GetComponent<RightNote>();
        right_note.IntervalData(400f);

        timingManager.Right_NoteList.Add(t_note_Right);
    }
    #endregion

    #region 노트 없어지는 것 확인
    internal void LeftNoteDestroy(GameObject leftnoteobj)
    {
        timingManager.Left_NoteList.Remove(leftnoteobj);
    }
    internal void RightNoteDestroy(GameObject rightnoteobj)
    {
        timingManager.Right_NoteList.Remove(rightnoteobj);
    }

    #endregion

    #region 노트 누르는 것 확인
    internal bool NotePlay()
    {
        return isMusicPlay;
    }



    internal void LeftNoteIn()
    {
        myAudio.Play();
        isMusicPlay = true;
    }

    internal void RightNoteIn()
    {
        myAudio.Play();
        isMusicPlay = true;
    }



    internal void LeftNoteOut()
    {
        isMusicPlay = false;
    }

    internal void RightNoteOut()
    {
        isMusicPlay = false;
    }

    #endregion
}
