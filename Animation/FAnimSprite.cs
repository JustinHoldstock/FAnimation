using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FAnimSprite : FSprite {
	
	private Dictionary<string, List<Frame>> m_animations;
	private Frame m_currentFrame;
	private string m_strCurrentAnimation;
	private int m_nFrame;
	private float m_fFrameTimer; //increment by DT to trigger next frames
	private float m_fPlaySpeed; //the speed at which to play animations
	
	public FAnimSprite() : base() {
		m_nFrame = 0;
		m_fFrameTimer = 0;
		m_fPlaySpeed = 1;
	}
	
	public FAnimSprite(string _spriteID) : base() {
		
		_localVertices = new Vector2[4];
		m_nFrame = 0;
		m_fFrameTimer = 0;
		m_fPlaySpeed = 1;
		
		load(_spriteID);
	}
	
	public void load(string _spriteID) {
		m_animations = FAnimationManager.Instance.getSpriteData(_spriteID);
		
		if(m_animations == null) {
			Debug.LogWarning("No Sprite Data for " + _spriteID);
		}
		else {
			setAnimation(m_animations.Keys.First());
			
			Init(FFacetType.Quad, _element,1);
			
			_isAlphaDirty = true;
			
			UpdateLocalVertices();
		}
	}
	
	override public void Redraw(bool shouldForceDirty, bool shouldUpdateDepth)
	{
		//if there/s more than one frame, UPDATE!
		if(m_animations[m_strCurrentAnimation].Count > 1) {
			
			m_fFrameTimer += Time.deltaTime * m_fPlaySpeed;
			
			if(m_fFrameTimer > m_currentFrame.Delay) {
				
				++m_nFrame;
				
				//animation has ended, so let's reset the current frame and trigger an event
				if(m_nFrame >= m_animations[m_strCurrentAnimation].Count) {
					m_nFrame = 0;
					onAnimEnd();
				}
				
				m_currentFrame = m_animations[m_strCurrentAnimation][m_nFrame];
				
				_element = m_currentFrame.Element;
				
				m_fFrameTimer = 0;
				shouldForceDirty = true;
			}
		}	
		base.Redraw(shouldForceDirty, shouldUpdateDepth);
	}
	
	#region Animation Helpers
	//resets play speed to one
	public void resetPlaySpeed() {
		PlaySpeed = 1.0f;
	}
	
	//pauses the animation
	public void pause() {
		PlaySpeed = 0.0f;
	}
	
	//reset the current animation to its first frame
	public void resetAnimation() {
		m_currentFrame = m_animations[m_strCurrentAnimation][0];
		m_fFrameTimer = 0;
		m_nFrame = 0;
	}
		
	//triggered at the end of an animation
	public virtual void onAnimEnd() {
	}
	#endregion
	
	#region ACCESSORS & MUTATORS	
	public float PlaySpeed {
		get { return m_fPlaySpeed; }
		set { m_fPlaySpeed = value; }
	}
	
	public void setAnimation(string _anim) {
		
		if(_anim != m_strCurrentAnimation) {
			if(m_animations.ContainsKey(_anim)) {
				m_strCurrentAnimation = _anim;
				_element = m_animations[m_strCurrentAnimation][0].Element;
			}
			else {
				Debug.Log("Animation Doesn't exists for " + _anim + " Reverting");
			}
			resetAnimation();
		}		
	}
	
	public string getCurrentAnimation() {
		return m_strCurrentAnimation;
	}
	
	#endregion
	
	public void logAnimations() {
		foreach(KeyValuePair<string, List<Frame>> kvp in m_animations) {
			Debug.Log(kvp.Key.ToString());
		}
	}
}