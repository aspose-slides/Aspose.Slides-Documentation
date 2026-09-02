---
title: "Récupérer et mettre à jour les informations de présentation en JavaScript"
linktitle: "Informations de présentation"
type: docs
weight: 30
url: /fr/nodejs-java/examine-presentation/
keywords:
- "format de présentation"
- "propriétés de présentation"
- "propriétés du document"
- "obtenir des propriétés"
- "lire les propriétés"
- "modifier les propriétés"
- "modifier les propriétés"
- "mettre à jour les propriétés"
- "examiner PPTX"
- "examiner PPT"
- "examiner ODP"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument à l'aide de JavaScript pour des analyses plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d'une présentation et lire ses métadonnées de document sans créer un modèle d'objet de présentation complet. Cela est utile lorsque vous devez classer des fichiers, établir un inventaire ou inspecter les propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre comment effectuer une inspection légère à l'aide de [PresentationFactory](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/) et [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/), ainsi que des mises à jour ciblées via [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/).

## **Vérifier le format d'une présentation**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) pour inspecter un fichier sans créer d'instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). La méthode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/getloadformat/) indique le format détecté, comme PPTX, PPT ou ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Créer un inventaire de présentation léger**

Lorsque vous traitez de nombreux fichiers de présentation, il se peut que vous ayez besoin d'un inventaire compact pour la validation, l'indexation ou un système de gestion de documents. Dans ce scénario, utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) pour obtenir un objet [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/), puis appelez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) pour lire les métadonnées du document. Cette approche ne crée pas d'instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et ne vous oblige pas à parcourir le modèle d'objet complet de la présentation.

Les propriétés étendues exposées par [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/) fournissent les valeurs d'inventaire suivantes :

| Méthode | Valeur d’inventaire |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getSlides) | Nombre total de diapositives. |
| [getHiddenSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Nombre de diapositives masquées. |
| [getNotes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getNotes) | Nombre de diapositives contenant des notes. |
| [getParagraphs](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Nombre total de paragraphes, lorsqu'ils sont disponibles. |
| [getWords](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getWords) | Nombre total de mots. |
| [getMultimediaClips](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Nombre total de clips audio et vidéo. |

L'exemple suivant lit ces valeurs sans créer d'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et affiche un inventaire compact. Il combine également [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) avec [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) pour afficher des groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Chaque [HeadingPair](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/headingpair/) fournit un nom de groupe via [HeadingPair.getName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/headingpair/#getName) et le nombre d'éléments dans ce groupe via [HeadingPair.getCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) renvoie un tableau plat et ordonné, il faut donc consommer le nombre de titres consécutifs indiqué par chaque paire de titres.

### **Métadonnées stockées et limitations du format**

Les propriétés d'inventaire renvoyées par [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) reflètent les métadonnées disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d'objet de la présentation pour recalculer ces valeurs lors de cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être obsolètes si l'application qui a enregistré le fichier en dernier n'a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour le nombre de diapositives, de notes, de diapositives masquées, de paragraphes, de mots et de médias, ainsi que les paires d'en-têtes et les titres des parties. Leur disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker les propriétés de résumés de document correspondantes. Si une propriété est absente ou n'a pas été actualisée par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou la valeur par défaut plutôt que de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales du document, comme le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas à toutes les propriétés étendues spécifiques à PowerPoint. Les métadonnées de diapositives masquées, de notes, de médias, de paires d'en-têtes et de titres de parties peuvent être indisponibles, et les propriétés d'inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zero ou un tableau vide comme une preuve définitive que le contenu correspondant est absent.

Utilisez l'approche de métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d'objet en direct lorsque le résultat doit refléter les modifications en mémoire ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés de la présentation**

Les propriétés renvoyées par [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) peuvent également être modifiées sans créer d'instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Appliquez les modifications avec [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), puis écrivez la présentation liée avec [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

L'image suivante montre les propriétés du document d'origine.

![Propriétés originales du document de la présentation PowerPoint](input_properties.png)

L'exemple suivant modifie le titre et la date de dernière sauvegarde, puis écrit le résultat dans un nouveau fichier :

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

L'image suivante montre les propriétés du document mises à jour.

![Propriétés modifiées du document de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour les vérifications de sécurité liées et les paramètres de protection, consultez les articles suivants :

- [Protéger les présentations par mot de passe](/slides/fr/nodejs-java/password-protected-presentation/)
- [Protéger les présentations en écriture](/slides/fr/nodejs-java/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Chargez la présentation et utilisez [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getfontsmanager/). Appelez [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) pour obtenir les polices incorporées et [FontsManager.getFonts](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getfonts/) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats afin de trouver les polices nécessaires au rendu mais non incorporées.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Lorsque les métadonnées du document stockées sont suffisantes, lisez [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) et [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Cela convient à un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou obsolètes, ou si vous devez vérifier les valeurs en direct, parcourez [Presentation.getSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslides/) et inspectez la méthode [Slide.getHidden](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/gethidden/) de chaque diapositive à la place.

**Puis-je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et appelez [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslidesize/). Utilisez [SlideSize.getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/getsize/) et [SlideSize.getOrientation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/getorientation/) pour comparer les paramètres actuels avec le préréglage et les dimensions attendus.

**Existe-t-il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/) et appelez [ChartData.getDataSourceType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Pour un classeur externe, appelez [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Le type de source de données et le chemin identifient une référence externe, mais vérifier si la cible est disponible nécessite une vérification de ressource distincte.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l'exportation PDF ?**

Il n'existe pas de propriété unique de complexité. Parcourez [Presentation.getSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslides/) et la collection [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getShapes) de chaque diapositive. Utilisez le nombre de formes et la présence d'images volumineuses, d'effets, d'animations ou de médias comme indicateurs de filtrage, et mesurez un rendu ou une exportation représentative avant de considérer une diapositive comme un goulot d'étranglement de performance confirmé.