# Flight Simulator

## Table of contents :smile_cat:
* [General info](#general-info)
* [File Organiztion](#file-organiztion)
* [Setup](#setup)
* [Run](#run)
* [UML](#uml)
* [Youtube Video](#youtube-video)




## General info
This project is a Flight Simulator Research Tool.
Part of Advenced Programing 2 at Bar-Ilan University.
This project was build with MVVM Methodology.


![](https://i2.paste.pics/C77JW.png?trs=475c231022680624d5590487b5db54382c3c1bd4cf6636753bc4d2d0f400a67e)


### Main Features:
* Server-Client connection with FlightGear
* UI for Copy Playback_small.Xml File and Connect to FlightGear with csv file.
![](https://i2.paste.pics/C6W96.png?trs=475c231022680624d5590487b5db54382c3c1bd4cf6636753bc4d2d0f400a67e)
* Scrolling through time with the time scroller - you can jump whenever you want and you can change the speed ratio, see the current Time, play and pause the Simulator.
![](https://i2.paste.pics/C727K.png?trs=475c231022680624d5590487b5db54382c3c1bd4cf6636753bc4d2d0f400a67e)
* you can see the joystick of the pilot
* Visualing data of the plane and Stick:
![](https://i2.paste.pics/C6WBC.png?trs=475c231022680624d5590487b5db54382c3c1bd4cf6636753bc4d2d0f400a67e)
![](https://i2.paste.pics/C72BV.png?trs=475c231022680624d5590487b5db54382c3c1bd4cf6636753bc4d2d0f400a67e)
* Visual Graphs: you can see 3 Graphs: Feature Graph, Coralate Graph and Regeression Graph
![](https://i2.paste.pics/C782W.png)
* Upload Dll for Research your Flight and find some Errors
* [](https://i2.paste.pics/C783D.png)

	
  
  
  
## File Organiztion
Project is created with:
* View Folder - Contains all the Views and Imgs.
* ViewModel Folder - Contains all the ViewModels
* Model Folder - Contains all the Models
* Plugin - Contains all the Plugin and the Api for more Plugins



	
## Setup
To install this project you need to install FlightGear 2020.3.6 or older.
in FlightGear -> settings -> Additional Settngs
```
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
--httpd=8080
```
Download playback_small.xml from the Model.




## Run
* run FG and press "Fly!" wait until running
* run this project
* Copy Playback_small - put the folder source of the file and the folder destention and press "copy XML" 
* example XML: 
* folder Source : C:\Downloads
* folder Destenation : C:\Program Files\FlightGear 2020.3.6\data\Protocol
* example CSV:
* folder Source : C:\Users\Omer\source\repos\FlightSimulator2\model
* make sure yout IP and port are set to 127.0.0.1:5400
* press "Connect to FG"
* ENJOY

## UML
Need To Add




## Youtube Video
Need To Add
