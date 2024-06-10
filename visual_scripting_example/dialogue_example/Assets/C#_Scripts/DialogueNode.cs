using System;
using UnityEngine;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueNode", order = 1)]
[Serializable, Inspectable]
public class DialogueNode : ScriptableObject
{
    [Inspectable]
    public string main_text;
    [Inspectable]
    public string answer_a_text;
    [Inspectable]
    public string answer_b_text;
    [Inspectable]
    public DialogueNode answer_a_node;
    [Inspectable]
    public DialogueNode answer_b_node;
}