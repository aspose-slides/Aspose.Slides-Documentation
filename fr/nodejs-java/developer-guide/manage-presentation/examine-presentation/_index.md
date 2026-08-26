---
title: Récupérer et mettre à jour les informations de présentation en JavaScript
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/nodejs-java/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument à l’aide de JavaScript pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Cet article montre comment inspecter les informations d’une présentation dans Aspose.Slides. Il explique comment déterminer le format actuel d’une présentation sans charger le fichier complet, lire ses propriétés de document, et mettre à jour ces propriétés si nécessaire.

Les exemples sont basés sur les API [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/) et démontrent des opérations courantes pour travailler avec les métadonnées d’une présentation.

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir dans quel format (PPT, PPTX, ODP, etc.) la présentation se trouve actuellement.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code JavaScript :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Obtenir les propriétés de la présentation**

Ce code JavaScript montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Vous voudrez peut‑être voir les [propriétés sous DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) qui vous permet de modifier les propriétés d’une présentation.

Imaginons que nous ayons une présentation PowerPoint avec les propriétés du document affichées ci‑dessous.

![Propriétés originales du document de la présentation PowerPoint](input_properties.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Les résultats de la modification des propriétés du document sont affichés ci‑dessous.

![Propriétés modifiées du document de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, vous trouverez peut‑être ces liens utiles :

- [Présentations protégées par mot de passe](/slides/fr/nodejs-java/password-protected-presentation/)
- [Présentations protégées en écriture](/slides/fr/nodejs-java/write-protected-presentation/)

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les [informations sur les polices incorporées](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontsmanager/getfonts/) afin d’identifier quelles polices sont essentielles pour le rendu.

**Comment puis‑je rapidement savoir si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/gethidden/) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslidesize/) et l’orientation actuelles avec les préréglages standard ; cela permet d’anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de savoir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), et notez si les données sont internes ou basées sur un lien, y compris les liens cassés.

**Comment puis‑je évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez le nombre d’objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les multimédias ; attribuez un score de complexité approximatif afin de signaler les points chauds de performance potentiels.