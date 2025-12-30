---
title: Personnaliser les polices PowerPoint en JavaScript
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
description: "Personnalisez les polices des diapositives PowerPoint avec JavaScript et Aspose.Slides pour Node.js via Java afin de garder vos présentations nettes et cohérentes sur n’importe quel appareil."
---

{{% alert color="primary" %}} 

Aspose Slides vous permet de charger ces polices en utilisant la méthode [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation — comme le PDF, les images et d'autres formats pris en charge — de sorte que les documents résultants restent cohérents entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.  
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) pour charger les polices à partir de ces dossiers.  
3. Chargez et rendez/exportez la présentation.  
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) pour nettoyer le cache des polices.  

L'exemple de code suivant montre le processus de chargement des polices :
```js
// Définir les dossiers contenant les fichiers de polices personnalisées.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Charger les polices personnalisées depuis les dossiers spécifiés.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Rendre/exporter la présentation (p. ex., en PDF, images ou autres formats) en utilisant les polices chargées.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vider le cache des polices après la fin du travail.
    aspose.slides.FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.  
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir le dossier des polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` ainsi que les dossiers de polices du système.

Ce code JavaScript montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) :
```javascript
// Cette ligne renvoie les dossiers où les fichiers de polices sont recherchés.
// Ce sont les dossiers ajoutés via la méthode LoadExternalFonts et les dossiers de polices du système.
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
    // CustomFont1, CustomFont2, et les polices des dossiers assets\fonts & global\fonts ainsi que leurs sous-dossiers sont disponibles pour la présentation
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer les polices externes**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) qui vous permet de charger des polices externes à partir de données binaires.

Ce code JavaScript démontre le processus de chargement d'une police à partir d'un tableau d'octets :
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

Non. Enregistrer une police pour le rendu n'est pas la même chose que l'intégrer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les [fonctions d'intégration](/slides/fr/nodejs-java/embedded-font/).

**Puis-je contrôler le comportement de secours lorsqu'une police personnalisée ne possède pas certains glyphes ?**  

Oui. Configurez la [substitution de police](/slides/fr/nodejs-java/font-substitution/), les [règles de remplacement](/slides/fr/nodejs-java/font-replacement/) et les [ensembles de secours](/slides/fr/nodejs-java/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est manquant.

**Puis-je utiliser des polices dans des conteneurs Linux/Docker sans les installer au niveau du système ?**  

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices système dans l'image du conteneur.

**Qu'en est-il de la licence —puis-je intégrer n'importe quelle police personnalisée sans restriction ?**  

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l'intégration ou l'utilisation commerciale. Examinez toujours le CLUF de la police avant de distribuer les résultats.