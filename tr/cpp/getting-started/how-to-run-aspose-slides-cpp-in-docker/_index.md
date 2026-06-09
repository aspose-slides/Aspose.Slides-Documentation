---
title: Aspose.Slides for C++'ı Docker'da Çalıştırma
type: docs
weight: 140
url: /tr/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- Aspose.Slides'ı indirin
- Aspose.Slides'ı kurun
- Aspose.Slides kurulumu
- Docker
- Windows
- macOS
- Linux
- çapraz platform uyumluluğu
- bağımlılık izolasyonu
- basitleştirilmiş dağıtım
- proje kurulumu
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides'ı Docker konteynerlerinde çalıştırın: görüntüleri, bağımlılıkları, yazı tiplerini ve lisanslamayı yapılandırarak PowerPoint ve OpenDocument işleyen ölçeklenebilir hizmetler oluşturun."
---
## **Giriş**

Aspose.Slides for C++ docker konteynerleri içinde çalışabilir. Aspose.Slides for C++'ı Linux ortamında çalıştırmak için bir docker dosyası kullanabilirsiniz. 

## **Dockerfile Açıklaması**

Örneğin, Ubuntu 16.04 ile Aspose.Slides for C++ için bu docker dosyasını kullanabilirsiniz: 

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

Dosya üç ana bölüm (prosedür) içerir:

1. Aspose.Slides for C++'ı çalıştırmak için gereken araçların kurulması:

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

2. msttcorefonts paketinin kurulması (varsayılan olarak, msttcorefonts paketinin EULA'sı kabul edilmemiştir):

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. /slides-cpp klasörünü, ana makinadaki slides-cpp kaynak klasörüne erişim sağlamak için bir bağlama noktası olarak ilan etme; örneklerin derlenmesi ve çalıştırılması:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Bir Görüntü Oluşturma ve Çalıştırma**

1. [Docker'ı Kurun](https://docs.docker.com/engine/install/) bir ana sistemde.

2. Bir görüntü oluşturun.  

   Bir terminal çalışma dizini, yukarıdaki içeriğe sahip bir Dockerfile dosyası içermelidir. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/tr/cpp) dosyasını indirin ve zip dosyasını açın.
4. Docker'un kullanabilmesi için Aspose.Slides for C++ ile klasörü paylaşın: 
   - Windows'ta görev çubuğundaki Docker simgesine sağ tıklayın. Ayarlar'ı seçin.
   - Resources > File Sharing bölümünden geçin. 
5. Görüntüyü bir konteyner olarak şu yöntemlerden biriyle çalıştırın:

* Yöntem A: adlandırılmış bir konteyner oluşturup çalıştırın:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

İkinci ve sonraki başlatmalarda şu komutu kullanmalısınız:

```
docker start slides-cpp-ubuntu -i
```

* Yöntem B: isimsiz geçici bir konteyner oluşturup çalıştırın:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Örnek projenin derleme ve çalıştırmasını göreceksiniz:

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