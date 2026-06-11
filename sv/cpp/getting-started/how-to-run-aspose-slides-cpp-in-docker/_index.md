---
title: Hur man kör Aspose.Slides för C++ i Docker
type: docs
weight: 140
url: /sv/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- installation av Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- plattformsoberoende kompatibilitet
- isolering av beroenden
- förenklad distribution
- projektuppsättning
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Kör Aspose.Slides i Docker-behållare: konfigurera bilder, beroenden, teckensnitt och licenser för att bygga skalbara tjänster som bearbetar PowerPoint och OpenDocument."
---
## **Introduktion**

Aspose.Slides for C++ kan köras i Docker-behållare. För att köra Aspose.Slides for C++ i en Linux-miljö kan du använda en Dockerfil. 

## **Beskrivning av Dockerfil**

Till exempel kan du använda denna Dockerfil för Aspose.Slides for C++ med Ubuntu 16.04: 

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

Filen innehåller tre huvuddelar (procedurer):

1. Installera verktygen som krävs för att köra Aspose.Slides for C++:

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

2. Installera msttcorefonts-paketet (standard är att msttcorefonts-paketets EULA inte accepteras): 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Deklarera /slides-cpp-mappen som en monteringspunkt för att ge åtkomst till slides-cpp källkoden på värddatorn; Bygga och köra exempel:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Bygga och köra en bild**

1. [Installera Docker](https://docs.docker.com/engine/install/) på ett värdsystem.

2. Bygg en image. 

   En terminalens arbetskatalog bör innehålla en fil Dockerfile med innehållet ovan. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Ladda ner och packa upp [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/sv/cpp).

4. Dela mappen med Aspose.Slides for C++ för att låta Docker använda den: 
   - I Windows, högerklicka på Docker-ikonen i aktivitetsfältet. Välj Inställningar.
   - Gå till Resurser > Fil delning. 
5. Kör imagen som en behållare med någon av dessa metoder:

* Metod A: skapa och kör en namngiven behållare:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

För de andra och efterföljande körningarna måste du använda:

```
docker start slides-cpp-ubuntu -i
```

* Metod B: skapa och kör en oidentifierad tillfällig behållare:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Du kommer att se bygget och körningen av exempelprojektet:

``` 
-- CXX-kompilatoridentifiering är Clang 3.9.1
-- Kontrollera fungerande CXX-kompilator: /usr/bin/clang++
-- Kontrollera fungerande CXX-kompilator: /usr/bin/clang++ -- fungerar
-- Detekterar CXX-kompilator ABI-info
-- Detekterar CXX-kompilator ABI-info - klart
-- Detekterar CXX-kompileringsfunktioner
-- Detekterar CXX-kompileringsfunktioner - klart
-- Konfiguration klar
-- Generering klar
-- Byggfiler har skrivits till: /slides-cpp/sample/build
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