using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIXAnim_Controller : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private List<PIXAnim_Animation> animations;
    public PIXAnim_Animation currentAnimation = null;

    private bool playing = false;

    private bool looping = false;

    private bool reversing = false;

    private int currentFrame = 0;

    private float timeToNextFrame = 0;

    void Update()
    {
        if (!playing)
        {
            return;
        }
        if (!reversing)
        {
            if (currentFrame < currentAnimation.Frames.Count)
            {
                UpdateFrame();
                return;
            }
            if (looping)
            {
                currentFrame = 0;
                UpdateFrame();
                return;
            }
            playing = false;
            return;
        }
        if (currentFrame > currentAnimation.Frames.Count)
        {
            UpdateFrame();
            return;
        }
        if (looping)
        {
            currentFrame = currentAnimation.Frames.Count - 1;
            UpdateFrame();
            return;
        }
        playing = false;
    }

    private void UpdateFrame()
    {
        if (timeToNextFrame <= 0)
        {
            spriteRenderer.sprite = currentAnimation.Frames[currentFrame];
            timeToNextFrame = 1 / (float)currentAnimation.FrameRate;
            if (!reversing)
            {
               currentFrame++;
            }
            else
            {
               currentFrame--;
            }
        }
        timeToNextFrame -= Time.deltaTime;
    }

    public void PlayAnimationByName(string animationName, bool playReverse, bool loop, int frameToStart)
    {
        foreach (var animation in animations)
        {
            if (animation.Name == animationName)
            {
                PlayAnimationByIndex(animations.IndexOf(animation), playReverse, loop, frameToStart);
            }
        }
    }

    public void PlayAnimationByIndex(int index, bool playReverse, bool loop, int frameToStart)
    {
        if (currentAnimation == null)
        {
            SetAnimation(index, frameToStart);
            reversing = playReverse;
            looping = loop;
        }
        else if (currentAnimation.Name != animations[index].Name)
        {
            SetAnimation(index, frameToStart);
            reversing = playReverse;
            looping = loop;
        }

    }

    private void SetAnimation(int index, int frameToStart)
    {
        currentAnimation = animations[index];
        playing = true;
        currentFrame = frameToStart;
        timeToNextFrame = 0;
    }

    public int GetIndexOfAnimation(string animationName)
    {
        foreach (var animation in animations)
        {
            if (animation.name == animationName)
            {
                return animations.IndexOf(animation);
            }
        }
        Debug.Log("Animation not found.");
        return 0;
    }

    public PIXAnim_Animation GetAnimationData(int index)
    {
        return animations[index];
    }
}

