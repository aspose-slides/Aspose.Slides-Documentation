---
title: Comment exécuter Aspose.Slides dans Docker
type: docs
weight: 140
url: /fr/net/comment-executer-aspose-slides-dans-docker/
keywords: "Exécution d'Aspose.Slides dans un conteneur Docker, Aspose Docker, Aspose.Slides dans un Docker"
description: "Exécutez Aspose.Slides dans un conteneur Docker pour Linux, Windows Server et tout système d'exploitation."
---

## **Systèmes d'exploitation pris en charge**
Aspose.Slides peut s'exécuter à l'intérieur de conteneurs Docker utilisant la plateforme .NET Core. En général, Aspose.Slides prend en charge tous les types de conteneurs (systèmes d'exploitation) que la plateforme .NET Core prend en charge. Cependant, le GDI ou [libgdiplus](https://github.com/mono/libgdiplus) doit être disponible et correctement configuré dans les conteneurs concernés.

Pour utiliser Docker, vous devez d'abord l'installer sur votre système. Pour apprendre comment installer Docker sur Windows ou Mac, utilisez ces liens :

- [Installer Docker sur Windows](https://docs.docker.com/docker-for-windows/install/)
- [Installer Docker sur Mac](https://docs.docker.com/docker-for-mac/install/)

Vous pouvez également exécuter Docker sur Linux et Windows Server en suivant les instructions sur ces pages :

- [Installer et configurer Docker sur Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Installer et configurer Docker sur Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [Installer et configurer Docker sur Windows Server Core](#install-and-configure-docker-on-windows-server-core)

L'installation et la configuration de Docker sur Windows Server Nano ne sont pas prises en charge. Malheureusement, Windows Server Nano ne contient pas le sous-système graphique. Il ne contient pas gdiplus.dll, qui est requis par la bibliothèque System.Drawing.Common, et ne peut pas être utilisé avec la bibliothèque Aspose.Slides.

Bien qu'il soit possible d'exécuter des conteneurs Linux sous Windows, nous vous recommandons de les exécuter nativement sur Linux (même sur un Linux installé manuellement sur une VM utilisant VirtualBox).

## **Installer et configurer Docker sur Linux (apt-get libgdiplus)**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Ce fichier Docker contient des instructions pour construire une image de conteneur avec le package libgdiplus installé à partir des dépôts de packages officiels d'Ubuntu.

Voici le contenu du fichier Docker :

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# installer libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# créer des points de montage

VOLUME /slides-src

\# construire et tester Aspose.Slides au démarrage

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Examinons ce que chaque ligne de code dans le fichier Docker signifie :

1. L'image du conteneur est basée sur l'image microsoft/dotnet:2.1-sdk-bionic (l'image déjà construite par Microsoft et publiée sur le [hub public de Docker](https://hub.docker.com/r/microsoft/dotnet/)). Cette image contient le SDK .NET 2.1 déjà installé. Le suffixe Bionic signifie qu'Ubuntu 18.04 (nom de code bionic) sera utilisé comme système d'exploitation du conteneur. En changeant le suffixe, il est possible de changer le système d'exploitation sous-jacent (par exemple : stretch -- Debian 9, alpine -- Alpine Linux). Dans ce cas, une modification du contenu du fichier Docker sera nécessaire (par exemple, changer 'apt-get' en 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Met à jour la base de données des packages disponibles et installe le package apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Installe les packages 'libgdiplus' et 'libc6-dev' requis par la bibliothèque System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Déclare le dossier /slides-src comme point de montage que nous utiliserons pour fournir un accès au dossier de sources slide-net sur la machine hôte.

``` csharp

 VOLUME /slides-src

```

1. Définit slides-src comme répertoire de travail à l'intérieur du conteneur.

``` csharp

 WORKDIR /slides-src

```

1. Déclare une commande par défaut qui sera exécutée au démarrage du conteneur en cas d'absence de commande explicite.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Selon les instructions dans le fichier Docker, l'image résultante du conteneur aura Ubuntu 18.04 OS, dotnet-sdk, libgdiplus et les packages libc6-dev déjà installés. De plus, cette image aura un point de montage prédéfini et une commande prédéfinie à l'exécution.

Pour construire une image en utilisant ce fichier Docker, vous devez vous rendre dans le dossier docker de slides-netuil et exécuter :

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- l'option spécifie quel fichier Docker utiliser.

*-t ubuntu18_04_apt_get_libgdiplus* -- spécifie un tag (nom) pour l'image résultante.

*'.'* -- spécifie le contexte pour Docker. Dans notre cas, le contexte est le dossier actuel et il est vide—puisque nous choisissons de fournir les sources de slides-net comme point de montage (ce qui nous permet de ne pas reconstruire l'image Docker à chaque changement dans les sources).

Le résultat de l'exécution devrait ressembler à ceci :

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Pour vous assurer que la nouvelle image a été ajoutée au dépôt d'images local :

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

*-it* -- spécifie que la commande doit être exécutée de manière interactive, nous permettant de voir la sortie et de capturer l'entrée.

*-v `pwd`/../../:/slides-src* -- spécifie le dossier pour le point de montage prédéfini—puisque le répertoire de travail actuel est slides-netuildocker, le dossier slides-src dans le conteneur pointera vers le dossier slides-net sur l'hôte. `pwd` est utilisé pour spécifier le chemin relatif.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- modifie le fichier hosts du conteneur pour résoudre l'URL dev.slides.external.tool.server.

*ubuntu1804aptgetlibgdiplus:latest* -- spécifie l'image à exécuter en tant que conteneur.

Le résultat de la commande ci-dessus sera la sortie de netcore.linux.tests.sh (puisqu'elle a été définie comme commande par défaut pour le conteneur) :

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

D'après le résultat, il est clair que les fichiers journaux des tests Func et Regr ont été placés dans le répertoire /build-out/netstandard20/test-results/main/. De plus, environ 200 tests ont échoué au total—et tous ces problèmes sont liés à l'absence de polices requises sur le conteneur.

Pour remplacer la commande par défaut du conteneur lors de l'exécution, nous pourrions utiliser cette commande :

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Ainsi, au lieu de netcore.linux.tests.sh, le /bin/bash sera exécuté et il fournira une session terminal active d'un conteneur à partir de laquelle il peut être exécuté (./build/netcore.linux.tests.sh). Cette approche peut être utile dans des scénarios de dépannage.
## **Installer et configurer Docker sur Linux (make install libgdiplus)**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile-Ubuntu18_04_make_libgdiplus

À l'heure actuelle, Ubuntu ne contient que la version 4.2 de libgdiplus tandis que la version 5.6 est déjà disponible sur le [site officiel du produit](https://github.com/mono/libgdiplus/releases). Pour tester la dernière version de libgdiplus, nous devons préparer une image avec libgdiplus construit à partir des sources.

Examinons le contenu du fichier Docker :

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# construire la dernière version stable de libgdiplus

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

\# construire et tester Aspose.Slides au démarrage

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

La seule différence est la section *construire la dernière version stable de libgdiplus*. Cette section installe tous les outils nécessaires pour construire libgdiplus, clone les sources, puis les construit et les installe à l'emplacement correct. Tout le reste est le même que [Installer et configurer Docker sur Linux (apt-get libgdiplus)](/slides/fr/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Remarque** : N'oubliez pas d'utiliser des balises (noms) d'images différentes pour l'image résultante sur les commandes docker build et docker run :

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Installer et configurer Docker sur Windows Server Core**
- OS : Ubuntu 18.04.
- Dockerfile : Dockerfile*WinServerCore*

**Remarque** : Windows 10 Pro ou Windows Server 2016 est requis pour exécuter des conteneurs Windows.

Malheureusement, Microsoft ne fournit pas d'image Windows Server Core avec le SDK dotnet installé, donc nous devons l'installer manuellement :

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Récupérer le SDK .NET Core

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'VÉRIFICATION DE LA SOMME DE CONTRÔLE ÉCHOUÉE !'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#return cmd as default executor

SHELL ["cmd", "/S", "/C"]

\# Afin de définir le PATH système, le ContainerAdministrator doit être utilisé

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# créer des points de montage

VOLUME c:/slides-src

#construire et tester Aspose.Slides au démarrage

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

L'image résultante sera construite à partir de l'image microsoft/windowsservercore:1803 fournie par Microsoft sur le [hub Docker](https://hub.docker.com/r/microsoft/windowsservercore/). Le SDK dotnet de la version spécifiée sera téléchargé et décompressé ; la variable PATH du système sera mise à jour pour contenir le chemin vers l'exécutable dotnet. La dernière ligne définit la commande qui exécute des tests func et regr sur le conteneur en utilisant nant.exe comme action par défaut lors de l'exécution du conteneur.

Commande pour construire l'image :

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Commande pour exécuter l'image :

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Remarque** : La commande pour le conteneur Windows utilise 2 arguments supplémentaires :

*-cpu-count 3*

*-memory 8589934592*

Ils définissent le nombre de cœurs et la quantité de mémoire disponible pour le conteneur. Par défaut, un seul cœur et 1 Go de RAM sont disponibles pour le conteneur Windows (les conteneurs Linux n'ont pas de limitations par défaut).

De plus, 1 argument est omis par rapport à la même commande que nous avons utilisée pour exécuter le conteneur Linux :

*-add-host dev.slides.external.tool.server:192.168.1.48*

Car le conteneur exécuté sur Windows n'a tout simplement pas besoin de external.tool.server.

Le résultat de la commande ci-dessus devrait ressembler à ceci :

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Suppression du répertoire 'c:\slides-src\build-out\netcore20\test-results\'. 

   [mkdir] Création du répertoire 'c:\slides-src\build-out\netcore20\test-results\'. 

...

[exec] Resultats Fichier: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Total des tests : 2338. Réussis : 2115. Échoués : 19. Ignorés : 204.

...

[exec] Resultats Fichier: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Total des tests : 2728. Réussis : 2147. Échoués : 110. Ignorés : 471.

```