---
title: Hoe Aspose.Slides in Docker uit te voeren
linktitle: Aspose.Slides in Docker
type: docs
weight: 140
url: /nl/net/how-to-run-aspose-slides-in-docker/
keywords:
- ondersteund OS
- Aspose.Slides in Docker
- Docker-container
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- image-repository
- Windows Server Core
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides uitvoeren in Docker-containers: configureer images, afhankelijkheden, lettertypen en licenties om schaalbare services te bouwen die PowerPoint- en OpenDocument-bestanden verwerken."
---
## **Ondersteunde OS**
Aspose.Slides kan binnen Docker-containers worden uitgevoerd met het .NET Core-platform. Over het algemeen ondersteunt Aspose.Slides alle container‑typen (OS) die het .NET Core-platform ondersteunt. De GDI of [libgdiplus](https://github.com/mono/libgdiplus) moet echter beschikbaar zijn en correct worden ingesteld op de betrokken containers.

Om Docker te gebruiken, moet u het eerst op uw systeem installeren. Om te leren hoe u Docker op Windows of Mac installeert, gebruik deze links:

- [Docker installeren op Windows](https://docs.docker.com/docker-for-windows/install/)
- [Docker installeren op Mac](https://docs.docker.com/docker-for-mac/install/)

U kunt Docker ook op Linux en Windows Server uitvoeren door de instructies op deze pagina's te volgen:

- [Docker installeren en configureren op Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Docker installeren en configureren op Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Docker installeren en configureren op Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Installatie en configuratie van Docker op Windows Server Nano wordt niet ondersteund. Helaas bevat Windows Server Nano geen grafisch subsysteem. Het bevat geen gdiplus.dll, die de System.Drawing.Common‑bibliotheek vereist, en kan niet worden gebruikt met de Aspose.Slides‑bibliotheek.

Hoewel het mogelijk is om Linux‑containers in Windows uit te voeren, raden we aan ze native op Linux te draaien (zelfs op een Linux die handmatig op een VM met VirtualBox is geïnstalleerd).

## **Docker installeren en configureren op Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Dit Docker‑bestand bevat instructies om een container‑image te bouwen met het libgdiplus‑pakket geïnstalleerd vanuit de officiële Ubuntu‑pakketbronnen.

Hieronder staat de inhoud van het Docker‑bestand:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus installeren

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# mount‑punten aanmaken

VOLUME /slides-src

\# bouw en test Aspose.Slides bij start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Laten we bekijken wat elke regel code in het Docker‑bestand betekent:

1. De container‑image is gebaseerd op de microsoft/dotnet:2.1-sdk-bionic image (de image die al door Microsoft is gebouwd en gepubliceerd op de Docker [public hub](https://hub.docker.com/r/microsoft/dotnet/)). Deze image bevat de reeds geïnstalleerde dotnet 2.1 SDK. Bionic‑suffix betekent dat Ubuntu 18.04 (codenaam bionic) wordt genomen als het OS van de container. Door de suffix te wijzigen, kan het onderliggende OS worden veranderd (bijvoorbeeld: stretch – Debian 9, alpine – Alpine Linux). In dat geval moet de inhoud van het Docker‑bestand worden aangepast (bijvoorbeeld, 'apt-get' naar 'yum' veranderen).

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Werkt de database met beschikbare pakketten bij en installeert het apt-utils‑pakket.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Installeert de pakketten 'libgdiplus' en 'libc6-dev' die vereist zijn door de System.Drawing.Common‑bibliotheek.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Declareert de map /slides-src als een mount‑punt dat gebruikt wordt om toegang te bieden tot de slide‑net‑bronmap op de hostmachine.

``` csharp

 VOLUME /slides-src

```

1. Stelt slides-src in als werkdirectory binnen de container.

``` csharp

 WORKDIR /slides-src

```

1. Declareert een standaardcommando dat bij het starten van de container wordt uitgevoerd als er geen expliciet commando is opgegeven.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Volgens de instructies in het Docker‑bestand zal de resulterende container‑image Ubuntu 18.04 OS, dotnet‑SDK, libgdiplus en libc6‑dev pakketten reeds geïnstalleerd hebben. Ook zal deze image een vooraf gedefinieerd mount‑punt en een vooraf gedefinieerd commando bij uitvoering bevatten.

Om een image te bouwen met dit Docker‑bestand, moet u naar de slides-netuil Docker‑map gaan en uitvoeren:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* – optie die aangeeft welk Docker‑bestand moet worden gebruikt.  
*-t ubuntu18_04_apt_get_libgdiplus* – geeft de tag (naam) op voor de resulterende image.  
*'.'* – specificeert de context voor Docker. In ons geval is de context de huidige map en is leeg — omdat we ervoor kiezen om de slides‑net‑bronnen als mount‑punt te leveren (dit voorkomt dat we de Docker‑image bij elke wijziging in de bron opnieuw moeten bouwen).

Het resultaat van de uitvoering zou er als volgt uit moeten zien:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Om te controleren dat de nieuwe image aan de lokale image‑repository is toegevoegd:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Zodra de image klaar is, kunnen we deze uitvoeren met dit commando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* – geeft aan dat het commando interactief moet worden uitgevoerd, zodat we de output kunnen zien en invoer kunnen vastleggen.  
*-v `pwd`/../../:/slides-src* – specificeert de map voor het vooraf gedefinieerde mount‑punt — omdat de huidige werkmap slides-netuildocker is, zal de slides‑src map in de container wijzen naar de slides‑net map op de host. `pwd` wordt gebruikt om een relatief pad op te geven.  
*--add-host dev.slides.external.tool.server:192.168.1.48* – wijzigt het hosts‑bestand van de container om de URL dev.slides.external.tool.server te resolven.  
*ubuntu1804aptgetlibgdiplus:latest* – geeft de image op die de container moet uitvoeren.

Het resultaat van het bovenstaande commando zal de output van netcore.linux.tests.sh zijn (aangezien dit als standaardcommando voor de container is gedefinieerd):

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

Uit het resultaat blijkt duidelijk dat logbestanden van de Func‑ en Regr‑tests zijn geplaatst in de map /build-out/netstandard20/test-results/main/. Ook zijn ongeveer 200 tests in totaal gefaald — en dit zijn allemaal rendering‑problemen die verband houden met het ontbreken van vereiste lettertypen in de container.

Om het standaardcommando van de container tijdens een run te overschrijven, kunnen we dit commando gebruiken:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Dus in plaats van netcore.linux.tests.sh wordt /bin/bash uitgevoerd en biedt het een actieve terminalsessie van de container waaruit het kan worden uitgevoerd (./build/netcore.linux.tests.sh). Deze aanpak kan nuttig zijn bij probleemoplossingsscenario's.

## **Docker installeren en configureren op Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Momenteel bevat Ubuntu alleen versie 4.2 van libgdiplus, terwijl versie 5.6 al beschikbaar is op de [officiële site](https://github.com/mono/libgdiplus/releases) van het product. Om de nieuwste versie van libgdiplus te testen, moeten we een image voorbereiden met libgdiplus gebouwd vanuit de broncode.

Laten we de inhoud van het Docker‑bestand bekijken:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# bouw de nieuwste stabiele libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# maak mount‑punten aan

VOLUME /slides-src

\# bouw en test Aspose.Slides bij start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Het enige verschil is de sectie *build latest stable libgdiplus*. Deze sectie installeert alle benodigde tools om libgdiplus te bouwen, kloont de broncode en bouwt deze vervolgens en installeert ze op de juiste locatie. De rest is hetzelfde als [Docker installeren en configureren op Linux (apt-get libgdiplus)](/slides/nl/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Opmerking**: Vergeet niet verschillende image‑tags (namen) te gebruiken voor de resulterende image bij de docker build‑ en docker run‑commando's:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Docker installeren en configureren op Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Opmerking**: Windows 10 Pro of Windows Server 2016 is vereist om Windows‑containers uit te voeren.

Helaas levert Microsoft geen Windows Server Core‑image met de dotnet‑SDK geïnstalleerd, dus moeten we deze handmatig installeren:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

# stel powershell-standaarduitvoerder in

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

# stel powershell-standaarduitvoerder in

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Haal .NET Core SDK op

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

# stel cmd in als standaarduitvoerder

SHELL ["cmd", "/S", "/C"]

# Om het systeem-PATH in te stellen moet ContainerAdministrator worden gebruikt

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

# maak mount‑punten aan

VOLUME c:/slides-src

# bouw en test Aspose.Slides bij start

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

De resulterende image wordt gebouwd bovenop de microsoft/windowsservercore:1803‑image die door Microsoft wordt geleverd op [Docker hub](https://hub.docker.com/u/microsoft). De dotnet‑SDK van de opgegeven versie wordt gedownload en uitgepakt; de PATH‑variabele van het systeem wordt bijgewerkt zodat deze het pad naar het dotnet‑executable bevat. De laatste regel definieert het commando dat func‑ en regr‑tests uitvoert in de container met nant.exe als standaardactie bij het uitvoeren van de container.

Commando om de image te bouwen:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Commando om de image uit te voeren:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Opmerking**: Het commando voor Windows‑containers gebruikt 2 extra argumenten:
*-cpu-count 3*
*-memory 8589934592*
Ze stellen respectievelijk het aantal cores en de hoeveelheid geheugen in die beschikbaar is voor de container. Standaard is er slechts 1 core en 1 GB RAM beschikbaar voor de Windows‑container (Linux‑containers hebben standaard geen beperkingen).

Ook ontbreekt één argument vergeleken met hetzelfde commando dat we gebruikten om de Linux‑container uit te voeren:
*-add-host dev.slides.external.tool.server:192.168.1.48*
Omdat een container die op Windows draait geen external.tool.server nodig heeft.

Het resultaat van het bovenstaande commando zou er als volgt uit moeten zien:

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