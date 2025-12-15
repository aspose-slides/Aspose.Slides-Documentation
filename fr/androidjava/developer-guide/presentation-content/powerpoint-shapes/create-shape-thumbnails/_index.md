---
title: Créer des miniatures de formes de présentation sur Android
linktitle: Miniatures de formes
type: docs
weight: 70
url: /fr/androidjava/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- représentation de forme
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir de diapositives PowerPoint avec Aspose.Slides for Android via Java – créez et exportez facilement des miniatures de présentation."
---

## **Aperçu**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de voir les images des formes séparément dans un visualiseur d’images. Dans ce cas, Aspose.Slides for Android via Java les aide à générer des images miniatures des formes de la diapositive.

{{% /alert %}} 

Dans ce sujet, nous montrons comment générer des miniatures de diapositives dans différentes situations :

- Génération d’une miniature de forme à l’intérieur d’une diapositive.  
- Génération d’une miniature de forme pour une forme de diapositive avec des dimensions définies par l’utilisateur.  
- Génération d’une miniature de forme dans les limites de l’apparence d’une forme.

## **Générer une miniature de forme à partir d’une diapositive**
Pour générer une miniature de forme à partir de n’importe quelle diapositive à l’aide d’Aspose.Slides for Android via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive à l’aide de son ID ou de son index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) de la diapositive référencée à l’échelle par défaut.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple montre comment générer une miniature de forme à partir d’une diapositive :
```java
// Instanciez une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créez une image à l'échelle réelle
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


## **Générer une miniature avec un facteur d’échelle défini par l’utilisateur**
Pour générer la miniature de forme d’une diapositive à l’aide d’Aspose.Slides for Android via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive à l’aide de son ID ou de son index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l’utilisateur.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple montre comment générer une miniature de forme en fonction d’un facteur d’échelle défini :
```java
// Instancie une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crée une image à pleine échelle
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Enregistre l'image sur le disque au format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer une miniature de forme basée sur les limites d’apparence**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l’apparence de la forme. Elle prend en compte tous les effets de la forme. La miniature de forme générée est restreinte par les limites de la diapositive. Pour générer une miniature d’une forme de diapositive dans les limites de son apparence, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive à l’aide de son ID ou de son index.
1. Obtenez l’image miniature de la diapositive référencée avec les limites de forme comme apparence.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple est basé sur les étapes ci‑dessus :
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


## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/), et d’autres. Les formes peuvent également être [exportées au format vectoriel SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites « Shape » et « Appearance » lors du rendu d’une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/androidjava/shape-effect/) (ombres, lueurs, etc.).

**Que se passe‑t‑il si une forme est marquée comme cachée ? Sera‑t‑elle toujours rendue en miniature ?**

Une forme cachée reste partie du modèle et peut être rendue ; le drapeau caché affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, les graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/) et [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système affectent‑elles la qualité des miniatures pour les formes texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/androidjava/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/androidjava/font-substitution/)) pour éviter les substitutions indésirables et le ré‑enroulement du texte.