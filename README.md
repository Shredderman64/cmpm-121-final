# Devlog Entry - 11/22/2024

## How we satisfied the requirements

## F0.a

F0.a was Implemented using a GridManager class that instantiated a 2D array of Tiles. This corresponds to the Array of Structures format. Player movement is based on discrete units determined by Tile size, while their global position is restricted by the overall size of the grid. Tile-specific data can be accessed through the GetTileAt function. Movement was implemented by checking for keyboard presses binded for movement which are the WASD keys. Pressing a key for the desired direction sends out a target exactly one tile away in the direction the player wishes to move in. If the target returns a valid coordinate within the grid system, the player moves smoothly to the target tile.

## F0.b

F0.b was Implemented using a separate TimeManager class that increments a day counter and adds a basic UI button for manually advancing time. The observer pattern is used to allow other components in the game to subscribe to and listen for the "OnNextDay" event, which is invoked whenever time is advanced by pressing the button.

## F0.c

Rendered tiles are generated in the scene according to the base grid layout. A tile interaction script is attached to the player character that uses raycasting to return the tile that mouse is currently over. A UI menu that allows players to sow three different kinds of plants on that tile will show up when the left mouse button is clicked. The player can then reap tiles that have plants sowed in them which simply destroys the object that is referenced in that tile.

## F0.d

Tiles have attributes for sun and water levels. These get randomized whenever time is advanced by having the GridManager listen for the "OnNextDay" event. Sun levels are assigned a random value within a certain range. Water levels are partially retained between events by having them either increment or decrement by a random value selected from the set of pre-defined values.

## F0.e

For our F0.e feature, we used prefabs to create a template for each plant, and used these prefabs when instantiating plants. All plants share a common parent prefab which it inherits from, called Plant. Each specific plant like the carrot plant is a variant of the Plant prefab. This means that each Prefab Variant of the Plant Prefab is a child that inherits from the Plant prefab. The Plant Prefab contains scripts and values that are common across all plants, while the Prefab variants have modified fields in its properties such as growth time and minimum growth requirements to set it apart from other plants.

## F0.f

All plants have a script attached to them that dictates when and how they grow. The various growth stages for each plant are stored as children under a parent prefab which serves as the initial in-game object for the plant. A check for plant growth is triggered when the "OnNextDay" event is invoked from the TimeManager. If the conditions for that plant based on tile-specific data are all met, the plant will update to the next prefab in its stored list of stages.

## F0.g

When going into F0.g we first discussed how to best implement the feature given all prior steps, due to us having to implement plant growth and planting features before reaching the complete play scenario condition. A script called PlayScenarioManager runs a check on every OnNextDay event to see if it meets the targetFullyGrownPlants. It then sends out a message to the console log that the play scenario is complete. It gathers the Plant objects in the scene using FindObjectsOfType<Plant>() and checks if their currentStage is at its final stage.

## Reflection

From the very beginning, we had some broad ideas as to where we wanted to take the direction of our game. This included making our game more specifically as a dungeon crawler or implementing a “blight” feature that affects crop growth. However as we worked towards fulfilling the requirements of F0, we realized that the task was much more difficult at hand. There may be a time where we can implement these game design concepts, but they are not our top priority within our game since we just wanted to meet basic requirements first and foremost. Another thing that we pivoted away from was the use of an isometric camera. However, we found that going with top-down angled perspective may be better since it gave a better look at moving throughout the game space, hence why we switched to that. We did not have to reconsider any of the choices previously described for Tools and Materials or our roles, since we took time to research and consider the best possibilities for us to execute our game’s creation without running into too many hitches. The only thing that may be considered a change was thinking there was a larger emphasis on needing to model 3D assets for our game (since one of our members is skilled with that) but we were able to find pretty good use out of free online assets that were able to represent what we needed to satisfy the game requirements.

# Devlog Entry - 11/14/2024

## Introducing the Team
Issac Kim - Engine Lead </br>
Nolan Jensen - Design Co-Lead </br>
Steven Hernandez - Design Co-Lead </br>
Garrett Yu - Tools Co-Lead </br>
Kellum Inglin - Tools Co-Lead </br>

## Tools and Materials
In regards to the engines we plan on using, we chose Unity as our initial engine based off
the team's relative familiarity with it. We also found that it would be useful to gain additional 
experience in a game engine used typically in modern game development compared to the likes of Phaser.
We were also interested in making the game 3D, which other older game engines may be uncapable of doing,
whereas Unity is one of a few engines that is perfect for that. We plan to use placeholder assets from
within Unity, though we are interested in making our own if possible to add flair to the game.

We intend on using C# as our primary programming language due it being the default language 
in Unity. Unity also features a multitude of scripting opportunities so we intend to use them to
their fullest extent to execute our game. We may need to convert our game objects to JSON, so that
is something we may need to consider as an additional data language to help our process.

For tools, we plan on using VSCode for our IDE with Git version control. Again, these were
chosen largely based on team familiarity alongside their ease of integration with our chosen
engines. Issues regarding merge conflicts would also likely be kept to a minimum since Unity 
is object-based in terms of its coding. We also have one team member who has experience in 3D 
modeling, so we'll likely use the appropriate software needed for that, such as Blender and Substance Painter.

Our alternative platform that we intend to use is Godot. Our main reason being that the engine is
similar to Unity and is also based in C#. This would allow us to easily transfer our game from one engine
to another when we need to make the switch. In terms of recreating the essential objects required for the
game, the similarities in engines should play to our advantage and hopefully shouldn't deter the process.

## Outlook

One of the outcomes that we expect from this project is that we'll gain more relevant experience
in regards to building and deploying software from scratch, especially since up to this point,
we've mainly been given the appropriate frameworks to begin with. We anticipate the hardest
parts of this project to be time management and communicating clearly on what each of us is
developing.
