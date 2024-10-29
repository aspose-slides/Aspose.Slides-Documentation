---
title: So führen Sie Aspose.Slides in Docker aus
type: docs
weight: 140
url: /de/net/how-to-run-aspose-slides-in-docker/
keywords: "Aspose.Slides in Docker-Container ausführen, Aspose Docker, Aspose.Slides in einem Docker"
description: "Führen Sie Aspose.Slides in einem Docker-Container für Linux, Windows Server und jedes Betriebssystem aus."
---

## **Unterstützte Betriebssysteme**
Aspose.Slides kann in Docker-Containern mit der .NET Core-Plattform betrieben werden. Im Allgemeinen unterstützt Aspose.Slides alle Containerarten (Betriebssysteme), die die .NET Core-Plattform unterstützt. Allerdings muss GDI oder [libgdiplus](https://github.com/mono/libgdiplus) verfügbar sein und korrekt in den beteiligten Containern eingerichtet werden.

Um Docker zu verwenden, müssen Sie es zunächst auf Ihrem System installieren. Um zu erfahren, wie Sie Docker unter Windows oder Mac installieren, verwenden Sie diese Links:

- [Installieren Sie Docker unter Windows](https://docs.docker.com/docker-for-windows/install/)
- [Installieren Sie Docker auf dem Mac](https://docs.docker.com/docker-for-mac/install/)

Sie können Docker auch unter Linux und Windows Server ausführen, indem Sie den Anweisungen auf diesen Seiten folgen:

- [Installieren und Konfigurieren von Docker unter Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Installieren und Konfigurieren von Docker unter Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [Installieren und Konfigurieren von Docker auf Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Die Installation und Konfiguration von Docker auf Windows Server Nano wird nicht unterstützt. Leider enthält Windows Server Nano das Grafik-Subsystem nicht. Es enthält nicht gdiplus.dll, das die System.Drawing.Common-Bibliothek benötigt, und kann nicht mit der Aspose.Slides-Bibliothek verwendet werden.

Obwohl es möglich ist, Linux-Container unter Windows auszuführen, empfehlen wir, sie nativ unter Linux auszuführen (auch auf einem manuell auf einer VM mit VirtualBox installierten Linux).

## **Installieren und Konfigurieren von Docker unter Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Diese Docker-Datei enthält Anweisungen zum Erstellen eines Container-Images mit dem libgdiplus-Paket, das aus den offiziellen Paket-Repositories von Ubuntu installiert wird.

Hier sind der Inhalt der Docker-Datei:

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

Lassen Sie uns überprüfen, was jede Zeile des Codes in der Docker-Datei bedeutet:

1. Das Image des Containers basiert auf dem microsoft/dotnet:2.1-sdk-bionic-Image (dem von Microsoft bereits erstellten und auf dem Docker [public hub](https://hub.docker.com/r/microsoft/dotnet/) veröffentlichten Image). Dieses Image enthält das bereits installierte dotnet 2.1 SDK. Der Bionic-Suffix bedeutet, dass Ubuntu 18.04 (Codename bionic) als Betriebssystem des Containers verwendet wird. Durch Ändern des Suffix kann das zugrunde liegende Betriebssystem geändert werden (zum Beispiel: stretch -- Debian 9, alpine -- Alpine Linux). In diesem Fall sind Änderungen am Inhalt der Docker-Datei erforderlich (zum Beispiel, um 'apt-get' in 'yum' zu ändern).

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Aktualisiert die Datenbank der verfügbaren Pakete und installiert das Paket apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Installiert die Pakete 'libgdiplus' und 'libc6-dev', die von der System.Drawing.Common-Bibliothek benötigt werden.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Erklärt den Ordner /slides-src als Mount-Punkt, den wir verwenden werden, um Zugang zum Slide-Net-Quellordner auf dem Host-Rechner zu erhalten.

``` csharp

 VOLUME /slides-src

```

1. Setzt slides-src als Arbeitsverzeichnis innerhalb des Containers.

``` csharp

 WORKDIR /slides-src

```

1. Erklärt einen Standardbefehl, der beim Start des Containers ausgeführt wird, falls kein expliziter Befehl angegeben ist.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Gemäß den Anweisungen in der Docker-Datei wird das resultierende Container-Image das Betriebssystem Ubuntu 18.04, die Pakete dotnet-sdk, libgdiplus und libc6-dev bereits installiert haben. Auch wird dieses Image einen vordefinierten Mount-Punkt und einen vordefinierten Befehl beim Ausführen haben.

Um ein Image mit dieser Docker-Datei zu erstellen, müssen Sie in den Docker-Ordner von slides-netuil wechseln und folgendes ausführen:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- Option gibt an, welche Docker-Datei verwendet werden soll.

*-t ubuntu18_04_apt_get_libgdiplus* -- legt das Tag (den Namen) für das resultierende Image fest.

*'.'* -- gibt den Kontext für Docker an. In unserem Fall ist der Kontext der aktuelle Ordner, und er ist leer – da wir uns entschieden haben, die Slides-Net-Quellen als Mount-Punkt bereitzustellen (dies ermöglicht es uns, das Docker-Image bei jeder Änderung in den Quellen nicht neu zu erstellen)

Das Ergebnis der Ausführung sollte folgendermaßen aussehen:

``` csharp

 Erfolgreich erstellt 62dd34ddc142

Erfolgreich getaggt ubuntu18_04_apt_get_libgdiplus:latest

```

Um sicherzustellen, dass das neue Image im lokalen Images-Repository hinzugefügt wurde:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        vor 2 Minuten          1,78 GB

```

Sobald das Image bereit ist, können wir es mit diesem Befehl ausführen:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- legt fest, dass der Befehl interaktiv ausgeführt werden soll, damit wir die Ausgabe sehen und die Eingabe erfassen können.

*-v `pwd`/../../:/slides-src* -- legt den Ordner für den vordefinierten Mount-Punkt fest – da das aktuelle Arbeitsverzeichnis slides-netuildocker ist, wird der Ordner slides-src im Container auf den Ordner slides-net auf dem Host verweisen. `pwd` wird verwendet, um den relativen Pfad anzugeben.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- ändert die Hosts-Datei des Containers, um die URL dev.slides.external.tool.server aufzulösen.

*ubuntu1804aptgetlibgdiplus:latest* -- gibt das Image an, das den Container ausführen soll.

Das Ergebnis des obigen Befehls wird eine Ausgabe von netcore.linux.tests.sh sein (da dies als Standardbefehl für den Container definiert wurde):

``` csharp

 Wiederherstellen von Paketen für /slides-src/targets/.NETCore/tests/Aspose.Slides.FuncTests.NetCore/Aspose.Slides.FuncTests.NetCore.csproj...

Wiederherstellen von Paketen für /slides-src/targets/.NETStandard/main/Aspose.Slides.DOM.NetStandard/Aspose.Slides.DOM.NetStandard.csproj...

Wiederherstellen von Paketen für /slides-src/targets/.NETStandard/main/Aspose.Slides.CompoundFile.NetStandard/Aspose.Slides.CompoundFile.NetStandard.csproj...

Installation von System.Text.Encoding.CodePages 4.4.0.

Installation von System.Drawing.Common 4.5.0.

...

Ergebnisdatei: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.FuncTests.NetCore.trx

Gesamtanzahl der Tests: Unbekannt. Bestanden: 2110. Fehlgeschlagen: 108. Übersprungen: 210.

...

Ergebnisdatei: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.RegrTests.NetCore.trx

Gesamtanzahl der Tests: 2124. Bestanden: 1550. Fehlgeschlagen: 103. Übersprungen: 471.

```

Aus dem Ergebnis ist klar, dass die Protokolldateien von Func- und Regr-Tests im Verzeichnis /build-out/netstandard20/test-results/main/ abgelegt wurden. Auch sind insgesamt etwa 200 Tests fehlgeschlagen – und all diese sind Rendering-Probleme, die mit dem Fehlen erforderlicher Schriftarten im Container zusammenhängen.

Um den Standardbefehl des Containers beim Ausführen zu überschreiben, könnten wir diesen Befehl verwenden:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Statt netcore.linux.tests.sh wird also /bin/bash ausgeführt, und es wird eine aktive Terminalsitzung von einem Container bereitgestellt, von der aus es ausgeführt werden kann (./build/netcore.linux.tests.sh). Dieser Ansatz kann in Fehlerszenarien nützlich sein.
## **Installieren und Konfigurieren von Docker unter Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Momentan enthält Ubuntu nur Version 4.2 von libgdiplus, während Version 5.6 bereits auf der [offiziellen Website](https://github.com/mono/libgdiplus/releases) des Produkts verfügbar ist. Um die neueste Version von libgdiplus zu testen, müssen wir ein Image mit dem aus den Quellen erstellten libgdiplus vorbereiten.

Überprüfen wir den Inhalt der Docker-Datei:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# neueste stabile libgdiplus erstellen

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# Mount-Punkte erstellen

VOLUME /slides-src

\# Aspose.Slides beim Start bauen und testen

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Der einzige Unterschied ist der Abschnitt *neueste stabile libgdiplus erstellen*. In diesem Abschnitt werden alle notwendigen Tools installiert, um libgdiplus zu bauen, die Quellen geklönt und dann gebaut und an den richtigen Ort installiert. Alles andere ist dasselbe wie [Installieren und Konfigurieren von Docker unter Linux (apt-get libgdiplus)](/slides/de/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Hinweis**: Vergessen Sie nicht, unterschiedliche Image-Tags (Namen) für das resultierende Image bei den docker build- und docker run-Befehlen zu verwenden:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Installieren und Konfigurieren von Docker auf Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Hinweis**: Windows 10 Pro oder Windows Server 2016 ist erforderlich, um Windows-Container auszuführen.

Leider stellt Microsoft kein Windows Server Core-Image mit dem .NET SDK zur Verfügung, daher müssen wir es manuell installieren:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#setze PowerShell Standard-Executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#setze PowerShell Standard-Executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# .NET Core SDK abrufen

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'PRÜFUNG DER PRÜFSUMME SCHEITERT!'; 

        exit 1; 

    }; 

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#gebe cmd als Standard-Executor zurück

SHELL ["cmd", "/S", "/C"]

\# Um den System-Pfad festzulegen, muss ContainerAdministrator verwendet werden

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# Mount-Punkte erstellen

VOLUME c:/slides-src

#bauen und testen von Aspose.Slides beim Start

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Das resultierende Image wird auf dem von Microsoft bereitgestellten Image microsoft/windowsservercore:1803 auf [docker hub](https://hub.docker.com/r/microsoft/windowsservercore/) aufgebaut. Das dotnet-sdk der angegebenen Version wird heruntergeladen und entpackt; die PATH-Variable des Systems wird aktualisiert, um den Pfad zur dotnet-executive zu enthalten. Die letzte Zeile definiert den Befehl, der die Func- und Regr-Tests im Container unter Verwendung von nant.exe als Standardaktion beim Ausführen des Containers ausführt.

Befehl zum Erstellen des Images:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Befehl zum Ausführen des Images:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Hinweis**: Der Befehl für den Windows-Container verwendet 2 zusätzliche Argumente:

*-cpu-count 3*

*-memory 8589934592*

Diese legen die Anzahl der Kerne und den verfügbaren Arbeitsspeicher für den Container fest. Standardmäßig sind nur 1 Kern und 1 GB RAM für den Windows-Container verfügbar (Linux-Container haben standardmäßig keine Einschränkungen).

Außerdem fehlt 1 Argument im Vergleich zu demselben Befehl, den wir verwendet haben, um den Linux-Container auszuführen:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Da der Container, der unter Windows ausgeführt wird, einfach keine externe.tool.server benötigt.

Das Ergebnis des obigen Befehls sollte folgendermaßen aussehen:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 9.6.2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Löschen des Verzeichnisses 'c:\slides-src\build-out\netcore20\test-results\'.

   [mkdir] Erstellen des Verzeichnisses 'c:\slides-src\build-out\netcore20\test-results\'.

...

[exec] Ergebnisdatei: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Gesamtanzahl der Tests: 2338. Bestanden: 2115. Fehlgeschlagen: 19. Übersprungen: 204.

...

[exec] Ergebnisdatei: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Gesamtanzahl der Tests: 2728. Bestanden: 2147. Fehlgeschlagen: 110. Übersprungen: 471.

```