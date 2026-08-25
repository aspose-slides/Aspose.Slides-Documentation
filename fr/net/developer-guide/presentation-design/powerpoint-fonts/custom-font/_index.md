---
title: "Personnaliser les polices PowerPoint dans .NET"
linktitle: "Police personnalisée"
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
description: "Personnalisez les polices des diapositives PowerPoint avec Aspose.Slides pour .NET afin de garder vos présentations nettes et cohérentes sur n’importe quel appareil."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'utiliser des polices personnalisées dans les présentations sans les installer sur le système d’exploitation. Vous pouvez charger des polices à partir de dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lors du rendu ou de l’exportation d’une présentation, par exemple vers PDF, images et autres formats pris en charge. Cela permet de maintenir une sortie de présentation cohérente entre différents environnements. L’article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

L’enregistrement de polices personnalisées pour le rendu est distinct de l’incorporation de polices dans un fichier PPTX. Si une police doit être stockée à l’intérieur même de la présentation, utilisez explicitement les fonctionnalités d’incorporation de polices.

Un thème de présentation peut référencer différentes familles de polices pour des systèmes d’écriture individuels. Ces correspondances stockent les noms de polices mais n’installent ni ne chargent les fichiers de police. Consultez [Script-Specific Theme Fonts](/slides/fr/net/script-specific-font-mappings/) pour gérer les correspondances, et utilisez les options de chargement ci‑dessous pour rendre les polices référencées disponibles pour un rendu cohérent.

{{% alert color="info" title="Note" %}}
Aspose Slides vous permet de charger ces polices en utilisant la méthode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Polices TrueType (.ttf) et collections TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d’exportation — comme PDF, images et autres formats pris en charge — de sorte que les documents résultants restent cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Indiquez un ou plusieurs dossiers contenant les fichiers de police.
2. Appelez la méthode statique [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.ClearCache](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/clearcache/) pour vider le cache des polices.

L’exemple de code suivant illustre le processus de chargement des polices :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Définir les dossiers contenant les fichiers de polices personnalisées.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Charger les polices personnalisées depuis les dossiers spécifiés.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendre/exporter la présentation (par ex. en PDF, images ou autres formats) en utilisant les polices chargées.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Vider le cache des polices après la fin du travail.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l’ordre d’initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d’exploitation.
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**

Aspose.Slides fournit la méthode [GetFontFolders](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/getfontfolders/) qui vous permet de retrouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code C# montre comment utiliser [GetFontFolders](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/getfontfolders/) :

```c#
using Aspose.Slides;

// Cette ligne renvoie les dossiers qui sont vérifiés pour les fichiers de police.
// Il s'agit des dossiers ajoutés via la méthode LoadExternalFonts et des dossiers de polices système.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec une présentation**

Aspose.Slides fournit la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/documentlevelfontsources/) qui vous permet de spécifier les polices externes à utiliser avec la présentation.

Ce code C# montre comment utiliser la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/documentlevelfontsources/) :

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Travailler avec la présentation
    // CustomFont1, CustomFont2 et les polices provenant des dossiers assets\fonts & global\fonts ainsi que leurs sous‑dossiers sont disponibles pour la présentation
}
```

## **Gérer les polices de façon externe**

Aspose.Slides fournit la méthode [LoadExternalFont](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code C# démontre le processus de chargement d’une police sous forme de tableau d’octets :

```c#
using Aspose.Slides;

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

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’incorporer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser explicitement les [fonctions d’incorporation](/slides/fr/net/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu'une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/net/font-substitution/), les [règles de remplacement](/slides/fr/net/font-replacement/) et les [ensembles de secours](/slides/fr/net/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer au niveau du système ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d’octets. Cela élimine toute dépendance aux répertoires de polices système dans l’image du conteneur.

> **Note for Linux/Docker** : Lors de l’appel à `FontsLoader.LoadExternalFonts`, assurez‑vous que chaque entrée du tableau `directories` contient un chemin non vide pointant vers un répertoire existant. Si une variable d’environnement utilisée pour construire le chemin de police est indéfinie ou vide, Aspose.Slides peut tenter de résoudre la valeur vide comme un chemin complet, ce qui entraîne une `System.ArgumentException`.

**Qu'en est‑il de la licence — puis‑je incorporer n'importe quelle police personnalisée sans restrictions ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’incorporation ou l’utilisation commerciale. Consultez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.