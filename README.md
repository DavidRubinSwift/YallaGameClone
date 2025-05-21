Mobile Game on Unity

YALLAGAME

#Participants

Student A (Gameplay): Mikhail Nazarenko
Student B (ScriptableObjects & Pooling): David Rubin

##Project Description

#This is a mobile game developed in Unity, where the player controls a ball and avoids obstacles. The game is optimized for mobile devices and includes various control mechanics.

##Core Mechanics

#Ball Control
Basic ball movement (BallMovement.cs)
Advanced control with jumps (BallMovementWithJump.cs)
Adaptive control for mobile devices
Obstacle System
Optimized obstacle spawning using object pooling (ObstaclePooler.cs)
Configurable obstacle behavior logic (Obstacle.cs)
Flexible spawn point system
User Interface
Mobile pause menu (PauseMenuMobile.cs)
Sound control (SoundToggle.cs)
Screen orientation detection (ScreenOrientationDetector.cs)
Technical Features

#Optimization
Use of object pooling for efficient obstacle management
Optimized physics performance
Adaptation to various screen resolutions
Mobile Adaptation
Support for different screen orientations
Optimized touch screen controls
Adaptive user interface
Gameplay Mechanics

#Ball Control
Smooth movement
Jump system
Physically accurate behavior
Obstacles
Dynamic spawning
Adjustable difficulty parameters
Object reuse system
Project Setup

##Required Components
Unity Editor (recommended version: 6000.0.37f1)
Built-in Render Pipeline
Project Structure
Assets/
├── Scripts/
│ ├── BallMovement.cs
│ ├── BallMovementWithJump.cs
│ ├── Obstacle.cs
│ ├── ObstaclePooler.cs
│ ├── PauseMenuMobile.cs
│ ├── ScreenOrientationDetector.cs
│ └── SoundToggle.cs
├── Scenes/
├── Prefabs/
└── Resources/

##Setup and Launch

#Open the project in Unity Editor
Configure the component parameters:
ObstaclePooler: pool size and spawn parameters
BallMovement/BallMovementWithJump: control parameters
PauseMenuMobile: UI settings
Build the project for the target platform

#Supported Platforms
Android

##Important Notes

Make sure the physics settings are correctly configured
Test across different screen resolutions
Adjust difficulty settings for balanced gameplay
Debugging

Check the Unity console for errors
Use built-in profiling tools
Test on various devices
Development Recommendations

Monitor performance on mobile devices
Test regularly across different screen resolutions
Optimize physics calculations
Adjust game difficulty for various player skill levels
