using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerController : MonoBehaviour
{
    public VideoClip[] videoClips;
    public RawImage playerScreen;
    public GameObject window;

    private VideoPlayer videoPlayer;

    void Awake() {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = new RenderTexture(1920, 1080, 24);
        playerScreen.texture = videoPlayer.targetTexture;
    }

    public void PlayVideo(int index)
    {
        window.SetActive(true);
        videoPlayer.clip = videoClips[index];
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        window.SetActive(false);
        vp.Stop();
    }

    public void CloseWindow() => OnVideoEnd(videoPlayer);
}
