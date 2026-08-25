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
description: "Personnalisez les polices des diapositives PowerPoint avec Aspose.Slides pour Android via Java afin de garder vos présentations nettes et cohérentes sur tout appareil."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'utiliser des polices personnalisées dans les présentations sans les installer sur le système d'exploitation. Vous pouvez charger des polices depuis des dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lors du rendu ou de l'exportation d'une présentation, par exemple vers PDF, images et autres formats pris en charge. Cela permet de maintenir la cohérence du rendu de la présentation sur différents environnements. L'article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

L'enregistrement de polices personnalisées pour le rendu est distinct de l'intégration de polices dans un fichier PPTX. Si une police doit être stockée à l'intérieur même de la présentation, utilisez explicitement les fonctionnalités d'intégration de polices.

Un thème de présentation peut référencer différentes familles de polices pour des systèmes d'écriture individuels. Ces correspondances stockent les noms de polices mais n'installent ni ne chargent les fichiers de polices. Consultez [Polices de thème spécifiques au script](/slides/fr/androidjava/script-specific-font-mappings/) pour gérer les correspondances, et utilisez les options de chargement ci-dessous pour rendre les polices référencées disponibles pour un rendu cohérent.

{{% alert color="info" title="Note" %}}
Aspose Slides vous permet de charger ces polices à l'aide de la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et collections TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte le résultat de l'exportation — tel que PDF, images et autres formats pris en charge — de sorte que les documents générés restent cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pour charger les polices à partir de ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontsLoader#clearCache--) pour vider le cache des polices.

L'exemple de code suivant montre le processus de chargement des polices :

```java
import com.aspose.slides.*;

// Définir les dossiers contenant les fichiers de polices personnalisées.
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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ajoute des dossiers supplémentaires aux chemins de recherche de polices, mais ne modifie pas l'ordre d'initialisation des polices. Les polices sont initialisées dans cet ordre :

1. Le chemin de polices par défaut du système d'exploitation.
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) permettant de récupérer les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code Java vous montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) :

```java
import com.aspose.slides.*;

// Cette ligne renvoie les dossiers où les fichiers de police sont recherchés.
// Il s'agit des dossiers ajoutés via la méthode LoadExternalFonts et des dossiers de polices du système.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes à utiliser avec la présentation.

Ce code Java vous montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

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
    // CustomFont1, CustomFont2, et les polices des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer les polices de manière externe**

Aspose.Slides propose la méthode [loadExternalFont](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pour charger des polices externes à partir de données binaires.

Ce code Java démontre le processus de chargement de police à partir d'un tableau d'octets :

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
        //        police externe chargée pendant la durée de vie de la présentation
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

Oui. Les polices associées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

### Les polices personnalisées sont-elles automatiquement incorporées dans le PPTX résultant ?

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'intégrer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les [fonctionnalités d'intégration](/slides/fr/androidjava/embedded-font/).

### Puis-je contrôler le comportement de substitution lorsqu'une police personnalisée ne possède pas certains glyphes ?

Oui. Configurez la [substitution de polices](/slides/fr/androidjava/font-substitution/), les [règles de remplacement](/slides/fr/androidjava/font-replacement/) et les [ensembles de secours](/slides/fr/androidjava/fallback-font/) afin de définir précisément la police utilisée lorsqu'un glyphe demandé est absent.

### Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer à l'échelle du système ?

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d'octets. Cela élimine toute dépendance aux répertoires de polices du système dans l'image du conteneur.

### Qu'en est-il des licences — puis-je incorporer n'importe quelle police personnalisée sans restriction ?

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Vérifiez toujours le EULA de la police avant de distribuer les résultats.