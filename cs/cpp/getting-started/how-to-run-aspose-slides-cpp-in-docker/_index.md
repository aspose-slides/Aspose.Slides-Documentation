---
title: Jak spustit Aspose.Slides pro C++ v Dockeru
type: docs
weight: 140
url: /cs/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- instalace Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilita napříč platformami
- izolace závislostí
- zjednodušené nasazení
- nastavení projektu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spusťte Aspose.Slides v Docker kontejnerech: nakonfigurujte obrazy, závislosti, fonty a licencování pro vytvoření škálovatelných služeb, které zpracovávají PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides for C++ může běžet v docker kontejnerech. Pro spuštění Aspose.Slides for C++ v Linuxovém prostředí můžete použít docker soubor.

## **Popis Dockerfile**

Například můžete použít tento docker soubor pro Aspose.Slides for C++ s Ubuntu 16.04:

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

Soubor obsahuje tři hlavní části (postupy):

1. Instalace nástrojů potřebných k běhu Aspose.Slides for C++:

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

2. Instalace balíčku msttcorefonts (ve výchozím nastavení není akceptována licence EULA balíčku msttcorefonts):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Deklarace složky /slides-cpp jako bodu připojení, aby byl umožněn přístup ke zdrojové složce slides-cpp na hostitelském počítači; sestavení a spuštění příkladů:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Sestavení a spuštění obrazu**

1. [Install Docker](https://docs.docker.com/engine/install/) na hostitelském systému.

2. Sestavte obraz.

   Pracovní adresář v terminálu by měl obsahovat soubor Dockerfile s výše uvedeným obsahem.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Stáhněte a rozbalte [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cs/cpp).
4. Sdílejte složku s Aspose.Slides for C++ tak, aby ji Docker mohl použít:
   - Ve Windows klikněte pravým tlačítkem na ikonu Dockeru na hlavním panelu. Vyberte Settings.
   - Přejděte na Resources > File Sharing.
5. Spusťte obraz jako kontejner jednou z následujících metod:

* Metoda A: vytvořte a spusťte pojmenovaný kontejner:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Pro druhé a další spuštění použijte:

```
docker start slides-cpp-ubuntu -i
```

* Metoda B: vytvořte a spusťte nepojmenovaný dočasný kontejner:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Uvidíte sestavení a spuštění ukázkového projektu:

```
-- Identifikace kompilátoru CXX je Clang 3.9.1
-- Kontrola funkčnosti kompilátoru CXX: /usr/bin/clang++
-- Kontrola funkčnosti kompilátoru CXX: /usr/bin/clang++ -- funguje
-- Zjišťování informací ABI kompilátoru CXX
-- Zjišťování informací ABI kompilátoru CXX - hotovo
-- Zjišťování funkcí kompilátoru CXX
-- Zjišťování funkcí kompilátoru CXX - hotovo
-- Konfigurace dokončena
-- Generování dokončeno
-- Soubory sestavení byly zapsány do: /slides-cpp/sample/build
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