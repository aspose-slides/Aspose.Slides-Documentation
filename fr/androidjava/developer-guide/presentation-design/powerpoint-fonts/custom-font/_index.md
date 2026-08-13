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
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour Android via Java afin de garder vos présentations nettes et cohérentes sur tout appareil."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'utiliser des polices personnalisées dans les présentations sans les installer sur le système d'exploitation. Vous pouvez charger des polices depuis des dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lors du rendu ou de l'exportation d'une présentation, par exemple vers PDF, images et autres formats pris en charge. Cela permet de garder une sortie de présentation cohérente entre différents environnements. L'article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment nettoyer le cache des polices après avoir travaillé avec des polices externes.

L'enregistrement de polices personnalisées pour le rendu est distinct de l'intégration de polices dans un fichier PPTX. Si une police doit être stockée à l'intérieur même de la présentation, utilisez explicitement les fonctionnalités d'intégration de polices.

{{% alert color="info" %}} 

Aspose Slides vous permet de charger ces polices à l'aide de la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et collection TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation—tel que PDF, images et autres formats pris en charge—de sorte que les documents résultants restent cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de police.
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontsLoader#clearCache--) pour vider le cache des polices.

Le code suivant montre le processus de chargement des polices :

```java
import com.aspose.slides.*;

// Définir les dossiers contenant les fichiers de police personnalisés.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Charger les polices personnalisées depuis les dossiers spécifiés.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Rendre/exporter la présentation (p. ex. en PDF, images ou autres formats) en utilisant les polices chargées.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vider le cache des polices après la fin du travail.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.
2. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides propose la méthode [getFontFolders](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) qui vous permet de retrouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code Java montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) :

```java
import com.aspose.slides.*;

// Cette ligne renvoie les dossiers où les fichiers de police sont recherchés.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices du système.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides propose la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes à utiliser avec la présentation.

Ce code Java montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

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

## **Gérer les polices de manière externe**

Aspose.Slides propose la méthode [loadExternalFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code Java montre le processus de chargement d'une police à partir d'un tableau d'octets :

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

### Les polices personnalisées sont‑elles automatiquement intégrées dans le PPTX résultant ?

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’intégrer dans un PPTX. Si vous avez besoin que la police soit contenue dans le fichier de présentation, vous devez utiliser explicitement les [fonctions d’intégration](/slides/fr/androidjava/embedded-font/).

### Puis‑je contrôler le comportement de secours lorsqu’une police personnalisée ne possède pas certains glyphes ?

Oui. Configurez la [substitution de police](/slides/fr/androidjava/font-substitution/), les [règles de remplacement](/slides/fr/androidjava/font-replacement/) et les [ensembles de secours](/slides/fr/androidjava/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est absent.

### Puis‑je utiliser des polices dans des conteneurs Linux/Docker sans les installer globalement ?

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices du système dans l'image du conteneur.

### Qu’en est‑il de la licence —puis‑je intégrer n’importe quelle police personnalisée sans restriction ?

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’intégration ou l’utilisation commerciale. Consultez toujours le contrat de licence (EULA) de la police avant de diffuser les sorties.