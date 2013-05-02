This is a plugin for Matt Rix's Futile Framework, https://github.com/MattRix/Futile, that allows for animations to be loaded and played using FAnimSprite.

The naming convention of all assets must be as follows: SpriteID-Animation-FrameNum-Delay

SpriteID will be parsed as a string to be used for referencing sprite data.

Animation will be parsed as a string for which animation set it belongs to. ** is optional  **

Frame is parsed as an int to be used for sorting frame list ** is optional, needs to be implemented   **

Delay will be parsed as a float value. indicates FPS for animation to be played at. ** optional, uses 60FPS by default   **


So, steps to use animations:
1) Replace all Futile.atlasManager.LoadAtlas(""path)
with
FAnimationManager.Instance.LoadAtlas("path");

2)FAnimSprite construtor takes in the SpriteID (outlined in the Naming Convention)
FAnimSprite mySprite = new FAnimSprite("SuperDude");

3)To change the animation of the asset call setAnimation("animationName")
mySprite.setAnimation("Run");

4)To change the atlas/id of a sprite, just use FAnimSprite.load("SpriteID");
//mySprite is currently using the SuperDude sprite data. next line changes it to use EvilDude images and data
mySprite.load("EvilDude");


MORE TO COME IN LATER UPDATES:

-proper cleanup 

-setting a delay factor to speed up and slow down animations

-optimizations

-sorting frames based on FrameNum

-anything suggested by other users!

**disclaimer. Will be tidied and optimized. Works right now, just no asset cleanup.
