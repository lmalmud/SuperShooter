# HW 5: Chapters 11, 12, 13
- To see that the enemies have explosions upon death, you can manually set "Amount" to 0 in the editor and they will blow up (sorry, sometimes they are hard to shoot and/or look at but you can spam click and it should work)
- There is a bonfire and waterfall implemented on the side of the scene
- There is a light rain over the entire scene (sorry if it is difficult to see)

# HW 4: Chapters 3, 4, 10
- You can see the floating sky cube which implements the initial texture and the pile of water (on the right) which implements the main part of the chapter
- Everything is in the scene called "Game"
- I tried to also integrate with the things from the previous chapter- so the player now has a texture and the enemies can walk on the NavMesh that is on the surface we made this time around
- The player still shoots and moves (just really slowly)

# HW3: Chapters 7, 8, 9
- The enemies are not very good at getting the player, so to check the win condition, it may be better to manually set ```Life > amount``` to be zero
- Movement is WASD, but the player glides around very smoothly so it might be tricky (sorry)
- You can click to shoot and see that the enemies will die. To win, you must kill all enemies.
- There is a win screen that has an ellipsoid and a lose screen that has a capsule.

# HW2: Chapters 1, 2, 5, 6
- You may notice some extra GameObjects floating around (one of the "challenges" to create a room, etc.)
- My work is in `SampleSene`
- The bulk of this assignment had to do with adding movement and bullet firing. This behavior was implemented in `Enemies > Moving Flying Enemy`
    - The relevant scripts are in the `Assets > Scripts` folder
    - You can use usual WASD keys to move and the mouse to rotate (the sensitivity on my Mac was quite low)
