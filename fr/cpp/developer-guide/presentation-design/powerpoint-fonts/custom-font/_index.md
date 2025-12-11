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
- charger une police
- gérer les polices
- dossier de polices
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour C++ afin de garantir que vos présentations restent nettes et cohérentes sur tous les appareils."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices qui seront rendues dans les présentations sans devoir les installer. Les polices sont chargées à partir d'un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) et appelez la méthode [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. Chargez la présentation qui sera rendue.
3. Videz le cache de la classe [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

Ce code C++ montre le processus de chargement des polices :
``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Définit le chemin des polices
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Charge les polices du répertoire de polices personnalisé
FontsLoader::LoadExternalFonts(folders);

// Effectue des opérations et rend la présentation/la diapositive
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Vide le cache des polices
FontsLoader::ClearCache();
```


## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) pour vous permettre de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code C++ vous montre comment utiliser la méthode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) :
``` cpp
// Cette ligne affiche les dossiers qui sont vérifiés pour les fichiers de police.
// Il s'agit des dossiers ajoutés via la méthode LoadExternalFonts et des dossiers de police système.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) pour vous permettre de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code C++ vous montre comment utiliser la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //travailler avec la présentation
    //CustomFont1, CustomFont2 ainsi que les polices provenant des dossiers assets\fonts & global\fonts et de leurs sous-dossiers sont disponibles pour la présentation
}
```


## **Gérer les polices externement**
Aspose.Slides fournit la méthode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) pour vous permettre de charger des polices externes dans un tableau d'octets.

Ce code C++ montre le processus de chargement d’une police dans un tableau d'octets :
```cpp
// Le chemin du répertoire de documents
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

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont-elles automatiquement incorporées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'incorporer dans un PPTX. Si vous avez besoin que la police soit intégrée dans le fichier de présentation, vous devez utiliser les [fonctionnalités d'incorporation](/slides/fr/cpp/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu'une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/cpp/font-substitution/), les [règles de remplacement](/slides/fr/cpp/font-replacement/) et les [ensembles de secours](/slides/fr/cpp/fallback-font/) pour définir exactement quelle police est utilisée lorsqu'un glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer au niveau du système ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices du système dans l'image du conteneur.

**Qu'en est-il de la licence — puis-je incorporer n'importe quelle police personnalisée sans restrictions ?**

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l'incorporation ou l'utilisation commerciale. Consultez toujours le CLUF de la police avant de diffuser les résultats.