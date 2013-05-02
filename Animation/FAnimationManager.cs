//a single Animation is List<FAtlasElement> AKA List<AnimationFrames>
//sprite data is Dictionary<string, List<FAtlasElement>> AKA Dictionary<AnimName, Frames>
//atlas data is stored as Dictionary<string, Dictionary<string, List<AtlasElement>>> AKA Dictionary<SpriteID, Animations>
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FAnimationManager {
	
	private static FAnimationManager m_instance;
	//there's a better custom container for this, but will use this for now : <atlasID, <spriteid, <animationID, list<animFrames>>>>
	private Dictionary<string, SpriteData> m_spriteData;
	
	FAnimationManager() {
		m_spriteData = new Dictionary<string, SpriteData>();
	}
	
	public static FAnimationManager Instance {
		get {
			if(m_instance == null) {
				m_instance = new FAnimationManager();
			}
			
			return m_instance;
		}
	}
	
	//oad an image using FAtlasManager and parse its data
	public void LoadAtlas(string _path) {
		Futile.atlasManager.LoadAtlas(_path);
		//parse data. going to be a lot like FAtlasManager.AddAtlas(FAtlas atlas);
		addAtlas(Futile.atlasManager.GetAtlasWithName(_path));
	}
	
	//unload all sprite data and the atlas manager
	public void unloadImage(string _path) {
	}
		
	/******* PARSING DATA ************/
	//add an atlas, and then take out it's elements and put them into m_Atlases
	private void addAtlas(FAtlas _atlas) {
		
		int elementCount = _atlas.elements.Count;
		for(int e = 0; e<elementCount; ++e)
		{
			FAtlasElement element = _atlas.elements[e];
			element.atlas = _atlas;
			element.atlasIndex = _atlas.index;
			//remember the concention "ID-ANIMATION-#-DELAY"
			string[] name = element.name.Split('-');
			int length = name.Length;
			string id = name[0];
			string animation = length > 1 ? name[1] : "default";
			int frameNum = length > 2 ? int.Parse(name[2]) : 1;
			float delay = length > 3 ? 1.0f/float.Parse(name[3]) : 1.0f/60.0f;
			
			Frame frame = new Frame();
			frame.Num = frameNum;
			frame.Element = element;
			frame.Delay = delay;

			if(!m_spriteData.ContainsKey(id)) {
				
				SpriteData spriteData = new SpriteData();
				spriteData.data = new Dictionary<string, List<Frame>>();
				spriteData.data.Add(animation, new List<Frame>());
				spriteData.data[animation].Add(frame);
				
				m_spriteData[id] = spriteData;
			}
			else {
				//it's a duplicate, so check for new animation name
				SpriteData spriteData = m_spriteData[id];
				//duplicate animName, add to list
				if(!spriteData.data.ContainsKey(animation)) {
					spriteData.data[animation] = new List<Frame>();
				}
				
				//add frame
				spriteData.data[animation].Add(frame);
				
				//then sort
				spriteData.data[animation] = spriteData.data[animation].OrderBy(f=>f.Num).ToList();
			}
		}
	}
	
	
	
	
	/************* GETTING DATA TO A SPRITE *************/
	//return sprite data based off a sprite id
	public Dictionary<string, List<Frame>> getSpriteData(string _id) {
		if(m_spriteData.ContainsKey(_id)) {
			return m_spriteData[_id].data;
		}
		else {
			Debug.LogWarning("Data not present " + _id);
			return null;
		}
	}
}



//for the sake of code readability, I'm going to make this easier with structs
public struct SpriteData {
	public Dictionary<string, List<Frame>> data;
}

public struct Frame {
	public int Num;
	public float Delay;
	public FAtlasElement Element;
}