---
title: Personnaliser les polices PowerPoint en C++
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/cpp/custom-font/
keywords:
- police
- police personnalisée
- police externe
- charger police
- gérer les polices
- dossier de polices
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour C++ afin de garder vos présentations nettes et cohérentes sur n'importe quel appareil."
---
## **Aperçu**

Aspose.Slides vous permet d'utiliser des polices personnalisées dans les présentations sans les installer sur le système d'exploitation. Vous pouvez charger des polices à partir de dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de police au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lorsqu'une présentation est rendue ou exportée, par exemple vers PDF, des images et d'autres formats pris en charge. Cela permet de garantir que le rendu de la présentation reste cohérent sur différents environnements. L'article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

L'enregistrement de polices personnalisées pour le rendu est distinct de l'intégration de polices dans un fichier PPTX. Si une police doit être stockée à l'intérieur même de la présentation, utilisez explicitement les fonctionnalités d'intégration de polices.

{{% alert color="info" %}} 

Aspose Slides vous permet de charger ces polices en utilisant [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices utilisées dans une présentation sans les installer sur le système. Cela affecte le rendu des exports—tels que PDF, images et autres formats pris en charge—de façon à ce que les documents générés restent cohérents d'un environnement à l'autre. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de police.  
2. Appelez la méthode statique [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices depuis ces dossiers.  
3. Chargez et rendez/exportez la présentation.  
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/clearcache/) pour vider le cache des polices.

L'exemple de code suivant illustre le processus de chargement des polices :

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Définir les dossiers contenant les fichiers de police personnalisés.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Charger les polices personnalisées depuis les dossiers spécifiés.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendre/exporter la présentation (par ex., en PDF, images ou autres formats) en utilisant les polices chargées.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Vider le cache des polices après la fin du travail.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Remarque" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.  
2. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**

Aspose.Slides fournit [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/getfontfolders/) pour vous permettre de retrouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code C++ montre comment utiliser la méthode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/getfontfolders/) :

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Cette ligne renvoie les dossiers qui sont vérifiés pour les fichiers de police.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de police du système.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec une présentation**

Aspose.Slides fournit la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) pour vous permettre de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code C++ montre comment utiliser la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //travailler avec la présentation
    //CustomFont1, CustomFont2 ainsi que les polices provenant des dossiers assets\fonts et global\fonts et de leurs sous-dossiers sont disponibles pour la présentation
}
```

## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/loadexternalfont/) pour vous permettre de charger des polices externes dans un tableau d'octets.

Ce code C++ démontre le processus de chargement d'une police sous forme de tableau d'octets :

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Le chemin du répertoire des documents
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

### Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

### Les polices personnalisées sont-elles automatiquement intégrées dans le PPTX résultant ?

Non. L'enregistrement d'une police pour le rendu n'est pas identique à son intégration dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser explicitement les [fonctions d'intégration](/slides/fr/cpp/embedded-font/).

### Puis-je contrôler le comportement de secours lorsqu'une police personnalisée ne possède pas certains glyphes ?

Oui. Configurez [font substitution](/slides/fr/cpp/font-substitution/), [replacement rules](/slides/fr/cpp/font-replacement/), et [fallback sets](/slides/fr/cpp/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est manquant.

### Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer au niveau du système ?

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices du système dans l'image du conteneur.

### Qu'en est‑il de la licence —puis‑je intégrer n'importe quelle police personnalisée sans restriction ?

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Vérifiez toujours le contrat de licence (EULA) de la police avant de distribuer les sorties.