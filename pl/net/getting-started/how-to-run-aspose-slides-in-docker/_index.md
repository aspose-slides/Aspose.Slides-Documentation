---
title: Jak uruchomić Aspose.Slides w Dockerze
linktitle: Aspose.Slides w Dockerze
type: docs
weight: 140
url: /pl/net/how-to-run-aspose-slides-in-docker/
keywords:
- obsługiwane systemy operacyjne
- Aspose.Slides w Dockerze
- kontener Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- repozytorium obrazów
- Windows Server Core
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Uruchom Aspose.Slides w kontenerach Docker: skonfiguruj obrazy, zależności, czcionki i licencjonowanie, aby tworzyć skalowalne usługi przetwarzające PowerPoint i OpenDocument."
---
## **Obsługiwane systemy operacyjne**
Aspose.Slides może działać w kontenerach Docker przy użyciu platformy .NET Core. Generalnie, Aspose.Slides obsługuje wszystkie typy kontenerów (systemów operacyjnych), które obsługuje platforma .NET Core. Jednak GDI lub [libgdiplus](https://github.com/mono/libgdiplus) musi być dostępny i poprawnie skonfigurowany w używanych kontenerach.

Aby używać Dockera, musisz najpierw zainstalować go na swoim systemie. Aby dowiedzieć się, jak zainstalować Dockera na Windows lub Mac, skorzystaj z następujących linków:

- [Zainstaluj Docker na Windows](https://docs.docker.com/docker-for-windows/install/)
- [Zainstaluj Docker na Mac](https://docs.docker.com/docker-for-mac/install/)

Możesz także uruchomić Docker na Linuksie i Windows Server, postępując zgodnie z instrukcjami na tych stronach:

- [Zainstaluj i skonfiguruj Docker na Linuksie (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Zainstaluj i skonfiguruj Docker na Linuksie (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Zainstaluj i skonfiguruj Docker na Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Instalacja i konfiguracja Dockera na Windows Server Nano nie jest wspierana. Niestety, Windows Server Nano nie zawiera wbudowanego podsystemu graficznego. Nie zawiera pliku gdiplus.dll, którego wymaga biblioteka System.Drawing.Common, i nie może być używany z biblioteką Aspose.Slides.

Choć istnieje możliwość uruchamiania kontenerów Linux w Windows, zalecamy uruchamianie ich natywnie na Linuxie (nawet na Linuxie zainstalowanym ręcznie w maszynie wirtualnej przy użyciu VirtualBox).

## **Zainstaluj i skonfiguruj Docker na Linuksie (apt-get libgdiplus)**
- System operacyjny: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Ten plik Docker zawiera instrukcje budowania obrazu kontenera z zainstalowanym pakietem libgdiplus pochodzącym z oficjalnych repozytoriów pakietów Ubuntu.

Oto zawartość pliku Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# zainstaluj libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# utwórz punkty montowania

VOLUME /slides-src

\# buduj i testuj Aspose.Slides przy starcie

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Przejrzyjmy, co oznacza każda linia kodu w pliku Docker:

1. Obraz kontenera oparty jest na obrazie microsoft/dotnet:2.1-sdk-bionic (obraz już zbudowany przez Microsoft i opublikowany w [publiczny hub Docker](https://hub.docker.com/r/microsoft/dotnet/)). Ten obraz zawiera już zainstalowane dotnet 2.1 SDK. Przyrostek Bionic oznacza, że jako system operacyjny kontenera zostanie użyty Ubuntu 18.04 (kodowa nazwa bionic). Zmieniając przyrostek, można zmienić podstawowy system operacyjny (np.: stretch – Debian 9, alpine – Alpine Linux). W takim przypadku konieczna będzie modyfikacja zawartości pliku Docker (np. zamiana 'apt-get' na 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Aktualizuje bazę dostępnych pakietów i instaluję pakiet apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Instaluje pakiety 'libgdiplus' i 'libc6-dev' wymagane przez bibliotekę System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Deklaruje folder /slides-src jako punkt montowania, który będzie używany do zapewnienia dostępu do folderu źródeł slide-net na maszynie hosta.

``` csharp

 VOLUME /slides-src

```

1. Ustawia slides-src jako katalog roboczy wewnątrz kontenera.

``` csharp

 WORKDIR /slides-src

```

1. Deklaruje domyślne polecenie, które zostanie uruchomione przy starcie kontenera, jeśli nie zostanie podane jawne polecenie.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Zgodnie z instrukcjami w pliku Docker, wynikowy obraz kontenera będzie miał zainstalowane Ubuntu 18.04, dotnet-sdk, pakiety libgdiplus i libc6-dev. Dodatkowo, ten obraz będzie posiadał zdefiniowany punkt montowania oraz domyślne polecenie przy uruchomieniu.

Aby zbudować obraz przy użyciu tego pliku Docker, przejdź do folderu docker w slides-netuil i wykonaj:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- opcja określa, którego pliku Docker użyć.  
*-t ubuntu18_04_apt_get_libgdiplus* -- określa tag (nazwę) dla wynikowego obrazu.  
*'.'* -- określa kontekst dla Dockera. W naszym przypadku kontekstem jest bieżący folder i jest on pusty — ponieważ wybieramy dostarczenie źródeł slides-net jako punkt montowania (pozwala to nie przebudowywać obrazu Dockera przy każdej zmianie źródeł).

Wynik wykonania powinien wyglądać tak:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Aby upewnić się, że nowy obraz został dodany do lokalnego repozytorium obrazów:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Gdy obraz jest gotowy, możemy go uruchomić za pomocą tego polecenia:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- określa, że polecenie ma być uruchomione interaktywnie, umożliwiając podgląd wyjścia i wprowadzanie danych.  
*-v `pwd`/../../:/slides-src* -- określa folder dla zdefiniowanego punktu montowania — ponieważ bieżący katalog roboczy to slides-netuildocker, folder slides-src w kontenerze będzie wskazywał na folder slides-net na hoście. `pwd` służy do określenia ścieżki względnej.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- modyfikuje plik hosts kontenera, aby rozwiązać adres URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* -- określa obraz, z którego uruchamiany jest kontener.

Wynik powyższego polecenia będzie wyjściem skryptu netcore.linux.tests.sh (ponieważ został on zdefiniowany jako domyślne polecenie dla kontenera):

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

Z wyniku wyraźnie wynika, że pliki dzienników z testów Func i Regr zostały umieszczone w katalogu /build-out/netstandard20/test-results/main/. Ponadto, łącznie nie powiodło się około 200 testów — wszystkie dotyczą problemów z renderowaniem spowodowanych brakiem wymaganych czcionek w kontenerze.

Aby nadpisać domyślne polecenie kontenera podczas uruchamiania, możemy użyć tego polecenia:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

W związku z tym zamiast netcore.linux.tests.sh zostanie uruchomiony /bin/bash, który zapewni aktywną sesję terminalową kontenera, z której można uruchomić (./build/netcore.linux.tests.sh). Takie podejście może być przydatne w sytuacjach diagnostycznych.

## **Zainstaluj i skonfiguruj Docker na Linuksie (make install libgdiplus)**
- System operacyjny: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Obecnie Ubuntu zawiera tylko wersję 4.2 libgdiplus, podczas gdy wersja 5.6 jest już dostępna na [oficjalnej stronie produktu](https://github.com/mono/libgdiplus/releases). Aby przetestować najnowszą wersję libgdiplus, musimy przygotować obraz z libgdiplus zbudowanym ze źródeł.

Przejrzyjmy zawartość pliku Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# zbuduj najnowszy stabilny libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# utwórz punkty montowania

VOLUME /slides-src

\# buduj i testuj Aspose.Slides przy starcie

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Jedyną różnicą jest sekcja *build latest stable libgdiplus*. Sekcja ta instaluje wszystkie niezbędne narzędzia do budowy libgdiplus, klonuje źródła, a następnie buduje je i instaluje w odpowiednim miejscu. Wszystko inne jest takie samo jak w [Zainstaluj i skonfiguruj Docker na Linuksie (apt-get libgdiplus)](/slides/pl/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Uwaga**: Nie zapomnij używać różnych tagów (nazw) obrazu dla wynikowego obrazu w poleceniach docker build i docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Zainstaluj i skonfiguruj Docker na Windows Server Core**
- System operacyjny: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Uwaga**: Windows 10 Pro lub Windows Server 2016 jest wymagany do uruchamiania kontenerów Windows.

Niestety, Microsoft nie udostępnia obrazu Windows Server Core z zainstalowanym dotnet SDK, więc musimy go zainstalować ręcznie:

``` csharp

 # escape=

FROM microsoft/dotnet:2.1-sdk-bionic AS build

#ustaw domyślnego wykonawcę powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#ustaw domyślnego wykonawcę powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

#pobierz .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#zwróć cmd jako domyślnego wykonawcę

SHELL ["cmd", "/S", "/C"]

# aby ustawić systemowy PATH, ContainerAdministrator musi być użyty

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

#utwórz punkty montowania

VOLUME c:/slides-src

#buduj i testuj Aspose.Slides przy starcie

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Wynikowy obraz zostanie zbudowany na bazie obrazu microsoft/windowsservercore:1803 udostępnionego przez Microsoft na [docker hub](https://hub.docker.com/u/microsoft). Dotnet-sdk w określonej wersji zostanie pobrany i rozpakowany; zmienna PATH systemu zostanie zaktualizowana, aby zawierać ścieżkę do wykonywalnego pliku dotnet. Ostatnia linia definiuje polecenie, które uruchamia testy func i regr w kontenerze przy użyciu nant.exe jako domyślnej akcji przy uruchamianiu kontenera.

Polecenie budowania obrazu:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Polecenie uruchomienia obrazu:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Uwaga**: Polecenie dla kontenera Windows używa 2 dodatkowych argumentów:

*-cpu-count 3*  
*-memory 8589934592*  

Ustawiają liczbę rdzeni i ilość pamięci dostępnej dla kontenera. Domyślnie dla kontenera Windows dostępny jest tylko 1 rdzeń i 1 GB pamięci RAM (kontenery Linux nie mają domyślnych ograniczeń).

Ponadto brakuje jednego argumentu w porównaniu do polecenia używanego do uruchomienia kontenera Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48* -- ponieważ kontener działający w Windows nie wymaga external.tool.server.

Wynik powyższego polecenia powinien wyglądać tak:

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