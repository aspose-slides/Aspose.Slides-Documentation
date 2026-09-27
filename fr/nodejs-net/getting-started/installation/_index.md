---
title: Installation
type: docs
weight: 70
url: /fr/nodejs-net/installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- installation Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installez Aspose.Slides for Node.js via .NET depuis npm sur Windows ou Linux: prérequis, la substitution edge-js, une restauration NuGet unique, et un premier programme qui crée une présentation."
---
## **Aperçu**

Aspose.Slides for Node.js via .NET est le package npm `aspose.slides.via.net`. Il exécute la bibliothèque Aspose.Slides .NET à l'intérieur de Node.js via le pont [edge-js](https://github.com/agracio/edge-js), ainsi une installation fonctionnelle nécessite à la fois Node.js et .NET.

Cet article vous guide depuis une machine vierge jusqu'à un premier programme qui crée une présentation. Il y a quatre étapes : créer un projet avec une substitution edge-js, installer le package depuis npm, restaurer une fois les dépendances .NET du package, et exécuter votre script depuis le dossier du projet.

## **Prérequis**

- **Node.js 22 ou 24 LTS**, version x64, depuis [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 ou ultérieur**, depuis [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Le runtime .NET seul ne suffit pas : l'étape de restauration ci‑dessous nécessite le SDK, tout comme le pont lorsque votre script s'exécute. Exécutez `dotnet --list-sdks` pour vérifier quels SDK sont installés.
- **Sur Linux uniquement** :
  - les outils de compilation `python3`, `make` et `g++`, car npm compile edge-js pendant l'installation sur Linux ;
  - la bibliothèque fontconfig, que la bibliothèque de dessin native Aspose.Slides charge.

  Sur Debian, ce sont les paquets `python3`, `make`, `g++` et `libfontconfig1`.

Les étapes de cet article ont été testées sur ces plateformes :

| Plateforme | Résultat |
|---|---|
| Windows x64 avec Node.js 22 ou 24 | Fonctionne. Testé avec le redistribuable Microsoft Visual C++ installé. |
| Linux x64 avec Node.js 22 ou 24, où OpenSSL du système provient de la même branche que OpenSSL intégré à Node.js, par exemple Debian 13 | Fonctionne. |
| Linux où les deux versions d’OpenSSL diffèrent, comme Debian 12 | Node.js se bloque avec une faute de segmentation lorsqu’une présentation est créée. |
| macOS | Non vérifié. |

Sur Linux, comparez les deux versions avant de commencer. La première commande affiche la version d’OpenSSL intégrée à Node.js ; la deuxième affiche la version du système. Utilisez un système où les deux commencent par les mêmes numéros majeur et mineur, par exemple `3.5` :

```sh
node -p process.versions.openssl
openssl version
```

Si la commande `openssl` n’est pas trouvée, installez d’abord le paquet `openssl`.

## **Créer un projet**

Créez un dossier pour votre projet, initialisez‑le, et ajoutez une substitution qui indique à npm quelle version d’edge‑js installer :

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Le package demande une version plus ancienne d’edge‑js dont les binaires Windows précompilés s’arrêtent à Node.js 20, ainsi sans la substitution le premier script sous Windows s’interrompt avec « The edge module has not been pre-compiled for node.js version ». La commande écrit la substitution dans la section `overrides` de `package.json` ; ajoutez‑la avant d’installer le package.

## **Installer le package**

Installez Aspose.Slides for Node.js via .NET depuis npm :

```sh
npm install aspose.slides.via.net
```

Pendant l’installation, le package copie ses bibliothèques de dessin natives (les fichiers dont le nom contient `aspose.slides.drawing.capi`) dans le dossier du projet, à côté de `package.json`.

Le package est également publié sous forme d’archive ZIP sur [releases.aspose.com](https://releases.aspose.com/slides/fr/nodejs-net/). Cet article traite uniquement de l’installation depuis npm.

## **Restaurer les dépendances .NET**

Le package contient les assemblages .NET d’Aspose.Slides, mais pas les 20 packages NuGet dont ces assemblages dépendent. À l’exécution, .NET les recherche dans le cache des packages NuGet : `%USERPROFILE%\.nuget\packages` sous Windows, `~/.nuget/packages` sous Linux, ou le dossier indiqué par la variable d’environnement `NUGET_PACKAGES`. S’ils sont absents, le premier script s’arrête avec « assembly specified in the dependencies manifest was not found ».

Pour remplir le cache, créez un dossier nommé `deps` dans le dossier du projet et enregistrez‑y le fichier suivant sous le nom `deps.csproj`. Chaque élément `PackageDownload` télécharge un package à la version exacte entre crochets ; rien n’est construit.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Puis restaurez‑le depuis le dossier du projet :

```sh
dotnet restore deps/deps.csproj
```

Vous avez besoin de cette étape une fois par machine, pas une fois par projet : les packages restent dans le cache NuGet, et les projets ultérieurs sur la même machine les utilisent. Après la restauration, vous pouvez supprimer le dossier `deps`.

## **Exécuter un premier programme**

Créez un fichier nommé `hello.js` dans le dossier du projet avec le code suivant. Il crée une présentation, ajoute un rectangle contenant le texte « Hello, World! » à la première diapositive, et enregistre le résultat sous `hello.pptx` :

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Une nouvelle présentation contient une diapositive vide.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La position et la taille sont en points (1/72 pouce) : x, y, largeur, hauteur.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Libérer l'objet .NET qui supporte la présentation.
    presentation.dispose();
}
```

Exécutez‑le depuis le dossier du projet :

```sh
node hello.js
```

Le script affiche `Saved hello.pptx`. Ouvrez `hello.pptx` pour voir une diapositive avec un rectangle rempli contenant le texte. Sans licence, Aspose.Slides ajoute également un filigrane d’évaluation ; voir [Evaluate Aspose.Slides](/slides/fr/nodejs-net/evaluate-aspose-slides/) et [Licensing](/slides/fr/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Exécutez vos scripts depuis le dossier du projet, celui qui contient `package.json`. Les chemins relatifs comme `hello.pptx` sont résolus par rapport au dossier actuel, et sur certaines machines un script lancé depuis un autre dossier ne peut pas créer de présentation.
{{% /alert %}}

L’API JavaScript reflète Aspose.Slides pour .NET : les classes conservent leurs noms .NET, les propriétés et méthodes utilisent le camelCase (`Slides` devient `slides`, `AddAutoShape` devient `addAutoShape`), et les éléments de collection sont lus avec `get(index)`. Il n’existe pas de référence API distincte pour ce package, utilisez donc la [référence API Aspose.Slides pour .NET](https://reference.aspose.com/slides/fr/net/) pour les détails des classes et membres, par exemple [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**Que signifie « The edge module has not been pre-compiled for node.js version » ?**

npm a installé la version plus ancienne d’edge‑js demandée par le package. Ajoutez la substitution depuis [Créer un projet](#create-a-project) et exécutez de nouveau `npm install`.

**Que signifie « assembly specified in the dependencies manifest was not found » ?**

Les dépendances .NET ne se trouvent pas dans le cache NuGet. La même exécution signale également « edge.initializeClrFunc is not a function ». Suivez [Restaurer les dépendances .NET](#restore-the-net-dependencies) une fois, puis relancez votre script.

**Que signifie « The edge native module is not available » sous Linux ?**

edge‑js n’a pas été compilé pendant `npm install`, par exemple parce que `python3`, `make` ou `g++` était absent. npm ne signale pas cela comme une erreur. Installez les outils de compilation, puis exécutez `npm rebuild edge-js` dans le dossier du projet.

**Pourquoi la création d’une présentation échoue-t‑elle avec une « Error » vide ?**

Sous Linux, vérifiez que la bibliothèque fontconfig est installée (`libfontconfig1` sur Debian) ; sans elle, la bibliothèque de dessin native ne peut pas se charger. Sur tout système, assurez‑vous également d’exécuter le script depuis le dossier du projet.

**Pourquoi Node.js se bloque avec une faute de segmentation sous Linux ?**

Les OpenSSL du système et celui intégré à Node.js proviennent de branches différentes. Comparez‑les comme indiqué dans [Prerequisites](#prerequisites) et utilisez une distribution ou une version de Node.js où ils correspondent.

**Dois‑je répéter la restauration NuGet pour chaque projet ?**

Non. La restauration remplit le cache NuGet pour votre compte utilisateur, et chaque projet sur cette machine utilise le même cache.