---
title: How to Run Aspose.Slides for C++ in Docker
type: docs
weight: 140
url: /cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords: "Running Aspose.Slides for C++ in Docker container, Aspose Docker, Aspose.Slides for C++ in a Docker"
description: "Run Aspose.Slides for C++ in a Docker container for Linux. "
---

Aspose.Slides for C++ can run inside docker containers. To run Aspose.Slides for C++ in a Linux environment, you can use a docker file. 

## Dockerfile Description

For example, you can use this docker file for Aspose.Slides for C++ with Ubuntu 16.04: 

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y ~-~-no-install-recommends\
 && apt-get install -y ~-~-no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives ~-~-install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives ~-~-install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives ~-~-install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives ~-~-install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives ~-~-install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives ~-~-install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives ~-~-install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives ~-~-install /usr/bin/c++ c++ /usr/bin/g++-6 30

ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y ~-~-no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v

VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

The file contains three main parts (procedures):

1. Installing the tools required to run Aspose.Slides for C++:

```
FROM ubuntu:16.04

RUN apt-get update && apt-get install software-properties-common -y \
 && add-apt-repository ppa:ubuntu-toolchain-r/test \
 && apt-get update && apt-get upgrade libstdc++6 -y ~-~-no-install-recommends\
 && apt-get install -y ~-~-no-install-recommends  \
    unzip \
    cmake \
    make \
    clang-3.9 \
    gcc-6 \
    g++-6 \
    fontconfig \
    libglu1-mesa \ 
 && update-alternatives ~-~-install /usr/bin/clang   clang   /usr/bin/clang-3.9 30 \
 && update-alternatives ~-~-install /usr/bin/clang++ clang++ /usr/bin/clang++-3.9 30 \
 && update-alternatives ~-~-install /usr/bin/cc  cc  /usr/bin/clang-3.9 40 \
 && update-alternatives ~-~-install /usr/bin/c++ c++ /usr/bin/clang++-3.9 40 \
 && update-alternatives ~-~-install /usr/bin/gcc gcc /usr/bin/gcc-6 30 \
 && update-alternatives ~-~-install /usr/bin/g++ g++ /usr/bin/g++-6 30 \
 && update-alternatives ~-~-install /usr/bin/cc  cc  /usr/bin/gcc-6 30 \
 && update-alternatives ~-~-install /usr/bin/c++ c++ /usr/bin/g++-6 30
```

2. Installing the msttcorefonts package. By default, the msttcorefonts package EULA isn't accepted: 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y ~-~-no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Declaring the /slides-cpp folder as a mounting point to provide access to the slides-cpp sources folder on the host machine; Building and running examples:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## Building and Running an Image

1. [Install Docker](https://docs.docker.com/engine/install/) on a host system;

2. Build an image. 

   A terminal working directory should contain a file Dockerfile with the content above. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Download and unzip [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/cpp);
4. Share the folder with Aspose.Slides for C++ to Docker can use it (For Windows: Settings -> Resources -> File Sharing);
5. Run the image as a container through either of these methods:

* Method A: create and execute a named container:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

For the second and subsequent launches, you have to use:

```
docker start slides-cpp-ubuntu -i
```

* Method B: create and execute an unnamed temporary container:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

You will see the build and execution of the sample project:

```
-- The CXX compiler identification is Clang 3.9.1
-- Check for working CXX compiler: /usr/bin/clang++
-- Check for working CXX compiler: /usr/bin/clang++ ~-~- works
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