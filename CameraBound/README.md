# CameraBound

A set of scripts is used to manage camera movements within an image (Sprite) and allow for zooming in/out. 
When the mouse is hovering over an UI element, it is no longer considered voluntarily. 

## How to use ?
Place the scripts like this.

1. GameObject Camera
 * Projection = Perspective (allows you to use the field of view parameter using in the Zoom script)
 * CameraMove
 * Zoom
   * Cam = GameObject Camera
   * Move = Script CameraMove
   * Zoom Multiplier = Speed of Zoom (set what you want, test different value)
   * Zoom Max = Limit of Zoom out (set by the script in the Start section)
   * Zoom Min = Limit of Zoom in (set what you want, test different value)

2. GameObject Sprite (this is the sprite where your camera stand)
 * SetWorldBounds
