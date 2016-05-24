using UnityEngine;
using System.Collections;

public class tapHandler : MonoBehaviour {

	GameObject[] list;
	int index;

	// Use this for initialization
	void Awake () {
		index = 0;
		list = GameObject.FindGameObjectsWithTag ("model1");
		for (int i = 0; i < list.Length; i++) 
		{
			if (i == index)
				list [i].SetActive(true);
			else
				list [i].SetActive(false);
		}
	}

    void startVideos()
    {
        VideoPlaybackBehaviour[] videos = GetComponentsInChildren<VideoPlaybackBehaviour>();
        foreach (VideoPlaybackBehaviour video in videos)
        {
            if (video != null && video.AutoPlay)
            {
                if (video.VideoPlayer.IsPlayableOnTexture())
                {
                    VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
                    if (state == VideoPlayerHelper.MediaState.PAUSED ||
                        state == VideoPlayerHelper.MediaState.READY ||
                        state == VideoPlayerHelper.MediaState.STOPPED)
                    {
                        // Pause other videos before playing this one
                        // PauseOtherVideos(video);

                        // Play this video on texture where it left off
                        video.VideoPlayer.Play(false, video.VideoPlayer.GetCurrentPosition());
                    }
                    else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                    {
                        // Pause other videos before playing this one
                        // PauseOtherVideos(video);

                        // Play this video from the beginning
                        video.VideoPlayer.Play(false, 0);
                    }
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
		if (Input.GetTouch(0).phase == TouchPhase.Began)
		{
			index = (index + 1) % list.Length;
			for (int i = 0; i < list.Length; i++) 
			{
                if (i == index)
                {
                    list[i].SetActive(true);
                    startVideos();
                }
                else
                    list[i].SetActive(false);
			}
        }
    }
}
