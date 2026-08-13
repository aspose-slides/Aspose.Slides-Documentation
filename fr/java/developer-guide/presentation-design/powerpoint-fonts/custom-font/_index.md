---
title: Personnaliser les polices PowerPoint en Java
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/java/custom-font/
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
- Java
- Aspose.Slides
description: "Personnalisez les polices dans les diapositives PowerPoint avec Aspose.Slides pour Java afin de garder vos présentations nettes et cohérentes sur n'importe quel appareil."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d’utiliser des polices personnalisées dans les présentations sans les installer sur le système d’exploitation. Vous pouvez charger des polices depuis des dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lorsqu’une présentation est rendue ou exportée, par exemple vers PDF, images et autres formats pris en charge. Cela permet de garantir que la sortie de la présentation reste cohérente sur différents environnements. L’article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

L’enregistrement de polices personnalisées pour le rendu est distinct de l’incorporation de polices dans un fichier PPTX. Si une police doit être stockée à l’intérieur même de la présentation, utilisez explicitement les fonctionnalités d’incorporation de polices.

{{% alert color="info" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d’exportation — telle que PDF, images et autres formats pris en charge—de sorte que les documents résultants sont cohérents entre les environnements. Les polices sont chargées depuis des répertoires personnalisés.

1. Indiquez un ou plusieurs dossiers contenant les fichiers de police.  
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pour charger les polices à partir de ces dossiers.  
3. Chargez et rendez/exportez la présentation.  
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontsLoader#clearCache--) pour vider le cache des polices.

L’exemple de code suivant illustre le processus de chargement des polices :

```java
import com.aspose.slides.*;

// Définir les dossiers contenant les fichiers de police personnalisés.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Charger les polices personnalisées à partir des dossiers spécifiés.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Rendre/exporter la présentation (par ex. en PDF, images ou autres formats) en utilisant les polices chargées.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Effacer le cache des polices après la fin du traitement.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Remarque" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l’ordre d’initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d’exploitation.  
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**

Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#getFontFolders--) qui vous permet de retrouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code Java montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#getFontFolders--) :

```java
import com.aspose.slides.*;

// Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices du système.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec une présentation**

Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes à utiliser avec la présentation.  

Ce code Java montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

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
    // CustomFont1, CustomFont2 et les polices provenant des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code Java montre le processus de chargement d’une police à partir d’un tableau d’octets :

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

### Les polices personnalisées affectent-elles l’exportation vers tous les formats (PDF, PNG, SVG, HTML) ?

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d’exportation.

### Les polices personnalisées sont‑elles automatiquement incorporées dans le PPTX résultant ?

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’incorporer dans un PPTX. Si vous avez besoin que la police soit contenue dans le fichier de présentation, vous devez recourir aux [fonctions d’incorporation](/slides/fr/java/embedded-font/).

### Puis‑je contrôler le comportement de secours lorsqu’une police personnalisée ne possède pas certains glyphes ?

Oui. Configurez la [substitution de police](/slides/fr/java/font-substitution/), les [règles de remplacement](/slides/fr/java/font-replacement/) et les [ensembles de secours](/slides/fr/java/fallback-font/) pour définir exactement quelle police utiliser lorsqu’un glyphe requis est absent.

### Puis‑je utiliser des polices sous Linux/Docker sans les installer globalement ?

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d’octets. Cela supprime toute dépendance aux répertoires de polices du système dans l’image du conteneur.

### Qu’en est‑il de la licence — puis‑je incorporer n’importe quelle police personnalisée sans restriction ?

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’incorporation ou l’utilisation commerciale. Consultez toujours le contrat de licence (EULA) de la police avant de distribuer les sorties.