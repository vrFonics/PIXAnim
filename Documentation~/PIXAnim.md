PIXAnim Documentation:

How to create an animation:

1. Create a new ScriptableObject of type PIXAnim_Animation.
2. Add all desired sprites to the Frames array of the PIXAnim_Animation. The animation will by default play forwards starting with the first frame at index 0 of the array and incrementing to each successive positive value for the next frame.
3. Set the desired framerate of the PIXAnim_Animation using the FrameRate float value.
4. Set the desired animation name using the Name string.

How to add animation functionality to a GameObject:

1. Add a PIXAnim_Controller script to the GameObject containing the sprite renderer you want to animate. (The system does not require the target SpriteRenderer of the PIXAnim_Controller to be parented to the GameObject the PIXAnim_Controller is attached to, however in my own projects I follow the convention of attaching the PIXAnim_Controller to the parent GameObject in almost all cases for consistency.)
2. Set the target SpriteRenderer using the TargetSpriteRenderer variable on the PIXAnim_Controller.
3. Add all desired PIXAnim_Animation ScriptableObjects to the Animations array of the PIXAnim_Controller.

How to play animations from a C# script:

1. Reference the target PIXAnim_Controller. 

2. There are two callable methods on the PIXAnim_Controller to play an animation:


void PlayAnimationByName(string animationName, bool playReverse, bool loop, int frameToStart)

void PlayAnimationByIndex(int index, bool playReverse, bool loop, int frameToStart)


PlayAnimationByIndex() is far more performant than PlayAnimationByName(). You can use the helper method GetIndexOfAnimation(string animationName) on the Start() method which returns the index of the animation matching animationName allowing you to store it as a lasting reference to call during runtime.