---
title: Convertir des diapositives PowerPoint en PNG en JavaScript
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/nodejs-java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir rapidement des présentations PowerPoint en images PNG de haute qualité en JavaScript avec Aspose.Slides pour Node.js, garantissant des résultats précis et automatisés."
---
## **Vue d'ensemble**

Cet article explique comment convertir des diapositives de présentation en images PNG à l'aide d'Aspose.Slides pour Node.js via Java. Vous pouvez charger des présentations aux formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l'enregistrer en tant qu'image PNG distincte.

Les exemples ci-dessous montrent le rendu à l'échelle par défaut, l'augmentation de l'échelle, la spécification des dimensions de sortie en pixels, et le choix d'un style de rendu de dégradé.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et accédez à ses diapositives via la collection [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). L'exemple rend chaque diapositive avec [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) sans paramètres pour créer une miniature. Il appelle ensuite [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) avec [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) pour enregistrer chaque diapositive rendue en tant qu'image PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
La surcharge sans paramètre de [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) rend à une échelle de 0,2. Par exemple, une diapositive mesurant 720 × 540 points produit une miniature de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d'échelle ou une taille d'image explicite comme indiqué ci‑dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez les facteurs d'échelle horizontaux et verticaux à [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont à 2, ainsi une diapositive mesurant 720 × 540 points produit une image de 1440 × 1080 pixels. Des facteurs d'échelle égaux conservent le rapport d'aspect de la diapositive. Chaque image est enregistrée au format PNG avec [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, transmettez une taille à [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) au lieu des facteurs d'échelle. Cet exemple rend chaque diapositive à 960 × 720 pixels et enregistre le résultat avec [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Choisissez des dimensions correspondant au rapport d'aspect de la diapositive afin d'éviter d'étirer l'image.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Choisir un style de rendu de dégradé**

Supposons qu'une diapositive contienne des remplissages en dégradé, mais que les transitions dans le PNG exporté paraissent plus claires ou différentes de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la méthode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) héritée de [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) pour choisir la façon dont les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez-le dans le répertoire de travail de l'application. Sa première diapositive contient deux dégradés linéaires : du cyan à l'orange en haut et du bleu au jaune en bas. Chaque dégradé possède deux arrêts, à 0 % et 100 %.

L'exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Par défaut | PowerPointUI |
| --- | --- |
| ![Dégradés cyan‑à‑orange et bleu‑à‑jaune rendus avec Par défaut](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `Default` produit des couleurs intermédiaires plus claires, tandis que `PowerPointUI` produit des couleurs intermédiaires plus foncées. La différence dépend des couleurs et des arrêts du dégradé.

Choisissez `Default` lorsque la sortie standard d'Aspose.Slides répond à vos besoins. Essayez `PowerPointUI` lorsque votre priorité est de reproduire l'apparence dans PowerPoint. Comparez les deux résultats avec votre résultat attendu ; aucun mode n'est universellement préférable.

## **FAQ**

**Comment puis‑je exporter une forme spécifique, telle qu'un graphique ou une image, au lieu de toute la diapositive ?**

Aspose.Slides prend en charge [générer des miniatures pour des formes individuelles](/slides/fr/nodejs-java/create-shape-thumbnails/), permettant de rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque fil d'exécution ou processus ; [ne partagez pas une même instance entre les threads](/slides/fr/nodejs-java/multithreading/).

**Quelles sont les limitations de l'évaluation lors de l'exportation en PNG ?**

Le mode évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/nodejs-java/licensing/) jusqu'à ce qu'une licence soit appliquée.