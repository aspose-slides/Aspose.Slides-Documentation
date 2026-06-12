---
title: Cara Menjalankan Aspose.Slides di Docker
linktitle: Aspose.Slides di Docker
type: docs
weight: 140
url: /id/net/how-to-run-aspose-slides-in-docker/
keywords:
- sistem operasi yang didukung
- Aspose.Slides di Docker
- kontainer Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- repositori image
- Windows Server Core
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jalankan Aspose.Slides dalam kontainer Docker: konfigurasikan image, dependensi, font, dan lisensi untuk membangun layanan skalabel yang memproses PowerPoint dan OpenDocument."
---
## **OS yang Didukung**
Aspose.Slides dapat dijalankan di dalam kontainer docker menggunakan platform .NET Core. Secara umum, Aspose.Slides mendukung semua tipe kontainer (OS) yang didukung oleh platform .NET Core. Namun, GDI atau [libgdiplus ](https://github.com/mono/libgdiplus) harus tersedia dan dikonfigurasi dengan benar pada kontainer yang bersangkutan.

Untuk menggunakan Docker, Anda harus menginstalnya terlebih dahulu pada sistem Anda. Untuk mempelajari cara menginstal Docker pada Windows atau Mac, gunakan tautan berikut:

- [Instal Docker di Windows](https://docs.docker.com/docker-for-windows/install/)
- [Instal Docker di Mac](https://docs.docker.com/docker-for-mac/install/)

Anda juga dapat menjalankan Docker pada Linux dan Windows Server dengan mengikuti petunjuk pada halaman berikut:  

- [Instal dan konfigurasi Docker di Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Instal dan konfigurasi Docker di Linux (make install libgdiplus)   ](#install-and-configure-docker-on-linux-make-install-libgdiplus) 

- [Instal dan konfigurasi Docker di Windows Server Core ](#install-and-configure-docker-on-windows-server-core)  

  Instalasi dan konfigurasi Docker pada Windows Server Nano tidak didukung. Sayangnya, Windows Server Nano tidak menyertakan subsistem grafis. Ia tidak memiliki gdiplus.dll, yang diperlukan oleh pustaka System.Drawing.Common, dan tidak dapat digunakan dengan pustaka Aspose.Slides.

Meskipun memungkinkan untuk menjalankan kontainer Linux di Windows, kami menyarankan Anda menjalankannya secara native di Linux (bahkan pada Linux yang diinstal secara manual pada VM menggunakan VirtualBox).

## **Instal dan Konfigurasi Docker di Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

File Docker ini berisi instruksi untuk membangun image kontainer dengan paket libgdiplus yang diinstal dari repositori paket resmi Ubuntu.

Berikut isi file Docker tersebut:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# instal libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# buat titik mount

VOLUME /slides-src

\# bangun dan uji Aspose.Slides saat memulai

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Mari kita tinjau apa arti masing‑masing baris kode dalam file Docker:

1. Image kontainer berbasis pada gambar microsoft/dotnet:2.1-sdk-bionic (gambar yang sudah dibangun oleh Microsoft dan dipublikasikan di [public hub](https://hub.docker.com/r/microsoft/dotnet/)). Gambar ini sudah berisi dotnet 2.1 SDK yang terinstal. Akhiran Bionic berarti Ubuntu 18.04 (codename bionic) akan dipakai sebagai OS kontainer. Dengan mengubah akhiran, Anda dapat mengganti OS dasarnya (misalnya: stretch -- Debian 9, alpine -- Alpine Linux). Dalam kasus tersebut, modifikasi isi file Docker diperlukan (misalnya, mengubah 'apt-get' menjadi 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Memperbarui basis data paket yang tersedia dan menginstal paket apt‑utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Menginstal paket 'libgdiplus' dan 'libc6-dev' yang diperlukan oleh pustaka System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Menyatakan folder /slides-src sebagai titik mount yang akan kami gunakan untuk memberikan akses ke folder sumber slide‑net pada mesin host.

``` csharp

 VOLUME /slides-src

```

1. Menetapkan slides-src sebagai direktori kerja di dalam kontainer.

``` csharp

 WORKDIR /slides-src

```

1. Menyatakan perintah default yang akan dijalankan saat kontainer dimulai bila tidak ada perintah eksplisit yang diberikan.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Menurut instruksi dalam file Docker, image kontainer yang dihasilkan akan memiliki OS Ubuntu 18.04, dotnet‑sdk, libgdiplus, dan paket libc6‑dev yang sudah terinstal. Selain itu, image ini akan memiliki titik mount dan perintah default yang telah ditentukan.

Untuk membangun sebuah image menggunakan file Docker ini, Anda harus masuk ke folder docker slides‑netuil dan mengeksekusi:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- opsi yang menentukan file Docker mana yang akan dipakai.

*-t ubuntu18_04_apt_get_libgdiplus* -- menentukan tag (nama) untuk image yang dihasilkan.

*'.'* -- menentukan konteks untuk Docker. Dalam kasus kami, konteksnya adalah folder saat ini yang kosong—karena kami memilih untuk menyediakan sumber slides‑net sebagai titik mount (ini memungkinkan kami tidak harus membangun ulang image Docker setiap kali ada perubahan pada sumber).

Hasil eksekusi akan terlihat seperti berikut:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Untuk memastikan image baru telah ditambahkan ke repositori image lokal:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Setelah image siap, kami dapat menjalankannya dengan perintah berikut:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- menentukan bahwa perintah harus dijalankan secara interaktif, sehingga kami dapat melihat output dan memberikan input.

*-v `pwd`/../../:/slides-src* -- menentukan folder untuk titik mount yang telah ditentukan—karena direktori kerja saat ini adalah slides‑netuildocker, maka folder slides‑src di dalam kontainer akan mengarah ke folder slides‑net pada host. `pwd` digunakan untuk menentukan jalur relatif.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- memodifikasi file hosts pada kontainer untuk menyelesaikan nama dev.slides.external.tool.server.

*ubuntu1804aptgetlibgdiplus:latest* -- menentukan image yang akan dijalankan oleh kontainer.

Hasil perintah di atas akan menampilkan output dari netcore.linux.tests.sh (karena ia didefinisikan sebagai perintah default untuk kontainer):

``` csharp

 Restoring packages for /slides-src/targets/.NETCore/tests/Aspose.Slides.FuncTests.NetCore/Aspose.Slides.FuncTests.NetCore.csproj...

Restoring packages for /slides-src/targets/.NETStandard/main/Aspose.Slides.DOM.NetStandard/Aspose.Slides.DOM.NetStandard.csproj...

Restoring packages for /slides-src/targets/.NETStandard/main/Aspose.Slides.CompoundFile.NetStandard/Aspose.Slides.CompoundFile.NetStandard.csproj...

Installing System.Text.Encoding.CodePages 4.4.0.

Installing System.Drawing.Common 4.5.0.

...

Results File: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.FuncTests.NetCore.trx

Total tests: Unknown. Passed: 2110. Failed: 108. Skipped: 210.

...

Results File: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.RegrTests.NetCore.trx

Total tests: 2124. Passed: 1550. Failed: 103. Skipped: 471.

```

Dari hasil tersebut, terlihat bahwa file log dari tes Func dan Regr ditempatkan di direktori /build-out/netstandard20/test-results/main/. Selain itu, sekitar 200 tes gagal secara total—semua terkait masalah rendering karena ketiadaan font yang diperlukan pada kontainer.

Untuk mengganti perintah default kontainer saat dijalankan, kami dapat menggunakan perintah berikut:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Jadi, alih‑alih menjalankan netcore.linux.tests.sh, /bin/bash akan dieksekusi dan menyediakan sesi terminal aktif pada kontainer sehingga kami dapat menjalankannya secara manual (./build/netcore.linux.tests.sh). Pendekatan ini berguna untuk scenario pemecahan masalah.

## **Instal dan Konfigurasi Docker di Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Saat ini, Ubuntu hanya menyertakan versi 4.2 libgdiplus padahal versi 5.6 sudah tersedia di [situs resmi produk](https://github.com/mono/libgdiplus/releases). Untuk menguji versi terbaru libgdiplus, kami perlu menyiapkan image dengan libgdiplus yang dibangun dari sumber.

Berikut isi file Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# bangun libgdiplus stabil terbaru

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# buat titik mount

VOLUME /slides-src

\# bangun dan uji Aspose.Slides saat mulai

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Satu‑satunya perbedaan adalah bagian *build latest stable libgdiplus*. Bagian ini menginstal semua alat yang diperlukan untuk membangun libgdiplus, mengkloning sumber, lalu membangunnya dan menginstalnya ke lokasi yang tepat. Semua hal lain sama seperti pada [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/id/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Catatan**: Jangan lupa menggunakan tag image (nama) yang berbeda untuk image yang dihasilkan pada perintah docker build dan docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Instal dan Konfigurasi Docker di Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Catatan**: Windows 10 Pro atau Windows Server 2016 diperlukan untuk menjalankan kontainer Windows.

Sayangnya, Microsoft tidak menyediakan image Windows Server Core dengan dotnet SDK terinstal, sehingga kami harus menginstalnya secara manual:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Ambil .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#kembalikan cmd sebagai executor default

SHELL ["cmd", "/S", "/C"]

\# Agar dapat mengatur PATH sistem, ContainerAdministrator harus digunakan

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# buat titik mount

VOLUME c:/slides-src

#bangun dan uji Aspose.Slides saat mulai

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Image yang dihasilkan akan dibangun di atas image microsoft/windowsservercore:1803 yang disediakan Microsoft di [docker hub](https://hub.docker.com/u/microsoft). Dotnet‑sdk versi yang ditentukan akan diunduh dan diekstrak; variabel PATH sistem akan diperbarui untuk menyertakan jalur ke executable dotnet. Baris terakhir mendefinisikan perintah yang mengeksekusi tes func & regr pada kontainer menggunakan nant.exe sebagai aksi default saat kontainer dijalankan.

Perintah untuk membangun image:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Perintah untuk menjalankan image:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Catatan**: Perintah untuk kontainer Windows menggunakan 2 argumen tambahan:

*-cpu-count 3*

*-memory 8589934592*

Kedua argumen tersebut menetapkan jumlah inti CPU dan besaran memori yang tersedia untuk kontainer. Secara default, hanya 1 inti CPU dan 1 GB RAM yang tersedia untuk kontainer Windows (kontainer Linux tidak memiliki batasan secara default).

Selain itu, ada 1 argumen yang tidak ada dibandingkan dengan perintah yang kami gunakan untuk menjalankan kontainer Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Karena kontainer yang berjalan di Windows tidak memerlukan external.tool.server.

Hasil perintah di atas akan terlihat seperti berikut:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Deleting directory 'c:\slides-src\build-out\netcore20\test-results\'.

   [mkdir] Creating directory 'c:\slides-src\build-out\netcore20\test-results\'.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Total tests: 2338. Passed: 2115. Failed: 19. Skipped: 204.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Total tests: 2728. Passed: 2147. Failed: 110. Skipped: 471.

```