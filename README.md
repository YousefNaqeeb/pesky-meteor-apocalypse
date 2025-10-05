SUMMARY

Pesky Meteor Apocalypse is a game intended to happen during a time when a meteor is about to hit Earth in a matter of years or less. 
Your job is to prepare and to decide how you'll defend the planet!! Whether it's changing the meteor's directory or nuking it 
as a whole. You choose how and what is going to happen. The asteroid's impact/predicted time to crash is based on the data from 
NASA's Sentry API, which addresses the challenge's requirements. This is crucial for educating and preparing our population for 
the potential impact of meteors that may crash onto Earth in the future.

PROJECT DETAILS

This is a draft with some implementation of features. We used a flask back end that will create points for the orbit using real 
NASA data, and it will get a list of meteors/asteroids that the user may select. Unity will be used to render the orbit. We will 
also calculate where the asteroid will impact the Earth and the size of its crater. Additionally, it will be calculating overpressure, 
tsunamis, and earthquakes. This is coded using Python for the backend, unity / c# for the game parts and rendering, spacificly for orbits we planned on using poliastro for creating points and having unity render the path. by uusing poliastro we could also show realistic spacecraft paths if we wanted to, for intersepting the asteroid, and to calculate orbits well even after applying changes from attempted deflection methods.

It will educate the general public about the effects of asteroids and meteors, and it will show them the ways we can prevent them 
by using our time wisely and efficiently. This would also serve to educate others about how areas around the crater would also be 
affected by a set of meteors (due to earthquakes and tsunamis).

This project is creative and innovative from our perspective since it takes the idea of meteors crashing onto Earth and focuses on 
ways to prevent them. The project is also very user interactive as it focuses on what you, the user, want and how to do it. We 
considered that we wanted to have as realistic as possible orbital mechanics without too much difficulty, which is why we chose to 
write a Python backend. We also decided to use the Sentry API because it specifically only relied on meteors and asteroids that had 
a chance of hitting the Earth.

Our team plans to introduce different asteroid mitigation strategies to the simulation to help understand their limits and find their uses for different types of asteroids. The strategies will be either destructive or desruptive. Meaning the mitigation strategies will either break the asteroid into less hazardous pieces or change the asteroid's trajectory or, in some cases, break the asteroid in such a way that no fragment of it collides with earth. There will also be stratigies such as vacuations for areas that may have effects from the impacts such as waves or earthquakes. The purpose of introducing the strategies into the simulation is to simulate different scenarios with different factors. These factors include warning time and asteroid size. The varying mitigation strategies such as kinetic impactors and laser ablation will allow users to simulate almost every possible asteroid impact scenario and find out what is the most appropriate mitigation strategy.   
