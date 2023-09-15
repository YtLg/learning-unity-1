# Learning-Unity
My first attempt at learning unity basics since my 6th form project.

## The tutorial

#### To learn unity again, I used the following tutorial:

https://www.youtube.com/watch?v=XtQMytORBmM

#### From this I learnt multiple things, including, but not limited to:

- How to manipulate objects ( physics, movement, etc.)
- how unity handles object references
- How to create blueprints
- How to create & utilise UI

## to-do

- [x] finish the game ( tutorial)

#### After finishing the tutorial, they reccomended multiple things that I could do to discover and learn more about unity myself

- [X] add animation
- [X] Add sound
- [X] Add a game-over if out of bounds
- [X] Add a particle system generate moving background
- [X] Add a title screen
- [X] Add a way to save the score of the player

#### After completing the list of additional features he has mentioned, he also suggested that I should attempt to add a new mechanic into the game

- [X] Add a new feature to the game

Note: I opted in to add in ramping speeds for the pipes that made the game more challenging the higher the player's score got, at first I applied the speed addition to the PipeMove script itself (the blueprint script component), however that only applied to the first pipe generated, so I had to put getters and setters in the SpawnScript of the PipeSpawner game object which would then alter the pipe speed that the PipeMove script would get via a getter and apply it to their own.


#### Although not needed, since it was a beginner project to learn the ropes of how to make a basic game, I felt the assets looked rushed and needed polishing:

- [X] Polish game appearance
      note: I changed the background and the particle system image as well as the pipe image, but not the UI appearance
