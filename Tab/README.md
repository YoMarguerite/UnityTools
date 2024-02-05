# Tab

A set of scripts is used to manage camera movements within an image (Sprite) and allow for zooming in/out. 
When the mouse is hovering over an UI element, it is no longer considered voluntarily. 

## How to use ?
Place the scripts like this.

1. GameObject Tab (Could be many Tabs)
 * Image
 * Sprite (sprite when tab is select)
 * Sprite (sprite when tab is unselect)
 * Tab
   * Image = Component Image
   * SpriteSelect = Component Sprite
   * SpriteUnselect = Component Sprite
   * Screen = GameObject (to show when tab is select)

2. GameObject TabManager
 * TabManager
   * List<Tab> = All tabs in relation
