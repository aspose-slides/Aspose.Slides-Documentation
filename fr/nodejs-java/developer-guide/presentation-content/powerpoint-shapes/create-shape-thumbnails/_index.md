---
title: Créer des miniatures de forme
type: docs
weight: 70
url: /fr/nodejs-java/create-shape-thumbnails/
---

## **Vue d'ensemble**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides for Node.js via Java les aide à générer des images miniatures des formes de la diapositive.

{{% /alert %}} 

Dans ce sujet, nous montrerons comment générer des miniatures de diapositives dans différentes situations :

- Générer une miniature d’une forme à l’intérieur d’une diapositive.
- Générer une miniature d’une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature d’une forme dans les limites de l’apparence de la forme.

## **Génération de miniatures de forme à partir des diapositives**
Pour générer une miniature de forme à partir de n’importe quelle diapositive en utilisant Aspose.Slides for Node.js via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son indice.
1. [Obtenez l’image miniature de la forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) de la diapositive référencée à l’échelle par défaut.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple montre comment générer une miniature de forme à partir d’une diapositive :
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


## **Génération de miniatures de forme avec un facteur d’échelle défini par l'utilisateur**
Pour générer la miniature de forme d’une diapositive en utilisant Aspose.Slides for Node.js via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son indice.
1. [Obtenez l’image miniature de la forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple montre comment générer une miniature de forme basée sur un facteur d’échelle défini :
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


## **Génération de la miniature de forme dans les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l’apparence de la forme. Elle prend en compte tous les effets de la forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature d’une forme de diapositive dans les limites de son apparence, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenez la référence de n’importe quelle diapositive en utilisant son ID ou son indice.
1. Obtenez l’image miniature de la diapositive référencée avec les limites de forme comme apparence.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple est basé sur les étapes ci‑dessus :
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


## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/), et d’autres. Les formes peuvent également être [exportées au format vectoriel SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d’une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/nodejs-java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme masquée ? Sera‑t‑elle toujours rendue en tant que miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) et [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système affectent‑elles la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/nodejs-java/custom-font/) (ou [configurer les substitutions de police](/slides/fr/nodejs-java/font-substitution/)) pour éviter les recours indésirables et le re‑flux du texte.