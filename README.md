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

1) Replace all <code>Futile.atlasManager.LoadAtlas("path")</code>
with
<code>FAnimationManager.Instance.LoadAtlas("path");</code>

2)FAnimSprite construtor takes in the SpriteID (outlined in the Naming Convention) <br>
<code>FAnimSprite mySprite = new FAnimSprite("SuperDude");</code>

3)To change the animation of the asset call setAnimation("animationName")<br>
<code>mySprite.setAnimation("Run");</code>

4)To change the atlas/id of a sprite, just use FAnimSprite.load("SpriteID");<br>
<code>
//mySprite is currently using the SuperDude sprite data. next line changes it to use EvilDude images and data<br>
mySprite.load("EvilDude");
</code>

<h2>Playback Speed</h2>
So, knowing that it's impossible to have enough control, I've added the ability to control the speed at which <br>
animations are played, during runtime. If you want to speed them up during their playback, just use it like the <br>
examples below.<br>
<code>
//speeds up the animation playback by 2x<br>
mySprite.PlaySpeed = 2.0f;<br>
//slows the animation playback to half<br>
mySprite.PlaySpeed = 0.5f;<br>
//the default speed, as in the delta time added to the delay is unchanged<br>
mySprite.PlaySpeed = 1.0f;<br>
</code>

<h1>More To Come</h1>

-optimizations

-anything suggested by other users!
