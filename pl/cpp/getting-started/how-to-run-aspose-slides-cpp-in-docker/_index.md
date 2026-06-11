---
title: Jak uruchomić Aspose.Slides dla C++ w Dockerze
type: docs
weight: 140
url: /pl/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- Instalacja Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatybilność wieloplatformowa
- izolacja zależności
- uproszczone wdrażanie
- konfiguracja projektu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Uruchom Aspose.Slides w kontenerach Docker: skonfiguruj obrazy, zależności, czcionki i licencjonowanie, aby zbudować skalowalne usługi przetwarzające PowerPoint i OpenDocument."
---
## **Wstęp**

Aspose.Slides for C++ może działać w kontenerach Docker. Aby uruchomić Aspose.Slides for C++ w środowisku Linux, możesz użyć pliku Docker.

## **Opis Dockerfile**

Na przykład możesz użyć tego pliku Docker dla Aspose.Slides for C++ z Ubuntu 16.04:

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

Plik zawiera trzy główne części (procedury):

1. Instalacja narzędzi wymaganych do uruchomienia Aspose.Slides for C++:

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

2. Instalacja pakietu msttcorefonts (domyślnie EULA pakietu msttcorefonts nie jest akceptowana):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Deklaracja folderu /slides-cpp jako punktu montowania, aby zapewnić dostęp do folderu źródłowego slides-cpp na maszynie hosta; budowanie i uruchamianie przykładów:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Budowanie i uruchamianie obrazu**

1. [Zainstaluj Docker](https://docs.docker.com/engine/install/) na systemie hosta.

2. Zbuduj obraz.

   Katalog roboczy terminala powinien zawierać plik Dockerfile z powyższą zawartością.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Pobierz i rozpakuj [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/pl/cpp).

4. Udostępnij folder z Aspose.Slides for C++, aby Docker mógł go używać:
   - W systemie Windows kliknij prawym przyciskiem myszy ikonę Docker na pasku zadań. Wybierz Ustawienia.
   - Przejdź do Zasoby > Udostępnianie plików.

5. Uruchom obraz jako kontener przy użyciu jednej z poniższych metod:

* Metoda A: utwórz i uruchom nazwany kontener:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Przy drugim i kolejnych uruchomieniach należy użyć:

```
docker start slides-cpp-ubuntu -i
```

* Metoda B: utwórz i uruchom nienazwany tymczasowy kontener:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Zobaczysz budowanie i wykonanie przykładowego projektu:

``` 
-- Identyfikacja kompilatora CXX to Clang 3.9.1
-- Sprawdzanie działającego kompilatora CXX: /usr/bin/clang++
-- Sprawdzanie działającego kompilatora CXX: /usr/bin/clang++ -- działa
-- Wykrywanie informacji ABI kompilatora CXX
-- Wykrywanie informacji ABI kompilatora CXX - zakończone
-- Wykrywanie funkcji kompilacji CXX
-- Wykrywanie funkcji kompilacji CXX - zakończone
-- Konfigurowanie zakończone
-- Generowanie zakończone
-- Pliki kompilacji zostały zapisane w: /slides-cpp/sample/build
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