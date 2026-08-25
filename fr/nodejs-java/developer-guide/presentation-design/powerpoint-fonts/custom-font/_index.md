---
title: Personnaliser les polices PowerPoint avec JavaScript
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personnalisez les polices des diapositives PowerPoint avec JavaScript et Aspose.Slides pour Node.js via Java afin de garder vos présentations nettes et cohérentes sur tous les appareils."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'utiliser des polices personnalisées dans les présentations sans les installer sur le système d'exploitation. Vous pouvez charger des polices à partir de dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lorsqu'une présentation est rendue ou exportée, par exemple vers PDF, images et d'autres formats pris en charge. Cela permet de maintenir la sortie de la présentation cohérente sur différents environnements. L'article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

Enregistrer des polices personnalisées pour le rendu est séparé de l'incorporation de polices dans un fichier PPTX. Si une police doit être stockée à l'intérieur de la présentation elle‑même, utilisez explicitement les fonctionnalités d'incorporation de polices.

Un thème de présentation peut référencer différentes familles de polices pour des systèmes d'écriture individuels. Ces mappages stockent les noms de polices mais n'installent ni ne chargent les fichiers de polices. Voir [Script-Specific Theme Fonts](/slides/fr/nodejs-java/script-specific-font-mappings/) pour gérer les mappages, et utilisez les options de chargement ci‑dessous pour rendre les polices référencées disponibles pour un rendu cohérent.

{{% alert color="info" title="Note" %}}
Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation — comme PDF, images et autres formats pris en charge — de sorte que les documents générés soient cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.  
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices à partir de ces dossiers.  
3. Chargez et rendez/exportez la présentation.  
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/clearcache/) pour vider le cache des polices.

L'exemple de code suivant montre le processus de chargement des polices :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Définir les dossiers contenant les fichiers de polices personnalisées.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Charger les polices personnalisées à partir des dossiers spécifiés.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Rendre/exporter la présentation (par ex. en PDF, images ou autres formats) en utilisant les polices chargées.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vider le cache des polices après la fin du travail.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche de polices, mais ne modifie pas l'ordre d'initialisation des polices.
Les polices sont initialisées dans cet ordre :

1. Le chemin de polices par défaut du système d'exploitation.  
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtenir le dossier de polices personnalisées**

Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code JavaScript vous montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cette ligne affiche les dossiers où les fichiers de polices sont recherchés.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts ainsi que les dossiers de polices système.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Spécifier les polices personnalisées utilisées avec la présentation**

Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code JavaScript vous montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Travailler avec la présentation
    // CustomFont1, CustomFont2 et les polices provenant des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code JavaScript montre le processus de chargement d'une police à partir d'un tableau d'octets :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // police externe chargée pendant la durée de vie de la présentation
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

### Les polices personnalisées sont‑elles automatiquement incorporées dans le PPTX résultant ?

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'incorporer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les [fonctions d'incorporation](/slides/fr/nodejs-java/embedded-font/).

### Puis‑je contrôler le comportement de secours lorsqu'une police personnalisée ne contient pas certains glyphes ?

Oui. Configurez [font substitution](/slides/fr/nodejs-java/font-substitution/), [replacement rules](/slides/fr/nodejs-java/font-replacement/) et [fallback sets](/slides/fr/nodejs-java/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est absent.

### Puis‑je utiliser des polices dans des conteneurs Linux/Docker sans les installer système‑wide ?

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela élimine toute dépendance aux répertoires de polices système dans l'image du conteneur.

### Qu'en est‑il de la licence — puis‑je incorporer n'importe quelle police personnalisée sans restrictions ?

Vous êtes responsable de la conformité aux licences des polices. Les conditions varient ; certaines licences interdisent l'incorporation ou l'utilisation commerciale. Examinez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.