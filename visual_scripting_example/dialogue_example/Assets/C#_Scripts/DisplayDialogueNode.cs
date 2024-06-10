
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



[UnitShortTitle("DisplayDialogueNode")]
[UnitTitle("Displays a Dialogue Node")]
public class DisplayDialogueNode : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;

    [DoNotSerialize] // No need to serialize ports
    public ValueInput dialogueNode;

    [DoNotSerialize] // No need to serialize ports
    public ValueInput main_text_ui;

    [DoNotSerialize] // No need to serialize ports
    public ValueInput answer_a_text_ui;

    [DoNotSerialize] // No need to serialize ports
    public ValueInput answer_b_text_ui;

    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", (flow) =>
        {
            SetUI_Texts(flow.GetValue<DialogueNode>(dialogueNode),
                        flow.GetValue<TextMeshProUGUI>(main_text_ui),
                        flow.GetValue<TextMeshProUGUI>(answer_a_text_ui),
                        flow.GetValue<TextMeshProUGUI>(answer_b_text_ui));

            return outputTrigger;
        });

        outputTrigger = ControlOutput("outputTrigger");

        //Making input value ports visible, setting the port label name and its default value  
        dialogueNode = ValueInput<DialogueNode>("dialogueNode", null);
        main_text_ui = ValueInput<TextMeshProUGUI>("main_text_ui", null);
        answer_a_text_ui = ValueInput<TextMeshProUGUI>("answer_a_text_ui", null);
        answer_b_text_ui = ValueInput<TextMeshProUGUI>("answer_b_text_ui", null);

        Requirement(dialogueNode, inputTrigger); //Specifies that we need this value to be set before the node can run.
        Requirement(main_text_ui, inputTrigger); //Specifies that we need this value to be set before the node can run.
        Requirement(answer_a_text_ui, inputTrigger); //Specifies that we need this value to be set before the node can run.
        Requirement(answer_b_text_ui, inputTrigger); //Specifies that we need this value to be set before the node can run.

        Succession(inputTrigger, outputTrigger); //Specifies that the input trigger port's input exits at the output trigger port. Not setting your succession also dims connected nodes, but the execution still completes.
    }

    private void SetUI_Texts(DialogueNode dialogueNode, TextMeshProUGUI main_text_ui, TextMeshProUGUI answer_a_ui, TextMeshProUGUI answer_b_ui)
    {
        if (dialogueNode == null)
        {
            Debug.LogWarning("DisplayDialogueNode - SetUI_Texts - invalid DialogueNode");
            return;
        }

        main_text_ui.text = dialogueNode.main_text;

        if (dialogueNode.answer_a_node != null)
        {
            answer_a_ui.text = dialogueNode.answer_a_text;
        }
        else
        {
            answer_a_ui.text = "";
        }

        if (dialogueNode.answer_b_node != null)
        {
            answer_b_ui.text = dialogueNode.answer_b_text;
        }
        else
        {
            answer_b_ui.text = "";
        }
    }
}