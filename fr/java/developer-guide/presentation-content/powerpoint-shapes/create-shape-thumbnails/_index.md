---
title: Créer des miniatures de formes de présentation en Java
linktitle: Miniatures de formes
type: docs
weight: 70
url: /fr/java/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir de diapositives PowerPoint avec Aspose.Slides pour Java – créez et exportez facilement des miniatures de présentations."
---
## **Introduction**

Aspose.Slides for Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de visualiser séparément les images des formes dans un visualiseur d'images. Dans de tels cas, Aspose.Slides for Java les aide à générer des images miniatures des formes de la diapositive.

Cet article explique comment générer des miniatures de diapositive de différentes manières :

- Générer une miniature de forme à l'intérieur d'une diapositive.
- Générer une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature de forme dans les limites de l'apparence d'une forme.

## **Générer une miniature de forme à partir d'une diapositive**
Pour générer une miniature de forme à partir de n'importe quelle diapositive avec Aspose.Slides for Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getImage--) de la diapositive référencée à l'échelle par défaut.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

```java
// Instanciez une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créez une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Enregistrez l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Générer une miniature avec un facteur d'échelle défini par l'utilisateur**
Pour générer la miniature de forme d'une diapositive avec Aspose.Slides for Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

```java
// Instanciez une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créez une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Enregistrez l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une miniature d'apparence de forme basée sur les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de la forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature d'une forme de diapositive dans les limites de son apparence, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image miniature de la forme de la diapositive référencée en utilisant les limites de la forme comme apparence.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

```java
// Instanciez une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créez une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Enregistrez l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les limites visuelles réelles d'une forme**

Les propriétés de cadre de [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) — ses méthodes `getX()`, `getY()`, `getWidth()` et `getHeight()` — décrivent le rectangle stocké dans le modèle de la présentation. Le contenu réellement rendu peut s'étendre au-delà de ce cadre ou occuper un rectangle aligné différemment. La rotation, les contours, les pointes de flèche, la disposition du texte et le débordement, la géométrie SmartArt générée, et d'autres effets de rendu peuvent tous modifier la zone occupée.

Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getVisualBounds--) pour calculer cette zone occupée sans créer d'image. La méthode retourne un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) en coordonnées de diapositive. Le rectangle retourné n'est pas découpé selon la diapositive, ses coordonnées peuvent donc être négatives lorsque le contenu dépasse l'origine de la diapositive.

Actuellement, [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getVisualBounds--) n'est pas déclaré par l'interface [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/). Par conséquent, conservez la forme obtenue à partir de la collection de formes de la diapositive en tant que valeur d'interface et effectuez le cast uniquement lors de l'appel de la méthode.

L'exemple suivant récupère et compare les limites du cadre et les limites visuelles :

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Le même [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) peut être utilisé pour aligner des formes adjacentes à son bord gauche, droit, supérieur ou inférieur ; réserver suffisamment d'espace dans une mise en page générée ; ou détecter du contenu en dehors d'une zone autorisée. Les limites visuelles sont particulièrement utiles pour SmartArt, les zones de texte, les flèches, les images, les formes tournées et les formes groupées, où le cadre stocké peut ne pas représenter le résultat rendu complet.

Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getVisualBounds--) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [IShape.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getImage--) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensionne l'image à partir des limites de la forme, y compris les paramètres de contour, tandis que `ShapeThumbnailBounds.Appearance` la dimensionne à partir de l'apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getVisualBounds--) ne renvoie que le rectangle calculé et ne le découpe pas à la diapositive.

## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées en tant que SVG vectoriel](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d'une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme cachée ? Sera-t-elle toujours rendue en miniature ?**

Une forme cachée reste partie du modèle et peut être rendue ; le drapeau caché affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont-ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/), et [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système affectent-elles la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/java/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/java/font-substitution/)) pour éviter les substitutions indésirables et le réarrangement du texte.