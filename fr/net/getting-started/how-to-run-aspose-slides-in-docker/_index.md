---
title: Exécuter Aspose.Slides pour .NET dans Docker
linktitle: Docker
type: docs
weight: 140
url: /fr/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Conteneur Docker
- construction multi-étapes
- image de conteneur
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- polices
- conversion PDF
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Construisez et exécutez une application console Aspose.Slides pour .NET dans Docker : un Dockerfile multi-étapes sur les images .NET officielles, les bibliothèques Linux et les polices nécessaires, et comment copier les fichiers générés sur votre machine."
---
## **Vue d'ensemble**

Cet article montre comment exécuter Aspose.Slides pour .NET dans un conteneur Docker. Vous créez une petite application console qui crée une présentation avec une zone de texte et la convertit en PDF, l'emballe avec un Dockerfile à plusieurs étapes sur les images .NET officielles de Microsoft, l'exécute, puis copie les fichiers générés sur votre machine. L'article répertorie également les bibliothèques Linux et les polices dont Aspose.Slides a besoin dans le conteneur et se termine par une variante pour Alpine Linux.

Vous n'avez besoin que de Docker sur votre machine. Le SDK .NET fait partie de l'image de construction, vous n'avez donc pas besoin de l'installer. Pour installer Docker, consultez [Obtenir Docker](https://docs.docker.com/get-started/get-docker/).

## **Choisir le package et l'image de base**

Les images de conteneur .NET 10 par défaut sont basées sur Ubuntu 24.04. Sur ces images, utilisez le package [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Il nécessite la bibliothèque `fontconfig`, et l'image d'exécution .NET ne contient ni cette bibliothèque ni aucune police, c'est pourquoi le Dockerfile de cet article les installe tous les deux.

Aspose.Slides.NET6.CrossPlatform ne fonctionne pas sur Alpine Linux. Pour les images basées sur Alpine, utilisez le package [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) avec `libgdiplus`, comme décrit dans [Exécuter sur Alpine Linux](#run-on-alpine-linux). [Installation](/slides/fr/net/installation/) compare les deux packages.

## **Créer le projet**

Créez un dossier nommé *HelloSlidesDocker* et ajoutez‑y les trois fichiers suivants.

*HelloSlidesDocker.csproj* décrit une application console pour .NET 10, la version des images de conteneur utilisées ci‑dessous, et référence Aspose.Slides.NET6.CrossPlatform. Définissez la version du package à la plus récente listée sur [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* crée une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), ajoute un rectangle avec du texte à sa première diapositive, et enregistre la présentation deux fois avec la méthode [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) : en PPTX et en PDF. Les deux fichiers sont placés dans le dossier *output* du répertoire de travail. L'application liste ensuite les polices qui ont été remplacées lors du rendu du PDF, en utilisant [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/), afin que vous puissiez voir si le conteneur possède les polices utilisées par la présentation.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* garde les dossiers *bin* et *obj* d'une construction locale, ainsi que les sorties des exécutions précédentes, hors du contexte de construction Docker, de sorte que l'image est construite uniquement à partir des fichiers source.

```text
bin/
obj/
output/
```

## **Écrire le Dockerfile**

Ajoutez un fichier nommé *Dockerfile* dans le même dossier :

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Le fichier comporte deux étapes :

- **L'étape de construction** démarre à partir de l'image du SDK .NET. Elle copie d'abord le fichier projet et restaure les packages NuGet, de sorte que Docker réutilise cette couche tant que le fichier projet ne change pas. Elle copie ensuite le code source et publie l'application dans */app*.
- **L'étape d'exécution** démarre à partir de l'image d'exécution .NET plus petite, qui ne possède pas de SDK, et ne copie que l'application publiée. Elle installe deux paquets :
  - `libfontconfig1` : Aspose.Slides.NET6.CrossPlatform charge cette bibliothèque au démarrage. Sans elle, l'application s'arrête avec une `DllNotFoundException` indiquant `libfontconfig.so.1`.
  - `fonts-dejavu-core` : l'image d'exécution ne contient aucune police, et Aspose.Slides a besoin d'au moins une police installée pour dessiner du texte ; sans aucune, la conversion s'arrête avec `InvalidOperationException: Cannot find any fonts installed on the system.` Le texte avec des polices non installées est rendu avec une police de substitution. Les polices DejaVu sont un petit ensemble qui permet de rendre le texte ; pour rendre les présentations avec les polices pour lesquelles elles ont été conçues, consultez [Déployer des polices](/slides/fr/net/deploy-fonts/).

`--no-install-recommends` et la suppression des listes de paquets maintiennent l'image petite. Les dernières lignes créent le dossier *output*, le donnent à l'utilisateur non root `app` que les images .NET officielles définissent (son ID utilisateur se trouve dans la variable `APP_UID`), et exécutent l'application en tant que cet utilisateur.

Pour une application ASP.NET Core, démarrez l'étape d'exécution depuis `mcr.microsoft.com/dotnet/aspnet:10.0` à la place. Elle repose sur la même image Ubuntu, donc les mêmes paquets sont nécessaires.

## **Construire et exécuter le conteneur**

Ouvrez un terminal dans le dossier *HelloSlidesDocker*. Construisez l'image, puis lancez un conteneur à partir de celle‑ci :

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

La première construction télécharge les images de base et les packages NuGet, donc elle prend plus de temps que les constructions ultérieures. Le conteneur exécute l'application puis s'arrête. Il affiche :

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

La première ligne montre que le texte utilise Calibri, la police par défaut d'une nouvelle présentation, et que Calibri n'est pas installé dans l'image, ainsi Aspose.Slides a rendu le texte avec DejaVu Sans. Le texte du PDF est réel, sélectionnable dans cette police. Sans licence, Aspose.Slides ajoute également un filigrane d'évaluation à chaque diapositive qu'il enregistre ; consultez [Licences](/slides/fr/net/licensing/).

## **Copier la sortie sur votre machine**

Les fichiers se trouvent dans le dossier */app/output* du conteneur arrêté. Copiez‑les dans un dossier *output* sur votre machine, puis supprimez le conteneur :

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Ces deux commandes fonctionnent de la même manière dans Bash, PowerShell et l'invite de commandes Windows.

Sous Linux, vous pouvez à la place monter un dossier de votre machine dans le conteneur, afin que l'application y écrive directement les fichiers :

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

L'option `--user` exécute l'application avec vos ID d'utilisateur et de groupe, ainsi elle peut écrire dans le dossier que vous avez créé et les fichiers vous appartiennent. `--rm` supprime le conteneur lorsqu'il s'arrête.

## **Exécuter sur Alpine Linux**

Pour exécuter l'application dans une image basée sur Alpine, passez au package Aspose.Slides.NET et modifiez l'étape d'exécution. L'étape de construction reste identique.

1. Dans *HelloSlidesDocker.csproj*, remplacez la référence du package :

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. Dans *Program.cs*, ajoutez cet énoncé après les directives `using`, avant le premier appel à Aspose.Slides. Il active la prise en charge de System.Drawing pour Linux que Aspose.Slides.NET utilise :

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. Dans *Dockerfile*, remplacez l'étape d'exécution (tout à partir de la deuxième ligne `FROM`) par :

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

L'étape Alpine installe trois paquets et modifie un paramètre :

- `libgdiplus` est la bibliothèque graphique que Aspose.Slides.NET utilise sous Linux.
- `font-dejavu` fournit des polices. Sans aucune police, la conversion s'arrête avec `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` et `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` fournissent les données de culture. Les images .NET Alpine s'exécutent par défaut en mode globalisation invariante, et dans ce mode Aspose.Slides s'arrête avec une `CultureNotFoundException` pour `en-US`.

Construisez, exécutez et copiez la sortie avec les mêmes commandes qu'auparavant. Sur cette image, l'application n'affiche que la ligne `Saved` : avec Aspose.Slides.NET sous Linux, fontconfig choisit le remplacement d'une police manquante, et [GetSubstitutions](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontsmanager/getsubstitutions/) ne la répertorie pas. [Déployer des polices](/slides/fr/net/deploy-fonts/) montre comment vérifier quelle police est utilisée.

## **FAQ**

**L'application s'arrête avec « Unable to load shared library 'libaspose.slides.drawing.capi…' ». Qu'est‑ce qui manque ?**

Sur les images Ubuntu et Debian, le paquet `libfontconfig1` ; le message indique `libfontconfig.so.1` comme le fichier qui n'a pas pu être ouvert. Sous Alpine Linux, le message signifie que Aspose.Slides.NET6.CrossPlatform est utilisé ; passez à Aspose.Slides.NET comme décrit dans [Exécuter sur Alpine Linux](#run-on-alpine-linux).

**Pourquoi le texte du PDF apparaît‑il avec une police différente de celle de PowerPoint ?**

Les polices utilisées par la présentation ne sont pas installées dans l'image, ainsi Aspose.Slides rend le texte avec une police de substitution. La sortie de l'application indique chaque police remplacée. [Déployer des polices](/slides/fr/net/deploy-fonts/) explique comment installer des polices dans l'image ou les charger depuis le dossier de l'application.

**Ai‑je besoin du SDK .NET sur ma machine ?**

Non. L'étape de construction compile l'application à l'intérieur de l'image du SDK. Vous n'avez besoin du SDK que si vous souhaitez également construire et exécuter l'application hors de Docker ; consultez [Installation](/slides/fr/net/installation/).