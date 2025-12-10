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
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir de diapositives PowerPoint avec Aspose.Slides for Java – créez et exportez facilement des miniatures de présentation."
---

## **Aperçu**
{{% alert color="primary" %}} 

Aspose.Slides for Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être affichées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de visualiser les images des formes séparément dans un visualiseur d’images. Dans ces cas, Aspose.Slides for Java les aide à générer des images miniatures des formes de diapositive.

{{% /alert %}} 

Dans ce sujet, nous montrerons comment générer des miniatures de diapositive dans différentes situations :

- Génération d’une miniature de forme à l’intérieur d’une diapositive.
- Génération d’une miniature de forme pour une forme de diapositive avec des dimensions définies par l’utilisateur.
- Génération d’une miniature de forme dans les limites de l’apparence d’une forme.

## **Générer une miniature de forme à partir d’une diapositive**
Pour générer une miniature de forme à partir de n’importe quelle diapositive avec Aspose.Slides for Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive quelconque en utilisant son ID ou son index.
1. [Obtenez l’image miniature de la forme](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) de la diapositive référencée avec l’échelle par défaut.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple montre comment générer une miniature de forme à partir d’une diapositive :
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


## **Générer une miniature avec facteur d’échelle défini par l’utilisateur**
Pour générer la miniature d’une forme d’une diapositive avec Aspose.Slides for Java, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive quelconque en utilisant son ID ou son index.
1. [Obtenez l’image miniature de la forme](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l’utilisateur.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple montre comment générer une miniature de forme basée sur un facteur d’échelle défini :
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


## **Créer une vignette d’apparence de forme basée sur les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l’apparence de la forme. Elle prend en compte tous les effets de la forme. La miniature générée est limitée par les limites de la diapositive. Pour générer une miniature d’une forme de diapositive dans les limites de son apparence, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive quelconque en utilisant son ID ou son index.
1. Obtenez l’image miniature de la diapositive référencée avec les limites de forme comme apparence.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

Ce code d’exemple est basé sur les étapes ci‑dessus :
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


## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/), et d’autres. Les formes peuvent également être [exportées en tant que SVG vectoriel](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites « Shape » et « Appearance » lors du rendu d’une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe‑t‑il si une forme est marquée comme masquée ? Sera‑t‑elle toujours rendue en miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) et [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système influent‑elles sur la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/java/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/java/font-substitution/)) afin d’éviter les substitutions indésirables et le ré‑enroulement du texte.