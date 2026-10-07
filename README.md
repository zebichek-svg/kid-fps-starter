# Kid FPS Starter

A beginner-friendly first-person shooter starter project for kids.

This project focuses on the fundamentals of FPS gameplay in a simple way:
- WASD movement
- Jumping
- Crouching
- Mouse look
- Character controller setup

This repository is intentionally simple and beginner-friendly so you can learn the important mechanics before adding shooting, enemies, or scoring.

## Recommended Unity version
Use Unity 2022 LTS or later.

## Setup steps
1. Open Unity Hub
2. Create a new 3D project (URP or Built-in is okay)
3. Clone this repo into a folder or copy the files into your Unity project
4. In the Unity editor, create an empty GameObject called `Player`
5. Add a `CharacterController` component to the Player object
6. Add a child camera to the Player object and name it `Main Camera`
7. Attach `MouseLook.cs` to the camera
8. Attach `FirstPersonController.cs` to the Player object
9. Drag the camera into the `cameraTransform` field on the controller
10. Press Play and use:
   - `WASD` to move
   - `Space` to jump
   - `Left Control` to crouch
   - `Shift` to sprint
   - Mouse to look around

## Scripts included
- `Assets/Scripts/FirstPersonController.cs` – handles movement, jumping, sprinting, crouching, and gravity
- `Assets/Scripts/MouseLook.cs` – handles the camera rotation with the mouse

## Beginner notes
This project is intentionally minimal. The goal is to learn how FPS controls work before adding more advanced systems like shooting recoil, enemies, or projectile physics.

## Next step after movement
Once movement feels good, we will add:
- shooting
- recoil
- hit detection
- target objects
- score and health
- fun kid-friendly arena polish

If you want, the next step is to build the shooting system.
