# Meeting-Order-Website

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Heroku](https://img.shields.io/badge/heroku-%23430098.svg?style=for-the-badge&logo=heroku&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)

![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Markdown](https://img.shields.io/badge/markdown-%23000000.svg?style=for-the-badge&logo=markdown&logoColor=white)
<br>
<br>

## Introduction

Hi, :wave: I'm Joey and welcome to my GitHub repo for my Meeting Web App project!


I'm a Software Engineer and once upon a time the small group of people I work with grew in size. 
When it did, we needed a fair way of picking the order in which developers spoke during our Scrum meetings. 
To quickly fix the problem at hand I remember writing a ~10 line console app that did the job. 
However, as our team size continues to change, the delivery and management of updates to the list of names should be standardized. 
So this project is to serve that purpose.


This project is a simple web site that displays a randomized order foreach member on the team. 
It randomizes the order based on the current day (used as the seed), so any day the site is accessed it will provide a new random order.
I'm going to be hosting this web site on my personal Heroku account (because it's free). 
Within Heroku I will also be setting up automatic CI/CD deployments to their cloud everytime I push to master. 
I would like to attempt to setup an RSS feed so that our Microsoft Teams chat can display this info in a chat message when we begin our meeting. 
But if not, a public site still solves the new problem at hand...
till next time, see ya :grin:!
<br>
<br>

## Technologies

### Backend
- ASP.NET Core 8 Razor Pages Web Application
- Heroku .NET Core Buildpack [GitHub](https://github.com/jincod/dotnetcore-buildpack)
- Heroku Basic Dyno
NOTE: Heroku dynos have ephemeral file systems, so by ignoring .env files from my git repo I configure them to the server on startup.
todo... for now public names are ok...
<br>

### Frontend
- JavaScript
- CSS
- HTML
<br>

## License

[![Licence](https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge)](./LICENSE)
<br>
<br>

## Author

**Joseph Connelly** 

You can reach me via:
- [Email](mailto:joseph_a_connelly@yahoo.com)
- [LinkedIn](https://www.linkedin.com/in/joseph-connelly-6775012b5)
- [GitHub](https://github.com/jconnelly-dev)

![LinkedIn](https://img.shields.io/badge/linkedin-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white) ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
