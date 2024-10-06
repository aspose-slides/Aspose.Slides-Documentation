---
title: Créer des vignettes de forme
type: docs
weight: 70
url: /java/create-shape-thumbnails/
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides pour Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être consultées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides pour Java les aide à générer des images miniatures des formes de diapositive.

{{% /alert %}} 

Dans ce sujet, nous allons montrer comment générer des vignettes de diapositive dans différentes situations :

- Génération d'une vignette de forme à l'intérieur d'une diapositive.
- Génération d'une vignette de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Génération d'une vignette de forme dans les limites de l'apparence d'une forme.

## **Génération de Vignettes de Forme à Partir de Diapositives**
Pour générer une vignette de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) de la diapositive référencée à l'échelle par défaut.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une vignette de forme à partir d'une diapositive :

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créer une image à l'échelle complète
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

## **Génération de Vignettes de Forme avec Facteur d'Échelle Défini par l'Utilisateur**
Pour générer la vignette de forme d'une diapositive en utilisant Aspose.Slides pour Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une vignette de forme basée sur un facteur d'échelle défini :

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créer une image à l'échelle complète
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

## **Génération de Vignette de Forme des Limites**
Cette méthode de création de vignettes de formes permet aux développeurs de générer une vignette dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de la forme. La vignette de forme générée est limitée par les limites de la diapositive. Pour générer une vignette d'une forme de diapositive dans les limites de son apparence, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée avec les limites de forme comme apparence.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple est basé sur les étapes ci-dessus :

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Créer une image à l'échelle complète
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