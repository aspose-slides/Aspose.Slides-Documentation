---
title: Installer Aspose.Slides pour Node.js via Java en utilisant Docker
type: docs
weight: 75
url: /fr/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- installation d'Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilité multiplateforme
- isolation des dépendances
- déploiement simplifié
- configuration du projet
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Exécutez Aspose.Slides dans des conteneurs Docker : configurez les images, les dépendances, les polices et la licence pour créer des services évolutifs qui traitent PowerPoint et OpenDocument."
---

## Prérequis :
* Installez Docker sur votre machine. Vous pouvez suivre le guide d'installation officiel [ici](https://docs.docker.com/get-docker/).

## Étapes :

### 1. **Créer le Dockerfile** 
   Créez un nouveau fichier nommé Dockerfile dans le répertoire de votre projet avec le contenu suivant :
   ```
   # Utiliser Ubuntu 20.04 comme image de base
   FROM ubuntu:20.04

   # Mettre à jour la liste des paquets et installer les paquets essentiels pour ajouter des dépôts et télécharger des fichiers
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Installer Node.js version 18.x depuis le dépôt Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Installer Python 2.x, requis par certains paquets npm comme node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Installer OpenJDK 11, requis par Aspose.Slides pour les dépendances Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Installer le paquet build-essential, qui comprend des outils comme 'make' requis pour la compilation de modules natifs
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Installer node-gyp globalement, un outil utilisé pour compiler des modules natifs pour Node.js
   RUN npm install -g node-gyp

   # Définir le répertoire de travail à l'intérieur du conteneur sur /app
   WORKDIR /app

   # Créer le fichier package.json avec les détails et dépendances nécessaires
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # Créer le fichier index.js avec un exemple de code pour créer une présentation avec Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Installer le package Aspose.Slides via Java indiqué dans package.json
   RUN npm install aspose.slides.via.java

   # Définir la commande par défaut pour exécuter l'application au démarrage du conteneur
   CMD ["node", "index.js"]
   ```


### 2. **Construire l'image Docker**
   Exécutez la commande suivante dans le répertoire où se trouve votre Dockerfile pour construire l'image Docker :
   ```bash
   docker build -t aspose-slides-nodejs .
   ```


### 3. **Exécuter le conteneur Docker**
   Lancez le conteneur et enregistrez son ID :
```bash
CONTAINER_ID=$(docker create aspose-slides-nodejs)
docker start -a $CONTAINER_ID
```


### 4. **Accéder à Aspose.Slides dans Docker** 
   Après le démarrage du conteneur, le script génèrera un fichier PPTX. Vous pouvez trouver le fichier de sortie généré `NewPresentation.pptx` dans le dossier `/app` à l'intérieur du conteneur :
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```

   Supprimer le conteneur temporaire :
   ```bash
   docker rm $CONTAINER_ID
   ```
