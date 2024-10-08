---
title: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /fr/java/convert-powerpoint-to-png/
keywords: PowerPoint en PNG, PPT en PNG, PPTX en PNG, java, Aspose.Slides pour Java
description: Convertir une présentation PowerPoint en PNG
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.

{{% alert title="Conseil" color="primary" %}} Vous voudrez peut-être consulter les **Convertisseurs PowerPoint en PNG** gratuits d'Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ce sont des mises en œuvre en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez l'objet diapositive de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) sous l'interface [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide).
3. Utilisez une méthode [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) pour obtenir la miniature de chaque diapositive.
4. Utilisez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) pour enregistrer la miniature de la diapositive au format PNG.

Ce code Java vous montre comment convertir une présentation PowerPoint en PNG :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine échelle, vous pouvez définir les valeurs pour `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.

Ce code en Java illustre l'opération décrite :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine taille, vous pouvez passer vos arguments préférés `width` et `height` pour `ImageSize`.

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```