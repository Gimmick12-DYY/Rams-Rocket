# Rams-Rocket
## Authors: Lingxiao Han, Wai Phyo Hein, Ben Luis, Yuyang Deng
Check out our newest version of the game on <ins>ramsrocket.online</ins>!

## Inspiration and Background Info
This project, **Rams-Rocket**, is essentially inspired by the recent heated tech topic about SpaceX's rocket launches and Boeing's failure on NASA's next-gen rocket development. We deeply felt that an easy-accessible educational game is needed as an educational tool for people to gain a brief understanding about rocket and the technologies behind it. After deep review of the existing products on the market, we felt that an educational simulator game is a more favorable way to attract users, as the interactive element was proven to be beneficial on enforcing learning experiences, hence the Rams-Rocket project came alive.   

[Overall Design](#overall-design)  
[Unity Platform and C#](#unity-platform-and-c)    
[Math Function](#math-function)  
[Graphics Involved](#graphics-involved)  
[Accessibility on Website and WebGL Build](#accessibility-on-website-and-webgl-build)  
[Delegation of Work and Roles](#delegation-of-work-and-roles)  


## Overall Design
We split the game to two modes: the **Game** mode and the **Learn** mode. The **Game** mode contains two scenes: the **Rocket Customization** and the **Rocket Launch**. The **Learn** mode provides information about the three parts of a rocket that were used in the demo: the **Payload**, the **Body**, and the **Propulsion**. We also include important physics theorems and formula in the **Learn** mode to provide educational information. 

Overall, We created **8 scenes** in Unity:

**StartGameScene**  
The scene is the introduction to the Game, with a button that will lead to the next scene.    
**ChooseModeScene**   
The scene is the site for the player to choose between the two modes. There're two buttons that will lead to the corresponding scenes for the two modes.    
**LearnModeScene**  
The scene is the mother to three children scene, the players are able to choose what part of the rocket they want to learn about by clicking the corresponding buttons.  
**BodyScene**  
The scene containing the information for the body part of the rocket.  
**PayloadScene**  
The scene containing the information for the payload part of the rocket.  
**PropulsionScene**  
The scene containing the information for the propulsion part of the rocket.  
**BuildRocketScene**  
The scene that the players will first enter when they choose the **Game** mode, and they can customize the rocket according to the customization panel. Each click on the buttons will swap the prefabs between a collected list of the prefabs for the rocket parts. The behavior is controlled by the script **RocketPartManager**. On the other side, the rocket status panel will show the statistics for the rocket that will affect the launch of the rocket, which includes the thrust and the weight of the rocket. The launch button will lead the player into the next scene.   
**LaunchScene**   
The scene that the rocket will actually launch. This scene includes the rocket GameObject, a VFX particle that performs as the flame from the rocket's engine, the changing sprites of the background image. The effect is acheived by multiple scripts, which will be explained in the following section. 

## Unity Platform and C#
The biggest challenge of doing this project lies within ourselves: **All members of our team were focused on Back-end Development, and we basically knew nothing about Full-stack Development**. During our start-up team meeting on Friday, after brainstorm we proposed two methods of building this **Full Stack Project**: 1) Use full-stack frameworks such as **React** or **Tailwind CSS**; 2) Use game engine such as **Unity**. After in-depth consideration we decided to use the later, giving the fact that we have to learn all the basic functions for either choice, we decided to use a more industry-specific tool for our development. After studying the basics of Unity through tutorials, we started development on Saturday.

It turns out that Unity was especially helpful for our development and we were able to apply much of its unique features to help up build the game project. We utilized the **Prefab** feature from Unity to create undestroyable GameObjects that can persist as our UI and rocket model. We converted much of the **Prefabs** into **Scriptable GameObjects** so that they can be applied into our **C# Scripts**. The unique **Scene Controll** helped us a lot to regulate and assort different assets that were used in the project. We were also able to apply the **VFX Objects** and **Particle renderer** from Unity to create the visual effects that improve the player experience, such as the flame object from our Rocket launch. In addition, Unity Engine was helpful in its building options, we were not only able to build the game in the traditional executable .exe format, but also a WebGL format so that it can operate on a website.

We created multiple **C# Scripts** for the Unity project, which will be illustrated in the following list:

### SceneManagerTool
A simple helper script that takes in a string as parameter and utilizes Unity's built-in **sceneLoad** feature to help us switch between scenes. This helper script was mainly used on the buttons we implemented for scene swapping.
### DontDestroyOnLoad
A simpler helper script that utilizes Unity's built-in **DontDestroyOnLoad** feature to keep the GameObject undestroyed when accross to different scenes. 
### RocketPartManager
This script helped us to assemble the rocket from different options of rocket parts. It takes in **Scriptable GameObject** into three distinctive lists that contain all the prefabs we designed for the rocket. It also contains functions that helped to display the basic statistics of the customized rocket: weight and thrust.
### RocketPartData
This script defines the **Scriptable GameObject** that we will use to assemble the rocket, the attributes of the rocket are defined in the file, namely the statistics of each part, including weight, name, thrust (propulsion part), and the prefabs created.
### RocketManager
This script is the very core of the game which controlls all the **real-time calculation** for the rocket's motion in the Launch scene. All the math functions involved will be explained in the following section. In addition, multiple Update functions were used to update the real-time mass of the rocket, as well as the velocity and acceleration so that they can be displayed for the players. We used the **FindComponent** and **Tag** feature in Unity to help us track variables across different scripts, which helped us to better regulate the game rendering process.
### ScrollUV
This script primarily helped us to controll camera motion during Rocket Launch. The **integration of camera following motion and changing mesh of the quad background** helped us to achieve a visual effect of the Rocket Launch that as if the scene is built in 3D. 

## Graphics Involved
The lack of assets that we need to use in the Unity project was yet another big challenge for us to resolve. We lacked the time to inidividually design different styles of rocket parts as well as other visual elements in the game. We came up with the idea of utilizing **generative AI** to produce most of the art for our game. The main tool that we used was **Adobe Express**, the powerful generative tool provided by Adobe. The chief advantage of **Adobe Express** was its ability to select through different artistic styles during generation, through which we were able to finish a Game project with an unified artistic style. The result was magnificent. Through the help of **Adobe Express**, we were able to generate 4 sets of Rocket design, sum to 12 distinctive assets, as well as all the background images for our game scenes. 

## Math Function
There are five main functions for mathematical calculation of the rocket **calculateNetPropulsion, ConsumeFuel calculateAcceleration, updateHeight,** and **getGravity.**

Before the launch, the rocket can be assembled on the player's preference that changes the weight and the propulsion of the rocket. 

We calculate the gravitational force using G = $\frac{Mm}{r^2}$ where total weight of the rocket depends on the player chosen payload and body before the launch. The radius in the formula is calculated as the combined distance of the radius of the earth (constant) and the distance traveled of the rocket after the launch, which is changing. We use the **updateHeight** function for the distance traveled. To reflect the real-world scenario, we use the **calculateNetPropulsion** to subtract the gravitational force derived from **getGravity** from the **totalPropulsion**. To show how the rocket is accelerating, we use the **calculateAcceleration** function to reflect the changing acceleration of the rocket while it is traveling into the space. We also have the **ConsumeFuel** function to calculate how many fuel has been consumed during the travel. Here, it is significant because the fuel consumption rate reflects the total weight of the rocket that reflects the gravitational force between the rocket body and the earth. 

## Website Platform and WebGL Build
We aimed to make our game accessible to a broad audience by hosting it on a website. To achieve this, we chose to build the game using **WebGL**, allowing seamless display of game elements across web platforms. Unity served as our development engine, providing flexibility for building and deploying the game in multiple formats should we decide to explore other hosting options in the future. For deployment, we created a **static website** incorporating the **WebGL** element to showcase the game. GitHub Pages was selected as our hosting service, offering a cost-effective solution for static sites. Additionally, we purchased a custom domain and **configured DNS** records to direct traffic to GitHub’s servers, ensuring our website was accessible through our chosen domain. Initially, we launched our game on a **.tech domain**, but it was mistakenly flagged as malware by the school's network, likely due to the absence of an **SSL security certificate**. To resolve this, we secured a new .site domain, where we will implement HTTPS to ensure secure, trusted access to our website and enhance user confidence .

## Possible Extensions and Updates for the Project
## What's next for Rams-Rocket
There are two categories that we would like to improve: Graphic and User Interface for more interactions and complex physics and mathematics to power the rocket for more functions.    

We would like to improve more on Learn part of the game for educational interactions with interactive labels for each part of the rocket. In the future, we would also like to include 3D models for parts as well. We also would like to add a graphical feature to mimic parameters like _current velocity, current acceleration,_ and _remaining fuel._     

For more mathematical calculations, we would like to include _Aerodynamic Drag_ to experience air resistance, _Altitude-Based Air Density_ to simulate the Earth's atmosphere, and _Rocket Staging_.

## Delegation of Work and Roles
**"Game Dev":** Lingxiao & Yuyang  
The two individuals primarily focused on Unity development, including the coding for most C# scripts, scene designs, and engine build.   
**"Chief Scientist":** Wei Phyo   
The individual primarily focused on building the **Learn** mode, including finding the background physics concepts and theories, as well as developing the math functions for us to calculate rocket velocity.   
**"Web Dev":** Ben  
The individual primarily focused on setting up the configuration of the website access of our game, including DNS configuration, WebGL loading, as well as generating the visual elements that were used in our project.   

