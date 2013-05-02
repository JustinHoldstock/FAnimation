using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FAnimSprite : FSprite {
	
	private Dictionary<string, List<Frame>> m_animations;
	private FAtlasElement m_currentFrame;
	private string m_strCurrentAnimation;
	private int m_nFrame;
	private float m_fFrameDelay; //delay between frames
	private float m_fFrameTimer; //increment by DT to trigger next frames
	
	public FAnimSprite() {
	}
	
	public FAnimSprite(string _spriteID) : base() {
		
		
	}
	
	public void load(string _spriteID) {
		m_animations = FAnimationManager.Instance.getSpriteData(_spriteID);
		
		if(m_animations == null) {
			Debug.Log("No Sprite Data for " + _spriteID);
		}
	}
}