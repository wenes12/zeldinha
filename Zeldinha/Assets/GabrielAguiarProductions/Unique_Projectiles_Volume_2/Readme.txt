Unique Projectiles Volume 2 - Readme


This package contains:

- 30 Projectiles Prefabs;
- 30 Hits/Impacts Prefabs;
- 26 Muzzles Prefabs;
- Demo Scene;
- Customizable Shaders;
- Particle System Controller Script (control size, speed, color, lights, trails, enable/disable vfxs, etc);
- Projectile Script (control fire rate, accuracy, fire point, etc);




DEMO SCENE - SHORTCUTS:

Mouse 1 - Fire Projectile
D - Next Effect
A - Previous Effect
C - Change Camera
Z - Zoom In
X - Zoom Out
1 - Enable/Disable Camera Shake




PARTICLE SYSTEM CONTROLLER SCRIPT - DESCRIPTION:

This script is used to change Size, Color, Enable/Disable Particle Systems, etc. It's a tool.
It only works on Prefabs that are in the folder, not in the Scene/Hierarchy.
Recommended to duplicate the effect before using.

Options:
'Size' - Multiplies Particle Systems and Trails sizes.
'Speed' - Multiplies Particle Systems and Trails speeds.
'Loop' - Enable/Disable Particle Systems loop.
'Lights' - Enable/Disable Particle Systems lights.
'Trails' - Enable/Disable Particle Systems trails.
'Changes Color' - Enable/Disable changing color of Particle Systems and Trails speeds.
'New Max Color' - New maximum color.
'New Min Color' - New minimum color.
'Particle Systems' - The Particle Systems and Trails the prefab contains. Can be filled automatically with 'Fill Lists' button, or manually.
'Active Particle Systems' - Choose which Particle Systems and Trails are active. Can be filled automatically with 'Fill Lists' button, or manually.
'Fill Lists' - Finds and adds Particle Systems and Trails, of the parent and childs of current gameobject, to 'Particle Systems' and 'Active Particle Systems' lists.
'Empty Lists' - Emptys 'Particle Systems' and 'Active Particle Systems' lists.
'Apply' - It will apply the changes you made (Size, Speed, Loop, Lights Enabled/Disabled, Trails Enabled/Disabled, Change Color) to the particle systems in 'Particle Systems' that ARE active in the 'Active Particle Systems' list. It will also save the original settings in a folder called 'Original Settings' inside the folder of the vfx prefab.
'Reset' - Resets the Particle Systems and Trails to the original settings which are saved in a folder called 'Original Settings' inside the folder of the vfx prefab.

Workflow:
1) Add script to any VFX prefab;
2) Press 'Fill Lists' to automatically find and add Particle Systems and Trails to lists;
3) Make your changes (Size, Speed, Loop Enabled/Disabled, Lights Enabled/Disabled, Trails Enabled/Disabled, Change Color, Enable/Disable Particle Systems with 'Active Particle Systems' lists);
4) Press 'Aplly';
5) Script saves original settings and applies changes;
6) That's it, enjoy. 
PS: You can always press 'Reset' to go back to original settings.

Warnings:
1) If you need to change the name of the VFX, you can. BUT you must go to the respective 'Original Settings' folder and copy paste the exact same name of the VFX.
2) Some properties of the particle systems, IF changed manually, may break the connection with original settings and won't be able to reset it to default.
3) If you are afraid of messing the original effect, create a duplicate first. In case you messed up you can always reimport from the Asset Store.





PROJECTILE MOVE SCRIPT - DESCRIPTION:

This script is only for the DEMONSTRATION of the Projectile's Visual Effects! It's not perfect.

Options:
'Speed' - The speed of the projectile.
'Accuracy' - The accuracy the projectile has. Goes from 0 to 100. For example, 100% of accuracy means it goes exactly where we aiming at.
'Fire Rate' - The fire rate of the projectile. For example, 1 means it will fire 1 projectile each second.
'Muzzle Prefab' - The effect to spawn each time we fire the projectile.
'Hit Prefab' - The effect to spawn when hitting something.
'Shot SFX' - The sound it makes when firing a projectile.
'Hit SFX' - The sound for when hitting something.
'Trails' - It's the 'Particle Systems' or 'Trail Renderers' that we want to dettach when hitting something. If not added it will destroy the trail of particles or the trail renderer as soon as it it's something.

Workflow:
1) Choose the 'Speed' of the projectile.
2) Choose the 'Accuracy' it will have. For example, 100% of accuracy means it goes exactly where we aiming at.
3) Choose the 'Fire Rate' . For example, 1 means it will fire 1 projectile each second.
4) Assign the respective Muzzle Flash you want to the 'Muzzle Prefab'.
5) Assign the respective Hit effect you want to the 'Hit Prefab'.
6) If you have SFX, you can assign them to the 'Shot SFX' for when shooting and the 'Hit SFX' for when hitting something.
7) In the 'Trails' you can add the trail renderers, and the respective particles that leave a trail, preventing from being immediatly destryoed on collision.






POST-PROCESSING EFFECTS INFO:

All footage was done using Post-Processing Effects. Follow this steps if you want to achieve that quality:

1) Go to Unity Archives ( https://unity3d.com/get-unity/download/archive ), select your version and download the Standard Assets from the drop-down list;

2) Import that package to your project in Unity (you can only import the Effects folder if you want);

3) In the DemoScene01 you can add "Depth Of Field", "Bloom", "Vignetter And Chromatic Aberration", "Sun Shafts" and "Color Correction Curves" components to the cameras;

4) Play with the values;

4) Enjoy and Have Fun!





CONTACTS:

Feel free to contact me via links bellow in case you have any doubts. 

Twitter: @GabrielAguiProd

Facebook: facebook.com/gabrielaguiarprod/

YouTube: youtube.com/c/gabrielaguiarprod








NOTES:
ALL THE SCRIPTS are used for DEMONSTRATION porpuses of the Projectiles! They are not perfect.
I recommend everyone to eventually create their own code for their own projects.
Please contact me if any doubts emerge.




Thank you for purchasing the Unique Projectiles Volume 2 package.
Unique Projectiles Volume 02 is created by Gabriel Aguiar



If you liked this Visual Effects package, please leave a review on the Asset Store! It means a lot. Thank you!

