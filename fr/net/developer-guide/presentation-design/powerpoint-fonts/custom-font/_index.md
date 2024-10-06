---
title: Police PowerPoint personnalisée en C#
linktitle: Police personnalisée
type: docs
weight: 20
url: /net/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Polices personnalisées PowerPoint en C#"
---

{{% alert color="primary" %}} 

Aspose Slides permet de charger ces polices en utilisant la méthode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Polices TrueType (.ttf) et collection TrueType (.ttc). Voir [TrueType](https://fr.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://fr.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans les présentations sans avoir à installer ces polices. Les polices sont chargées à partir d'un répertoire personnalisé.

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) et appelez la méthode [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Chargez la présentation qui sera rendue.
3. Videz le cache dans la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Ce code C# démontre le processus de chargement de polices :

``` csharp
// Le chemin vers le répertoire des documents
string dataDir = "C:\\";

// dossiers pour chercher des polices
String[] folders = new String[] { dataDir };

// Charge les polices du répertoire de polices personnalisées
FontsLoader.LoadExternalFonts(folders);

// Effectuez quelques opérations et effectuez le rendu de la présentation / des diapositives
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Videz le cache des polices
FontsLoader.ClearCache();
```

## **Obtenir le dossier des polices personnalisées**
Aspose.Slides fournit la méthode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) pour vous permettre de trouver des dossiers de polices. Cette méthode retourne les dossiers ajoutés via la méthode `LoadExternalFonts` et les dossiers de polices système.

Ce code C# vous montre comment utiliser [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) :

```c#
// Cette ligne affiche les dossiers qui sont vérifiés pour les fichiers de polices.
// Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec la présentation**
Aspose.Slides fournit la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) pour vous permettre de spécifier des polices externes qui seront utilisées avec la présentation.

Ce code C# vous montre comment utiliser la propriété [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) :

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Travailler avec la présentation
    // CustomFont1, CustomFont2, et polices des dossiers assets\fonts & global\fonts et leurs sous-dossiers sont disponibles pour la présentation
}
```

## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) pour vous permettre de charger des polices externes à partir de données binaires.

Ce code C# démontre le processus de chargement de polices à partir d'un tableau d'octets :

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