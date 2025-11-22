---
title: Police PowerPoint personnalisée en JavaScript
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/nodejs-java/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Polices personnalisées PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices à l'aide de la méthode [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans les présentations sans avoir à les installer. Les polices sont chargées depuis un répertoire personnalisé. 

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) et appelez la méthode [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Chargez la présentation qui sera rendue.
3. [Videz le cache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--) dans la classe [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader).

Ce code JavaScript démontre le processus de chargement des polices :
```javascript
// Dossiers à rechercher des polices
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// Charge les polices du répertoire de polices personnalisées
aspose.slides.FontsLoader.loadExternalFonts(folders);
// Effectuer du travail et rendre la présentation/diapositive
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
    // Vide le cache des polices
    aspose.slides.FontsLoader.clearCache();
}
```


## **Obtenir le dossier des polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices système.

Ce code JavaScript montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) :
```javascript
// Cette ligne affiche les dossiers où les fichiers de police sont recherchés.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices système.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **Spécifier les polices personnalisées utilisées avec la présentation**
Aspose.Slides fournit la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) qui vous permet de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code JavaScript montre comment utiliser la propriété [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) :
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Travailler avec la présentation
    // CustomFont1, CustomFont2 et les polices des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code JavaScript démontre le processus de chargement des polices à partir d'un tableau d'octets :
```javascript
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

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont-elles automatiquement intégrées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’intégrer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les [fonctions d’intégration](/slides/fr/nodejs-java/embedded-font/).

**Puis-je contrôler le comportement de repli lorsqu'une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/nodejs-java/font-substitution/), les [règles de remplacement](/slides/fr/nodejs-java/font-replacement/) et les [ensembles de repli](/slides/fr/nodejs-java/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est absent.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer à l'échelle du système ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d’octets. Cela supprime toute dépendance aux répertoires de polices système dans l’image du conteneur.

**Qu'en est-il de la licence — puis-je intégrer n'importe quelle police personnalisée sans restrictions ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’intégration ou l’usage commercial. Consultez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.