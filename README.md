This is a plugin for Matt Rix's Futile Framework, https://github.com/MattRix/Futile, that allows for animations to be loaded and played using FAnimSprite.

<h1>Naming Convention</h1>
The naming convention of all assets must be as follows: SpriteID-Animation-FrameNum-Delay
<p>
ie) SuperDude-Jump-1-60 <br/>
SuperDude-Run-1-30 <br/>
SuperDude-Run-2-30 <br/>
SuperDude-Run-3-30 <br/>
</p>

SpriteID will be parsed as a string to be used for referencing sprite data.

Animation will be parsed as a string for which animation set it belongs to. ** is optional  **

Frame is parsed as an int to be used for sorting frame list ** is optional, needs to be implemented   **

Delay will be parsed as a float value. indicates FPS for animation to be played at. ** optional, uses 60FPS by default   **


<h1>Use</h1>
So, steps to use animations:

1) Replace all Futile.atlasManager.LoadAtlas("path")
with
FAnimationManager.Instance.LoadAtlas("path");

2)FAnimSprite construtor takes in the SpriteID (outlined in the Naming Convention) <br>
FAnimSprite mySprite = new FAnimSprite("SuperDude");

3)To change the animation of the asset call setAnimation("animationName")<br>
mySprite.setAnimation("Run");

4)To change the atlas/id of a sprite, just use FAnimSprite.load("SpriteID");<br>
//mySprite is currently using the SuperDude sprite data. next line changes it to use EvilDude images and data<br>
mySprite.load("EvilDude");


<h1>More To Come</h1>

-setting a delay factor to speed up and slow down animations

-optimizations

-anything suggested by other users!
