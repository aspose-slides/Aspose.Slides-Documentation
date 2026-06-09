---
title: Docker'da Aspose.Slides Nasıl Çalıştırılır
linktitle: Docker'da Aspose.Slides
type: docs
weight: 140
url: /tr/net/how-to-run-aspose-slides-in-docker/
keywords:
- desteklenen işletim sistemi
- Docker'da Aspose.Slides
- Docker konteyneri
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- görüntü deposu
- Windows Server Core
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: Docker konteynerlerinde Aspose.Slides çalıştırın: PowerPoint ve OpenDocument işleyecek ölçeklenebilir hizmetler oluşturmak için görüntüleri, bağımlılıkları, fontları ve lisanslamayı yapılandırın.
---
## **Desteklenen OS**
Aspose.Slides, .NET Core platformunu kullanarak docker konteynerleri içinde çalışabilir. Genel olarak, Aspose.Slides, .NET Core platformunun desteklediği tüm konteyner (OS) türlerini destekler. Ancak, GDI veya [libgdiplus](https://github.com/mono/libgdiplus) konteynerlerde mevcut olmalı ve doğru şekilde ayarlanmış olmalıdır.

Docker'ı kullanmak için önce sisteminize kurmanız gerekir. Windows veya Mac üzerinde Docker'ı nasıl kuracağınızı öğrenmek için şu bağlantıları kullanın:
- [Windows'ta Docker'ı Kurun](https://docs.docker.com/docker-for-windows/install/)
- [Mac'te Docker'ı Kurun](https://docs.docker.com/docker-for-mac/install/)

Linux ve Windows Server üzerinde Docker'ı çalıştırmak için aşağıdaki sayfalardaki talimatları izleyebilirsiniz:
- [Linux'ta Docker'ı Kur ve Yapılandır (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Linux'ta Docker'ı Kur ve Yapılandır (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Windows Server Core'ta Docker'ı Kur ve Yapılandır](#install-and-configure-docker-on-windows-server-core)

Windows Server Nano üzerinde Docker kurulumu ve yapılandırması desteklenmemektedir. Ne yazık ki, Windows Server Nano yerleşik grafik alt sistemine sahip değildir. System.Drawing.Common kütüphanesinin gerektirdiği gdiplus.dll dosyasını içermez ve Aspose.Slides kütüphanesiyle kullanılamaz.

Linux konteynerlerini Windows üzerinde çalıştırmak mümkün olsa da, onları doğrudan Linux üzerinde (VirtualBox kullanarak bir VM'e manuel olarak kurulan Linux dahil) çalıştırmanızı öneririz.

## **Linux'ta Docker'ı Kur ve Yapılandır (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Bu Dockerfile, Ubuntu'nun resmi paket depolarından libgdiplus paketi kurulmuş bir konteyner görüntüsü oluşturmak için talimatlar içerir.

Dockerfile içeriği aşağıdadır:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus kur

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# bağlama noktaları oluştur

VOLUME /slides-src

\# başlangıçta Aspose.Slides'ı derle ve test et

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Dockerfile'daki her bir satırın ne anlama geldiğine bir göz atalım:
1. Konteyner görüntüsü, microsoft/dotnet:2.1-sdk-bionic görüntüsüne dayanır (Microsoft tarafından oluşturulmuş ve Docker'ın [public hub](https://hub.docker.com/r/microsoft/dotnet/) üzerinde yayınlanmıştır). Bu görüntü, önceden kurulu dotnet 2.1 SDK'yı içerir. Bionic son eki, Ubuntu 18.04 (kod adı bionic) işletim sisteminin konteynerde kullanılacağını ifade eder. Son eki değiştirerek temel işletim sistemi değiştirilebilir (örnek: stretch — Debian 9, alpine — Alpine Linux). Bu durumda Dockerfile içeriğinin (örneğin 'apt-get' yerine 'yum' yazılması) değiştirilmesi gerekir.

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

2. Mevcut paketlerin veritabanasını günceller ve apt-utils paketini kurar.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

3. 'System.Drawing.Common' kütüphanesinin gerektirdiği 'libgdiplus' ve 'libc6-dev' paketlerini kurar.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

4. /slides-src klasörünü, ana makinedeki slide-net kaynak klasörüne erişim sağlamak için kullanılacak bir bağlama noktası (mount point) olarak tanımlar.

``` csharp

 VOLUME /slides-src

```

5. slides-src'yi konteyner içinde çalışma dizini olarak ayarlar.

``` csharp

 WORKDIR /slides-src

```

6. Açık bir komut belirtilmemişse, konteyner başlatıldığında çalıştırılacak varsayılan bir komut tanımlar.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Dockerfile talimatlarına göre, ortaya çıkan konteyner görüntüsü Ubuntu 18.04 işletim sistemi, dotnet-sdk, libgdiplus ve libc6-dev paketlerine önceden kurulmuş olarak sahip olacak. Ayrıca bu görüntü, önceden tanımlanmış bir bağlama noktası ve çalıştırma sırasında kullanılacak bir varsayılan komuta sahip olacaktır.

Bu Dockerfile kullanarak bir görüntü oluşturmak için slides-netuil docker klasörüne gidip aşağıdaki komutu çalıştırmanız gerekir:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* — hangi Dockerfile'ın kullanılacağını belirten seçenektir.

*-t ubuntu18_04_apt_get_libgdiplus* — ortaya çıkan görüntü için etiket (isim) belirler.

*'.'* — Docker bağlamını (context) belirtir. Bizim örneğimizde bağlam, mevcut klasördür ve boştur — çünkü slides-net kaynaklarını bağlama noktası olarak sağlamayı seçtik (bu, kaynaklardaki her değişiklikte Docker görüntüsünü yeniden oluşturmayı engeller).

Çalıştırmanın sonucu aşağıdaki gibi görünmelidir:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Yeni görüntünün yerel görüntü deposuna eklendiğini doğrulamak için:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Görüntü hazır olduğunda, aşağıdaki komutla çalıştırabiliriz:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* — komutun etkileşimli olarak çalıştırılmasını sağlar, böylece çıktıyı görebilir ve girişi yakalayabiliriz.

*-v `pwd`/../../:/slides-src* — önceden tanımlanmış bağlama noktası için klasörü belirtir; mevcut çalışma dizini slides-netuildocker olduğundan, konteynerdeki slides-src klasörü ana makinedeki slides-net klasörüne işaret eder. `pwd` göreli yolu belirtmek için kullanılır.

*--add-host dev.slides.external.tool.server:192.168.1.48* — konteynerin hosts dosyasını değiştirerek dev.slides.external.tool.server URL'sini çözer.

*ubuntu1804aptgetlibgdiplus:latest* — konteyneri çalıştıracak görüntüyü belirtir.

Yukarıdaki komutun sonucu netcore.linux.tests.sh çıktısı olacaktır (çünkü konteyner için varsayılan komut olarak tanımlanmıştır):

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

Sonuçtan, Func ve Regr testlerinin günlük dosyalarının /build-out/netstandard20/test-results/main/ dizinine yerleştirildiği açıktır. Ayrıca toplamda yaklaşık 200 test başarısız olmuş—ve bunların hepsi, konteynerde gerekli fontların olmamasına bağlı render hatalarıdır.

Bir çalıştırmada konteynerin varsayılan komutunu geçersiz kılmak için aşağıdaki komutu kullanabiliriz:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Dolayısıyla, netcore.linux.tests.sh yerine /bin/bash çalıştırılacak ve konteynerin içine bir etkileşimli terminal oturumu açılacak; bu oturumda (./build/netcore.linux.tests.sh) komutu çalıştırılabilir. Bu yaklaşım sorun giderme senaryolarında faydalı olabilir.

## **Linux'ta Docker'ı Kur ve Yapılandır (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Şu anda Ubuntu, libgdiplus'un sadece 4.2 sürümünü içerirken, 5.6 sürümü ürünün [official site](https://github.com/mono/libgdiplus/releases) adresinde zaten mevcuttur. libgdiplus'un en yeni sürümünü test etmek için, libgdiplus kaynaklarından derlenmiş bir görüntü hazırlamamız gerekir.

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# en son kararlı libgdiplus'ı oluştur

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# bağlama noktaları oluştur

VOLUME /slides-src

\# başlangıçta Aspose.Slides'ı derle ve test et

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Tek fark, *build latest stable libgdiplus* bölümüdür. Bu bölüm, libgdiplus'ı derlemek için gerekli tüm araçları kurar, kaynakları klonlar, ardından derler ve doğru konuma kurar. Diğer her şey, [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/tr/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/) ile aynıdır.

**Not**: Docker build ve Docker run komutlarında ortaya çıkan görüntü için farklı image tag'leri (isimleri) kullanmayı unutmayın:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Windows Server Core'ta Docker'ı Kur ve Yapılandır**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Not**: Windows konteynerlerini çalıştırmak için Windows 10 Pro veya Windows Server 2016 gereklidir.

Ne yazık ki, Microsoft Windows Server Core görüntüsü içinde dotnet SDK'sı önceden kurulu olarak sağlamıyor, bu yüzden elle kurmamız gerekir:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell varsayılan yürütücü

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell varsayılan yürütücü

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# .NET Core SDK'sını al

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 
    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#return cmd varsayılan yürütücü olarak

SHELL ["cmd", "/S", "/C"]

\# sistem PATH'ini ayarlamak için ContainerAdministrator kullanılmalı

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# bağlama noktaları oluştur

VOLUME c:/slides-src

#başlangıçta Aspose.Slides'ı derle ve test et

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Ortaya çıkan görüntü, Microsoft tarafından [docker hub](https://hub.docker.com/u/microsoft) üzerinde sağlanan microsoft/windowsservercore:1803 görüntüsü üzerine inşa edilecektir. Belirtilen sürümün dotnet-sdk'sı indirilecek ve açılacak; sistemin PATH değişkeni dotnet çalıştırılabilir dosyasının yolunu içerecek şekilde güncellenecek. Son satır ise, konteyner çalıştırıldığında varsayılan eylem olarak nant.exe kullanarak func ve regr testlerini çalıştıran komutu tanımlar.

Command to build the image:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Command to run the image:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Not**: Windows konteyneri için komut iki ekstra argüman kullanır:
*-cpu-count 3* — konteyner için kullanılacak çekirdek sayısını 3 olarak ayarlar.
*-memory 8589934592* — konteynerin bellek miktarını 8589934592 byte (8 GB) olarak ayarlar.

Bu argümanlar, konteynerin kullanabileceği çekirdek sayısını ve bellek miktarını belirler. Varsayılan olarak, Windows konteyneri için yalnızca 1 çekirdek ve 1 GB RAM mevcuttur (Linux konteynerlerinin varsayılan bir sınırlaması yoktur).

Ayrıca, Linux konteynerinde kullandığımız komuttan eksik bir argüman vardır:
*-add-host dev.slides.external.tool.server:192.168.1.48* — Linux konteynerinde kullandığımız komuttan eksik bir argümandır.

Çünkü Windows üzerinde çalışan konteyner, external.tool.server'ı gerektirmez.

Yukarıdaki komutun sonucu aşağıdaki gibi görünmelidir:

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