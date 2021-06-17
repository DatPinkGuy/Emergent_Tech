This is one of the projects that I got to develop during my stay at University as BSc.</br>
The project's main idea is to give user a space which they could use as a reference for real life and model that virtual environment with any furniture or decorations available at the time.</br></br>
You can see the project in action below:  *(Click on Image)*</br>
[![Video](https://img.youtube.com/vi/kVT4dgxFq9E/0.jpg)](https://youtu.be/kVT4dgxFq9E)

Systems created for this project allow for:</br>
1. Automatic [sorting](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/Editor/SortFurnitureEditor.cs#L53) of all available furniture into different categories based on room type selected for furniture (used for [in-game menu](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/Manager.cs#L45))</br>
![](https://github.com/DatPinkGuy/Emergent_Tech/blob/main/GitGifs/sorteditor.gif)
![](https://github.com/DatPinkGuy/Emergent_Tech/blob/main/GitGifs/sorting.gif)</br></br>
2. Furniture and decorations [can only be placed on areas specified](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/LineAndPlacement.cs#L80) by user</br>
![](https://github.com/DatPinkGuy/Emergent_Tech/blob/main/GitGifs/areas.gif)</br></br>
3. Furniture and decor can be moved, [rotated](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/LineAndPlacement.cs#L133), [placed](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/LineAndPlacement.cs#L125) and [removed](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/LineAndPlacement.cs#L119) from the scene</br>
![](https://github.com/DatPinkGuy/Emergent_Tech/blob/main/GitGifs/rotatemovedel.gif)</br></br>
4. Walls and floors can be [changed](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/Manager.cs#L117) to different ones</br>
![](https://github.com/DatPinkGuy/Emergent_Tech/blob/main/GitGifs/floor.gif)</br></br>
5. Line renderer only [appears when user can interact](https://github.com/DatPinkGuy/Emergent_Tech/blob/442514d144a18f46e4fcfc59ed0968db33e7daea/EmergentTech/Assets/Scripts/LineAndPlacement.cs#L51) with something
![](https://github.com/DatPinkGuy/Emergent_Tech/blob/main/GitGifs/render.gif)</br></br>
</br>
