# PhotonNetwork TeleportManager

## Overview

The `PhotonNetwork TeleportManager` is a Unity `MonoBehaviour` script designed to work with Photon Networking (PUN). It provides runtime controls for teleporting and manipulating a `GameObject` across a networked game. The script includes options for adjusting position, rotation, scale, gravity, time scale, and Rigidbody component of the target `GameObject` using Photon’s RPC system.

## Features

- **Teleport Position:** Move the `GameObject` to a specified position across the network.
- **Teleport Rotation (Euler Angles):** Set the rotation of the `GameObject` using Euler angles across the network.
- **Teleport Rotation (Quaternion):** Set the rotation of the `GameObject` using a Quaternion across the network.
- **Change Scale:** Modify the scale of the `GameObject` across the network.
- **Change Gravity:** Adjust the gravity scale affecting the `GameObject`'s Rigidbody across the network.
- **Change Time Scale:** Modify the global time scale of the game across the network.
- **Add/Remove Rigidbody:** Add or remove a Rigidbody component from the `GameObject` across the network.

## Usage

### Setup

1. **Import Photon PUN:**
   - Import the Photon PUN package from the Unity Asset Store.

2. **Attach the Script:**
   - Add the `TeleportManager` script to any `GameObject` in your Unity scene.

3. **Assign Target Object:**
   - In the Unity Inspector, assign the `targetObject` field to the `GameObject` you want to manipulate.

4. **Photon Setup:**
   - Ensure you have Photon setup in your project. This includes setting up Photon networking and connecting to a Photon server.

### Controls

- **Teleport Position:**
  - Input X, Y, Z coordinates in the "Teleport Position" section.
  - Click the "Teleport Position" button to move the target `GameObject` to the specified position.

- **Teleport Rotation (Euler Angles):**
  - Input X, Y, Z rotation angles in degrees in the "Teleport Rotation (Euler)" section.
  - Click the "Teleport Rotation" button to rotate the target `GameObject` to the specified Euler angles.

- **Teleport Rotation (Quaternion):**
  - Input X, Y, Z, W values for a Quaternion in the "Teleport Rotation (Quaternion)" section.
  - Click the "Teleport Quaternion" button to set the target `GameObject`'s rotation to the specified Quaternion.

- **Change Scale:**
  - Input X, Y, Z scale values in the "Change Scale" section.
  - Click the "Change Scale" button to modify the target `GameObject`'s scale.

- **Change Gravity:**
  - Input the new gravity scale value in the "Change Gravity" section.
  - Click the "Change Gravity" button to adjust the gravity affecting the target `GameObject`'s Rigidbody.

- **Change Time Scale:**
  - Input the new global time scale in the "Change Time Scale" section.
  - Click the "Change Time Scale" button to modify the global time scale of the game.

- **Add/Remove Rigidbody:**
  - Toggle the "Add Rigidbody" option to add or remove the Rigidbody component.
  - Click the corresponding button to perform the action.
