---
title: Cómo ejecutar Aspose.Slides para C++ en Docker
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "Ejecutar Aspose.Slides para C++ en contenedor Docker, Aspose Docker, Aspose.Slides para C++ en Docker"
description: "Ejecuta Aspose.Slides para C++ en un contenedor Docker para Linux."
---

Aspose.Slides para C++ puede ejecutarse dentro de contenedores Docker. Para ejecutar Aspose.Slides para C++ en un entorno Linux, puedes usar un archivo Docker.

## Descripción del Dockerfile

Por ejemplo, puedes usar este archivo Docker para Aspose.Slides para C++ con Ubuntu 16.04:

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

El archivo contiene tres partes principales (procedimientos):

1. Instalando las herramientas requeridas para ejecutar Aspose.Slides para C++:

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

2. Instalando el paquete msttcorefonts (por defecto, la EULA del paquete msttcorefonts no se acepta):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Declarando la carpeta /slides-cpp como un punto de montaje para proporcionar acceso a la carpeta de fuentes de slides-cpp en la máquina host; Construyendo y ejecutando ejemplos:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## Construyendo y ejecutando una imagen

1. [Instalar Docker](https://docs.docker.com/engine/install/) en un sistema host.

2. Construir una imagen.

   Un directorio de trabajo de terminal debe contener un archivo Dockerfile con el contenido anterior.

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Descargar y descomprimir [Aspose.Slides para C++ YY.M Linux](https://downloads.aspose.com/slides/cpp).
4. Compartir la carpeta con Aspose.Slides para C++ para permitir a Docker usarla:
   - En Windows, haz clic derecho en el ícono de Docker en tu barra de tareas. Selecciona Configuración.
   - Ve a Recursos > Compartir archivos.
5. Ejecutar la imagen como un contenedor a través de cualquiera de estos métodos:

* Método A: crear y ejecutar un contenedor nombrado:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Para el segundo y posteriores lanzamientos, debes usar:

```
docker start slides-cpp-ubuntu -i
```

* Método B: crear y ejecutar un contenedor temporal sin nombre:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Verás la construcción y ejecución del proyecto de ejemplo:

```
-- La identificación del compilador CXX es Clang 3.9.1
-- Verificando si el compilador CXX funciona: /usr/bin/clang++
-- Verificando si el compilador CXX funciona: /usr/bin/clang++ -- funciona
-- Detectando información de ABI del compilador CXX
-- Detectando información de ABI del compilador CXX - listo
-- Detectando características de compilación CXX
-- Detectando características de compilación CXX - listo
-- Configuración completada
-- Generación completada
-- Los archivos de construcción se han escrito en: /slides-cpp/sample/build
Escaneando dependencias del objetivo Aspose.Slides.Cpp.Examples
[ 14%] Construyendo objeto CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/chart.cpp.o
[ 42%] Construyendo objeto CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/main.cpp.o
[ 42%] Construyendo objeto CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/presentation_export.cpp.o
[ 57%] Construyendo objeto CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/smart_art.cpp.o
[ 71%] Construyendo objeto CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/text.cpp.o
[ 85%] Construyendo objeto CXX CMakeFiles/Aspose.Slides.Cpp.Examples.dir/sources/thumbnail.cpp.o
[100%] Vinculando ejecutable CXX Aspose.Slides.Cpp.Examples
[100%] Objetivo construido Aspose.Slides.Cpp.Examples

Ejecutando ejemplos...

Ejecutando Chart::SampleChart...
Ejecutando Thumbnail::SampleThumbnail...
Ejecutando Text::SampleAddText...
Ejecutando SmartArt::SampleCreation...
Ejecutando SmartArt::SampleCloning...
Ejecutando SmartArt::SampleNodesTextEditing...
Ejecutando SmartArt::SampleNodeAdd...
Ejecutando SmartArt::SampleColorStyleEditing...
Ejecutando SmartArt::SampleQuickStyleEditing...
Ejecutando SmartArt::SampleNodeRemove...
Ejecutando SmartArt::SampleRemoveSmartArt...
Ejecutando PresentationExport::Export...
Guardando la presentación como PDF...OK
Guardando la presentación como XPS...OK
Guardando la presentación como SWF...OK
Guardando la presentación como HTML...OK
Guardando la presentación como PDF...OK
Guardando la presentación como XPS...OK
Guardando la presentación como SWF...OK
Guardando la presentación como HTML...OK
```