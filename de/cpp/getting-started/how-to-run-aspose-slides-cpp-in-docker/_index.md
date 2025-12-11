---
title: So führen Sie Aspose.Slides für C++ in Docker aus
type: docs
weight: 140
url: /de/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides Installation
- Docker
- Windows
- macOS
- Linux
- Plattformübergreifende Kompatibilität
- Isolierung von Abhängigkeiten
- Vereinfachte Bereitstellung
- Projekteinrichtung
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Führen Sie Aspose.Slides in Docker-Containern aus: Konfigurieren Sie Images, Abhängigkeiten, Schriftarten und Lizenzen, um skalierbare Dienste zu erstellen, die PowerPoint und OpenDocument verarbeiten."
---

Aspose.Slides for C++ kann in Docker-Containern ausgeführt werden. Um Aspose.Slides for C++ in einer Linux-Umgebung auszuführen, können Sie eine Docker-Datei verwenden. 

## **Dockerfile‑Beschreibung**

Zum Beispiel können Sie diese Docker-Datei für Aspose.Slides for C++ mit Ubuntu 16.04 verwenden: 
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


Die Datei enthält drei Hauptabschnitte (Verfahren):

1. Installieren der Werkzeuge, die zum Ausführen von Aspose.Slides for C++ erforderlich sind:
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


2. Installieren des msttcorefonts-Pakets (standardmäßig wird die EULA des msttcorefonts-Pakets nicht akzeptiert): 
```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```


3. Deklarieren des Ordners /slides-cpp als Einhängepunkt, um Zugriff auf den Quellordner slides-cpp des Host-Systems zu ermöglichen; Erstellen und Ausführen von Beispielen:
``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```


## **Erstellen und Ausführen eines Images**

1. [Docker installieren](https://docs.docker.com/engine/install/) auf einem Hostsystem.

2. Ein Image erstellen. 

   Das Arbeitsverzeichnis eines Terminals sollte eine Datei Dockerfile mit dem oben genannten Inhalt enthalten. 
```
docker build -t aspose-slides-ubuntu-16.04 .
```


3. Laden Sie [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp) herunter und entpacken Sie es.

4. Teilen Sie den Ordner mit Aspose.Slides for C++ , damit Docker ihn verwenden kann: 
   - In Windows klicken Sie mit der rechten Maustaste auf das Docker‑Symbol in Ihrer Taskleiste. Wählen Sie Einstellungen.
   - Navigieren Sie zu Ressourcen > Dateifreigabe. 

5. Führen Sie das Image als Container mit einer der folgenden Methoden aus:

* Methode A: Erstellen und führen Sie einen benannten Container aus:
```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


Für die zweite und nachfolgende Ausführungen müssen Sie verwenden:
```
docker start slides-cpp-ubuntu -i
```


* Methode B: Erstellen und führen Sie einen nicht benannten temporären Container aus:
```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```


Sie sehen den Build und die Ausführung des Beispielprojekts:
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
