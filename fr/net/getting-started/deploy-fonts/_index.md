---
title: Déployer des polices pour Aspose.Slides sur Linux et dans Docker
linktitle: Déployer des polices
type: docs
weight: 145
url: /fr/net/deploy-fonts/
keywords:
- déployer des polices
- installer des polices
- polices dans Docker
- polices sur Linux
- polices manquantes
- substitution de police
- polices de base Microsoft
- ttf-mscorefonts-installer
- polices personnalisées
- police par défaut
- serveur
- conteneur
- conversion PDF
- présentation
- .NET
- C#
- Aspose.Slides
description: "Déployer des polices pour Aspose.Slides pour .NET sur des serveurs Linux et dans des conteneurs Docker : vérifier quelles polices sont substituées, installer les paquets de polices sur Debian, Ubuntu et Alpine, ajouter vos propres fichiers de polices et définir une police par défaut."
---
## **Vue d'ensemble**

Aspose.Slides trace le texte avec les polices qui sont disponibles lorsqu’il rend une présentation, par exemple lorsqu’il convertit des diapositives en PDF ou en images. Un poste de travail Windows possède généralement les polices utilisées par les présentations. Les serveurs et conteneurs Linux possèdent peu ou aucune police, si bien qu’Aspose.Slides trace le texte avec une police de substitution. Une substitution possède des formes de lettres et des largeurs différentes, ce qui peut modifier le retour à la ligne et faire déborder le texte de sa forme, et les caractères absents dans la police de substitution ne sont pas rendus correctement. Si aucune police n’est installée, la conversion s’arrête avec une erreur.

Cet article montre comment vérifier quelles polices Aspose.Slides remplace, comment installer des polices sur Debian, Ubuntu et Alpine Linux, comment ajouter vos propres fichiers de polices, et comment définir la police utilisée lorsqu’une police est manquante. Les exemples s’exécutent dans Docker sur les images officielles .NET, comme dans [Run Aspose.Slides for .NET in Docker](/slides/fr/net/how-to-run-aspose-slides-in-docker/). Les commandes de paquet sont des instructions Dockerfile ; sur un serveur Linux, exécutez les mêmes commandes en tant que root.

Pour l’API de police elle‑même, comme l’incorporation de polices dans une présentation et les règles de secours et de remplacement, consultez [PowerPoint Fonts](/slides/fr/net/powerpoint-fonts/).

## **Vérifier quelles polices sont substituées**

L’application console suivante indique les polices qu’Aspose.Slides substitue dans l’environnement actuel. Créez un dossier nommé *FontCheck* et ajoutez‑y les fichiers ci‑dessous.

*FontCheck.csproj* référence [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), le paquet pour Debian et Ubuntu. Il copie également les fichiers d’un dossier *fonts* optionnel vers la sortie de l’application ; la section [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) l’utilise.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* ajoute une zone de texte par nom de police à une diapositive et assigne la police via la propriété [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/). Les noms de police proviennent de la ligne de commande ; sans arguments, l’application vérifie Calibri, Arial et Times New Roman. Elle affiche les dossiers dans lesquels Aspose.Slides recherche les polices ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), rend la diapositive vers *output/fonts.pdf* et affiche les substitutions signalées par [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). Les deux étapes optionnelles au début, le chargement d’un dossier *fonts* et la lecture d’une variable `DEFAULT_FONT`, sont expliquées plus loin dans cet article.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Les polices à vérifier : les arguments de ligne de commande, ou trois polices Office courantes.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Charger les fichiers de polices depuis le dossier fonts à côté de l'application, s'il existe.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Utiliser la police nommée dans la variable d'environnement DEFAULT_FONT, si elle est définie, pour le texte dont la police est manquante.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* garde les résultats de construction locaux hors du contexte de construction :

```text
bin/
obj/
output/
```

*Dockerfile* compile l’application avec l’image SDK .NET et l’exécute sur l’image runtime .NET. L’étape runtime installe `libfontconfig1`, requis par Aspose.Slides.NET6.CrossPlatform, et les polices DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/fr/net/how-to-run-aspose-slides-in-docker/) explique chaque instruction.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Construisez l’image et lancez la vérification :

```bash
docker build -t font-check .
docker run --rm font-check
```

L’image ne contient que les polices DejaVu, de sorte que les trois polices sont remplacées par DejaVu Sans :

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Pour vérifier les polices de vos propres présentations, passez leurs noms en arguments, par exemple `docker run --rm font-check "Segoe UI" Consolas`. Pour copier *output/fonts.pdf* hors du conteneur, utilisez les commandes de [Copy the Output to Your Machine](/slides/fr/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Installer des polices sur Debian et Ubuntu**

### **Polices de base Microsoft**

Le paquet `ttf-mscorefonts-installer` télécharge et installe les polices de base Microsoft pour le web, parmi lesquelles Arial, Times New Roman, Courier New, Verdana, Georgia et Trebuchet MS. Les polices sont licenciées sous le contrat de licence utilisateur final (EULA) de Microsoft, et le paquet les installe uniquement après acceptation de l’EULA. Une construction Docker ne peut pas répondre à l’invite, si bien que l’installateur refuse l’EULA et n’installe aucune police, tandis que `apt-get install` indique quand même un succès. Acceptez l’EULA avec `debconf-set-selections` **avant** l’installation du paquet.

Dans le *Dockerfile*, remplacez l’instruction `RUN` qui installe les paquets dans l’étape runtime par :

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Construisez l’image et relancez la vérification avec les mêmes deux commandes. Arial et Times New Roman sont maintenant installés :

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, la police par défaut d’une présentation créée par Aspose.Slides, ne fait pas partie des polices de base, elle est donc toujours remplacée. Voir [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Sur Debian, le paquet se trouve dans le composant de dépôt `contrib`, que les images Debian n’activent pas ; les images .NET 8 et .NET 9 sont basées sur Debian 12. Activez `contrib` dans la même instruction :

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Les images .NET 10 basées sur Ubuntu activent déjà `multiverse`, le composant Ubuntu qui contient le paquet.

### **Autres paquets de polices**

Debian et Ubuntu empaquetent également des polices sous licence libre, par exemple :

| Paquet | Polices |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif et Mono, avec les mêmes métriques qu’Arial, Times New Roman et Courier New |
| `fonts-crosextra-carlito` | Carlito, avec les mêmes métriques que Calibri |
| `fonts-crosextra-caladea` | Caladea, avec les mêmes métriques que Cambria |

Installez‑les avec `apt-get install` dans la même instruction `RUN`. Aspose.Slides.NET6.CrossPlatform n’applique pas les alias de police de la configuration Linux : avec `fonts-liberation` installé, le texte en Arial est toujours tracé avec la police de substitution générale, pas avec Liberation Sans. Pour utiliser une police compatible métriquement à la place d’une police manquante, définissez‑la comme [police par défaut](#set-a-default-font-for-missing-fonts) ou ajoutez une [règle de substitution de police](/slides/fr/net/font-substitution/).

## **Ajouter vos propres fichiers de polices**

Les polices que les distributions n’empaquettent pas, comme les polices de votre organisation ou d’autres polices pour lesquelles vous avez une licence serveur, peuvent être ajoutées sous forme de fichiers. Placez les fichiers de polices, par exemple des fichiers *.ttf*, dans un dossier nommé *fonts* à l’intérieur du dossier *FontCheck*. Les exemples ci‑dessous utilisent les fichiers de Carlito, une police aux mêmes métriques que Calibri, que vous pouvez télécharger depuis [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Installer les polices dans un dossier système**

Aspose.Slides lit les polices dans les dossiers affichés sur la ligne `Font folders`. Pour installer vos polices pour toutes les applications de l’image, copiez‑les dans */usr/local/share/fonts*, le dossier des polices installées localement. Ajoutez cette instruction à l’étape runtime du *Dockerfile*, après l’instruction `RUN` qui installe les paquets :

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Charger les polices depuis le dossier de l’application**

Au lieu d’installer les polices dans l’image, vous pouvez les livrer avec l’application et les charger avec [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). Les polices sont alors disponibles uniquement pour Aspose.Slides, et elles sont déployées avec l’application. *FontCheck* fait cela : *FontCheck.csproj* copie le dossier *fonts* vers la sortie de l’application, et *Program.cs* transmet ce dossier à `LoadExternalFonts` avant de créer la présentation. [Custom Font](/slides/fr/net/custom-font/) décrit les autres moyens de fournir des polices, comme le chargement depuis la mémoire.

Reconstruisez l’image, puis vérifiez Calibri et Carlito :

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Le dossier de l’application apparaît maintenant parmi les dossiers de polices, et Carlito n’est plus substitué :

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Définir une police par défaut pour les polices manquantes**

Lorsqu’une police est manquante, Aspose.Slides utilise une substitution qu’il choisit lui‑-même. Pour choisir vous‑même, définissez la propriété [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) de [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) et transmettez les options au constructeur [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). *FontCheck* lit le nom de police depuis la variable d’environnement `DEFAULT_FONT`. Avec Carlito chargé, utilisez‑le pour les polices manquantes :

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri est maintenant tracé avec Carlito, dont les caractères ont les mêmes largeurs que ceux de Calibri, de sorte que le texte conserve ses sauts de ligne :

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

La police par défaut remplace chaque police manquante. Pour mapper des polices individuelles, par exemple Arial vers Liberation Sans et Calibri vers Carlito, utilisez les [règles de substitution de police](/slides/fr/net/font-substitution/). Les règles modifient le rendu, mais `GetSubstitutions` ne les reflète pas, il faut donc vérifier les polices dans le fichier de sortie. Pour le texte asiatique, définissez également [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); voir [Default Font](/slides/fr/net/default-font/).

## **Installer des polices sur Alpine Linux**

Sur Alpine Linux, utilisez le paquet Aspose.Slides.NET ; [Run on Alpine Linux](/slides/fr/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) liste les modifications du projet. Apportez les mêmes changements à *FontCheck* : remplacez la référence du paquet, ajoutez l’instruction `SetSwitch` à *Program.cs*, et utilisez cette étape runtime, qui installe également les polices de base Microsoft :

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` télécharge et installe les mêmes polices de base Microsoft que le paquet Debian et Ubuntu, et leur EULA s’applique de la même façon. `fc-cache` met à jour le cache des polices.

Avec Aspose.Slides.NET sous Linux, la bibliothèque de configuration des polices (fontconfig) choisit la substitution pour une police manquante, et `GetSubstitutions` ne la signale pas, de sorte que *FontCheck* affiche `No font substitutions.` Pour savoir quelle police est utilisée pour un nom de police, interrogez fontconfig dans le conteneur :

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Avec les polices de base Microsoft installées, Arial est utilisé pour Arial :

```text
Arial.ttf: "Arial" "Regular"
```

Sans elles, lorsque l’instruction `RUN` n’installe que `icu-libs libgdiplus font-dejavu`, la même commande affiche :

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Pourquoi une présentation apparaît‑elle différente lorsqu’elle est convertie sur un serveur ?**

Le serveur ne possède pas les polices utilisées par la présentation, si bien qu’Aspose.Slides trace le texte avec une police de substitution dont les lettres ont d’autres largeurs. Exécutez *FontCheck* avec les noms de police de la présentation pour voir quelles polices sont substituées, puis installez ces polices ou chargez‑les depuis le dossier de l’application.

**Le build a installé ttf‑mscorefonts‑installer, mais Arial est toujours substitué. Pourquoi ?**

L’EULA n’a pas été acceptée avant l’installation du paquet, donc l’installateur a sauté les polices. Ajoutez la commande `debconf-set-selections` avant `apt-get install`, comme indiqué dans [Microsoft Core Fonts](#microsoft-core-fonts), et reconstruisez l’image.

**L’ordinateur qui ouvre le PDF a‑t‑il besoin des polices ?**

Non. Dans ces exemples, le PDF contient les polices utilisées pour tracer le texte, il apparaît donc de la même façon sur n’importe quel ordinateur. Les polices ne sont nécessaires que là où Aspose.Slides rend la présentation.