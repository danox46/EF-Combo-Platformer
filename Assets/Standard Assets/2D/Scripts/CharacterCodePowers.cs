using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

/*public struct CodeInput
{
    Color32 codeColor;
    int code;

}*/

public struct AttackInfo
{
    public List<int> correctCode;
    public string animTrigger;

} 


public class CharacterCodePowers : PlatformerCharacter2D
{

    private List<int> currentInput;
    private List<Color> keyInputsInfo;
    private List<AttackInfo> attacks;
    private Color baseSpriteColor;
    private SpriteRenderer sRenderer;
    public bool changingColor;
    private float keyTimer;
    [SerializeField] private float maxKeyTime;
    private bool waitingForKey;
    public GameObject uI;

    public override void Start()
    {
        base.Start();


        currentInput = new List<int>();
        keyInputsInfo = new List<Color>();

        keyInputsInfo.Add(Color.red);
        keyInputsInfo.Add(Color.blue);
        keyInputsInfo.Add(Color.yellow);
        keyInputsInfo.Add(Color.green);
        keyInputsInfo.Add(Color.grey);
        keyInputsInfo.Add(Color.black);

        attacks = new List<AttackInfo>();

        AttackInfo currentAttack;

        currentAttack.animTrigger = "Attacking";
        currentAttack.correctCode = new List<int> {1, 2, 3};

        attacks.Add(currentAttack);

        sRenderer = GetComponent<SpriteRenderer>();

        baseSpriteColor = sRenderer.color;

        waitingForKey = false;

    }

    public override void Update()
    {
        base.Update();

        if (waitingForKey)
            keyTimer += Time.deltaTime;

        if(keyTimer >= maxKeyTime)
        {
            sRenderer.color = baseSpriteColor;
            keyTimer = 0;
            ClearInputCode();
            waitingForKey = false;
        }
    }

    public override void TriggerAttacking()
    {
        bool foundCode = false;

        foreach(AttackInfo currentAttack in attacks)
        {
            //Debug.Log("Cheking attack: " + currentAttack.animTrigger);
            foundCode = true;
            for (int i = 0; i < currentInput.Count; i++)
            {

                //Debug.Log("Cheking input #" + i + "with an input of: " + currentInput[i] + "and a correct code of: " + currentAttack.correctCode[i]);
                if(currentInput[i] != currentAttack.correctCode[i])
                {
                    foundCode = false;
                }

            }

            if (foundCode)
            {
                m_Anim.SetTrigger(currentAttack.animTrigger);
                ReturnToNoKeys();
            }
        }

        if(!foundCode)
            m_Anim.SetTrigger("CodeFail");

        currentInput = new List<int>();
    }

    public override void Move(float move, bool crouch, bool jump)
    {
        if(!changingColor)
            base.Move(move, crouch, jump);
    }

    public void SetAttackCodeInput(int key)
    {
        if (!changingColor && !attaking && currentHp > 0)
        {
            m_Anim.SetTrigger("ColorChange");

            waitingForKey = true;

            keyTimer = 0f;

            sRenderer.color = keyInputsInfo[key];

            currentInput.Add(key);

            if (currentInput.Count == 3)
            {
                waitingForKey = false;
                keyTimer = 0f;

                Debug.Log("Triggering Attack");
                TriggerAttacking();
            }
        }
    }

    public void ClearInputCode()
    {
        currentInput = new List<int>();
    }

    public void ReturnToNoKeys()
    {
        ClearInputCode();
        sRenderer.color = baseSpriteColor;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadThis()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 
    }

    public override void Die()
    {
        if (gameObject.tag == "Player")
        {
            uI.SetActive(true);
        }
        base.Die();
        
    }

}
