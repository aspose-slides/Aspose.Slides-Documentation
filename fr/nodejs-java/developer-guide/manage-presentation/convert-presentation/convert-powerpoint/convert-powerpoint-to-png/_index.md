---
title: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /fr/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint en PNG, PPT en PNG, PPTX en PNG, java, Aspose.Slides pour Node.js via Java
description: Convertir une présentation PowerPoint en PNG
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très répandu.  

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.  

{{% alert title="Tip" color="primary" %}}Vous pouvez consulter les convertisseurs PowerPoint vers PNG gratuits d'Aspose **PowerPoint to PNG Converters** : [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils sont une implémentation en direct du processus décrit sur cette page.{{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Récupérez l'objet diapositive à partir de la collection retournée par la méthode [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) de la classe [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. Utilisez la méthode [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) pour obtenir la miniature de chaque diapositive.
4. Utilisez la méthode [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) pour enregistrer la miniature de la diapositive au format PNG.

Ce code JavaScript vous montre comment convertir une présentation PowerPoint en PNG :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.  

Ce code en JavaScript démontre l'opération décrite :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint en PNG avec une taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG d'une certaine taille, vous pouvez transmettre vos arguments préférés `width` et `height` pour `ImageSize`.  

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Comment puis‑je exporter uniquement une forme spécifique (par ex., un graphique ou une image) plutôt que la diapositive entière ?**  
Aspose.Slides prend en charge [la génération de miniatures pour des formes individuelles](/slides/fr/nodejs-java/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.  

**La conversion parallèle est‑elle prise en charge sur un serveur ?**  
Oui, mais [ne partagez pas](/slides/fr/nodejs-java/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance séparée par thread ou processus.  

**Quelles sont les limitations de la version d'essai lors de l'exportation en PNG ?**  
Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/nodejs-java/licensing/) jusqu'à ce qu'une licence soit appliquée.