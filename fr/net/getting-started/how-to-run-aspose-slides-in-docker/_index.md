---
title: Comment exécuter Aspose.Slides dans Docker
linktitle: Aspose.Slides dans Docker
type: docs
weight: 140
url: /fr/net/how-to-run-aspose-slides-in-docker/
keywords:
- systèmes d'exploitation pris en charge
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
description: "Exécuter Aspose.Slides dans des conteneurs Docker : configurer les images, les dépendances, les polices et la licence afin de créer des services évolutifs qui traitent PowerPoint et OpenDocument."
---

## **Systèmes d'exploitation pris en charge**
Aspose.Slides peut s'exécuter à l'intérieur de conteneurs Docker en utilisant la plateforme .NET Core. En général, Aspose.Slides prend en charge tous les types de conteneurs (OS) que la plateforme .NET Core prend en charge. Cependant, le GDI ou [libgdiplus](https://github.com/mono/libgdiplus) doit être disponible et correctement configuré sur les conteneurs concernés.

Pour utiliser Docker, vous devez d'abord l'installer sur votre système. Pour savoir comment installer Docker sur Windows ou Mac, utilisez ces liens :

- [Installer Docker sur Windows](https://docs.docker.com/docker-for-windows/install/)
- [Installer Docker sur Mac](https://docs.docker.com/docker-for-mac/install/)

Vous pouvez également exécuter Docker sur Linux et Windows Server en suivant les instructions sur ces pages :

- [Installer et configurer Docker sur Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Installer et configurer Docker sur Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Installer et configurer Docker sur Windows Server Core](#install-and-configure-docker-on-windows-server-core)

L'installation et la configuration de Docker sur Windows Server Nano ne sont pas prises en charge. Malheureusement, Windows Server Nano ne contient pas le sous‑système graphique. Il ne contient pas gdiplus.dll, requis par la bibliothèque System.Drawing.Common, et il ne peut pas être utilisé avec la bibliothèque Aspose.Slides.

Bien qu'il soit possible d'exécuter des conteneurs Linux sous Windows, nous vous recommandons de les exécuter nativement sous Linux (même sur un Linux installé manuellement dans une VM avec VirtualBox).

## **Installer et configurer Docker sur Linux (apt-get libgdiplus)**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Ce fichier Docker contient des instructions pour créer une image de conteneur avec le paquet libgdiplus installé à partir des dépôts officiels d'Ubuntu.

Voici le contenu du fichier Docker :
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# installer libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# créer les points de montage

VOLUME /slides-src

\# construire et tester Aspose.Slides au démarrage

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Passons en revue ce que signifie chaque ligne de code du fichier Docker :

1. L'image du conteneur est basée sur l'image microsoft/dotnet:2.1-sdk-bionic (l'image déjà construite par Microsoft et publiée sur le [hub public](https://hub.docker.com/r/microsoft/dotnet/) de Docker). Cette image contient le SDK dotnet 2.1 déjà installé. Le suffixe Bionic signifie que Ubuntu 18.04 (nom de code bionic) sera utilisé comme OS du conteneur. En changeant le suffixe, il est possible de changer l'OS sous‑jacent (par exemple : stretch – Debian 9, alpine – Alpine Linux). Dans ce cas, une modification du contenu du fichier Docker sera nécessaire (par exemple, remplacer « apt-get » par « yum »).  
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```


2. Met à jour la base de données des paquets disponibles et installe le paquet apt-utils.  
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


3. Installe les paquets 'libgdiplus' et 'libc6-dev' requis par la bibliothèque System.Drawing.Common.  
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


4. Déclare le dossier /slides-src comme point de montage que nous utiliserons pour fournir l'accès au dossier sources slide-net sur la machine hôte.  
``` csharp

 VOLUME /slides-src

```


5. Définit slides-src comme répertoire de travail à l'intérieur du conteneur.  
``` csharp

 WORKDIR /slides-src

```


6. Déclare une commande par défaut qui sera exécutée au démarrage du conteneur si aucune commande explicite n'est spécifiée.  
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Selon les instructions du fichier Docker, l'image du conteneur résultant contiendra Ubuntu 18.04, le SDK dotnet, les paquets libgdiplus et libc6-dev déjà installés. De plus, cette image disposera d'un point de montage prédéfini et d'une commande par défaut à l'exécution.

Pour créer une image à partir de ce fichier Docker, vous devez vous rendre dans le dossier docker de slides-netuil et exécuter :
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- option qui indique quel fichier Docker utiliser.  
*-t ubuntu18_04_apt_get_libgdiplus* -- indique le tag (nom) de l'image résultante.  
*'.'* -- indique le contexte pour Docker. Dans notre cas, le contexte est le dossier actuel et il est vide — car nous choisissons de fournir les sources slides-net comme point de montage (cela nous évite de reconstruire l'image Docker à chaque modification des sources).

Le résultat de l'exécution devrait ressembler à ceci :
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


Pour s'assurer que la nouvelle image a bien été ajoutée au référentiel d'images locales :
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


Une fois l'image prête, nous pouvons l'exécuter avec la commande suivante :
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* -- indique que la commande doit être exécutée en mode interactif, ce qui permet de voir la sortie et de saisir des entrées.  
*-v `pwd`/../../:/slides-src* -- spécifie le dossier pour le point de montage prédéfini — puisque le répertoire de travail actuel est slides-net/docker, le dossier slides-src dans le conteneur pointera vers le dossier slides-net sur l'hôte. `pwd` est utilisé pour indiquer le chemin relatif.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- modifie le fichier hosts du conteneur pour résoudre l'URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* -- indique l'image à exécuter.

Le résultat de la commande ci‑dessus sera la sortie de netcore.linux.tests.sh (car elle a été définie comme commande par défaut du conteneur) :
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


À partir du résultat, il apparaît clairement que les fichiers journaux des tests Func et Regr ont été placés dans le répertoire / build-out/netstandard20/test-results/main/. Environ 200 tests ont échoué au total — tous liés à des problèmes de rendu dus à l'absence des polices requises dans le conteneur.

Pour remplacer la commande par défaut du conteneur lors d'une exécution, nous pouvons utiliser la commande suivante :
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Ainsi, au lieu de netcore.linux.tests.sh, /bin/bash sera exécuté et offrira une session terminal active du conteneur depuis laquelle il pourra être lancé (./build/netcore.linux.tests.sh). Cette approche peut être utile pour le dépannage.

## **Installer et configurer Docker sur Linux (make install libgdiplus)**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile-Ubuntu18_04_make_libgdiplus

Actuellement, Ubuntu ne propose que la version 4.2 de libgdiplus alors que la version 5.6 est déjà disponible sur le [site officiel](https://github.com/mono/libgdiplus/releases) du produit. Pour tester la version la plus récente de libgdiplus, nous devons préparer une image avec libgdiplus compilé à partir des sources.

Passons en revue le contenu du fichier Docker :
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# compiler la version stable la plus récente de libgdiplus

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


La seule différence réside dans la section *build latest stable libgdiplus*. Cette section installe tous les outils nécessaires à la compilation de libgdiplus, clone les sources, les compile puis les installe à l'emplacement approprié. Tout le reste est identique à [Installer et configurer Docker sur Linux (apt-get libgdiplus)](/slides/fr/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Note** : n'oubliez pas d'utiliser des tags d'image différents (nom) pour l'image résultante lors des commandes docker build et docker run :
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Installer et configurer Docker sur Windows Server Core**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile*WinServerCore*

**Note** : Windows 10 Pro ou Windows Server 2016 est requis pour exécuter des conteneurs Windows.

Malheureusement, Microsoft ne fournit pas d'image Windows Server Core avec le SDK dotnet installé, nous devons donc l'installer manuellement :
``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set définir l'exécuteur par défaut powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set définir l'exécuteur par défaut powershell

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

#retourner cmd comme exécuteur par défaut

SHELL ["cmd", "/S", "/C"]

\# Pour définir le PATH système, ContainerAdministrator doit être utilisé

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# créer des points de montage

VOLUME c:/slides-src

# construire et tester Aspose.Slides au démarrage

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


L'image résultante sera construite à partir de l'image microsoft/windowsservercore:1803 fournie par Microsoft sur le [docker hub](https://hub.docker.com/u/microsoft). Le SDK dotnet de la version spécifiée sera téléchargé et décompressé ; la variable d'environnement PATH du système sera mise à jour pour inclure le chemin vers l'exécutable dotnet. La dernière ligne définit la commande qui exécute les tests func & regr dans le conteneur en utilisant nant.exe comme action par défaut à l'exécution du conteneur.

Commande pour créer l'image :
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Commande pour exécuter l'image :
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Note** : la commande pour le conteneur Windows utilise 2 arguments supplémentaires :

*-cpu-count 3*  
*-memory 8589934592*

Ils définissent le nombre de cœurs et la quantité de mémoire allouée au conteneur. Par défaut, un seul cœur et 1 Go de RAM sont disponibles pour le conteneur Windows (les conteneurs Linux n'ont aucune limitation par défaut).

De plus, un argument manque par rapport à la même commande que nous utilisions pour le conteneur Linux :

*-add-host dev.slides.external.tool.server:192.168.1.48*

Parce que le conteneur fonctionnant sous Windows n'a tout simplement pas besoin de external.tool.server.

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
