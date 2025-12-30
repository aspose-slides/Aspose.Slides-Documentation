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
- dossier de police
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les polices des diapositives PowerPoint avec Aspose.Slides pour C++ afin de garder vos présentations nettes et cohérentes sur tous les appareils."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d’exportation — comme le PDF, les images et d’autres formats pris en charge — de sorte que les documents résultants aient une apparence cohérente sur tous les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de police.
2. Appelez la méthode statique [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) pour vider le cache des polices.

L’exemple de code suivant montre le processus de chargement des polices :
```cpp
// Définissez les dossiers contenant les fichiers de polices personnalisées.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Chargez les polices personnalisées depuis les dossiers spécifiés.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendre/exporter la présentation (par exemple, en PDF, images ou autres formats) en utilisant les polices chargées.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Videz le cache des polices après la fin du travail.
FontsLoader::ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l’ordre d’initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d’exploitation.  
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides fournit [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) pour vous permettre de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code C++ montre comment utiliser la méthode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) :
``` cpp
// Cette ligne affiche les dossiers qui sont vérifiés pour les fichiers de police.
// Il s'agit des dossiers ajoutés via la méthode LoadExternalFonts et des dossiers de police du système.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides fournit la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) pour vous permettre de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code C++ montre comment utiliser la propriété [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //travail avec la présentation
    //CustomFont1, CustomFont2 ainsi que les polices des dossiers assets\fonts & global\fonts et de leurs sous-dossiers sont disponibles pour la présentation
}
```


## **Manage Fonts Externally**
Aspose.Slides fournit la méthode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) pour vous permettre de charger des polices externes dans un tableau d’octets.

Ce code C++ démontre le processus de chargement des polices dans un tableau d’octets :
```cpp
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

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont‑elles automatiquement intégrées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’intégrer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les [fonctions d’intégration](/slides/fr/cpp/embedded-font/).

**Puis‑je contrôler le comportement de secours lorsqu’une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/cpp/font-substitution/), les [règles de remplacement](/slides/fr/cpp/font-replacement/) et les [ensembles de secours](/slides/fr/cpp/fallback-font/) pour définir précisément la police à utiliser lorsque le glyphe demandé est absent.

**Puis‑je utiliser les polices dans des conteneurs Linux/Docker sans les installer sur le système ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d’octets. Cela élimine toute dépendance aux répertoires de polices du système dans l’image du conteneur.

**Et la licence — puis‑je intégrer n’importe quelle police personnalisée sans restriction ?**

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l’intégration ou l’utilisation commerciale. Consultez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.