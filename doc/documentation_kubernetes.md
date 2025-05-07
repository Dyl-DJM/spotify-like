installer kubernetes : 

https://github.com/k3d-io/k3d#get

commande donnée : 

```bash
curl -s https://raw.githubusercontent.com/k3d-io/k3d/main/install.sh | bash
```

vérifier sa version de kubernetes : 

```bash
k3d --version
```

initialiser un cluster : 

```bash

k3d cluster create --api-port IP_DE_VOTRE_SERVEUR:20135 -p "8080:80@loadbalancer" --volume $(pwd)/volume/:/data/ -s 1 -a 2 clusterSpotify1

```

concret : 

```bash
k3d cluster create --api-port 20135 -p "8080:80@loadbalancer" --volume $(pwd)/volume/:/data/ -s 1 -a 2 clusterSpotify1
```

explication : 

-s 1 -->  cela signifie que l'on aura un seul serveur

-a 2 --> cela signifie que l'on veut créer 2 agents.

-20135 --> c'est le numéro de port du serveur, par défaut c'est celui-là quui est choisi.

attention, il ne faut pas utiliser des numéros comme : 80, ... (d'autres ports réservés par l'ordi)


à quoi sert un pod :

pod : A Pod models an application-specific "logical host": it contains one or more application containers which are relatively tightly coupled. In non-cloud contexts, applications executed on the same physical or virtual machine are analogous to cloud applications executed on the same logical host.

Il vous faut un fichier yaml pour votre projet.
Mais ce fichier ne doit être en aucun cas rendu public via votre dépôt ou autre, car il donne accès à tout votre cluser kubernetes.

```bash

k3d kubeconfig write clusterSpotify1

```

-->

À cette étape, vous venez d'écrire la configuration de votre Cluster dans votre serveur. Cette configuration va nous permettre par la suite de piloter le cluster via votre ordinateur.

le fichier se trouve dans le path :

```
/home/nathanb/.config/k3d/kubeconfig-clusterSpotify1.yaml
```


accès au cluster en remoteur
(non faisable dans mon cas car il faudrait payer un serveur) :

```bash
scp nathanb@monServer.dev:.k3d/kubeconfig-clusterSpotify1 .
```

concrètement : 

```bash

scp nathanb@192.168.1.14:.k3d/kubeconfig-clusterSpotify1 .

```

dans mon cas je n'ai pas de serveur distant donc je dois faire : 

```bash
cp /home/nathanb/.config/k3d/kubeconfig-clusterSpotify1.yaml .

```

c'est à dire copier le contenu du yaml qui avait été sauvegardé par la commande précédnte et le mettre dans le dossier local.

ensuite : 

```bash
export KUBECONFIG=kubeconfig-clusterSpotify1.yaml
kubectl cluster-info
```

résultat si tout se passe bien :

"
Kubernetes control plane is running at https://0.0.0.0:20135
CoreDNS is running at https://0.0.0.0:20135/api/v1/namespaces/kube-system/services/kube-dns:dns/proxy
Metrics-server is running at https://0.0.0.0:20135/api/v1/namespaces/kube-system/services/https:metrics-server:https/proxy

To further debug and diagnose cluster problems, use 'kubectl cluster-info dump'.
"

