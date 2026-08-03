---
title: Créer des miniatures de formes de présentation sur Android
linktitle: Miniatures de formes
type: docs
weight: 70
url: /fr/androidjava/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendre la forme
- rendu de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Générez des miniatures de forme haute qualité à partir de diapositives PowerPoint avec Aspose.Slides pour Android via Java – créez et exportez facilement des miniatures de présentation."
---
## **Introduction**

Aspose.Slides for Android via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de voir les images des formes séparément dans un visualiseur d’images. Dans de tels cas, Aspose.Slides for Android via Java les aide à générer des images miniatures des formes de la diapositive.

Dans ce sujet, nous montrerons comment générer des miniatures de diapositives dans différentes situations :

- Générer une miniature d’une forme à l’intérieur d’une diapositive.  
- Générer une miniature d’une forme pour une forme de diapositive avec des dimensions définies par l’utilisateur.  
- Générer une miniature d’une forme dans les limites de l’apparence d’une forme.

## **Générer une miniature de forme à partir d’une diapositive**
Pour générer une miniature de forme à partir de n’importe quelle diapositive en utilisant Aspose.Slides for Android via Java, procédez comme suit :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).  
2. Obtenir la référence de n’importe quelle diapositive en utilisant son ID ou son indice.  
3. [Obtenir l’image miniature de la forme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShape#getImage--) de la diapositive référencée à l’échelle par défaut.  
4. Enregistrez l’image miniature dans le format d’image de votre choix.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créer une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Enregistrer l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Générer une miniature avec un facteur d’échelle défini par l'utilisateur**
Pour générer la miniature de forme d’une diapositive en utilisant Aspose.Slides for Android via Java, procédez comme suit :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).  
2. Obtenir la référence de n’importe quelle diapositive en utilisant son ID ou son indice.  
3. [Obtenir l’image miniature de la forme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l’utilisateur.  
4. Enregistrez l’image miniature dans le format d’image de votre choix.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créer une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Enregistrer l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une miniature d’apparence de forme basée sur les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l’apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est restreinte par les limites de la diapositive. Pour générer une miniature d’une forme de diapositive dans les limites de son apparence, procédez comme suit :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).  
2. Obtenir la référence de n’importe quelle diapositive en utilisant son ID ou son indice.  
3. Obtenir l’image miniature de la diapositive référencée avec les limites de forme comme apparence.  
4. Enregistrez l’image miniature dans le format d’image de votre choix.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créer une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Enregistrer l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les limites visuelles réelles d’une forme**

Les propriétés de cadre de [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) — ses méthodes `getX()`, `getY()`, `getWidth()` et `getHeight()` — décrivent le rectangle stocké dans le modèle de présentation. Le contenu réellement rendu peut s’étendre au‑delà de ce cadre ou occuper un rectangle aligné différemment. La rotation, les contours, les pointes de flèche, la mise en page du texte et le dépassement, la géométrie SmartArt générée et d’autres effets de rendu peuvent tous modifier la zone occupée.

Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getVisualBounds--) pour calculer cette zone occupée sans créer d’image. La méthode renvoie un [RectF](https://developer.android.com/reference/android/graphics/RectF) en coordonnées de diapositive. Le rectangle renvoyé n’est pas découpé à la diapositive, ses coordonnées peuvent donc être négatives lorsque le contenu s’étend au‑delà de l’origine de la diapositive.

`Shape.getVisualBounds` n’est pas actuellement déclaré par l’interface [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/). Par conséquent, conservez la forme obtenue à partir de la collection de formes de la diapositive comme valeur d’interface et ne la castrez que lors de l’appel de la méthode.

L’exemple suivant récupère et compare les limites du cadre et les limites visuelles :

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Le même [RectF](https://developer.android.com/reference/android/graphics/RectF) peut être utilisé pour aligner des formes voisines à son bord gauche, droit, supérieur ou inférieur ; réserver suffisamment d’espace dans une mise en page générée ; ou détecter du contenu en dehors d’une région autorisée. Les limites visuelles sont particulièrement utiles pour SmartArt, les zones de texte, les flèches, les images, les formes pivotées et les formes groupées, où le cadre stocké peut ne pas représenter le résultat rendu complet.

Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getVisualBounds--) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n’avez pas besoin d’un bitmap. Utilisez [IShape.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#getImage--) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensionne l’image à partir des limites de la forme, y compris les paramètres de contour, tandis que `ShapeThumbnailBounds.Appearance` la dimensionne à partir de l’apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getVisualBounds--) ne renvoie que le rectangle calculé et ne le découpe pas à la diapositive.

## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imageformat/), et d’autres. Les formes peuvent également être [exportées comme SVG vectoriel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d’une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/androidjava/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t‑il si une forme est marquée comme masquée ? Sera‑t‑elle toujours rendue en tant que miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/chart/) et [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/smartart/)) peut être enregistré comme miniature ou comme SVG.

**Les polices installées sur le système influencent‑elles la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/androidjava/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/androidjava/font-substitution/)) pour éviter les substitutions inattendues et le re‑flux de texte.