---
title: Créer des miniatures de formes
type: docs
weight: 70
url: /androidjava/create-shape-thumbnails/
---


## **Aperçu**
{{% alert color="primary" %}} 

Aspose.Slides pour Android via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides pour Android via Java les aide à générer des images en miniature des formes de la diapositive.

{{% /alert %}} 

Dans ce sujet, nous allons montrer comment générer des miniatures de diapositives dans différentes situations :

- Générer une miniature de forme à l'intérieur d'une diapositive.
- Générer une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature de forme dans les limites de l'apparence d'une forme.

## **Génération de Miniatures de Formes à partir de Diapositives**
Pour générer une miniature de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour Android via Java, faites ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) de la diapositive référencée à l'échelle par défaut.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme à partir d'une diapositive :

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

## **Génération de Miniatures de Formes avec un Facteur d'Élargissement Défini par l'Utilisateur**
Pour générer la miniature de forme d'une diapositive en utilisant Aspose.Slides pour Android via Java, faites ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) de la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple vous montre comment générer une miniature de forme basée sur un facteur d'élargissement défini :

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

## **Génération de Miniature de Forme des Limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature d'une forme de diapositive dans la limite de son apparence, faites ceci :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
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