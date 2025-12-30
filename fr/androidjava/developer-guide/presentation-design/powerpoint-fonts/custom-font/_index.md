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

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation — comme le PDF, les images et d'autres formats pris en charge — de sorte que les documents résultants soient cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.  
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pour charger les polices depuis ces dossiers.  
3. Chargez et rendez/exportez la présentation.  
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) pour vider le cache des polices.

L'exemple de code suivant démontre le processus de chargement des polices :
```java
// Définir les dossiers contenant les fichiers de police personnalisés.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Charger les polices personnalisées à partir des dossiers spécifiés.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Rendre/exporter la présentation (par exemple, en PDF, images ou autres formats) en utilisant les polices chargées.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vider le cache des polices après la fin du travail.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.  
2. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code Java montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) :
```java
// Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
// Ce sont des dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices du système.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code Java montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Travailler avec la présentation
    // CustomFont1, CustomFont2 et les polices des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les polices externes**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code Java démontre le processus de chargement d’une police à partir d’un tableau d’octets :
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

**Les polices personnalisées sont-elles automatiquement intégrées dans le PPTX résultant ?**  
Non. Enregistrer une police pour le rendu n'est pas équivalent à l'intégrer dans un PPTX. Si vous devez inclure la police dans le fichier de présentation, vous devez utiliser les [fonctionnalités d'intégration](/slides/fr/androidjava/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu'une police personnalisée manque certains glyphes ?**  
Oui. Configurez la [substitution de polices](/slides/fr/androidjava/font-substitution/), les [règles de remplacement](/slides/fr/androidjava/font-replacement/) et les [ensembles de secours](/slides/fr/androidjava/fallback-font/) pour définir exactement la police utilisée lorsqu'un glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer sur le système ?**  
Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices du système dans l'image du conteneur.

**Qu'en est-il de la licence — puis-je intégrer n'importe quelle police personnalisée sans restrictions ?**  
Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Revoyez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.