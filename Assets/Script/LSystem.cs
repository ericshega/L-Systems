using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TransformInfo
{
    public Vector3 position;
    public Quaternion rotation;
}
public class LSystem : MonoBehaviour
{
    public string axiom;
    private string currentString = string.Empty;

    public GameObject Branch;
    public GameObject Leafs;

    public int Iterations;
    public float Angle;
    public float Length;

    public Text Iterations_text;
    public Text Angle_text;
    public Text Length_text;
    public Text RulesGUI_Text;

    public bool isKeyPressed;

    private Dictionary<char, string> rules;

    private Stack<TransformInfo> transformStack;

    private List<GameObject> instantiatedObjects = new List<GameObject>();


    void Start()
    {
        transformStack = new Stack<TransformInfo>();

        RulesGUI_Text.text = " ";

        isKeyPressed = false;
    }

    void Update()
    {
        Iterations_text.text = "Iterations = " + Iterations;
        Angle_text.text = "Angle = " + Angle;
        Length_text.text = "Length = " + Length;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            TreeOne();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            TreeTwo();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            TreeThree();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            TreeFour();
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            TreeFive();
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            TreeSix();
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            TreeSeven();
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            TreeEight();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (isKeyPressed == false)
            {
                IncreaseIterations();
                isKeyPressed = true;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.F1))
        {
            isKeyPressed = false;
        }

        if (Input.GetKey(KeyCode.F2))
        {
            if (isKeyPressed == false)
            {
                DecreaseIterations();
                isKeyPressed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.F2))
        {
            isKeyPressed = false;
        }

        if (Input.GetKey(KeyCode.F3))
        {
            if (isKeyPressed == false)
            {
                IncreaseAngle();
                isKeyPressed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.F3))
        {
            isKeyPressed = false;
        }

        if (Input.GetKey(KeyCode.F4))
        {
            if (isKeyPressed == false)
            {
                DecreaseAngle();
                isKeyPressed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.F4))
        {
            isKeyPressed = false;
        }

        if (Input.GetKey(KeyCode.F5))
        {
            if (isKeyPressed == false)
            {
                IncreaseLength();
                isKeyPressed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.F5))
        {
            isKeyPressed = false;
        }

        if (Input.GetKey(KeyCode.F6))
        {
            if (isKeyPressed == false)
            {
                DecreaseLength();
                isKeyPressed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.F6))
        {
            isKeyPressed = false;
        }
    }

    public void IncreaseIterations()
    {
        Iterations = Mathf.Max(1, Iterations + 1);
        DestroyGeneratedObjects(); 
        GenerateRule();
    }

    public void DecreaseIterations()
    {
        Iterations = Mathf.Max(1, Iterations - 1);
        DestroyGeneratedObjects(); 
        GenerateRule();
    }

    public void IncreaseAngle()
    {
        Angle = Mathf.Max(5f, Angle + 5f);
        DestroyGeneratedObjects();
        GenerateRule();
    }

    public void DecreaseAngle()
    {
        Angle = Mathf.Max(5f, Angle - 5f); 
        DestroyGeneratedObjects();
        GenerateRule();
    }

    public void IncreaseLength()
    {
        Length = Mathf.Max(0.5f, Length + 0.5f);
        DestroyGeneratedObjects();
        GenerateRule();
    }

    public void DecreaseLength()
    {
        Length = Mathf.Max(0.5f, Length - 0.5f);
        DestroyGeneratedObjects();
        GenerateRule();
    }

    public void TreeOne()
    {
        TreeResetRule();

        Iterations = 5;
        Angle = 25.7f;
        axiom = "F";

        Length = 2f;

        rules = new Dictionary<char, string>
        {
            { 'F', "F[+F]F[-F]F" },
        };

        GenerateRule();

        RulesGUI_Text.text = "'F', \"F[+F]F[-F]F\"";
    }

    public void TreeTwo()
    {
        TreeResetRule();

        Iterations = 5;
        Angle = 20F;
        axiom = "F";

        Length = 8f;

        rules = new Dictionary<char, string>
        {
            { 'F', "F[+F]F[-F][F]" }
        };

        GenerateRule();

        RulesGUI_Text.text = "'F', \"F[+F]F[-F][F]\"";
    }

    public void TreeThree()
    {
        TreeResetRule();

        Iterations = 4;
        Angle = 22.5F;
        axiom = "F";

        Length = 8f;

        rules = new Dictionary<char, string>
        {
            { 'F', "FF-[-F+F+F]+[+F-F-F]" }
        };

        GenerateRule();

        RulesGUI_Text.text = "'F', \"FF-[-F+F+F]+[+F-F-F]\"";
    }

    public void TreeFour()
    {
        TreeResetRule();

        Iterations = 7;
        Angle = 20f;
        axiom = "X";

        Length = 2f;

        rules = new Dictionary<char, string>
        {
            { 'X', "F[+X]F[-X]+X" },
            { 'F', "FF" }
        };

        GenerateRule();

        RulesGUI_Text.text = "'X', \"F[+X]F[-X]+X\"\n'F', \"FF\"";
    }

    public void TreeFive()
    {
        TreeResetRule();

        Iterations = 7;
        Angle = 25.7f;
        axiom = "X";

        Length = 2f;

        rules = new Dictionary<char, string>
        {
            { 'X', "F[+X][-X]FX" },
            { 'F', "FF" }
        };

        GenerateRule();

        RulesGUI_Text.text = "'X', \"F[+X][-X]FX\"\n'F', \"FF\"";
    }
    public void TreeSix()
    {
        TreeResetRule();

        Iterations = 5;
        Angle = 22.5f;
        axiom = "X";

        Length = 5.5f;

        rules = new Dictionary<char, string>
        {
            { 'X', "F-[[X]+X]+F[+FX]-X" },
            { 'F', "FF" }
        };

        GenerateRule();

        RulesGUI_Text.text = "'X', \"F-[[X]+X]+F[+FX]-X\"\n'F', \"FF\"";
    }
    public void TreeSeven()
    {
        TreeResetRule();

        Iterations = 4;
        Angle = 45;
        axiom = "F";

        Length = 2f;

        rules = new Dictionary<char, string>
        {
            { 'F', "+-FF[+FF][-F]F[-F][+FF]" },
        };

        GenerateRule();

        RulesGUI_Text.text = "'F', \"+-FF[+FF][-F]F[-F][+FF]\"";
    }
    public void TreeEight()
    {
        TreeResetRule();

        Iterations = 5;
        Angle = 35;
        axiom = "+FF";

        Length = 4.5f;

        rules = new Dictionary<char, string>
        {
            { 'F', "FF-[-F+F+F]+[+F-F-F]" },
        };

        GenerateRule();

        RulesGUI_Text.text = "'X', \"[-F[+FX]FX]+F[-F[+FX]FX]\"\n'F', \"FF\"";
    }

    public void TreeResetRule()
    {

        transform.position = new Vector3(0,0,0);
        transform.rotation = Quaternion.identity;

        RulesGUI_Text.text = " "; 
        rules = new Dictionary<char, string>();

        Iterations = 0;
        Angle = 0f;
        Length = 0f;

        foreach (GameObject obj in instantiatedObjects)
        {
            Destroy(obj);
        }

        instantiatedObjects.Clear();
    }

    void DestroyGeneratedObjects()
    {
        foreach (GameObject obj in instantiatedObjects)
        {
            Destroy(obj);
        }
        instantiatedObjects.Clear();
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
    }


    void GenerateRule()
    {
        currentString = axiom;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            foreach (char c in currentString)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }

            currentString = sb.ToString();
            sb = new StringBuilder();
        }

        foreach (char c in currentString)
        {
            switch (c)
            {
                case 'F':
                    Vector3 InitialPosition = transform.position;
                    transform.Translate(Vector3.up * Length);
                    GameObject TreeSeg = Instantiate(Branch);

                    TreeSeg.GetComponent<LineRenderer>().SetPosition(0, InitialPosition);
                    TreeSeg.GetComponent<LineRenderer>().SetPosition(1, transform.position);

                    instantiatedObjects.Add(TreeSeg);

                    if (UnityEngine.Random.Range(0f, 1f) > 0.8f) 
                    {
                        GameObject leaf = Instantiate(Leafs, new Vector3(transform.position.x, transform.position.y, 0.5f), Quaternion.identity);
                        leaf.transform.localScale = new Vector3(2f, 2f, 2f);

                        instantiatedObjects.Add(leaf);
                    }
                    break;

                case 'X':
                    break;

                case '+':
                    transform.Rotate(Vector3.back * Angle);
                    break;

                case '-':
                    transform.Rotate(Vector3.forward * Angle);
                    break;

                case '[':
                    transformStack.Push(new TransformInfo()
                    {
                        position = transform.position,
                        rotation = transform.rotation,
                    });
                    break;

                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    break;

                default:
                    throw new InvalidOperationException("Invalid L-tree operation");
            }
        }
    }
}
