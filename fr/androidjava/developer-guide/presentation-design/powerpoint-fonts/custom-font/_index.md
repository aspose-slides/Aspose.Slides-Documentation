---
title: Personnaliser les polices PowerPoint sur Android
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Personnalisez les polices des diapositives PowerPoint avec Aspose.Slides pour Android via Java afin de garder vos présentations nettes et cohérentes sur n'importe quel appareil."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans les présentations sans avoir à installer ces polices. Les polices sont chargées à partir d'un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) et appelez la méthode [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Chargez la présentation qui sera rendue.
3. [Videz le cache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) dans la classe [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

Ce code Java montre le processus de chargement des polices :
```java
// Dossiers où chercher les polices
String[] folders = new String[] { externalFontsDir };

// Charge les polices du répertoire de polices personnalisées
FontsLoader.loadExternalFonts(folders);

// Effectuez des opérations et effectuez le rendu de la présentation/diapositive
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Vide le cache des polices
    FontsLoader.clearCache();
}
```


## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) qui vous permet de rechercher les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code Java vous montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) :
```java
// Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code Java vous montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Travail avec la présentation
    // CustomFont1, CustomFont2 et les polices provenant des dossiers assets\fonts & global\fonts ainsi que leurs sous‑dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code Java montre le processus de chargement d'une police à partir d'un tableau d'octets :
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


## **FAQ**

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont-elles automatiquement incorporées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'intégrer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les [embedding features](/slides/fr/androidjava/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu'une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [font substitution](/slides/fr/androidjava/font-substitution/), les [replacement rules](/slides/fr/androidjava/font-replacement/) et les [fallback sets](/slides/fr/androidjava/fallback-font/) pour définir exactement la police à utiliser lorsque le glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer à l'échelle du système ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices du système dans l'image du conteneur.

**Qu'en est-il de la licence —puis-je incorporer n'importe quelle police personnalisée sans restriction ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Examinez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.