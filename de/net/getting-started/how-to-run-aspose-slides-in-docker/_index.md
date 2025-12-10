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
description: "Führen Sie Aspose.Slides in Docker-Containern aus: Konfigurieren Sie Images, Abhängigkeiten, Schriften und Lizenzen, um skalierbare Dienste zu erstellen, die PowerPoint- und OpenDocument-Dateien verarbeiten."
---

## **Unterstützte Betriebssysteme**
Aspose.Slides kann in Docker‑Containern mit der .NET‑Core‑Plattform ausgeführt werden. Im Allgemeinen unterstützt Aspose.Slides alle Containertypen (OS), die die .NET‑Core‑Plattform unterstützt. Allerdings muss GDI oder [libgdiplus ](https://github.com/mono/libgdiplus) im Container verfügbar und korrekt eingerichtet sein.

Um Docker zu benutzen, müssen Sie es zuerst auf Ihrem System installieren. Um zu erfahren, wie Docker auf Windows oder Mac installiert wird, verwenden Sie diese Links:

- [Docker auf Windows installieren](https://docs.docker.com/docker-for-windows/install/)
- [Docker auf Mac installieren](https://docs.docker.com/docker-for-mac/install/)

Sie können Docker auch unter Linux und Windows Server ausführen, indem Sie den Anweisungen auf diesen Seiten folgen:

- [Install and configure Docker on Linux (apt-get libgdiplus) ](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Install and configure Docker on Linux (make install libgdiplus)   ](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Install and configure Docker on Windows Server Core ](#install-and-configure-docker-on-windows-server-core)

Installation und Konfiguration von Docker auf Windows Server Nano wird nicht unterstützt. Leider enthält Windows Server Nano kein grafisches Subsystem. Es enthält nicht die gdiplus.dll, die von der System.Drawing.Common‑Bibliothek benötigt wird, und kann nicht mit der Aspose.Slides‑Bibliothek verwendet werden.

Obwohl es möglich ist, Linux‑Container unter Windows auszuführen, empfehlen wir, sie nativ unter Linux zu betreiben (auch auf einem manuell in einer VM mit VirtualBox installierten Linux).

## **Installieren und Konfigurieren von Docker unter Linux (apt-get libgdiplus)**
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


Lassen Sie uns prüfen, was jede Codezeile in der Docker‑Datei bedeutet:

1. Das Image des Containers basiert auf dem microsoft/dotnet:2.1-sdk-bionic‑Image (das bereits von Microsoft gebaut und im Docker‑[public hub](https://hub.docker.com/r/microsoft/dotnet/) veröffentlicht wurde). Dieses Image enthält das bereits installierte dotnet‑2.1‑SDK. Der Suffix „bionic“ bedeutet, dass Ubuntu 18.04 (Codename bionic) als Betriebssystem des Containers verwendet wird. Durch Ändern des Suffixes kann das zugrunde liegende OS gewechselt werden (z. B.: stretch – Debian 9, alpine – Alpine Linux). In diesem Fall muss der Inhalt der Docker‑Datei angepasst werden (z. B. Änderung von 'apt-get' zu 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


2. Aktualisiert die Datenbank verfügbarer Pakete und installiert das Paket apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


3. Installiert die Pakete 'libgdiplus' und 'libc6-dev', die von der System.Drawing.Common‑Bibliothek benötigt werden.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


4. Deklariert den Ordner /slides-src als Einhängepunkt, über den wir Zugriff auf den slide-net-Quellordner des Host-Computers bereitstellen.
``` csharp

 VOLUME /slides-src

```


5. Setzt slides-src als Arbeitsverzeichnis innerhalb des Containers.
``` csharp

 WORKDIR /slides-src

```


6. Deklariert einen Standardbefehl, der beim Start des Containers ausgeführt wird, falls kein expliziter Befehl angegeben wurde.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Gemäß den Anweisungen in der Docker‑Datei wird das resultierende Container‑Image Ubuntu 18.04, das dotnet‑SDK, libgdiplus und libc6-dev bereits installiert haben. Außerdem wird es einen vordefinierten Einhängepunkt und einen vordefinierten Befehl beim Ausführen besitzen.

Um ein Image mit dieser Docker‑Datei zu bauen, wechseln Sie in den Ordner *slides-netuil* docker und führen Sie aus:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- Option gibt an, welche Docker‑Datei verwendet werden soll.  
*-t ubuntu18_04_apt_get_libgdiplus* -- Gibt den Tag (Namen) für das resultierende Image an.  
*'.'* -- Gibt den Kontext für Docker an. In unserem Fall ist der Kontext das aktuelle Verzeichnis und es ist leer – weil wir die slide‑net‑Quellen als Einhängepunkt bereitstellen (so müssen wir das Docker‑Image bei jeder Quelländerung nicht neu bauen).

Das Ergebnis der Ausführung sollte etwa so aussehen:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


Um sicherzustellen, dass das neue Image zum lokalen Image‑Repository hinzugefügt wurde:
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


Sobald das Image fertig ist, können wir es mit folgendem Befehl starten:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* -- Gibt an, dass der Befehl interaktiv ausgeführt werden soll, damit wir die Ausgabe sehen und Eingaben erfassen können.  
*-v `pwd`/../../:/slides-src* -- Gibt den Ordner für den vordefinierten Einhängepunkt an – da das aktuelle Arbeitsverzeichnis *slides-netuildocker* ist, wird der Ordner *slides-src* im Container auf den *slides-net*‑Ordner des Hosts zeigen. `pwd` wird verwendet, um den relativen Pfad anzugeben.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- Ändert die *hosts*-Datei des Containers, um die URL *dev.slides.external.tool.server* aufzulösen.  
*ubuntu1804aptgetlibgdiplus:latest* -- Gibt das Image an, das als Container gestartet werden soll.

Das Ergebnis des obigen Befehls ist die Ausgabe von *netcore.linux.tests.sh* (da dieser als Standardbefehl für den Container definiert wurde):
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


Aus dem Ergebnis wird deutlich, dass Log‑Dateien von Func‑ und Regr‑Tests nach */build-out/netstandard20/test-results/main/* geschrieben wurden. Außerdem sind etwa 200 Tests insgesamt fehlgeschlagen – alles Rendering‑Probleme, bedingt durch fehlende Schriftarten im Container.

Um den Standardbefehl des Containers beim Ausführen zu überschreiben, können wir folgenden Befehl nutzen:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Damit wird statt *netcore.linux.tests.sh* die * /bin/bash* ausgeführt, wodurch eine aktive Terminalsitzung des Containers bereitgestellt wird, von der aus *./build/netcore.linux.tests.sh* gestartet werden kann. Dieser Ansatz kann bei Fehlersuche‑Szenarien hilfreich sein.

## **Installieren und Konfigurieren von Docker unter Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Derzeit enthält Ubuntu nur Version 4.2 von libgdiplus, während Version 5.6 bereits auf der [offiziellen Seite](https://github.com/mono/libgdiplus/releases) des Produkts verfügbar ist. Um die neueste Version von libgdiplus zu testen, müssen wir ein Image vorbereiten, bei dem libgdiplus aus den Quellen gebaut wird.

Hier ist der Inhalt der Docker‑Datei:
``` csharp
 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# baue aktuelle stabile libgdiplus

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


Der einzige Unterschied ist der Abschnitt *build latest stable libgdiplus*. Dieser Abschnitt installiert alle notwendigen Werkzeuge zum Bauen von libgdiplus, klont die Quellen, baut sie und installiert sie am richtigen Ort. Alles andere ist identisch zu [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/de/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Hinweis**: Verwenden Sie unterschiedliche Image‑Tags (Namen) für das resultierende Image bei den Befehlen *docker build* und *docker run*:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Installieren und Konfigurieren von Docker auf Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Hinweis**: Windows 10 Pro oder Windows Server 2016 ist erforderlich, um Windows‑Container auszuführen.

Leider stellt Microsoft kein Windows‑Server‑Core‑Image mit vorinstalliertem dotnet‑SDK bereit, sodass wir es manuell installieren müssen:
``` csharp

 # escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#setze Standard-Executor für PowerShell
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#setze Standard-Executor für PowerShell
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# Lade .NET Core SDK herunter
ENV DOTNET_SDK_VERSION 2.1.301
ENV DOTNET_PATH "c:/Program Files/dotnet"
RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
#setze cmd als Standard-Executor
SHELL ["cmd", "/S", "/C"]
\# Um den System-PATH zu setzen, muss ContainerAdministrator verwendet werden
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
\# erstelle Einhängepunkte
VOLUME c:/slides-src
#baue und teste Aspify.Slides beim Start
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


Das resultierende Image wird über das *microsoft/windowsservercore:1803*‑Image aus dem Docker‑Hub von Microsoft gebaut. Das dotnet‑SDK der angegebenen Version wird heruntergeladen und entpackt; die System‑PATH‑Variable wird aktualisiert, sodass der Pfad zur dotnet‑Ausführungsdatei enthalten ist. Die letzte Zeile definiert den Befehl, der die Func‑ & Regr‑Tests im Container mit *nant.exe* als Standardaktion ausführt.

Befehl zum Bauen des Images:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Befehl zum Ausführen des Images:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Hinweis**: Der Befehl für den Windows‑Container verwendet zwei zusätzliche Argumente:

*-cpu-count 3*  
*-memory 8589934592*

Sie setzen die Anzahl der Kerne und den verfügbaren Arbeitsspeicher für den Container. Standardmäßig stehen Windows‑Containern nur 1 Kern und 1 GB RAM zur Verfügung (Linux‑Container haben standardmäßig keine Beschränkungen).

Außerdem fehlt ein Argument im Vergleich zum Befehl für den Linux‑Container:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Weil ein Container unter Windows diesen externen Host nicht benötigt.

Das Ergebnis des obenstehenden Befehls sollte etwa so aussehen:
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
