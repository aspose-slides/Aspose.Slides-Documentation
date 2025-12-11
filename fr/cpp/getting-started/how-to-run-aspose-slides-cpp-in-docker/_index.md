---
title: Comment exécuter Aspose.Slides pour C++ dans Docker
type: docs
weight: 140
url: /fr/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- installation Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilité multi-plateforme
- isolement des dépendances
- déploiement simplifié
- configuration du projet
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Exécuter Aspose.Slides dans des conteneurs Docker : configurer les images, les dépendances, les polices et la licence pour créer des services évolutifs qui traitent PowerPoint et OpenDocument."
---

Aspose.Slides for C++ peut s'exécuter à l'intérieur de conteneurs Docker. Pour exécuter Aspose.Slides for C++ dans un environnement Linux, vous pouvez utiliser un fichier Docker. 

## **Description du Dockerfile**

Par exemple, vous pouvez utiliser ce fichier Docker pour Aspose.Slides for C++ avec Ubuntu 16.04 :
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

1. Installation des outils requis pour exécuter Aspose.Slides for C++ :
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


2. Installation du paquet msttcorefonts (par défaut, le contrat de licence du paquet msttcorefonts n'est pas accepté) :
```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```


3. Déclaration du dossier /slides-cpp comme point de montage pour fournir l'accès au dossier source slides-cpp sur la machine hôte ; Construction et exécution des exemples :
``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```


## **Construire et exécuter une image**

1. [Installer Docker](https://docs.docker.com/engine/install/) sur un système hôte.

2. Construire une image.  

   Le répertoire de travail du terminal doit contenir un fichier Dockerfile avec le contenu ci‑dessus. 
```
docker build -t aspose-slides-ubuntu-16.04 .
```


3. Télécharger et décompresser [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).

4. Partager le dossier avec Aspose.Slides for C++ pour permettre à Docker de l'utiliser :  
   - Sous Windows, faites un clic droit sur l'icône Docker dans la barre des tâches. Sélectionnez Paramètres.  
   - Accédez à Ressources > Partage de fichiers.  

5. Exécuter l'image en tant que conteneur via l'une de ces méthodes :

* Méthode A : créer et exécuter un conteneur nommé :
```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


Pour les lancements suivants, vous devez utiliser :
```
docker start slides-cpp-ubuntu -i
```


* Méthode B : créer et exécuter un conteneur temporaire sans nom :
```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


Vous verrez la construction et l'exécution du projet d'exemple :
```
-- The CXX compiler identification is Clang 3.9.1
-- Check for working CXX compiler: /usr/bin/clang++
-- Check for working CXX compiler: /usr/bin/clang++ -- works
-- Detecting CXX compiler ABI info
-- Detecting CXX compiler ABI info - done
-- Detecting CXX compile features
-- Detecting CXX compile features - done
-- Configuring done
-- Generating done
-- Build files have been written to: /slides-cpp/sample/build
Scanning dependencies of target Aspose.Slides.Cpp.Examples
[ 14%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Building CXX object CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Linking CXX executable Aspose.Slides.Cpp.Examples
[100%] Built target Aspose.Slides.Cpp.Examples

Running examples...

Running Chart::SampleChart...
Running Thumbnail::SampleThumbnail...
Running Text::SampleAddText...
Running SmartArt::SampleCreation...
Running SmartArt::SampleCloning...
Running SmartArt::SampleNodesTextEditing...
Running SmartArt::SampleNodeAdd...
Running SmartArt::SampleColorStyleEditing...
Running SmartArt::SampleQuickStyleEditing...
Running SmartArt::SampleNodeRemove...
Running SmartArt::SampleRemoveSmartArt...
Running PresentationExport::Export...
Saving presentation as PDF...OK
Saving presentation as XPS...OK
Saving presentation as SWF...OK
Saving presentation as HTML...OK
Saving presentation as PDF...OK
Saving presentation as XPS...OK
Saving presentation as SWF...OK
Saving presentation as HTML...OK
```
