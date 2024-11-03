# Rams-Rocket
## Authors: Lingxiao Han, Wai Phyo Hein, Ben Luis, Yuyang Deng
Check out our newest version of the game on <ins>ramsrocket.online</ins>!

## Inspiration and Background Info
This project, **Rams-Rocket**, is essentially inspired by the recent heated tech topic about SpaceX's rocket launches and Boeing's failure on NASA's next-gen rocket development. We deeply felt that an easy-accessible educational game is needed as an educational tool for people to gain a brief understanding about rocket and the technologies behind it. After deep review of the existing products on the market, we felt that an educational simulator game is a more favorable way to attract users, as the interactive element was proven to be beneficial on enforcing learning experiences, hence the Rams-Rocket project came alive.   

[Overall Design](#overall-design)  
[Unity Platform and C#](#unity-platform-and-c)  
[Math Involved](#math-involved)  
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

## Math Invovled

## Graphics Involved

## Accessibility on Website and WebGL Build

## Delegation of Work and Roles
