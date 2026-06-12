---
title: Come eseguire Aspose.Slides in Docker
linktitle: Aspose.Slides in Docker
type: docs
weight: 140
url: /it/net/how-to-run-aspose-slides-in-docker/
keywords:
- OS supportati
- Aspose.Slides in Docker
- contenitore Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- repository di immagini
- Windows Server Core
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esegui Aspose.Slides in contenitori Docker: configura immagini, dipendenze, caratteri e licenze per creare servizi scalabili che elaborano PowerPoint e OpenDocument."
---
## **Sistemi Operativi supportati**
Aspose.Slides può essere eseguito all'interno di contenitori Docker usando la piattaforma .NET Core. In gener­ale, Aspose.Slides supporta tutti i tipi di contenitori (OS) supportati dalla piattaforma .NET Core. Tuttavia, il GDI o [libgdiplus](https://github.com/mono/libgdiplus) devono essere disponibili e correttamente configurati nei contenitori coinvolti.

Per utilizzare Docker, devi prima installarlo sul tuo sistema. Per apprendere come installare Docker su Windows o Mac, usa questi collegamenti:

- [Installa Docker su Windows](https://docs.docker.com/docker-for-windows/install/)
- [Installa Docker su Mac](https://docs.docker.com/docker-for-mac/install/)

Puoi anche eseguire Docker su Linux e Windows Server seguendo le istruzioni su queste pagine:

- [Installa e configura Docker su Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Installa e configura Docker su Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Installa e configura Docker su Windows Server Core](#install-and-configure-docker-on-windows-server-core)

L'installazione e la configurazione di Docker su Windows Server Nano non è supportata. Sfortunatamente, Windows Server Nano non contiene il sottosistema grafico. Non contiene gdiplus.dll, che la libreria System.Drawing.Common richiede, e non può essere utilizzato con la libreria Aspose.Slides.

Sebbene sia possibile eseguire contenitori Linux in Windows, ti consigliamo di eseguirli nativamente su Linux (anche su un Linux installato manualmente su una VM usando VirtualBox).

## **Installa e configura Docker su Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Questo file Docker contiene le istruzioni per costruire un'immagine di contenitore con il pacchetto libgdiplus installato dai repository ufficiali di Ubuntu.

Ecco il contenuto del file Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# installare libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# creare punti di montaggio

VOLUME /slides-src

\# compilare e testare Aspose.Slides all'avvio

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Esaminiamo il significato di ogni riga di codice nel file Docker:

1. L'immagine del contenitore si basa sull'immagine microsoft/dotnet:2.1-sdk-bionic (immagine già creata da Microsoft e pubblicata sul [public hub](https://hub.docker.com/r/microsoft/dotnet/) di Docker). Questa immagine contiene già installato il SDK dotnet 2.1. Il suffisso Bionic indica che Ubuntu 18.04 (nome in codice bionic) sarà preso come OS del contenitore. Cambiando il suffisso è possibile cambiare l'OS sottostante (ad esempio: stretch -- Debian 9, alpine -- Alpine Linux). In tal caso sarà necessaria una modifica al contenuto del file Docker (ad esempio, cambiare 'apt-get' in 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Aggiorna il database dei pacchetti disponibili e installa il pacchetto apt‑utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Installa i pacchetti 'libgdiplus' e 'libc6-dev' richiesti dalla libreria System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Dichiara la cartella /slides-src come punto di montaggio che sarà usato per fornire l'accesso alla cartella sorgente slide-net sulla macchina host.

``` csharp

 VOLUME /slides-src

```

1. Imposta slides-src come directory di lavoro all'interno del contenitore.

``` csharp

 WORKDIR /slides-src

```

1. Dichiara un comando predefinito che verrà eseguito all'avvio del contenitore nel caso in cui non sia specificato un comando esplicito.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Secondo le istruzioni nel file Docker, l'immagine risultante del contenitore avrà già installati Ubuntu 18.04 OS, dotnet‑sdk, libgdiplus e i pacchetti libc6‑dev. Inoltre, quest'immagine avrà un punto di montaggio predefinito e un comando predefinito all'esecuzione.

Per costruire un'immagine usando questo file Docker, devi andare nella cartella slides‑netuil docker e eseguire:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- l'opzione specifica quale file Docker usare.

*-t ubuntu18_04_apt_get_libgdiplus* -- specifica il tag (nome) per l'immagine risultante.

*'.'* -- specifica il contesto per Docker. Nel nostro caso, il contesto è la cartella corrente ed è vuoto, poiché scegliamo di fornire le sorgenti slides‑net come punto di montaggio (ciò ci permette di non ricostruire l'immagine Docker ad ogni modifica delle sorgenti).

Il risultato dell'esecuzione dovrebbe apparire così:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Per assicurarsi che la nuova immagine sia stata aggiunta al repository locale delle immagini:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Una volta pronta l'immagine, possiamo eseguirla con questo comando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- specifica che il comando deve essere eseguito in modalità interattiva, consentendo di vedere l'output e catturare l'input.

*-v `pwd`/../../:/slides-src* -- specifica la cartella per il punto di montaggio predefinito — poiché la directory di lavoro corrente è slides‑netuildocker, la cartella slides‑src nel contenitore punterà alla cartella slides‑net sull'host. `pwd` è usato per specificare il percorso relativo.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- modifica il file hosts del contenitore per risolvere l'URL dev.slides.external.tool.server.

*ubuntu1804aptgetlibgdiplus:latest* -- specifica l'immagine da utilizzare per eseguire il contenitore.

Il risultato del comando sopra sarà l'output di netcore.linux.tests.sh (poiché è stato definito come comando predefinito per il contenitore):

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

Dal risultato è chiaro che i file di log dei test Func e Regr sono stati posizionati nella directory /build-out/netstandard20/test-results/main/. Inoltre, circa 200 test sono falliti in totale — tutti questi sono problemi di rendering relativi all'assenza dei font richiesti nel contenitore.

Per sovrascrivere il comando predefinito del contenitore durante un'esecuzione, possiamo usare questo comando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Quindi, invece di netcore.linux.tests.sh, verrà eseguito /bin/bash e fornirà una sessione terminale attiva del contenitore da cui potrà essere eseguito (./build/netcore.linux.tests.sh). Questo approccio può essere utile in scenari di troubleshooting.

## **Installa e configura Docker su Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Al momento, Ubuntu contiene solo la versione 4.2 di libgdiplus mentre la versione 5.6 è già disponibile sul [sito ufficiale](https://github.com/mono/libgdiplus/releases) del prodotto. Per testare l'ultima versione di libgdiplus, è necessario preparare un'immagine con libgdiplus compilato dalle sorgenti.

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# costruire l'ultima versione stabile di libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# creare punti di montaggio

VOLUME /slides-src

\# compilare e testare Aspose.Slides all'avvio

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

L'unica differenza è la sezione *build latest stable libgdiplus*. Questa sezione installa tutti gli strumenti necessari per compilare libgdiplus, clona le sorgenti, quindi li compila e li installa nella posizione corretta. Tutto il resto è uguale a [Installa e configura Docker su Linux (apt-get libgdiplus)](/slides/it/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Nota**: Non dimenticare di usare tag immagine diversi (nome) per l'immagine risultante nei comandi docker build e docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Installa e configura Docker su Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Nota**: Windows 10 Pro o Windows Server 2016 sono richiesti per eseguire contenitori Windows.

Sfortunatamente, Microsoft non fornisce un'immagine Windows Server Core con il SDK dotnet installato, quindi dobbiamo installarlo manualmente:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Recupera .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 
    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#ritorna cmd come esecutore predefinito

SHELL ["cmd", "/S", "/C"]

\# Per impostare il PATH di sistema, è necessario usare ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# creare punti di montaggio

VOLUME c:/slides-src

#compilare e testare Aspose.Slides all'avvio

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

L'immagine risultante sarà costruita sull'immagine microsoft/windowsservercore:1803 fornita da Microsoft su [docker hub](https://hub.docker.com/u/microsoft). Il dotnet‑sdk della versione specificata verrà scaricato e decompresso; la variabile d'ambiente PATH del sistema sarà aggiornata per contenere il percorso dell'eseguibile dotnet. L'ultima riga definisce il comando che esegue i test func & regr sul contenitore usando nant.exe come azione predefinita all'esecuzione del contenitore.

Command to build the image:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Command to run the image:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Nota**: Il comando per il contenitore Windows utilizza 2 argomenti extra:

*-cpu-count 3*  
*-memory 8589934592*

Impostano il numero di core e la quantità di memoria disponibile per il contenitore. Per impostazione predefinita, solo 1 core e 1 GB di RAM sono disponibili per il contenitore Windows (i contenitori Linux non hanno limitazioni di default).

Inoltre, manca 1 argomento rispetto allo stesso comando usato per eseguire il contenitore Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Poiché il contenitore in esecuzione su Windows non richiede external.tool.server.

Il risultato del comando sopra dovrebbe apparire così:

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