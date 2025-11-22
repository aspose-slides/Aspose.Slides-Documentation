---
title: Police PowerPoint personnalisée en C#
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/net/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Polices personnalisées PowerPoint en C#"
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices utilisées dans les présentations sans avoir à les installer. Les polices sont chargées à partir d'un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) et appelez la méthode [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Chargez la présentation qui sera rendue.
3. Videz le cache de la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Ce code C# illustre le processus de chargement des polices :
``` csharp
// Le chemin vers le répertoire des documents
string dataDir = "C:\\";

// dossiers où rechercher les polices
String[] folders = new String[] { dataDir };

// Charge les polices du répertoire de polices personnalisé
FontsLoader.LoadExternalFonts(folders);

// Effectuer un travail et rendre la présentation/la diapositive
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Vide le cache des polices
FontsLoader.ClearCache();
```


## **Obtenir le dossier des polices personnalisées**
Aspose.Slides fournit la méthode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) qui vous permet de retrouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code C# montre comment utiliser [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) :
```c#
// Cette ligne affiche les dossiers qui sont vérifiés pour les fichiers de polices.
// Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec la présentation**
Aspose.Slides offre la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) qui vous permet de spécifier les polices externes à utiliser avec la présentation.

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

Aspose.Slides fournit la méthode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code C# illustre le processus de chargement d'une police à partir d'un tableau d'octets : 
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

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d’exportation.

**Les polices personnalisées sont-elles automatiquement incorporées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’incorporer dans un PPTX. Si vous devez inclure la police dans le fichier de présentation, vous devez utiliser les [fonctionnalités d’incorporation](/slides/fr/net/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu’une police personnalisée ne contient pas certains glyphes ?**

Oui. Configurez la [substitution de polices](/slides/fr/net/font-substitution/), les [règles de remplacement](/slides/fr/net/font-replacement/) et les [ensembles de secours](/slides/fr/net/fallback-font/) pour définir précisément la police à utiliser lorsque le glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer à l’échelle du système ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d’octets. Cela élimine toute dépendance aux répertoires de polices système dans l’image du conteneur.

**Qu’en est‑il de la licence—puis‑je incorporer n’importe quelle police personnalisée sans restriction ?**

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l’incorporation ou l’usage commercial. Consultez toujours le CLUF de la police avant de distribuer les résultats.