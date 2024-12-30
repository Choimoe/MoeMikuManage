# MoeMikuManage

## Overview

MoeMikuManage is a 3D model viewer application developed using C#. It supports loading models from OBJ files and provides functionalities for real-time rendering, transformations (translation, rotation, scaling), and interactive manipulation of 3D objects.

## Features

1. **Model Loading and Rendering**
   - Load 3D models from OBJ format files.
   - Realistic rendering with lighting and shading effects.
2. **Transformations**
   - Translation: Move models in 3D space.
   - Rotation: Rotate models around X, Y, and Z axes.
   - Scaling: Resize models uniformly or non-uniformly.
3. **Interactivity**
   - Smooth transitions between start and end positions for both translation and rotation.
   - Interactive UI for manual control over model transformations.
4. **Lighting and Camera Control** (Using RAY TRACING!!!)
   - Manual setting of light sources and camera positions for scene observation.

## Usage

### Running the Application

1. Ensure you have .NET Framework installed.
2. Open the solution file (`MoeMikuManage.sln`) in Visual Studio.
3. Build and run the application.

### Interacting with Models

- Use the sliders in the UI to adjust the position, rotation, and scale of the loaded model.
- Set up light sources and camera positions via the UI controls.

### Customization

- Modify the `App.config` file to configure application settings.
- Customize the appearance of the UI by editing `MainWin.Designer.cs`.

## Dependencies

- OpenTK.dll: For OpenGL bindings.
- Other referenced libraries as listed in `packages.config`.

## Contributing

If you find bugs or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the terms specified in the `LICENSE.txt` file.

------

Feel free to customize this template further to better fit your project's specifics!