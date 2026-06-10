---
title: Hogyan futtassuk az Aspose.Slides-t Dockerben
linktitle: Aspose.Slides Dockerben
type: docs
weight: 140
url: /hu/net/how-to-run-aspose-slides-in-docker/
keywords:
- támogatott OS
- Aspose.Slides Dockerben
- Docker konténer
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- képtár
- Windows Server Core
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides futtatása Docker konténerekben: képek, függőségek, betűtípusok és licenc beállítása a PowerPoint és OpenDocument feldolgozására szolgáló skálázható szolgáltatások építéséhez."
---
## **Támogatott operációs rendszerek**
Az Aspose.Slides futtatható Docker konténerekben a .NET Core platform használatával. Általánosságban az Aspose.Slides támogatja az összes konténer (OS) típust, amelyet a .NET Core platform támogat. Azonban a GDI vagy a [libgdiplus](https://github.com/mono/libgdiplus) elérhetőnek és megfelelően beállítottaknak kell lenniük a befolyásolt konténerekben.

A Docker használatához először telepíteni kell a rendszeren. A Docker Windows vagy Mac rendszerekre történő telepítésének megismeréséhez használja a következő hivatkozásokat:

- [Telepítse a Docker-t Windowsra](https://docs.docker.com/docker-for-windows/install/)
- [Telepítse a Docker-t Mac-re](https://docs.docker.com/docker-for-mac/install/)

Docker-t Linuxon és Windows Serveren is futtathatja a következő oldalak útmutatásait követve:

- [Docker telepítése és konfigurálása Linuxon (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Docker telepítése és konfigurálása Linuxon (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Docker telepítése és konfigurálása Windows Server Core-on](#install-and-configure-docker-on-windows-server-core)

A Docker Windows Server Nano-ra történő telepítése és konfigurálása nem támogatott. Sajnos a Windows Server Nano nem tartalmaz beépített grafikus alrendszert. Nem tartalmazza a gdiplus.dll fájlt, amelyre a System.Drawing.Common könyvtárnak szüksége van, ezért nem használható az Aspose.Slides könyvtárral együtt.

Miközben lehetséges Linux konténereket Windowson futtatni, azt javasoljuk, hogy natívan Linuxon futtassa őket (akár egy VirtualBox‑os VM‑ben kézzel telepített Linuxon is).

## **Docker telepítése és konfigurálása Linuxon (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Ez a Dockerfile olyan utasításokat tartalmaz, amelyekkel egy konténerkép építhető, a libgdiplus csomag az Ubuntu hivatalos csomagtárolóiból telepítve.

A Dockerfile tartalma:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus telepítése

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# csatolási pontok létrehozása

VOLUME /slides-src

\# Aspose.Slides felépítése és tesztelése indításkor

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Nézzük meg, mit jelent a Dockerfile minden egyes sorának:

1. A konténer képe a microsoft/dotnet:2.1-sdk-bionic képre épül (a Microsoft által előre épített és a Docker [public hub](https://hub.docker.com/r/microsoft/dotnet/) oldalon közzétett képre). Ez a kép már tartalmazza a telepített dotnet 2.1 SDK‑t. A Bionic utótag azt jelenti, hogy az Ubuntu 18.04 (kódnév bionic) lesz a konténer OS‑e. Az utótag megváltoztatásával lehetséges más alap‑OS-t használni (például: stretch – Debian 9, alpine – Alpine Linux). Ebben az esetben a Dockerfile tartalmának módosítása szükséges (például az 'apt-get' helyett 'yum' használata).

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

2. Frissíti a rendelkezésre álló csomagok adatbázisát, és telepíti az apt-utils csomagot.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

3. Telepíti a System.Drawing.Common könyvtár által igényelt 'libgdiplus' és 'libc6-dev' csomagokat.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

4. Deklarálja a /slides-src mappát csatolási pontként, amelyet a gazdagépen lévő slide‑net forrásmappához való hozzáférés biztosítására használunk.

``` csharp

 VOLUME /slides-src

```

5. Beállítja a slides‑src mappát munkakönyvtárként a konténeren belül.

``` csharp

 WORKDIR /slides-src

```

6. Deklarál egy alapértelmezett parancsot, amely a konténer indulásakor lesz futtatva, ha explicit módon nincs megadva más parancs.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Az útmutató szerint a konténer képe Ubuntu 18.04 OS‑szel, dotnet‑sdk‑val, libgdiplus‑szal és libc6‑dev‑csomagokkal lesz előre telepítve. Emellett a képen előre definiált csatolási pont és előre definiált parancs is lesz.

A kép építéséhez a Dockerfile használatával a slides‑netuil Docker könyvtárba kell menni, és a következőt kell futtatni:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- megadja, hogy melyik Dockerfile‑t használja.  
*-t ubuntu18_04_apt_get_libgdiplus* -- megadja a létrejövő kép címkéjét (nevét).  
*'.'* -- megadja a Docker kontextust. Jelen esetben a kontextus az aktuális mappa, és üres — mivel a slides‑net forrásokat csatolási pontként adjuk meg (így nem kell újraépíteni a Docker‑képet minden forrásváltozáskor).

A végrehajtás eredménye így néz ki:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Annak ellenőrzéséhez, hogy az új kép hozzá lett‑e adva a helyi képtárhoz:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Miután a kép elkészült, a következő paranccsal indíthatjuk el:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- megadja, hogy a parancs interaktívan fusson, lehetővé téve a kimenet megtekintését és a bevitel rögzítését.  
*-v `pwd`/../../:/slides-src* -- megadja a mappát az előre definiált csatolási ponthoz — mivel az aktuális munkakönyvtár a slides‑netuidocker, így a konténerben lévő slides‑src mappa a gazdagépen lévő slides‑net mappára mutat. A `pwd` relatív útvonalat ad meg.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- módosítja a konténer hosts fájlját, hogy feloldja a dev.slides.external.tool.server URL‑t.  
*ubuntu1804aptgetlibgdiplus:latest* -- megadja a futtatandó képet.

A fenti parancs eredménye a netcore.linux.tests.sh kimenete lesz (mivel ez volt beállítva alapértelmezett parancsként a konténerhez):

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

Az eredményből látszik, hogy a Func és Regr tesztek naplófájljai a /build-out/netstandard20/test-results/main/ könyvtárba kerültek. Összesen körülbelül 200 teszt hibázott – mindegyik a konténerben hiányzó szükséges betűtípusok miatt fellépő renderelési problémára vezethető vissza.

Az alapértelmezett konténerparancs felülírásához a futtatás során használhatjuk ezt a parancsot:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Így a netcore.linux.tests.sh helyett a /bin/bash lesz végrehajtva, és egy aktív terminál‑szekciót nyújt a konténerben, ahonnan a (./build/netcore.linux.tests.sh) futtatható. Ez a megközelítés hasznos lehet hibaelhárítási helyzetekben.

## **Docker telepítése és konfigurálása Linuxon (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Jelenleg az Ubuntu csak a libgdiplus 4.2‑es verzióját tartalmazza, míg a 5.6‑os verzió már elérhető a termék [official site](https://github.com/mono/libgdiplus/releases) oldalán. A libgdiplus legújabb verziójának teszteléséhez egy olyan képre van szükség, amely a forrásból épített libgdiplus‑t tartalmazza.

Nézzük meg a Dockerfile tartalmát:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# legújabb stabil libgdiplus felépítése

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# csatolási pontok létrehozása

VOLUME /slides-src

\# Aspose.Slides felépítése és tesztelése indításkor

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Az egyetlen különbség a *build latest stable libgdiplus* szakasz. Ez a szakasz telepíti az összes szükséges eszközt a libgdiplus felépítéséhez, klónozza a forráskódot, majd lefordítja és a megfelelő helyre telepíti. Minden egyéb megegyezik a [Docker telepítése és konfigurálása Linuxon (apt-get libgdiplus)](/slides/hu/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/) lapon leírtakkal.

**Megjegyzés**: Ne felejtse el különböző képcímkéket (neveket) használni a docker build és docker run parancsoknál a létrehozott képhez:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Docker telepítése és konfigurálása Windows Server Core-on**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Megjegyzés**: Windows 10 Pro vagy Windows Server 2016 szükséges a Windows konténerek futtatásához.

Sajnos a Microsoft nem biztosít Windows Server Core képet a dotnet SDK‑val előre telepítve, ezért azt manuálisan kell telepíteni:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
\# határozza meg a PowerShell alapértelmezett végrehajtót

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
\# határozza meg a PowerShell alapértelmezett végrehajtót

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Retrieve .NET Core SDK
\# .NET Core SDK lekérése

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
#return cmd as default executor
# visszaállítja a cmd-t alapértelmezett végrehajtónak
SHELL ["cmd", "/S", "/C"]
\# In order to set system PATH, ContainerAdministrator must be used
\# A rendszer PATH beállításához a ContainerAdministrator felhasználót kell használni
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
\# create mount points
\# csatolási pontok létrehozása
VOLUME c:/slides-src
#build and test Aspose.Slides on start
# Aspose.Slides felépítése és tesztelése indításkor
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

A kapott kép a microsoft/windowsservercore:1803 képre épül, amelyet a Microsoft a [docker hub](https://hub.docker.com/u/microsoft) oldalon biztosít. A megadott verziójú dotnet‑sdk le lesz töltve és kicsomagolva; a rendszer PATH változója frissül, hogy tartalmazza a dotnet végrehajtható állomány útvonalát. Az utolsó sor definiálja a parancsot, amely a func és regr teszteket futtatja a konténeren belül a nant.exe‑t használva alapértelmezett műveletként a konténer indításakor.

Parancs a kép építéséhez:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Parancs a kép futtatásához:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Megjegyzés**: A Windows konténer parancsa 2 extra argumentumot használ:

*-cpu-count 3* – a konténer számára rendelkezésre álló processzorok számát állítja be.  
*-memory 8589934592* – a konténer számára elérhető memória mennyiségét állítja be.

Ezek határozzák meg a magok számát és a rendelkezésre álló memória mennyiségét. Alapértelmezés szerint csak 1 mag és 1 GB RAM áll rendelkezésre a Windows konténerhez (a Linux konténereknek alapból nincs korlátozása).

Emellett egy argumentum hiányzik a Linux konténerhez használt parancshoz képest:

*-add-host dev.slides.external.tool.server:192.168.1.48* – mivel a Windows‑on futó konténernek nincs szüksége az external.tool.server‑re.

A fenti parancs eredménye a következőképpen néz ki:

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