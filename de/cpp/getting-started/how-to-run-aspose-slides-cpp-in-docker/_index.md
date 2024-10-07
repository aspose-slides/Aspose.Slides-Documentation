---
title: Wie man Aspose.Slides für C++ in Docker ausführt
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "Aspose.Slides für C++ im Docker-Container ausführen, Aspose Docker, Aspose.Slides für C++ in einem Docker"
description: "Führen Sie Aspose.Slides für C++ in einem Docker-Container für Linux aus."
---

Aspose.Slides für C++ kann innerhalb von Docker-Containern ausgeführt werden. Um Aspose.Slides für C++ in einer Linux-Umgebung auszuführen, können Sie eine Docker-Datei verwenden. 

## Dockerfile-Beschreibung

Sie können beispielsweise diese Docker-Datei für Aspose.Slides für C++ mit Ubuntu 16.04 verwenden:

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

Die Datei enthält drei Hauptteile (Prozeduren):

1. Installation der benötigten Werkzeuge zur Ausführung von Aspose.Slides für C++:

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

2. Installation des msttcorefonts-Pakets (standardmäßig wird die EULA des msttcorefonts-Pakets nicht akzeptiert):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Erklärung des /slides-cpp-Ordners als Einhängepunkt, um Zugang zum Quellordner von slides-cpp auf dem Host-Computer zu bieten; Erstellen und Ausführen von Beispielen:

```cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## Erstellen und Ausführen eines Images

1. [Installieren Sie Docker](https://docs.docker.com/engine/install/) auf einem Host-System.

2. Erstellen Sie ein Image.

   Ein Arbeitsverzeichnis im Terminal sollte eine Datei Dockerfile mit dem obigen Inhalt enthalten.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Laden Sie [Aspose.Slides für C++ YY.M Linux](https://downloads.aspose.com/slides/cpp) herunter und entpacken Sie es.
4. Teilen Sie den Ordner mit Aspose.Slides für C++, um Docker die Verwendung zu ermöglichen: 
   - Klicken Sie in Windows mit der rechten Maustaste auf das Docker-Symbol in Ihrer Taskleiste. Wählen Sie Einstellungen.
   - Gehen Sie zu Ressourcen > Dateifreigabe. 
5. Führen Sie das Image als Container auf eine dieser Arten aus:

* Methode A: Erstellen und Ausführen eines benannten Containers:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Für den zweiten und nachfolgenden Start müssen Sie verwenden:

```
docker start slides-cpp-ubuntu -i
```

* Methode B: Erstellen und Ausführen eines unbenannten temporären Containers:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Sie werden den Build und die Ausführung des Beispielprojekts sehen:

```
-- Die CXX-Compiler-Identifikation ist Clang 3.9.1
-- Überprüfen auf funktionierenden CXX-Compiler: /usr/bin/clang++
-- Überprüfen auf funktionierenden CXX-Compiler: /usr/bin/clang++ -- funktioniert
-- Erkennen der CXX-Compiler-ABI-Informationen
-- Erkennen der CXX-Compiler-ABI-Informationen - abgeschlossen
-- Erkennen der CXX-Compiler-Features
-- Erkennen der CXX-Compiler-Features - abgeschlossen
-- Konfigurieren abgeschlossen
-- Generierung abgeschlossen
-- Build-Dateien wurden geschrieben nach: /slides-cpp/sample/build
Überprüfen der Abhängigkeiten des Ziels Aspose.Slides.Cpp.Examples
[ 14%] Erstellen von CXX-Objekt CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Erstellen von CXX-Objekt CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Erstellen von CXX-Objekt CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Erstellen von CXX-Objekt CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Erstellen von CXX-Objekt CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Erstellen von CXX-Objekt CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Verknüpfen des CXX-Ausführungsprogramms Aspose.Slides.Cpp.Examples
[100%] Ziel Aspose.Slides.Cpp.Examples erstellt

Beispiele werden ausgeführt...

Ausführen von Chart::SampleChart...
Ausführen von Thumbnail::SampleThumbnail...
Ausführen von Text::SampleAddText...
Ausführen von SmartArt::SampleCreation...
Ausführen von SmartArt::SampleCloning...
Ausführen von SmartArt::SampleNodesTextEditing...
Ausführen von SmartArt::SampleNodeAdd...
Ausführen von SmartArt::SampleColorStyleEditing...
Ausführen von SmartArt::SampleQuickStyleEditing...
Ausführen von SmartArt::SampleNodeRemove...
Ausführen von SmartArt::SampleRemoveSmartArt...
Ausführen von PresentationExport::Export...
Speichern der Präsentation als PDF...OK
Speichern der Präsentation als XPS...OK
Speichern der Präsentation als SWF...OK
Speichern der Präsentation als HTML...OK
Speichern der Präsentation als PDF...OK
Speichern der Präsentation als XPS...OK
Speichern der Präsentation als SWF...OK
Speichern der Präsentation als HTML...OK
```