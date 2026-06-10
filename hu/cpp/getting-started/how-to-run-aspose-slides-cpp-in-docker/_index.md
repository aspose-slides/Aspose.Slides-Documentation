---
title: Hogyan futtassuk az Aspose.Slides for C++-t Dockerben
type: docs
weight: 140
url: /hu/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítés
- Docker
- Windows
- macOS
- Linux
- keresztplatformú kompatibilitás
- függőség izoláció
- egyszerűsített telepítés
- projekt beállítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides futtatása Docker konténerekben: képek, függőségek, betűtípusok és licenc beállítása skálázható szolgáltatások létrehozásához, amelyek feldolgozzák a PowerPoint és OpenDocument fájlokat."
---
## **Bevezetés**

Az Aspose.Slides for C++ Docker konténerekben futtatható. Az Aspose.Slides for C++ Linux környezetben való futtatásához használhat egy Docker fájlt. 

## **Dockerfile leírása**

Például használhatja ezt a Docker fájlt az Aspose.Slides for C++-hoz Ubuntu 16.04 alatt: 

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

A fájl három fő részből (eljárásból) áll:

1. Az Aspose.Slides for C++ futtatásához szükséges eszközök telepítése:

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

2. A msttcorefonts csomag telepítése (alapértelmezés szerint a msttcorefonts csomag EULA-ja nincs elfogadva): 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. A /slides-cpp mappa deklarálása csatolási pontként, hogy hozzáférést biztosítson a slides-cpp forrásmappához a gazdagépen; Példák felépítése és futtatása:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Kép felépítése és futtatása**

1. [Docker telepítése](https://docs.docker.com/engine/install/) egy gazdagépen.

2. Készítsen egy képet. 
   A terminál munkakönyvtárának tartalmaznia kell egy Dockerfile nevű fájlt a fenti tartalommal. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Töltse le és csomagolja ki az [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/hu/cpp) csomagot.
4. Ossza meg a mappát az Aspose.Slides for C++-vel, hogy a Docker használni tudja: 
   - Windows rendszeren kattintson jobb gombbal a Docker ikonra a tálcán. Válassza a Beállítások menüpontot.
   - Navigáljon a Resources > File Sharing részhez. 
5. Futtassa a képet konténerként az alábbi módszerek egyikével:

* Módszer A: hozzon létre és indítson egy névvel ellátott konténert:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

A második és az azt követő indításokhoz a következőt kell használni:

```
docker start slides-cpp-ubuntu -i
```

* Módszer B: hozzon létre és indítson egy névtelen ideiglenes konténert:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Látni fogja a minta projekt felépítését és végrehajtását:

```
-- A CXX fordító azonosítása: Clang 3.9.1
-- Ellenőrzés: működő CXX fordító: /usr/bin/clang++
-- Ellenőrzés: működő CXX fordító: /usr/bin/clang++ -- működik
-- CXX fordító ABI információk felismerése
-- CXX fordító ABI információk felismerése - kész
-- CXX fordítási jellemzők felismerése
-- CXX fordítási jellemzők felismerése - kész
-- Konfigurálás befejezve
-- Generálás befejezve
-- Az építési fájlok ide kerültek: /slides-cpp/sample/build
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