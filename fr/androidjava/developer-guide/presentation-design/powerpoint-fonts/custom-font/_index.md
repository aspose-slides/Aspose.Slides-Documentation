---
title: Police PowerPoint personnalisée en Java
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/androidjava/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Polices PowerPoint personnalisées en Java"
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des Polices Personnalisées**

Aspose.Slides vous permet de charger des polices qui sont affichées dans des présentations sans avoir à installer ces polices. Les polices sont chargées à partir d'un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) et appelez la méthode [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Chargez la présentation qui sera rendue.
3. [Videz le cache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) dans la classe [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

Ce code Java démontre le processus de chargement des polices :

```java
// Dossiers pour chercher des polices
String[] folders = new String[] { externalFontsDir };

// Charge les polices du répertoire de polices personnalisé
FontsLoader.loadExternalFonts(folders);

// Effectuez quelques travaux et réalisez le rendu de la présentation/de la diapositive
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Vide le cache des polices
    FontsLoader.clearCache();
}
```

## **Obtenir le Dossier des Polices Personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) pour vous permettre de trouver les dossiers de polices. Cette méthode retourne les dossiers ajoutés via la méthode `LoadExternalFonts` et les dossiers de polices système.

Ce code Java vous montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Cette ligne affiche les dossiers où les fichiers de polices sont recherchés.
// Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Spécifier les Polices Personnalisées Utilisées avec la Présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pour vous permettre de spécifier des polices externes qui seront utilisées avec la présentation.

Ce code Java vous montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Travaillez avec la présentation
    // CustomFont1, CustomFont2, et les polices des dossiers assets\fonts & global\fonts et leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer les Polices Externes**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pour vous permettre de charger des polices externes à partir de données binaires.

Ce code Java démontre le processus de chargement de polices à partir d'un tableau de bytes :

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // police externe chargée pendant la durée de vie de la présentation
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```