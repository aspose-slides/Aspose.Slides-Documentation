---
title: Hur man kör Aspose.Slides i Docker
linktitle: Aspose.Slides i Docker
type: docs
weight: 140
url: /sv/net/how-to-run-aspose-slides-in-docker/
keywords:
- stödd OS
- Aspose.Slides i Docker
- Dockerbehållare
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- avbildningsförråd
- Windows Server Core
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Kör Aspose.Slides i Docker-containrar: konfigurera avbildningar, beroenden, typsnitt och licensiering för att bygga skalbara tjänster som bearbetar PowerPoint och OpenDocument."
---
## **Stödda OS**
Aspose.Slides kan köras i Docker-containrar med .NET Core-plattformen. I allmänhet stöder Aspose.Slides alla containertyper (OS) som .NET Core-plattformen stödjer. Däremot måste GDI eller [libgdiplus](https://github.com/mono/libgdiplus) vara tillgänglig och korrekt konfigurerad i de involverade containrarna.

För att använda Docker måste du först installera det på ditt system. För att lära dig hur man installerar Docker på Windows eller Mac, använd dessa länkar:

- [Installera Docker på Windows](https://docs.docker.com/docker-for-windows/install/)
- [Installera Docker på Mac](https://docs.docker.com/docker-for-mac/install/)

Du kan också köra Docker på Linux och Windows Server genom att följa instruktionerna på dessa sidor:

- [Installera och konfigurera Docker på Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Installera och konfigurera Docker på Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Installera och konfigurera Docker på Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Installation och konfiguration av Docker på Windows Server Nano stöds inte. Tyvärr innehåller inte Windows Server Nano det grafiska subsystemet. Det saknar gdiplus.dll, som System.Drawing.Common-biblioteket kräver, och det kan inte användas med Aspose.Slides-biblioteket.

Även om det är möjligt att köra Linux-containrar i Windows rekommenderar vi att du kör dem native på Linux (även på en Linux som installerats manuellt i en VM med VirtualBox).

## **Installera och konfigurera Docker på Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Denna Dockerfil innehåller instruktioner för att bygga en containeravbildning med libgdiplus-paketet installerat från Ubuntus officiella paketarkiv.

Här är innehållet i Dockerfilen:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# installera libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# skapa monteringspunkter

VOLUME /slides-src

\# bygg och testa Aspose.Slides vid start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Låt oss gå igenom vad varje rad kod i Dockerfilen betyder:

1. Containerns avbildning är baserad på microsoft/dotnet:2.1-sdk-bionic-bilden (bilden är redan byggd av Microsoft och publicerad på Docker's [offentlig hub](https://hub.docker.com/r/microsoft/dotnet/)). Denna bild innehåller den redan installerade dotnet 2.1 SDK. Bionic-suffixet betyder att Ubuntu 18.04 (kodnamn bionic) kommer att användas som containerns OS. Genom att ändra suffixet kan man byta underliggande OS (t.ex. stretch – Debian 9, alpine – Alpine Linux). I så fall krävs en ändring av Dockerfilens innehåll (t.ex. byta 'apt-get' till 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

Uppdaterar databasen med tillgängliga paket och installerar apt-utils-paketet.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

Installerar 'libgdiplus' och 'libc6-dev' paket som krävs av System.Drawing.Common-biblioteket.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

Deklarerar /slides-src-mappen som en monteringspunkt som vi kommer att använda för att ge åtkomst till slide-net-källmappen på värdmaskinen.

``` csharp

 VOLUME /slides-src

```

Sätter slides-src som arbetskatalog i containern.

``` csharp

 WORKDIR /slides-src

```

Deklarerar ett standardkommando som kommer att köras när containern startas om inget explicit kommando har angetts.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Enligt instruktionerna i Dockerfilen kommer den resulterande containeravbildningen ha Ubuntu 18.04 OS, dotnet-sdk, libgdiplus och libc6-dev-paketen redan installerade. Dessutom får bilden en fördefinierad monteringspunkt och ett fördefinierat kommando vid körning.

För att bygga en avbildning med denna Dockerfil måste du gå till slides-netuil docker-mappen och köra:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

- f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -- alternativet anger vilken Dockerfil som ska användas.  
- t ubuntu18_04_apt_get_libgdiplus -- anger tagg (namn) för den resulterande avbildningen.  
'.' -- anger kontexten för Docker. I vårt fall är kontexten den aktuella mappen och den är tom – eftersom vi väljer att tillhandahålla slides-net-källor som monteringspunkt (detta gör att vi inte behöver bygga om Docker-avbildningen för varje förändring i källorna).

Resultatet av körningen bör se ut så här:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

För att säkerställa att den nya avbildningen lagts till i det lokala bildförrådet:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

När avbildningen är klar kan vi köra den med detta kommando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

- it -- anger att kommandot ska köras interaktivt, så att vi kan se utdata och mata in data.  
- v `pwd`/../../:/slides-src -- anger mappen för den fördefinierade monteringspunkten – eftersom den aktuella arbetskatalogen är slides-netuildocker, kommer slides-src-mappen i containern att peka på slides-net-mappen på värden. `pwd` används för att ange relativ sökväg.  
--add-host dev.slides.external.tool.server:192.168.1.48 -- ändrar containerns hosts-fil för att lösa dev.slides.external.tool.server‑adressen.  
ubuntu1804aptgetlibgdiplus:latest -- anger avbildningen som containern ska köras från.

Resultatet av kommandot ovan blir en utdata från netcore.linux.tests.sh (eftersom det definierades som standardkommando för containern):

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

Resultatet visar att loggfiler från Func- och Regr-tester placerades i katalogen /build-out/netstandard20/test-results/main/. Dessutom misslyckades cirka 200 tester totalt – alla dessa är renderingsproblem relaterade till avsaknad av nödvändiga typsnitt i containern.

För att åsidosätta containerns standardkommando vid körning kan vi använda detta kommando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Således, istället för netcore.linux.tests.sh, kommer /bin/bash att köras och det ger en aktiv terminalsession i containern från vilken den kan köras (./build/netcore.linux.tests.sh). Detta tillvägagångssätt kan vara användbart i felsökning.

## **Installera och konfigurera Docker på Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

För närvarande innehåller Ubuntu endast version 4.2 av libgdiplus medan version 5.6 redan finns tillgänglig på produktens [officiella sida](https://github.com/mono/libgdiplus/releases). För att testa den senaste versionen av libgdiplus måste vi förbereda en avbildning med libgdiplus byggd från källkoden.

Låt oss gå igenom Dockerfilens innehåll:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# bygg den senaste stabila libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# skapa monteringspunkter

VOLUME /slides-src

\# bygg och testa Aspose.Slides vid start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Den enda skillnaden är avsnittet *build latest stable libgdiplus*. Detta avsnitt installerar alla nödvändiga verktyg för att bygga libgdiplus, klonar källkoden och bygger sedan den samt installerar den på rätt plats. Allt annat är samma som [Installera och konfigurera Docker på Linux (apt-get libgdiplus)](/slides/sv/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Obs!**: Glöm inte att använda olika bildtaggar (namn) för den resulterande avbildningen i docker build- och docker run-kommandona:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Installera och konfigurera Docker på Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Obs!**: Windows 10 Pro eller Windows Server 2016 krävs för att köra Windows-containrar.

Tyvärr tillhandahåller inte Microsoft en Windows Server Core-avbildning med dotnet SDK installerad, så vi måste installera den manuellt:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

# sätt powershell standardexekutor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

# sätt powershell standardexekutor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Hämta .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

# återvänd till cmd som standardexekutor

SHELL ["cmd", "/S", "/C"]

# För att ange system‑PATH måste ContainerAdministrator användas

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

# skapa monteringspunkter

VOLUME c:/slides-src

# bygg och testa Aspose.Slides vid start

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Den resulterande avbildningen kommer att byggas på Microsofts microsoft/windowsservercore:1803-avbildning som finns på [docker hub](https://hub.docker.com/u/microsoft). dotnet-sdk av den angivna versionen kommer att hämtas och packas upp; systemets PATH‑variabel uppdateras för att innehålla sökvägen till dotnet‑exekverbara filen. Den sista raden definierar kommandot som kör func‑ och regr‑tester i containern med nant.exe som standardåtgärd vid körning av containern.

Kommando för att bygga avbildningen:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Kommando för att köra avbildningen:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Obs!**: Kommandot för Windows‑container använder två extra argument:

- cpu-count 3  
- memory 8589934592

De anger antalet kärnor och mängden minne som är tillgängligt för containern. Som standard är bara 1 kärna och 1 GB RAM tillgängligt för Windows‑containern (Linux‑containrar har inga begränsningar som standard).

Dessutom saknas ett argument jämfört med samma kommando som vi använde för att köra Linux‑containern:

- add-host dev.slides.external.tool.server:192.168.1.48

Eftersom en container som körs på Windows inte kräver external.tool.server.

Resultatet av kommandot ovan bör se ut så här:

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