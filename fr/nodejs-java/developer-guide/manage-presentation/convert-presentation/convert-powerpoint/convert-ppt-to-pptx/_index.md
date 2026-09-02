---
title: Convertir PPT en PPTX avec Node.js
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/nodejs-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT vers PPTX
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les fichiers PPT hérités en PPTX avec Node.js et Aspose.Slides. Inclut des exemples JavaScript pour la conversion d'un seul fichier et par lot, la gestion des erreurs et des notes de fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for Node.js via Java peut charger un fichier PPT et l'enregistrer en PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu'il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) , puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/). Le bloc `finally` libère la présentation et ses ressources.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Charger la présentation PPT héritée.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Enregistrer la présentation au format PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'extension du fichier ne sélectionne pas le format de sortie à elle seule ; c'est l'argument [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/) qui le fait. Gardez des chemins d'entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L'exemple suivant convertit chaque fichier `.ppt` d'un répertoire. Chaque fichier est traité de manière indépendante, de sorte qu'une conversion échouée n'arrête pas le reste du lot.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Pour les charges de travail en production, consignez l'erreur complète, décidez si un fichier de sortie existant peut être écrasé, et écrivez les noms des fichiers ayant échoué dans une file d'attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous entraîner un échec de conversion. Consultez [Password-Protected Presentations](/slides/fr/nodejs-java/password-protected-presentation/) pour charger des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion conserve normalement les diapositives, les maîtres, les dispositions, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même manière exacte. Une fonctionnalité héritée qui n'a pas d'équivalent PPTX, ou qui n'est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu'il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias incorporés, des polices rares ou des macros VBA. Un fichier PPTX ordinaire n'est pas un format habilité aux macros, utilisez donc un flux de travail approprié compatible avec les macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l'environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré de façon programmatique et inspectez le nombre de diapositives clés ainsi que le contenu, puis comparez son apparence et son comportement en mode diaporama dans le visualiseur prévu. Ne considérez pas un appel réussi à [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) comme une preuve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée dans les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d'archivage ou de restauration jusqu'à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, d'images, XPS ou d'un autre type de sortie, utilisez les recommandations spécifiques au format dans [Convert Presentations to Multiple Formats](/slides/fr/nodejs-java/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités éditables de PowerPoint.

## **Convertisseur en ligne**

Pour un fichier ponctuel ou une comparaison rapide, vous pouvez utiliser le [convertisseur PPT en PPTX en ligne](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions récurrentes, un traitement par lots ou la gestion d'erreurs au niveau de l'application, utilisez l'API Node.js via Java.

## **Articles associés**

- [PPT vs PPTX](/slides/fr/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/slides/fr/nodejs-java/save-presentation/)
- [Supported File Formats](/slides/fr/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/slides/fr/nodejs-java/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Node.js via Java charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion PPT en PPTX préservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation courant, mais la fidélité exacte n'est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu'il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l'échec de l'opération de chargement.

**Dois-je supprimer le fichier PPT après la conversion ?**

Conservez l'original jusqu'à ce que vous ayez vérifié le PPTX dans les visionneuses et les flux de travail qui vous importent. Cela fournit une copie de restauration si une fonctionnalité héritée se convertit différemment.