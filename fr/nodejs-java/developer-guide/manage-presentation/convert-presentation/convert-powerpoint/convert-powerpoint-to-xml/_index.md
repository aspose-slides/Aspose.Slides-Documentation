---
title: Convertir des présentations PowerPoint en XML en JavaScript
linktitle: PowerPoint en XML
type: docs
weight: 145
url: /fr/nodejs-java/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint en XML
- convertir la présentation en XML
- PPT en XML
- PPTX en XML
- ODP en XML
- Présentation PowerPoint XML
- SaveFormat.Xml
- enregistrer la présentation au format XML
- exporter la présentation en XML
- flux XML
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML en JavaScript avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java peut convertir les présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d'une représentation textuelle pour inspecter la structure de la présentation, dépanner les documents générés, comparer les résultats dans des tests automatisés, ou intégrer à un flux de travail qui consomme du XML plutôt qu'un paquet de présentation.

Utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) avec la valeur `Xml` de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crée une PowerPoint XML Presentation. Elle n'extrait pas les parties individuelles Office Open XML stockées dans un package PPTX. Si vous avez besoin des parties exactes du package PPTX, telles que `ppt/presentation.xml` ou les fichiers XML de chaque diapositive, inspectez le package PPTX lui‑-même.
{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/), puis transmettez le chemin de sortie et `SaveFormat.Xml` à [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save). La source peut être n'importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L'exemple suivant convertit une présentation PPTX en fichier XML :
```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Écrire la sortie XML dans un flux**

Utilisez la surcharge de flux de [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu'un service web, un fournisseur de stockage ou un pipeline de traitement XML. L'exemple suivant écrit le résultat dans un `ByteArrayOutputStream` Java et copie les données générées dans un `Buffer` Node.js :
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Passer xmlBuffer au prochain composant du flux de travail.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Comparer le XML avec les formats de présentation et d'exportation**

Choisissez le format de sortie en fonction de l'utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une PowerPoint XML Presentation | Inspection de la structure, dépannage, comparaison du résultat généré et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les flux de travail PowerPoint plus anciens |
| PPTX (`.pptx`) | Un package Office Open XML contenant plusieurs parties | Édition PowerPoint standard et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Une représentation rendue d'une diapositive individuelle | Vignettes, aperçus et ressources d'image |
| HTML ou HTML5 | Sortie de présentation orientée web | Visualisation dans le navigateur et publication web |

Contrairement aux PPT et PPTX, la sortie XML est principalement destinée à l'inspection et aux flux de travail orientés données. Contrairement aux PDF, TIFF, HTML et aux formats d'image de diapositive, elle représente les données de la présentation plutôt que de rendre les diapositives en tant que pages ou assets visuels. Le tableau [formats de fichiers pris en charge](/slides/fr/nodejs-java/supported-file-formats/) indique que PowerPoint XML Presentation est un format uniquement enregistrable, ne l'utilisez donc pas lorsqu'un flux de travail doit charger le fichier exporté à nouveau dans Aspose.Slides pour une édition continue.

## **FAQ**

**`SaveFormat.Xml` est‑il identique à l'enregistrement d'un fichier PPTX ?**  
Non. PPTX est un package contenant plusieurs parties Office Open XML, tandis que `SaveFormat.Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**  
Oui. Transmettez un flux writable à [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save). Par exemple, utilisez un `ByteArrayOutputStream` Java et copiez ses données dans un `Buffer` Node.js pour un traitement en mémoire.

**Aspose.Slides peut‑il recharger le fichier XML exporté ?**  
Non. PowerPoint XML Presentation est actuellement pris en charge uniquement pour l'enregistrement, pas pour le chargement. Utilisez PPTX ou un autre format de présentation pris en charge lorsque l'édition bidirectionnelle est requise.

**La conversion XML rend‑elle chaque diapositive comme une page ou une image ?**  
Non. La conversion XML écrit des données structurées de la présentation. Utilisez PDF ou TIFF pour une sortie orientée page, ou PNG, JPEG et SVG pour des images de diapositives individuelles.