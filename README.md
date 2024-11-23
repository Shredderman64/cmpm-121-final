# Devlog Entry - 11/27/2024

# Devlog Entry - 11/22/2024

## How we satisfied the requirements

## F0.a

Implemented a separate GridManager class that is instantiated as a collection of Tiles. Tiles can be
returned based on global position, which is translated to the corresponding grid position. Player
movement is based on discrete units determined by Tile size, while their global position is restricted
by the overall size of the grid. Tile-specific information can be returned through the GetTileAt
function.

## F0.b

Implemented a separate TimeManager class that increments a day counter and adds a basic UI for manually
advancing time. The observer pattern is used to allow components to listen for the "OnNextDay" event,
which is invoked whenever time is advanced.

## F0.c

Rendered tiles are generated in the scene according to the base grid layout. A tile interaction script is
attached to the player character that uses raycasting to return the tile that is currently moused over.
A UI menu that allows players to sow three different kinds of plants on that tile will show up when
"Mouse0" is clicked. The player can then reap tiles that have plants sowed in them which simply destroys
the prefab that is referenced in that tile.

## F0.d

Tiles have attributes for sun and water levels. These get randomized whenever time is advanced by having
the GridManager listen for the "OnNextDay" event. Sun levels are assigned a random value within a certian
range. Water levels are partially retained between events by having them either increment or decrement by
a random value.

## F0.e

## F0.f

All plants have a script attached to them that dictates when and how they grow. The various growth stages
for each plant are stored as children under a parent prefab which serves as the initial in-game object for
the plant. A check for plant growth is triggered when the "OnNextDay" event is invoked from the TimeManager.
If the conditions for that plant based on tile-specific data are met, the plant will update to the next
prefab in its stored list of stages.

## F0.g

## Reflection

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
