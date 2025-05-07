Problème :

comment cloner le repo git pour initier le projet.

solution :

git clone https://github.com/Dyl-DJM/spotify-like.git

+

git init dans le repo

(lien http)

remarque : 

cela permet aussi de se connecter au repo distant.

problème :

"failed to bind host port for 0.0.0.0:80:172.17.0.2:80/tcp: address already in use"

solution :

kill -9 $(lsof -t -i tcp:<port#>)


kill -9 $(lsof -t -i tcp:0.0.0.0:80:172.17.0.2:80)