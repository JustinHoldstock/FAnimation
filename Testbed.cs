using UnityEngine;

public class Testbed : MonoBehaviour {
  
	//the animation sprite
	FAnimSprite aSprite;
	//for switching animation demo!
	float time = 3.0f;
	
	
	/************ REPLACE THESE WITH YOUR OWN TEXTURE ATLASES TO SEE THE DEMO! ***********/
	//asset sheet
	const string MY_ATLAS_PATH = "Atlases/shapeAssets";
	//sprite id for a regular FSprite (located on the left)
	const string FSPRITE_ID = "Triangle-default-1";
	//sprite id for the animated sprite!
	const string FANIM_ID = "Triangle";
	//the animation to switch to after time runs out
	const string ANIMATION_TO_SWITCH_TO = "Run";
	/************************/
	
	
	public Testbed() {
	}
	
	// Use this for initialization
	void Start () {
	
		// Set up Futile.
		FutileParams fParams = new FutileParams(true, true, false, false);
		fParams.AddResolutionLevel(1024.0f, 1.0f, 1.0f, "");
		Futile.instance.Init(fParams);
		
		// Load assets.
		FAnimationManager.Instance.LoadAtlas(MY_ATLAS_PATH);
		
		FContainer container = new FContainer();
		
		FSprite sprite = new FSprite(FSPRITE_ID);
		sprite.SetPosition(-100,0);
		
		//setup the animation sprite
		aSprite = new FAnimSprite(FANIM_ID);
		aSprite.SetPosition(100, 0);
		
		Futile.stage.AddChild(container);
		
		container.AddChild(sprite);
		container.AddChild(aSprite);
		
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		
		//after time lapse, just change the animation!
		if(time < 0) {
			aSprite.setAnimation(ANIMATION_TO_SWITCH_TO);
			time = 99999999;
		}
	}
}
