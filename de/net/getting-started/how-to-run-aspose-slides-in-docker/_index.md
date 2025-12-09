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
description: "Führen Sie Aspose.Slides in Docker-Containern aus: Konfigurieren Sie Images, Abhängigkeiten, Schriftarten und Lizenzierung, um skalierbare Dienste zu erstellen, die PowerPoint und OpenDocument verarbeiten."
---

## **Unterstützte Betriebssysteme**
Aspose.Slides kann in Docker‑Containern auf der .NET‑Core‑Plattform ausgeführt werden. Im Allgemeinen unterstützt Aspose.Slides alle Container‑ (OS‑)Typen, die die .NET‑Core‑Plattform unterstützt. Allerdings muss GDI oder [libgdiplus](https://github.com/mono/libgdiplus) auf den betroffenen Containern verfügbar und korrekt eingerichtet sein.

Um Docker zu nutzen, müssen Sie es zunächst auf Ihrem System installieren. Wie Docker unter Windows oder macOS installiert wird, erfahren Sie über diese Links:

- [Install Docker on Windows](https://docs.docker.com/docker-for-windows/install/)
- [Install Docker on Mac](https://docs.docker.com/docker-for-mac/install/)

Docker kann auch unter Linux und Windows Server verwendet werden, indem Sie den Anweisungen auf den folgenden Seiten folgen:

- [Install and configure Docker on Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Install and configure Docker on Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Install and configure Docker on Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Die Installation und Konfiguration von Docker auf Windows Server Nano wird nicht unterstützt. Windows Server Nano enthält das Grafik‑Subsystem nicht, es fehlt die gdiplus.dll, die von der System.Drawing.Common‑Bibliothek benötigt wird, sodass die Aspose.Slides‑Bibliothek dort nicht verwendet werden kann.

Obwohl Linux‑Container unter Windows ausgeführt werden können, empfehlen wir, sie nativ auf Linux zu betreiben (auch auf einer manuell in einer VM über VirtualBox installierten Linux‑Instanz).

## **Installation und Konfiguration von Docker unter Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Diese Docker‑Datei enthält Anweisungen zum Erstellen eines Container‑Images mit dem libgdiplus‑Paket, das aus den offiziellen Ubuntu‑Paketquellen installiert wird.

Hier ist der Inhalt der Docker‑Datei:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus installieren

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# Einhängepunkte erstellen

VOLUME /slides-src

\# Aspose.Slides beim Start bauen und testen

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Nachfolgend wird jede Zeile der Docker‑Datei erklärt:

1. Das Container‑Image basiert auf dem microsoft/dotnet:2.1-sdk-bionic‑Image (das bereits von Microsoft gebaut und im Docker‑[public hub](https://hub.docker.com/r/microsoft/dotnet/) veröffentlicht wurde). Dieses Image enthält das bereits installierte dotnet 2.1 SDK. Das Suffix *bionic* bedeutet, dass Ubuntu 18.04 (Codename *bionic*) als OS des Containers verwendet wird. Durch Ändern des Suffixes kann das zugrundeliegende OS gewechselt werden (z. B.: *stretch* – Debian 9, *alpine* – Alpine Linux). In diesem Fall muss der Inhalt der Docker‑Datei angepasst werden (z. B. 'apt-get' zu 'yum' ändern).
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```


1. Aktualisiert die Paketdatenbank und installiert das Paket apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. Installiert die Pakete 'libgdiplus' und 'libc6-dev', die von der System.Drawing.Common‑Bibliothek benötigt werden.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. Deklariert den Ordner /slides-src als Einhängepunkt, den wir verwenden, um Zugriff auf den slide‑net‑Quellordner des Host‑Rechners zu ermöglichen.
``` csharp

 VOLUME /slides-src

```


1. Setzt slides‑src als Arbeitsverzeichnis im Container.
``` csharp

 WORKDIR /slides-src

```


1. Legt einen Standardbefehl fest, der beim Start des Containers ausgeführt wird, falls kein expliziter Befehl angegeben ist.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Gemäß den Anweisungen in der Docker‑Datei enthält das resultierende Container‑Image Ubuntu 18.04, das dotnet‑SDK, libgdiplus und libc6‑dev bereits installiert. Zudem ist ein vordefinierter Einhängepunkt und ein Standardbefehl beim Ausführen vorhanden.

Um ein Image mit dieser Docker‑Datei zu bauen, wechseln Sie in das slides‑netuil‑Docker‑Verzeichnis und führen Sie aus:
``` csharp
 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .
```


*‑f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* – Option, die anzugeben, welche Docker‑Datei verwendet werden soll.  
*‑t ubuntu18_04_apt_get_libgdiplus* – gibt das Tag (den Namen) des resultierenden Images an.  
*'.'* – gibt den Kontext für Docker an. In unserem Fall ist der Kontext das aktuelle Verzeichnis und ist leer – da wir die slide‑net‑Quellen als Einhängepunkt bereitstellen (dadurch muss das Docker‑Image nicht bei jeder Quelländerung neu gebaut werden).

Das Ergebnis der Ausführung sollte folgendermaßen aussehen:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


Um zu prüfen, ob das neue Image zum lokalen Image‑Repository hinzugefügt wurde:
``` csharp

 $ docker images

\----
REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


Nachdem das Image bereitsteht, können Sie es mit folgendem Befehl starten:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*‑it* – führt den Befehl interaktiv aus, sodass Ausgabe und Eingabe sichtbar sind.  
*‑v `pwd`/../../:/slides-src* – gibt den Ordner für den vordefinierten Einhängepunkt an – da das aktuelle Arbeitsverzeichnis slides‑netuildocker ist, zeigt der /slides‑src‑Ordner im Container auf den slides‑net‑Ordner des Hosts. `pwd` liefert den relativen Pfad.  
*--add-host dev.slides.external.tool.server:192.168.1.48* – modifiziert die hosts‑Datei des Containers, um die URL dev.slides.external.tool.server aufzulösen.  
*ubuntu1804aptgetlibgdiplus:latest* – gibt das zu startende Image an.

Das Ergebnis dieses Befehls ist die Ausgabe von netcore.linux.tests.sh (da dieser als Standardbefehl für den Container definiert ist):
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


Aus der Ausgabe geht hervor, dass Log‑Dateien der Func‑ und Regr‑Tests in das Verzeichnis /build-out/netstandard20/test-results/main/ geschrieben wurden. Außerdem sind insgesamt etwa 200 Tests fehlgeschlagen – alles Rendering‑Probleme, die durch fehlende Schriftarten im Container verursacht werden.

Um den Standardbefehl des Containers bei einem Lauf zu überschreiben, kann folgender Befehl verwendet werden:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Damit wird statt netcore.linux.tests.sh /bin/bash ausgeführt und Sie erhalten eine interaktive Terminalsitzung im Container, von der aus Sie ./build/netcore.linux.tests.sh starten können. Dieses Vorgehen kann bei Fehlersuchen hilfreich sein.

## **Installation und Konfiguration von Docker unter Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Derzeit enthalten die Ubuntu‑Pakete nur libgdiplus 4.2, während libgdiplus 5.6 bereits auf der [offiziellen Projekt‑Seite](https://github.com/mono/libgdiplus/releases) verfügbar ist. Um die neueste Version zu testen, müssen wir ein Image erstellen, in dem libgdiplus aus den Quellen gebaut wird.

Der Inhalt der Docker‑Datei lautet:
``` csharp
 FROM microsoft/dotnet:2.1-sdk-bionic AS build
\# baue neueste stabile libgdiplus
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
\# baue und teste Aspose.Slides beim Start
WORKDIR /slides-src
CMD ./build/netcore.linux.tests.sh
```


Der einzige Unterschied ist der Abschnitt *build latest stable libgdiplus*. Dieser Abschnitt installiert alle Werkzeuge, die zum Bauen von libgdiplus nötig sind, klont die Quellen, baut sie und installiert sie am richtigen Ort. Alles andere entspricht [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/de/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Hinweis**: Verwenden Sie unterschiedliche Image‑Tags (Namen) für das resultierende Image bei den Befehlen `docker build` und `docker run`:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Installation und Konfiguration von Docker auf Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Hinweis**: Windows 10 Pro oder Windows Server 2016 ist erforderlich, um Windows‑Container auszuführen.

Microsoft bietet kein Windows‑Server‑Core‑Image mit vorinstalliertem dotnet‑SDK an, daher muss es manuell installiert werden:
``` csharp
# escape=
FROM microsoft/windowsservercore:1803 AS installer-env

#setze powershell Standardausführer
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=
FROM microsoft/windowsservercore:1803 AS installer-env

#setze powershell Standardausführer
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# .NET Core SDK abrufen
ENV DOTNET_SDK_VERSION 2.1.301
ENV DOTNET_PATH "c:/Program Files/dotnet"
RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
# cmd als Standardausführer zurückgeben
SHELL ["cmd", "/S", "/C"]
# Um den System-PATH zu setzen, muss ContainerAdministrator verwendet werden
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
# erstelle Einhängepunkte
VOLUME c:/slides-src
# baue und teste Aspose.Slides beim Start
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


Das resultierende Image wird auf dem microsoft/windowsservercore:1803‑Image von Microsoft im [Docker‑Hub](https://hub.docker.com/r/microsoft/windowsservercore/) aufgebaut. Das dotnet‑SDK der angegebenen Version wird heruntergeladen und entpackt; die PATH‑Variable des Systems wird angepasst, sodass der Pfad zur dotnet‑Ausführungsdatei enthalten ist. Die letzte Zeile definiert den Befehl, der beim Start des Containers func‑ und regr‑Tests über nant.exe ausführt.

Befehl zum Erstellen des Images:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Befehl zum Ausführen des Images:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Hinweis**: Der Befehl für den Windows‑Container verwendet zwei zusätzliche Parameter:

*-cpu-count 3*  
*-memory 8589934592*

Sie legen die Anzahl der Kerne und den verfügbaren Arbeitsspeicher für den Container fest. Standardmäßig stehen nur 1 Kern und 1 GB RAM zur Verfügung (Linux‑Container besitzen standardmäßig keine Beschränkungen).

Ein weiterer Parameter fehlt im Vergleich zum Linux‑Befehl:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Da ein Windows‑Container diesen externen Host nicht benötigt, wird er weggelassen.

Das Ergebnis des obigen Befehls sollte folgendermaßen aussehen:
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
