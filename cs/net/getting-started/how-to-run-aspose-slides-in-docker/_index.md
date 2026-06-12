---
title: Jak spustit Aspose.Slides v Dockeru
linktitle: Aspose.Slides v Dockeru
type: docs
weight: 140
url: /cs/net/how-to-run-aspose-slides-in-docker/
keywords:
- podporované OS
- Aspose.Slides v Dockeru
- Docker kontejner
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- úložiště obrázků
- Windows Server Core
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spusťte Aspose.Slides v Docker kontejnerech: nakonfigurujte obrazy, závislosti, fonty a licencování pro vytvoření škálovatelných služeb, které zpracovávají PowerPoint a OpenDocument."
---
## **Podporované OS**
Aspose.Slides může běžet uvnitř Docker kontejnerů na platformě .NET Core. Obecně Aspose.Slides podporuje všechny typy kontejnerů (OS), které podporuje platforma .NET Core. Nicméně GDI nebo [libgdiplus ](https://github.com/mono/libgdiplus) musí být v kontejneru dostupné a správně nastavené.

Pro používání Dockeru jej musíte nejprve nainstalovat na svůj systém. Jak nainstalovat Docker na Windows nebo Mac, najdete na těchto odkazech:

- [Install Docker on Windows](https://docs.docker.com/docker-for-windows/install/)
- [Install Docker on Mac](https://docs.docker.com/docker-for-mac/install/)

Docker můžete také spustit na Linuxu a Windows Server podle instrukcí na těchto stránkách:  

- [Install and configure Docker on Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Install and configure Docker on Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)  

- [Install and configure Docker on Windows Server Core](#install-and-configure-docker-on-windows-server-core)  

Instalace a konfigurace Dockeru na Windows Server Nano není podporována. Bohužel Windows Server Nano neobsahuje grafický subsystém. Neobsahuje gdiplus.dll, kterou vyžaduje knihovna System.Drawing.Common, a nelze ji použít s knihovnou Aspose.Slides.

I když je možné spouštět Linux kontejnery ve Windows, doporučujeme je spouštět nativně na Linuxu (i na Linuxu nainstalovaném ručně na virtuálním stroji pomocí VirtualBox).

## **Install and Configure Docker on Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Tento Docker soubor obsahuje instrukce pro vytvoření obrazu kontejneru s nainstalovaným balíčkem libgdiplus z oficiálních úložišť Ubuntu.

Obsah Docker souboru:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# nainstalovat libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# vytvořit přípojené body

VOLUME /slides-src

\# sestavit a otestovat Aspose.Slides při startu

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Projděme si, co jednotlivé řádky kódu v Docker souboru znamenají:

1. Obrázek kontejneru je založen na obrazu microsoft/dotnet:2.1-sdk-bionic (obraz již vytvořený Microsoftem a publikovaný na Docker [public hub](https://hub.docker.com/r/microsoft/dotnet/)). Tento obraz obsahuje předinstalovaný dotnet 2.1 SDK. Přípona Bionic znamená, že jako OS kontejneru bude použito Ubuntu 18.04 (kódové jméno bionic). Změnou přípony lze změnit základní OS (například: stretch – Debian 9, alpine – Alpine Linux). V takovém případě bude nutná úprava obsahu Docker souboru (například změna „apt-get“ na „yum“).

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Aktualizuje databázi dostupných balíčků a nainstaluje balíček apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Instaluje balíčky „libgdiplus“ a „libc6-dev“, které jsou vyžadovány knihovnou System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Deklaruje složku /slides-src jako přípojný bod, který bude použit k poskytnutí přístupu ke zdrojům slide‑net na hostitelském počítači.

``` csharp

 VOLUME /slides-src

```

1. Nastaví /slides-src jako pracovní adresář uvnitř kontejneru.

``` csharp

 WORKDIR /slides-src

```

1. Definuje výchozí příkaz, který bude spuštěn při startu kontejneru, pokud není explicitně zadán.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Podle instrukcí v Docker souboru bude výsledný obraz kontejneru mít nainstalované Ubuntu 18.04, dotnet‑sdk, libgdiplus a libc6‑dev balíčky. Tento obraz bude také obsahovat předdefinovaný přípojný bod a předdefinovaný příkaz při spuštění.

Pro sestavení obrazu pomocí tohoto Docker souboru přejděte do složky slides‑netuil docker a spusťte:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* – určuje, který Docker soubor použít.  
*-t ubuntu18_04_apt_get_libgdiplus* – určuje tag (název) pro výsledný obraz.  
*'.'* – určuje kontext pro Docker. V našem případě je kontext aktuální složka a je prázdná – protože jako přípojný bod poskytujeme zdroje slide‑net (to nám umožňuje znovu nepřestavovat Docker obraz při každé změně ve zdrojích).

Výsledek provedení by měl vypadat takto:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Pro ověření, že byl nový obraz přidán do lokálního úložiště obrázků:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Jakmile je obraz připraven, můžeme ho spustit tímto příkazem:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* – spustí příkaz interaktivně, aby bylo vidět výstup a zachytit vstup.  
*-v `pwd`/../../:/slides-src* – určuje složku pro předdefinovaný přípojný bod – protože aktuální pracovní adresář je slides‑netuildocker, složka /slides‑src v kontejneru bude ukazovat na složku slides‑net na hostiteli. `pwd` slouží k zadání relativní cesty.  
*--add-host dev.slides.external.tool.server:192.168.1.48* – upraví hosts soubor kontejneru pro rozlišení URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* – určuje obraz, který se má spustit.

Výstup výše uvedeného příkazu bude výstup skriptu netcore.linux.tests.sh (protože byl definován jako výchozí příkaz pro kontejner):

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

Z výsledku je patrné, že log soubory z Func a Regr testů byly umístěny do adresáře /build-out/netstandard20/test-results/main/. Také přibližně 200 testů selhalo – všechny jsou problémy s vykreslováním způsobené chybějícími fonty v kontejneru.

Pro přepsání výchozího příkazu kontejneru při spuštění můžeme použít tento příkaz:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Tedy místo netcore.linux.tests.sh bude spuštěno /bin/bash, které poskytne aktivní terminál kontejneru, odkud lze spustit (./build/netcore.linux.tests.sh). Tento přístup může být užitečný při řešení problémů.

## **Install and Configure Docker on Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

V současnosti Ubuntu obsahuje pouze verzi 4.2 libgdiplus, zatímco verze 5.6 je již dostupná na [oficiálním webu produktu](https://github.com/mono/libgdiplus/releases). Pro testování nejnovější verze libgdiplus musíme připravit obraz s libgdiplus postaveným ze zdrojů.

Projděme si obsah Docker souboru:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# sestavit nejnovější stabilní libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# vytvořit přípojené body

VOLUME /slides-src

\# sestavit a otestovat Aspose.Slides při startu

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Jediný rozdíl je v sekci *build latest stable libgdiplus*. Tato sekce instaluje všechny potřebné nástroje pro sestavení libgdiplus, klonuje zdroje a poté je sestaví a nainstaluje na správné místo. Všechno ostatní je stejné jako v [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/cs/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Note**: Nezapomeňte použít odlišné image tagy (názvy) pro výsledný obraz při příkazech docker build a docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Install and Configure Docker on Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Note**: Pro běh Windows kontejnerů je vyžadován Windows 10 Pro nebo Windows Server 2016.

Bohužel Microsoft neposkytuje Windows Server Core obraz s nainstalovaným dotnet SDK, takže jej musíme nainstalovat ručně:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#nastavit výchozí spouštěč powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#nastavit výchozí spouštěč powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# načíst .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#vrátit cmd jako výchozí spouštěč

SHELL ["cmd", "/S", "/C"]

\# aby se nastavil systémový PATH, je nutné použít ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# vytvořit přípojené body

VOLUME c:/slides-src

#sestavit a otestovat Aspose.Slides při startu

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Výsledný obraz bude postaven na základě obrazu microsoft/windowsservercore:1803 poskytnutého Microsoftem na [docker hub](https://hub.docker.com/u/microsoft). Dotnet‑sdk požadované verze bude stažen a rozbalen; proměnná PATH systému bude aktualizována tak, aby obsahovala cestu k spustitelnému souboru dotnet. Poslední řádek definuje příkaz, který spouští func & regr testy v kontejneru pomocí nant.exe jako výchozí akci při spuštění kontejneru.

Příkaz pro sestavení obrazu:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Příkaz pro spuštění obrazu:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Note**: Příkaz pro Windows kontejner používá 2 extra argumenty:

*-cpu-count 3*  
*-memory 8589934592*

Nastavují počet jader a množství paměti dostupné pro kontejner. Ve výchozím nastavení je pro Windows kontejner k dispozici pouze 1 jádro a 1 GB RAM (Linux kontejner nemá ve výchozím nastavení žádná omezení).

Také zde chybí 1 argument, který byl u Linux kontejneru:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Protože kontejner běžící na Windows nepotřebuje external.tool.server.

Výsledek výše uvedeného příkazu by měl vypadat takto:

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