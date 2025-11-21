---
title: Comment exécuter Aspose.Slides dans Docker
linktitle: Aspose.Slides dans Docker
type: docs
weight: 140
url: /fr/net/how-to-run-aspose-slides-in-docker/
keywords:
- OS pris en charge
- Aspose.Slides dans Docker
- conteneur Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- dépôt d'images
- Windows Server Core
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Exécutez Aspose.Slides dans des conteneurs Docker : configurez les images, les dépendances, les polices et les licences pour créer des services évolutifs qui traitent PowerPoint et OpenDocument."
---

## **Systèmes d'exploitation pris en charge**
Aspose.Slides peut s'exécuter à l'intérieur de conteneurs Docker en utilisant la plateforme .NET Core. En général, Aspose.Slides prend en charge tous les types de conteneurs (OS) que la plateforme .NET Core prend en charge. Cependant, le GDI ou [libgdiplus](https://github.com/mono/libgdiplus) doit être disponible et correctement configuré sur les conteneurs concernés.

Pour utiliser Docker, vous devez d'abord l'installer sur votre système. Pour savoir comment installer Docker sur Windows ou Mac, utilisez ces liens :

- [Installer Docker sur Windows](https://docs.docker.com/docker-for-windows/install/)
- [Installer Docker sur Mac](https://docs.docker.com/docker-for-mac/install/)

Vous pouvez également exécuter Docker sur Linux et Windows Server en suivant les instructions de ces pages :

- [Installer et configurer Docker sur Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Installer et configurer Docker sur Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Installer et configurer Docker sur Windows Server Core](#install-and-configure-docker-on-windows-server-core)

L'installation et la configuration de Docker sur Windows Server Nano ne sont pas prises en charge. Malheureusement, Windows Server Nano ne contient pas le sous‑système graphique. Il ne possède pas gdiplus.dll, requis par la bibliothèque System.Drawing.Common, et ne peut pas être utilisé avec la bibliothèque Aspose.Slides.

Bien qu'il soit possible d'exécuter des conteneurs Linux sous Windows, nous vous recommandons de les exécuter nativement sous Linux (même sur un Linux installé manuellement sur une VM utilisant VirtualBox).

## **Installation et configuration de Docker sur Linux (apt-get libgdiplus)**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Ce fichier Docker contient les instructions pour créer une image de conteneur avec le paquet libgdiplus installé à partir des dépôts officiels d'Ubuntu.

Voici le contenu du fichier Docker :
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# installer libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# créer des points de montage

VOLUME /slides-src

\# compiler et tester Aspose.Slides au démarrage

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Passons en revue la signification de chaque ligne de code du fichier Docker :

1. L'image du conteneur est basée sur l'image microsoft/dotnet:2.1-sdk-bionic (image déjà construite par Microsoft et publiée sur le [public hub](https://hub.docker.com/r/microsoft/dotnet/) de Docker). Cette image contient le SDK dotnet 2.1 déjà installé. Le suffixe Bionic indique que Ubuntu 18.04 (nom de code bionic) sera utilisé comme système d'exploitation du conteneur. En modifiant le suffixe, il est possible de changer le système d'exploitation sous‑jacent (par exemple : stretch — Debian 9, alpine — Alpine Linux). Dans ce cas, une modification du contenu du fichier Docker sera nécessaire (par exemple, remplacer 'apt-get' par 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```


1. Met à jour la base de données des paquets disponibles et installe le paquet apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. Installe les paquets 'libgdiplus' et 'libc6-dev' requis par la bibliothèque System.Drawing.Common.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. Déclare le dossier /slides-src comme point de montage qui sera utilisé pour fournir l'accès au dossier des sources slide‑net sur la machine hôte.
``` csharp

 VOLUME /slides-src

```


1. Définit slides-src comme répertoire de travail à l'intérieur du conteneur.
``` csharp

 WORKDIR /slides-src

```


1. Déclare une commande par défaut qui sera exécutée au démarrage du conteneur si aucune commande explicite n'est spécifiée.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Selon les instructions du fichier Docker, l'image du conteneur résultante aura Ubuntu 18.04, le SDK dotnet, les paquets libgdiplus et libc6-dev déjà installés. De plus, cette image disposera d'un point de montage prédéfini et d'une commande par défaut à l'exécution.

Pour créer une image à l'aide de ce fichier Docker, vous devez vous rendre dans le dossier docker de slides‑netuil et exécuter :
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- l'option indique quel fichier Docker utiliser.  
*-t ubuntu18_04_apt_get_libgdiplus* -- indique le tag (nom) de l'image résultante.  
*'.'* -- indique le contexte pour Docker. Dans notre cas, le contexte est le dossier actuel et il est vide — car nous choisissons de fournir les sources slides‑net comme point de montage (cela nous évite de reconstruire l'image Docker à chaque modification des sources).

Le résultat de l'exécution devrait ressembler à ceci :
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


Pour vérifier que la nouvelle image a été ajoutée au référentiel d'images local :
``` csharp

 $ docker images

\----
REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


Une fois l'image prête, nous pouvons l'exécuter avec cette commande :
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* -- indique que la commande doit être exécutée de manière interactive, permettant de voir la sortie et de capturer l'entrée.  
*-v `pwd`/../../:/slides-src* -- spécifie le dossier pour le point de montage prédéfini — comme le répertoire de travail actuel est slides‑netuildocker, le dossier slides‑src dans le conteneur pointera vers le dossier slides‑net sur l'hôte. `pwd` est utilisé pour indiquer le chemin relatif.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- modifie le fichier hosts du conteneur pour résoudre l'URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* -- indique l'image à utiliser pour exécuter le conteneur.

Le résultat de la commande ci‑dessus sera la sortie de netcore.linux.tests.sh (car il a été défini comme commande par défaut du conteneur) :
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


D'après le résultat, il est clair que les fichiers journaux des tests Func et Regr ont été placés dans le répertoire /build-out/netstandard20/test-results/main/. De plus, environ 200 tests ont échoué au total — tous ces échecs sont liés à des problèmes de rendu dus à l'absence de polices nécessaires dans le conteneur.

Pour remplacer la commande par défaut du conteneur lors d'une exécution, nous pouvons utiliser cette commande :
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Ainsi, au lieu de netcore.linux.tests.sh, /bin/bash sera exécuté et offrira une session terminal active du conteneur depuis laquelle il pourra être lancé (./build/netcore.linux.tests.sh). Cette approche peut être utile dans les scénarios de dépannage.

## **Installation et configuration de Docker sur Linux (make install libgdiplus)**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile-Ubuntu18_04_make_libgdiplus

Actuellement, Ubuntu ne contient que la version 4.2 de libgdiplus alors que la version 5.6 est déjà disponible sur le [site officiel](https://github.com/mono/libgdiplus/releases) du produit. Pour tester la dernière version de libgdiplus, nous devons préparer une image avec libgdiplus construit à partir des sources.

Examinons le contenu du fichier Docker :
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# compiler la dernière version stable de libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# créer des points de montage

VOLUME /slides-src

\# compiler et tester Aspose.Slides au démarrage

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


La seule différence réside dans la section *build latest stable libgdiplus*. Cette section installe tous les outils nécessaires pour compiler libgdiplus, clone les sources, puis les compile et les installe au bon emplacement. Tout le reste est identique à [Installer et configurer Docker sur Linux (apt‑get libgdiplus)](/slides/fr/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Note** : N'oubliez pas d'utiliser des tags d'image différents (nom) pour l'image résultante lors des commandes docker build et docker run :
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Installation et configuration de Docker sur Windows Server Core**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile*WinServerCore*

**Note** : Windows 10 Pro ou Windows Server 2016 est requis pour exécuter des conteneurs Windows.

Malheureusement, Microsoft ne fournit pas d'image Windows Server Core avec le SDK dotnet installé, nous devons donc l'installer manuellement :
``` csharp
 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env
#définir l'exécuteur par défaut PowerShell
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# escape=
FROM microsoft/windowsservercore:1803 AS installer-env
#définir l'exécuteur par défaut PowerShell
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
\# Récupérer le SDK .NET Core
ENV DOTNET_SDK_VERSION 2.1.301
ENV DOTNET_PATH "c:/Program Files/dotnet"
RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 
    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 
    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 
        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 
        exit 1; 
    }; 
    
    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;
#retourner cmd en tant qu'exécuteur par défaut
SHELL ["cmd", "/S", "/C"]
\# Afin de définir le PATH système, ContainerAdministrator doit être utilisé
USER ContainerAdministrator
RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"
USER ContainerUser
\# créer des points de montage
VOLUME c:/slides-src
#compiler et tester Aspose.Slides au démarrage
WORKDIR c:/slides-src
CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


L'image résultante sera construite à partir de l'image microsoft/windowsservercore:1803 fournie par Microsoft sur le [docker hub](https://hub.docker.com/r/microsoft/windowsservercore/). Le dotnet-sdk de la version spécifiée sera téléchargé et décompressé ; la variable d'environnement PATH du système sera mise à jour pour contenir le chemin vers l'exécutable dotnet. La dernière ligne définit la commande qui exécute les tests func et regr dans le conteneur en utilisant nant.exe comme action par défaut lors de l'exécution du conteneur.

Commande pour construire l'image :
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Commande pour exécuter l'image :
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Note** : La commande pour le conteneur Windows utilise 2 arguments supplémentaires :

*-cpu-count 3*  
*-memory 8589934592*

Ils définissent le nombre de cœurs et la quantité de mémoire disponible pour le conteneur. Par défaut, seul 1 cœur et 1 Go de RAM sont disponibles pour le conteneur Windows (les conteneurs Linux n'ont aucune limitation par défaut).

De plus, 1 argument est absent par rapport à la même commande que nous utilisions pour exécuter le conteneur Linux :

*-add-host dev.slides.external.tool.server:192.168.1.48*

Parce que le conteneur exécuté sous Windows n'a simplement pas besoin de external.tool.server.

Le résultat de la commande ci‑dessus devrait ressembler à ceci :
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
