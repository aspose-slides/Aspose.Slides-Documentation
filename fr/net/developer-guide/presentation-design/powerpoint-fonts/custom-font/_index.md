---
title: Personnaliser les polices PowerPoint dans .NET
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour .NET afin de garder vos présentations nettes et cohérentes sur n'importe quel appareil."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation — comme le PDF, les images et d'autres formats pris en charge — de sorte que les documents résultants aient le même aspect sur tous les environnements. Les polices sont chargées depuis des répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.
2. Appelez la méthode statique [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) pour vider le cache des polices.

L'exemple de code suivant montre le processus de chargement des polices :
```cs
// Définir les dossiers contenant les fichiers de polices personnalisées.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Charger les polices personnalisées depuis les dossiers spécifiés.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendre/exporter la présentation (par ex. en PDF, images ou autres formats) en utilisant les polices chargées.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Vider le cache des polices une fois le travail terminé.
FontsLoader.ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides propose la méthode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code C# montre comment utiliser [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) :
```c#
// Cette ligne affiche les dossiers qui sont vérifiés pour les fichiers de polices.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides propose la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) qui vous permet de spécifier les polices externes à utiliser avec la présentation.

Ce code C# montre comment utiliser la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) :
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Travailler avec la présentation
    // CustomFont1, CustomFont2, et les polices provenant des dossiers assets\fonts et global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
}
```


## **Gérer les polices de façon externe**

Aspose.Slides propose la méthode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code C# montre le processus de chargement de police à partir d'un tableau d'octets : 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // police externe chargée pendant la durée de vie de la présentation
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **FAQ**

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont-elles incorporées automatiquement dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas la même chose que l’incorporer dans un PPTX. Si vous avez besoin que la police soit intégrée dans le fichier de présentation, vous devez utiliser les [fonctionnalités d’intégration](/slides/fr/net/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu’une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/net/font-substitution/), les [règles de remplacement](/slides/fr/net/font-replacement/) et les [ensembles de secours](/slides/fr/net/fallback-font/) pour définir exactement la police utilisée lorsque le glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer globalement sur le système ?**

Oui. Dirigez‑vous vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d’octets. Cela supprime toute dépendance aux répertoires de polices du système dans l’image du conteneur.

**Qu’en est‑il de la licence—puis‑je incorporer n’importe quelle police personnalisée sans restrictions ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’intégration ou l’utilisation commerciale. Vérifiez toujours le contrat de licence (EULA) de la police avant de diffuser les résultats.