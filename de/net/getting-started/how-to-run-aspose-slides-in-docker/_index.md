---
title: Wie man Aspose.Slides in Docker ausführt
linktitle: Aspose.Slides in Docker
type: docs
weight: 140
url: /de/net/how-to-run-aspose-slides-in-docker/
keywords:
- unterstützte Betriebssysteme
- Aspose.Slides in Docker
- Docker-Container
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- Image-Repository
- Windows Server Core
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Ausführen von Aspose.Slides in Docker‑Containern: Konfigurieren von Images, Abhängigkeiten, Schriftarten und Lizenzierung, um skalierbare Services zu erstellen, die PowerPoint‑ und OpenDocument‑Dateien verarbeiten."
---

## **Unterstützte Betriebssysteme**
Aspose.Slides kann in Docker‑Containern auf der .NET Core‑Plattform ausgeführt werden. Im Allgemeinen unterstützt Aspose.Slides alle Container‑ (Betriebssystem‑)Typen, die von der .NET Core‑Plattform unterstützt werden. Allerdings muss GDI oder [libgdiplus](https://github.com/mono/libgdiplus) in den Containern verfügbar und korrekt eingerichtet sein.

Um Docker zu verwenden, müssen Sie es zunächst auf Ihrem System installieren. Anleitungen zur Installation von Docker unter Windows oder macOS finden Sie über die folgenden Links:

- [Docker unter Windows installieren](https://docs.docker.com/docker-for-windows/install/)
- [Docker unter macOS installieren](https://docs.docker.com/docker-for-mac/install/)

Docker kann auch unter Linux und Windows Server ausgeführt werden; folgen Sie dazu den Anweisungen auf diesen Seiten:

- [Docker unter Linux installieren und konfigurieren (apt‑get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Docker unter Linux installieren und konfigurieren (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Docker unter Windows Server Core installieren und konfigurieren](#install-and-configure-docker-on-windows-server-core)

Die Installation und Konfiguration von Docker auf Windows Server Nano wird nicht unterstützt. Windows Server Nano enthält das Grafik‑Subsystem nicht. Es fehlt die gdiplus.dll, die die System.Drawing.Common‑Bibliothek benötigt, sodass die Aspose.Slides‑Bibliothek dort nicht verwendet werden kann.

Obwohl Linux‑Container unter Windows ausgeführt werden können, empfehlen wir, sie nativ auf Linux zu betreiben (auch wenn Linux manuell in einer VM mit VirtualBox installiert ist).

## **Docker unter Linux installieren und konfigurieren (apt‑get libgdiplus)**
- Betriebssystem: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Dieses Dockerfile enthält Anweisungen zum Erstellen eines Container‑Images mit dem libgdiplus‑Paket, das aus den offiziellen Ubuntu‑Paketquellen installiert wird.

Hier ist der Inhalt des Dockerfiles:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus installieren

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# Mount-Punkte erstellen

VOLUME /slides-src

\# Aspose.Slides beim Start bauen und testen

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Nachfolgend wird jede Zeile des Dockerfiles erklärt:

1. Das Container‑Image basiert auf dem Image **microsoft/dotnet:2.1-sdk-bionic** (das bereits von Microsoft gebaut und im Docker‑[Public Hub](https://hub.docker.com/r/microsoft/dotnet/) veröffentlicht wurde). Dieses Image enthält das bereits installierte .NET 2.1‑SDK. Das Suffix *bionic* bedeutet, dass Ubuntu 18.04 (Codename *bionic*) als Betriebssystem des Containers verwendet wird. Durch Ändern des Suffixes kann das zugrundeliegende Betriebssystem gewechselt werden (z. B. *stretch* – Debian 9, *alpine* – Alpine Linux). In diesem Fall müssten die Inhalte des Dockerfiles angepasst werden (z. B. *apt‑get* zu *yum* ändern).
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. Aktualisiert die Datenbank verfügbarer Pakete und installiert das Paket **apt-utils**.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. Installiert die Pakete **libgdiplus** und **libc6-dev**, die von der System.Drawing.Common‑Bibliothek benötigt werden.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. Deklariert den Ordner **/slides‑src** als Mount‑Punkt, über den auf den Quellordner *slide‑net* des Host‑Systems zugegriffen wird.
``` csharp

 VOLUME /slides-src

```


1. Setzt **/slides‑src** als Arbeitsverzeichnis im Container.
``` csharp

 WORKDIR /slides-src

```


1. Definiert einen Standardbefehl, der beim Start des Containers ausgeführt wird, falls kein expliziter Befehl angegeben ist.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Gemäß den Anweisungen im Dockerfile enthält das resultierende Container‑Image Ubuntu 18.04, das .NET‑SDK, libgdiplus und libc6‑dev bereits installiert. Zusätzlich verfügt das Image über einen vordefinierten Mount‑Punkt und einen vordefinierten Standardbefehl.

Um ein Image mit diesem Dockerfile zu bauen, navigieren Sie zum Ordner *slides‑netuil/docker* und führen Sie aus:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* – gibt an, welches Dockerfile verwendet werden soll.  
*-t ubuntu18_04_apt_get_libgdiplus* – legt den Tag (Namen) für das resultierende Image fest.  
*'.'* – definiert den Build‑Kontext für Docker. In unserem Fall ist der Kontext das aktuelle Verzeichnis; das ist leer, weil wir die *slides‑net*‑Quellen als Mount‑Punkt bereitstellen (so muss das Docker‑Image bei Änderungen am Quellcode nicht neu gebaut werden).

Das Ergebnis des Builds sollte etwa so aussehen:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


Um zu prüfen, ob das neue Image im lokalen Repository gespeichert wurde:
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


Sobald das Image fertig ist, können Sie es mit folgendem Befehl starten:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* – führt den Befehl interaktiv aus, sodass Ausgabe und Eingabe sichtbar sind.  
*-v `pwd`/../../:/slides‑src* – gibt den Ordner für den vordefinierten Mount‑Punkt an; das aktuelle Arbeitsverzeichnis ist *slides‑netuil/docker*, sodass */slides‑src* im Container auf den *slides‑net*‑Ordner des Hosts zeigt. `pwd` liefert den relativen Pfad.  
*--add-host dev.slides.external.tool.server:192.168.1.48* – passt die *hosts*-Datei des Containers an, um die angegebene URL aufzulösen.  
*ubuntu1804aptgetlibgdiplus:latest* – gibt das zu startende Image an.

Die Ausgabe dieses Befehls ist das Ergebnis von **netcore.linux.tests.sh** (der als Standardbefehl im Container definiert ist):
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


Aus der Ausgabe geht hervor, dass Log‑Dateien der Func‑ und Regr‑Tests in das Verzeichnis */build‑out/netstandard20/test‑results/main/* geschrieben wurden. Insgesamt sind etwa 200 Tests fehlgeschlagen – alles Rendering‑Probleme, die auf fehlende Schriftarten im Container zurückzuführen sind.

Um den Standardbefehl des Containers beim Ausführen zu überschreiben, kann folgender Befehl verwendet werden:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Damit wird statt **netcore.linux.tests.sh** die Shell **/bin/bash** gestartet, wodurch ein interaktives Terminal im Container erhalten bleibt (z. B. zum manuellen Ausführen von *./build/netcore.linux.tests.sh*). Diese Vorgehensweise ist für Fehlersuche‑Szenarien nützlich.

## **Docker unter Linux installieren und konfigurieren (make install libgdiplus)**
- Betriebssystem: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Derzeit enthält Ubuntu nur Version 4.2 von libgdiplus, während Version 5.6 bereits auf der [offiziellen Seite](https://github.com/mono/libgdiplus/releases) verfügbar ist. Um die neueste Version zu testen, müssen wir ein Image erstellen, in dem libgdiplus aus den Quellen gebaut wird.

Im Folgenden der Inhalt des Dockerfiles:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# erstelle neueste stabile libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# erstelle Einhängepunkte

VOLUME /slides-src

\# erstelle und teste Aspose.Slides beim Start

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Der einzige Unterschied ist der Abschnitt **build latest stable libgdiplus**. Dort werden alle Werkzeuge installiert, die zum Bau von libgdiplus nötig sind, die Quellen geklont, gebaut und an die richtige Stelle installiert. Ansonsten ist das Dockerfile identisch zu [Docker unter Linux installieren und konfigurieren (apt‑get libgdiplus)](/slides/de/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Hinweis**: Verwenden Sie für das resultierende Image bei den Befehlen *docker build* und *docker run* unterschiedliche Image‑Tags (Namen):
``` csharp
 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .
$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest
```


## **Docker auf Windows Server Core installieren und konfigurieren**
- Betriebssystem: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Hinweis**: Windows 10 Pro oder Windows Server 2016 werden benötigt, um Windows‑Container auszuführen.

Microsoft stellt kein Windows Server Core‑Image mit installiertem .NET‑SDK bereit, daher muss das SDK manuell installiert werden:
``` csharp

 # escape=
FROM microsoft/windowsservercore:1803 AS installer-env
# set powershell default executor
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# escape=
FROM microsoft/windowsservercore:1803 AS installer-env
# set powershell default executor
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# .NET Core SDK abrufen
ENV DOTNET_SDK_VERSION 2.1.301
ENV DOTNET_PATH "c:/Program Files/dotnet"
RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
# cmd als Standard-Executor zurückgeben
SHELL ["cmd", "/S", "/C"]
\# Um den System-PATH zu setzen, muss ContainerAdministrator verwendet werden
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
\# Mount-Punkte erstellen
VOLUME c:/slides-src
# Aspose.Slides beim Start bauen und testen
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


Das resultierende Image wird auf dem **microsoft/windowsservercore:1803**‑Image aufgebaut, das von Microsoft im [Docker Hub](https://hub.docker.com/u/microsoft) bereitgestellt wird. Das .NET‑SDK der angegebenen Version wird heruntergeladen und entpackt; die System‑PATH‑Variable wird um den Pfad zur *dotnet*-Exe erweitert. Die letzte Zeile definiert den Befehl, der beim Start des Containers die Func‑ und Regr‑Tests über *nant.exe* ausführt.

Befehl zum Erzeugen des Images:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Befehl zum Ausführen des Images:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Hinweis**: Der Befehl für Windows‑Container verwendet zwei zusätzliche Parameter:

*-cpu-count 3*  
*-memory 8589934592*

Sie setzen die Anzahl der Kerne und den verfügbaren Arbeitsspeicher des Containers. Standardmäßig stehen nur 1 Kern und 1 GB RAM zur Verfügung (Linux‑Container haben standardmäßig keine Beschränkungen).

Ein weiterer Parameter fehlt im Vergleich zum Linux‑Befehl:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Da ein Windows‑Container diesen Host nicht benötigt, wird das Argument weggelassen.

Die Ausgabe des oben genannten Befehls sollte etwa so aussehen:
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
