This branch is an implementation for procedural land generation with the Perlin Noise Technique, look to the others branches for different techniques.

-All the scripts are in the Assets folder:

--- The Noise.cs script generate the HeightMap

--- The MapGenerator.cs script gerate the ColourMap from the HeightMap

--- The TextureGenerator.cs script generate the textures for the HeightMap and the ColourMap

--- The MapDisplay.cs script draw the textures of the HeightMap and the ColourMap

-assing the MapGenerator and the MapDisplay scripts as components to an empty object named MapGenerator

-create a plane and assign the render of the plane to the MapDisplay
