using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PIXAnim Animation", menuName = "PIXAnim/Animation", order = 1)]
public class PIXAnim_Animation : ScriptableObject
{
    public string Name;
    [SerializeField]
    public List<Sprite> Frames;
    public int FrameRate;
}