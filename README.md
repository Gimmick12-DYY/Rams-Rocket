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

It turns out that Unity was especially helpful for our development and we were able to apply much of its unique features to help up build the game project. We utilized the **Prefab** feature from Unity to create undestroyable GameObjects that can persist as our UI and rocket model. We converted much of the **Prefabs** into **Scriptable GameObjects** so that they can be applied into our **C# Scripts**. The unique **Scene Controll** helped us a lot to regulate and assort different assets that were used in the project. We were also able to apply the **VFX Objects** and **Particle renderer** from Unity to create the visual effects that improve the player experience, such as the flame object from our Rocket launch.

We created multiple **C# Scripts** for the Unity project, which will be illustrated in the following list:

### SceneChangeManager

## Graphics Involved
The lack of assets that we need to use in the Unity project was yet another big challenge for us to resolve. We lacked the time to inidividually design different styles of rocket parts as well as other visual elements in the game. We came up with the idea of utilizing **generative AI** to produce most of the art for our game. The main tool that we used was **Adobe Express**, the powerful generative tool provided by Adobe. The chief advantage of **Adobe Express** was its ability to select through different artistic styles during generation, through which we were able to finish a Game project with an unified artistic style. The result was magnificent. Through the help of **Adobe Express**, we were able to generate 4 sets of Rocket design, sum to 12 distinctive assets, as well as all the background images for our game scenes. 

## Math Function

## Accessibility on Website and WebGL Build

## Delegation of Work and Roles
**"Game Dev":** Lingxiao & Yuyang  
**"Chief Scientist":** Wei Phyo  
**"Web Dev":** Ben  

