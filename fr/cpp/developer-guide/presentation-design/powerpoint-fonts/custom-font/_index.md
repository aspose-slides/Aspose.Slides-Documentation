---
title: Police personnalisée en C++
type: docs
weight: 20
url: /cpp/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Polices personnalisées PowerPoint en C++"
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Polices TrueType (.ttf) et Collection TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des Polices Personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans des présentations sans avoir à installer ces polices. Les polices sont chargées à partir d'un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) et appelez la méthode [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. Chargez la présentation qui sera rendue.
3. Videz le cache de la classe [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

Ce code C++ démontre le processus de chargement de polices :

```cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Définit le chemin des polices
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Charge les polices du répertoire de polices personnalisées
FontsLoader::LoadExternalFonts(folders);

// Effectuez des travaux et effectuez le rendu de la présentation / de la diapositive
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Vide le cache des polices
FontsLoader::ClearCache();
```

## **Obtenir le Dossier de Polices Personnalisées**
Aspose.Slides fournit [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) pour vous permettre de trouver des dossiers de polices. Cette méthode retourne des dossiers ajoutés via la méthode `LoadExternalFonts` et les dossiers de polices système.

Ce code C++ vous montre comment utiliser la méthode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) :

```cpp
// Cette ligne affiche les dossiers qui sont vérifiés pour les fichiers de polices.
// Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Spécifier les Polices Personnalisées Utilisées avec la Présentation**
Aspose.Slides fournit la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) pour vous permettre de spécifier des polices externes qui seront utilisées avec la présentation.

Ce code C++ vous montre comment utiliser la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

```cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // travaillez avec la présentation
    // CustomFont1, CustomFont2 ainsi que les polices des dossiers assets\fonts et global\fonts et leurs sous-dossiers sont disponibles pour la présentation
}
```

## **Gérer les Polices Externes**
Aspose.Slides fournit la méthode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) pour vous permettre de charger des polices externes dans un tableau d'octets.

Ce code C++ démontre le processus de chargement de polices dans un tableau d'octets :

```cpp
// Le chemin vers le répertoire des documents
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```