lancer docker pour lancer angular avec ses installations :

```bash
sudo docker build -t spotifycontainer .        
```


dans le dossier "./angular" :

```bash

ng serve --host 0.0.0.0
```

depuis spotify-like où il y a le dockerfile.

supprimer un container existant pour le mettre à jour :


```bash
docker stop my-container
docker rm my-container
docker run --name my-container <options> my-image

```

