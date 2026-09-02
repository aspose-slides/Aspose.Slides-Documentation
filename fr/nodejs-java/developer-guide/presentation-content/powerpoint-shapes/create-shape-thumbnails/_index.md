---
title: Créer des miniatures de formes de présentation en JavaScript
linktitle: Miniatures de formes
type: docs
weight: 70
url: /fr/nodejs-java/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir des diapositives PowerPoint avec JavaScript et Aspose.Slides pour Node.js – créez et exportez facilement des miniatures de présentation."
---
## **Introduction**

Aspose.Slides est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être consultées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs ont besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans ces cas, Aspose.Slides vous aide à générer des images miniatures des formes de la diapositive. La façon d'utiliser cette fonctionnalité est décrite dans cet article.
Cet article explique comment générer des miniatures de diapositives de différentes manières :

- Génération d’une miniature de forme à l'intérieur d’une diapositive.
- Génération d’une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Génération d’une miniature de forme dans les limites de l'apparence d'une forme.

## **Génération de miniatures de formes à partir des diapositives**

Pour générer une miniature de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour Node.js via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).
2. Obtenez la référence de n'importe quelle diapositive à l'aide de son ID ou de son index.
3. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#getImage--) de la diapositive référencée à l'échelle par défaut.
4. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme à partir d'une diapositive :

```javascript
// Instancier une classe Presentation qui représente le fichier de présentation
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Créer une image à pleine échelle
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Enregistrer l'image sur le disque au format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Génération de miniatures de formes avec facteur d'échelle défini par l'utilisateur**

Pour générer la miniature de forme d'une diapositive en utilisant Aspose.Slides pour Node.js via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).
2. Obtenez la référence de n'importe quelle diapositive à l'aide de son ID ou de son index.
3. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l'utilisateur.
4. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme basée sur un facteur d'échelle défini :

```javascript
// Instancier une classe Presentation qui représente le fichier de présentation
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Créer une image à pleine échelle
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Enregistrer l'image sur le disque au format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Génération d'une miniature de forme dans les limites**

Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de la forme. La miniature de forme générée est restreinte par les limites de la diapositive. Pour générer une miniature d'une forme de diapositive dans les limites de son apparence, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).
2. Obtenez la référence de n'importe quelle diapositive à l'aide de son ID ou de son index.
3. Obtenez l'image miniature de la diapositive référencée avec les limites de la forme comme apparence.
4. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple est basé sur les étapes ci-dessous :

```javascript
// Instancier une classe Presentation qui représente le fichier de présentation
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Créer une image à pleine échelle
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Enregistrer l'image sur le disque au format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obtenir les limites visuelles réelles d'une forme**

Les propriétés de cadre d'une [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) — ses méthodes `getX()`, `getY()`, `getWidth()` et `getHeight()` — décrivent le rectangle stocké dans le modèle de présentation. Le contenu réellement rendu peut dépasser ce cadre ou occuper un rectangle aligné différemment. La rotation, les contours, les pointes de flèche, la mise en page et le débordement du texte, la géométrie SmartArt générée et d'autres effets de rendu peuvent tous modifier la zone occupée.
Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getVisualBounds--) pour calculer cette zone occupée sans créer d'image. La méthode renvoie un objet [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordonnées de diapositive. Le rectangle renvoyé n'est pas découpé à la diapositive, ainsi ses coordonnées peuvent être négatives lorsque le contenu dépasse l'origine de la diapositive.
L'exemple suivant obtient et compare les limites de cadre et les limites visuelles :

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Le même rectangle peut être utilisé pour aligner les formes voisines à son bord gauche, droit, haut ou bas ; réserver suffisamment d'espace dans une mise en page générée ; ou détecter du contenu hors d'une région autorisée. Les limites visuelles sont particulièrement utiles pour SmartArt, les zones de texte, les flèches, les images, les formes pivotées et les formes groupées, où le cadre stocké peut ne pas représenter le rendu complet.
Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getVisualBounds--) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [Shape.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getImage--) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensionne l'image à partir des limites de la forme, y compris les paramètres de contour, tandis que `ShapeThumbnailBounds.Appearance` la dimensionne à partir de l'apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getVisualBounds--) ne renvoie que le rectangle calculé et ne le découpe pas à la diapositive.

## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées en SVG vectoriel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d’une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/nodejs-java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme masquée ? Sera‑t‑elle toujours rendue en tant que miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/), et [SmartArt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système affectent‑elles la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/nodejs-java/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/nodejs-java/font-substitution/)) pour éviter les substitutions indésirables et le ré‑agencement du texte.