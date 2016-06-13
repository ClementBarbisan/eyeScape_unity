using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tapMeshHandler : MonoBehaviour {
	public bool loop = true;
	public int nbModel = 0;
	bool detection = true;
	VideoPlaybackBehaviour[] videos;
	GameObject[] list;
	public List<textureChange> flags;
	int index;

	private delegate void changeTexture();
	private changeTexture changeTex;

	public void setDetection(bool val)
	{
		if (detection != val && (detection = val) == true && index < list.Length) {
			index = (index + 1) % list.Length;
			if (flags.Count > 0)
				changeTex ();
			enableMesh ();
		} 
		else if (!val)
			disableMesh ();
	}

	void disableMesh()
	{
		for (int i = 0; i < list.Length; i++) 
		{
			list[i].SetActive(false);
		}
	}

	void enableMesh()
	{
		for (int i = 0; i < list.Length; i++) 
		{
			if (i == index)
			{
				list[i].SetActive(true);
				videos = list[i].GetComponentsInChildren<VideoPlaybackBehaviour>();
				startVideos ();
			}
			else
				list[i].SetActive(false);
		}
	}

	// Use this for initialization
	void Awake () {
		index = 0;
		list = GameObject.FindGameObjectsWithTag ("model" + nbModel);
		videos = list [index].GetComponentsInChildren<VideoPlaybackBehaviour> ();
	}

	void Start()
	{
		for (int i = 0; i < flags.Count; i++)
			changeTex += flags [i].changeTexture;
		enableMesh ();
	}

	void startVideos()
    {
        foreach (VideoPlaybackBehaviour video in videos)
        {
			Debug.Log ("Video Number = " + videos.Length);
            if (video.AutoPlay)
            {
				if (video.VideoPlayer.IsPlayableOnTexture())
                {
                    VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
                    if (state == VideoPlayerHelper.MediaState.PAUSED ||
                        state == VideoPlayerHelper.MediaState.READY ||
                        state == VideoPlayerHelper.MediaState.STOPPED ||
						state == VideoPlayerHelper.MediaState.PLAYING)
                    {
                       	// Play this video on texture where it left off
						video.VideoPlayer.Play(false, video.VideoPlayer.GetCurrentPosition());
                    }
                    else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                    {
                        // Play this video from the beginning
                        video.VideoPlayer.Play(false, 0);
                    }
                }
            }
        }
    }

	void checkVideos()
	{
		foreach (VideoPlaybackBehaviour currentVideo in videos)
		{
			if (currentVideo.VideoPlayer.IsPlayableOnTexture () && loop) 
			{
				VideoPlayerHelper.MediaState state = currentVideo.VideoPlayer.GetStatus();
				if (state == VideoPlayerHelper.MediaState.REACHED_END)
					currentVideo.VideoPlayer.Play(false, 0);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		checkVideos ();
    }
}
