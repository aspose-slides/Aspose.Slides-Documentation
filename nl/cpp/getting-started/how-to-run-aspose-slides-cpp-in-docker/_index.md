---
title: Hoe Aspose.Slides voor C++ in Docker uit te voeren
type: docs
weight: 140
url: /nl/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- downloaden van Aspose.Slides
- Aspose.Slides installeren
- Aspose.Slides installatie
- Docker
- Windows
- macOS
- Linux
- cross-platform compatibiliteit
- isolatie van afhankelijkheden
- vereenvoudigde implementatie
- projectconfiguratie
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Voer Aspose.Slides uit in Docker-containers: configureer images, afhankelijkheden, lettertypen en licenties om schaalbare services te bouwen die PowerPoint- en OpenDocument-bestanden verwerken."
---
## **Inleiding**

Aspose.Slides for C++ kan draaien binnen Docker-containers. Om Aspose.Slides for C++ in een Linux-omgeving uit te voeren, kun je een Docker-bestand gebruiken. 

## **Beschrijving van Dockerfile**

Bijvoorbeeld kun je dit Docker-bestand gebruiken voor Aspose.Slides for C++ met Ubuntu 16.04: 

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

Het bestand bevat drie hoofdonderdelen (procedures):

1. Installeren van de tools die vereist zijn om Aspose.Slides for C++ uit te voeren:

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

2. Installeren van het msttcorefonts-pakket (standaard is de EULA van het msttcorefonts-pakket niet geaccepteerd): 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. De /slides-cpp-map declareren als aankoppelpunt om toegang te bieden tot de slides-cpp-bronmap op de hostmachine; het bouwen en uitvoeren van voorbeelden:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Een image bouwen en uitvoeren**

1. [Docker installeren](https://docs.docker.com/engine/install/) op een host-systeem.

2. Een image bouwen.  

   De werkmap in de terminal moet een bestand Dockerfile bevatten met de bovenstaande inhoud. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Download en pak [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/nl/cpp) uit.

4. De map delen met Aspose.Slides for C++ zodat Docker deze kan gebruiken: 
   - In Windows, klik met de rechtermuisknop op het Docker-icoon in de taakbalk. Selecteer Instellingen.
   - Ga naar Resources > File Sharing. 

5. Voer de image uit als een container via een van deze methoden:

* Methode A: een benoemde container aanmaken en uitvoeren:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Voor de tweede en volgende starts moet je gebruiken:

```
docker start slides-cpp-ubuntu -i
```

* Methode B: een niet-genoemde tijdelijke container aanmaken en uitvoeren:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Je zult de bouw en uitvoering van het voorbeeldproject zien:

```
-- De CXX-compileridentificatie is Clang 3.9.1
-- Controleren of CXX-compiler werkt: /usr/bin/clang++
-- Controleren of CXX-compiler werkt: /usr/bin/clang++ -- werkt
-- Detecteren van CXX-compiler ABI-informatie
-- Detecteren van CXX-compiler ABI-informatie - klaar
-- Detecteren van CXX-compileerfuncties
-- Detecteren van CXX-compileerfuncties - klaar
-- Configuratie voltooid
-- Generatie voltooid
-- Buildbestanden zijn geschreven naar: /slides-cpp/sample/build
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