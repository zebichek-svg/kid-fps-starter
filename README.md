# Kid FPS Starter

A beginner-friendly first-person shooter starter project for kids.

This project focuses on the fundamentals of FPS gameplay in a simple way:
- WASD movement
- Jumping
- Crouching
- Mouse look
- Shooting
- Recoil
- Target range
- Score tracking

This repository is intentionally simple and beginner-friendly so you can learn the important mechanics before adding more advanced systems like enemies, health, or bigger levels.

## Recommended Unity version
Use Unity 2022 LTS or later.

## Setup steps
1. Open Unity Hub
2. Create a new 3D project
3. Open this repository in the project folder or copy the scripts into a Unity project
4. Create a `Player` object with a `CharacterController`
5. Add a child camera named `Main Camera`
6. Attach `MouseLook.cs` to the camera
7. Attach `FirstPersonController.cs` to the `Player`
8. Attach `BasicShooter.cs` to the `Player`
9. Add a `Ground` object with a `Plane`
10. Create target cubes and tag them as `Target`
11. Add `TargetHealth.cs` to each target
12. Add a `Canvas` with two `Text` objects for score and timer
13. Attach `GameManager.cs` to an empty object and assign the UI Text references
14. Press Play and test:
   - `WASD` to move
   - `Space` to jump
   - `Left Control` to crouch
   - `Left Shift` to sprint
   - Mouse to look around
   - Left Click to shoot

## Included scripts
- `Assets/Scripts/FirstPersonController.cs` – movement, jump, sprint, crouch, gravity
- `Assets/Scripts/MouseLook.cs` – camera rotation and recoil
- `Assets/Scripts/BasicShooter.cs` – raycast shooting and target hit detection
- `Assets/Scripts/TargetHealth.cs` – target health and respawn logic
- `Assets/Scripts/GameManager.cs` – score and round timer

## What this shooting range includes
- movement
- aiming
- shooting
- recoil
- target damage
- score
- countdown timer
- target respawn

## Next step after this
Once the shooting range works, the next systems to add are:
- enemy characters
- health bars
- sound effects
- fun arena art
- more levels or modes

If you want, the next step is to add a simple enemy bot or a colorful winning screen.
