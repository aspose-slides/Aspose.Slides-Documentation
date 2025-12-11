---
title: Convertir les diapositives PowerPoint en PNG sur Android
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Convertissez les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour Android via Java, garantissant des résultats précis et automatisés."
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n’est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très répandu. 

**Cas d’utilisation :** Lorsque vous avez une image complexe et que la taille n’est pas un problème, le PNG est un meilleur format d’image que le JPEG. 

{{% alert title="Tip" color="primary" %}} Vous voudrez peut-être consulter les convertisseurs gratuits **PowerPoint en PNG** d’Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils sont une implémentation en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez l’objet diapositive à partir de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) via l’interface [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide).
3. Utilisez la méthode [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) pour obtenir la miniature de chaque diapositive.
4. Utilisez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) pour enregistrer la miniature de la diapositive au format PNG.

Ce code Java montre comment convertir une présentation PowerPoint en PNG :
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

Si vous souhaitez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante. 

Ce code Java illustre l’opération décrite :
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

Si vous souhaitez obtenir des fichiers PNG à une certaine taille, vous pouvez transmettre vos arguments préférés `width` et `height` pour `ImageSize`. 

Ce code montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images : 
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


## **FAQ**

**Comment exporter uniquement une forme spécifique (par ex. un graphique ou une image) plutôt que la diapositive entière ?**

Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/androidjava/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui, mais [ne partagez pas](/slides/fr/androidjava/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

**Quelles sont les limitations de la version d’essai lors de l’exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images de sortie et impose [d’autres restrictions](/slides/fr/androidjava/licensing/) tant qu’une licence n’est pas appliquée.