using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimalParent : MonoBehaviour
{

    public enum livestatus {live,die}
    public enum emotiontatus { funny,sad,cry,angry}
    public enum activetatus {walking,idle,jump,sleep,die}

    [SerializeField] protected livestatus Livestatus;
    [SerializeField] public emotiontatus Emotionstatus;
    [SerializeField] public activetatus Activesatatus;

    GameObject thisAnimal;
    Animator ani;
	IDictionary<int,string> Dicanimationlist =new Dictionary<int, string>();
	IDictionary<int, string> Dicshadelist = new Dictionary<int, string>();
	public List<string> animationList = new List<string>
											{   "Attack",
												"Bounce",
												"Clicked",
												"Death",
												"Eat",
												"Fear",
												"Fly",
												"Hit",
												"Idle_A", "Idle_B", "Idle_C",
												"Jump",
												"Roll",
												"Run",
												"Sit",
												"Spin/Splash",
												"Swim",
												"Walk"
											};
	public List<string> shapekeyList = new List<string>
											{   "Eyes_Annoyed",
												"Eyes_Blink",
												"Eyes_Cry",
												"Eyes_Dead",
												"Eyes_Excited",
												"Eyes_Happy",
												"Eyes_LookDown",
												"Eyes_LookIn",
												"Eyes_LookOut",
												"Eyes_LookUp",
												"Eyes_Rabid",
												"Eyes_Sad",
												"Eyes_Shrink",
												"Eyes_Sleep",
												"Eyes_Spin",
												"Eyes_Squint",
												"Eyes_Trauma",
												"Sweat_L",
												"Sweat_R",
												"Teardrop_L",
												"Teardrop_R"
											};
	public void setup()
    {
        thisAnimal = this.gameObject;
        ani = thisAnimal.GetComponent<Animator>();
        Livestatus = livestatus.live;
		for(int i=0;i<animationList.Count;i++)
        {
			Dicanimationlist.Add(i, animationList.ElementAt(i));
        }
		for (int i = 0; i < shapekeyList.Count; i++)
		{
			Dicshadelist.Add(i, shapekeyList.ElementAt(i));
		}
	}

    public void crlLivestatus()
    {
	    

       if(Livestatus==livestatus.live)
        {

			ani.Play(animationList.ElementAt(8));
        }
            else if (Livestatus == livestatus.die)
        {
			ani.Play(animationList.ElementAt(3));

		}
    }

	public void crlAcitvetatus()
	{


		switch (Activesatatus)
		{
			case activetatus.walking:
				{
					ani.Play(animationList.ElementAt(17));
					break;
				}
			case activetatus.sleep:
				{
					ani.Play(animationList.ElementAt(14));
					break;
				}
			case activetatus.idle:
				{
					ani.Play(animationList.ElementAt(8));
					break;
				}
			case activetatus.jump:
				{
					ani.Play(animationList.ElementAt(11));
					break;
				}
			case activetatus.die:
				{
					ani.Play(shapekeyList.ElementAt(3));
					break;
				}
		}

	}





	public void crlemojitatus()
	{

		switch(Emotionstatus)
        {
			case emotiontatus.funny: {
					ani.Play(shapekeyList.ElementAt(5));
					break;}
			case emotiontatus.angry:
				{
					ani.Play(shapekeyList.ElementAt(0));
					break;
				}
			case emotiontatus.sad:
				{
					ani.Play(shapekeyList.ElementAt(11));
					break;
				}
			case emotiontatus.cry:
				{
					ani.Play(shapekeyList.ElementAt(2));
					break;
				}

		}
		

	}

	// Start is called before the first frame update
	void Start()
    {
        setup();
    }

    // Update is called once per frame
    void Update()
    {
		//crlLivestatus();
		crlemojitatus();
		crlAcitvetatus();
    }
}
