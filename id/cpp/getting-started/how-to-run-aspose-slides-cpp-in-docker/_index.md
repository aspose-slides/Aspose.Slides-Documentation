---
title: Cara Menjalankan Aspose.Slides untuk C++ di Docker
type: docs
weight: 140
url: /id/cpp/how-to-run-aspose-slides-cpp-in-docker/
keywords:
- unduh Aspose.Slides
- pasang Aspose.Slides
- instalasi Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilitas lintas platform
- isolasi dependensi
- penyebaran yang disederhanakan
- penyiapan proyek
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Jalankan Aspose.Slides dalam kontainer Docker: konfigurasikan image, dependensi, font, dan lisensi untuk membangun layanan yang skalabel yang memproses PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Aspose.Slides for C++ dapat dijalankan di dalam kontainer docker. Untuk menjalankan Aspose.Slides for C++ di lingkungan Linux, Anda dapat menggunakan file docker. 

## **Deskripsi Dockerfile**

Sebagai contoh, Anda dapat menggunakan file docker ini untuk Aspose.Slides for C++ dengan Ubuntu 16.04: 

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

File tersebut berisi tiga bagian utama (prosedur):

1. Menginstal alat yang diperlukan untuk menjalankan Aspose.Slides for C++:

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

2. Menginstal paket msttcorefonts (secara default, EULA paket msttcorefonts tidak diterima): 

```
ARG accept_msttcorefonts_eula=false

ARG DEBIAN_FRONTEND=teletype
RUN apt-get install -y --no-install-recommends apt-transport-https debconf-utils
RUN echo msttcorefonts msttcorefonts/accepted-mscorefonts-eula select $accept_msttcorefonts_eula | \
    debconf-set-selections
RUN apt-get install -y msttcorefonts \
 && fc-cache -f -v
```

3. Mendeklarasikan folder /slides-cpp sebagai titik mount untuk menyediakan akses ke folder sumber slides-cpp pada mesin host; Membangun dan menjalankan contoh:

``` cpp
VOLUME /slides-cpp
WORKDIR /slides-cpp/sample/

CMD ./build_sample.sh
```

## **Membangun dan Menjalankan Image**

1. [Instal Docker](https://docs.docker.com/engine/install/) pada sistem host.

2. Bangun sebuah image. 

   Direktori kerja terminal harus berisi sebuah file Dockerfile dengan konten di atas. 

```
docker build -t aspose-slides-ubuntu-16.04 .
```

3. Unduh dan ekstrak [Aspose.Slides for C++ YY.M Linux](https://downloads.aspose.com/slides/id/cpp).
4. Bagikan folder dengan Aspose.Slides for C++ agar Docker dapat menggunakannya: 
   - Di Windows, klik kanan ikon Docker di taskbar Anda. Pilih Settings.
   - Masuk ke Resources > File Sharing. 
5. Jalankan image sebagai kontainer melalui salah satu metode berikut:

* Metode A: buat dan jalankan kontainer bernama:

```
docker run --name slides-cpp-ubuntu -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Untuk peluncuran kedua dan berikutnya, Anda harus menggunakan:

```
docker start slides-cpp-ubuntu -i
```

* Metode B: buat dan jalankan kontainer sementara tanpa nama:

```
docker run --rm -v d:\aspose-slides-cpp-linux-20.6:/slides-cpp aspose-slides-ubuntu-16.04
```

Anda akan melihat proses build dan eksekusi proyek contoh:

```
-- Identifikasi kompiler CXX adalah Clang 3.9.1
-- Memeriksa kompiler CXX yang berfungsi: /usr/bin/clang++
-- Memeriksa kompiler CXX yang berfungsi: /usr/bin/clang++ -- berhasil
-- Mendeteksi info ABI kompiler CXX
-- Mendeteksi info ABI kompiler CXX - selesai
-- Mendeteksi fitur kompilasi CXX
-- Mendeteksi fitur kompilasi CXX - selesai
-- Konfigurasi selesai
-- Pembuatan selesai
-- File build telah ditulis ke: /slides-cpp/sample/build
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