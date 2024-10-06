---
title: Comment exécuter Aspose.Slides pour C++ dans Docker
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "Exécution d'Aspose.Slides pour C++ dans un conteneur Docker, Aspose Docker, Aspose.Slides pour C++ dans un Docker"
description: "Exécutez Aspose.Slides pour C++ dans un conteneur Docker pour Linux."
---

Aspose.Slides pour C++ peut s'exécuter dans des conteneurs Docker. Pour exécuter Aspose.Slides pour C++ dans un environnement Linux, vous pouvez utiliser un fichier Docker.

## Description du Dockerfile

Par exemple, vous pouvez utiliser ce fichier Docker pour Aspose.Slides pour C++ avec Ubuntu 16.04 :

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y --no-install-recommends\
 && apt-get install -y --no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives --install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives --install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/g++-6 30

ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v

VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

Le fichier contient trois parties principales (procédures) :

1. Installation des outils requis pour exécuter Aspose.Slides pour C++ :

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y --no-install-recommends\
 && apt-get install -y --no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives --install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives --install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives --install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives --install /usr/bin/c++ c++ /usr/bin/g++-6 30
```

2. Installation du package msttcorefonts (par défaut, l'EULA du package msttcorefonts n'est pas acceptée) :

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Déclaration du dossier /slides-cpp comme point de montage pour fournir l'accès au dossier des sources slides-cpp sur la machine hôte ; Construction et exécution des exemples :

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## Construction et exécution d'une image

1. [Installez Docker](https://docs.docker.com/engine/install/) sur un système hôte.

2. Construisez une image.

   Un répertoire de travail de terminal doit contenir un fichier Dockerfile avec le contenu ci-dessus.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Téléchargez et décompressez [Aspose.Slides pour C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).
4. Partagez le dossier avec Aspose.Slides pour C++ pour permettre à Docker de l'utiliser :
   - Sous Windows, faites un clic droit sur l'icône Docker dans votre barre des tâches. Sélectionnez Paramètres.
   - Allez dans Ressources > Partage de fichiers.
5. Exécutez l'image en tant que conteneur via l'une de ces méthodes :

* Méthode A : créez et exécutez un conteneur nommé :

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Pour les lancements suivants, vous devez utiliser :

```
docker start slides-cpp-ubuntu -i
```

* Méthode B : créez et exécutez un conteneur temporaire anonyme :

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Vous verrez la construction et l'exécution du projet d'exemple :

```
-- L'identification du compilateur CXX est Clang 3.9.1
-- Vérification du bon fonctionnement du compilateur CXX : /usr/bin/clang++
-- Vérification du bon fonctionnement du compilateur CXX : /usr/bin/clang++ -- fonctionne
-- Détection des informations d'ABI du compilateur CXX
-- Détection des informations d'ABI du compilateur CXX - terminé
-- Détection des fonctionnalités de compilation CXX
-- Détection des fonctionnalités de compilation CXX - terminé
-- Configuration terminée
-- Génération terminée
-- Les fichiers de construction ont été écrits dans : /slides-cpp/sample/build
Analyse des dépendances de la cible Aspose.Slides.Cpp.Examples
[ 14%] Construction de l'objet CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Construction de l'objet CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Construction de l'objet CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Construction de l'objet CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Construction de l'objet CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Construction de l'objet CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Lien de l'exécutable CXX Aspose.Slides.Cpp.Examples
[100%] Cible Aspose.Slides.Cpp.Examples construite

Exécution des exemples...

Exécution de Chart::SampleChart...
Exécution de Thumbnail::SampleThumbnail...
Exécution de Text::SampleAddText...
Exécution de SmartArt::SampleCreation...
Exécution de SmartArt::SampleCloning...
Exécution de SmartArt::SampleNodesTextEditing...
Exécution de SmartArt::SampleNodeAdd...
Exécution de SmartArt::SampleColorStyleEditing...
Exécution de SmartArt::SampleQuickStyleEditing...
Exécution de SmartArt::SampleNodeRemove...
Exécution de SmartArt::SampleRemoveSmartArt...
Exécution de PresentationExport::Export...
Enregistrement de la présentation en tant que PDF...OK
Enregistrement de la présentation en tant que XPS...OK
Enregistrement de la présentation en tant que SWF...OK
Enregistrement de la présentation en tant que HTML...OK
Enregistrement de la présentation en tant que PDF...OK
Enregistrement de la présentation en tant que XPS...OK
Enregistrement de la présentation en tant que SWF...OK
Enregistrement de la présentation en tant que HTML...OK
```