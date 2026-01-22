---
title: Convertir les diapositives PowerPoint en PNG avec JavaScript
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertissez rapidement des présentations PowerPoint en images PNG de haute qualité avec JavaScript grâce à Aspose.Slides pour Node.js, garantissant des résultats précis et automatisés."
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très populaire. 

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un format d'image meilleur que le JPEG. 

{{% alert title="Tip" color="primary" %}} Vous pouvez consulter les **Convertisseurs PowerPoint en PNG** gratuits d'Aspose : [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils constituent une implémentation en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenir l'objet diapositive à partir de la collection renvoyée par la méthode [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) de la classe [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. Utiliser la méthode [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) pour obtenir la miniature de chaque diapositive.
4. Utiliser la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) pour enregistrer la miniature de la diapositive au format PNG.

Ce code JavaScript vous montre comment convertir une présentation PowerPoint en PNG:
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


## **Convertir PowerPoint en PNG avec dimensions personnalisées**

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


## **Convertir PowerPoint en PNG avec taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG d'une certaine taille, vous pouvez transmettre vos arguments `width` et `height` préférés pour `ImageSize`. 

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

**Comment exporter uniquement une forme spécifique (par exemple, un graphique ou une image) plutôt que la diapositive entière ?**  
Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/nodejs-java/create-shape-thumbnails/) ; vous pouvez rendre une forme sous forme d'image PNG.  

**La conversion parallèle est‑elle prise en charge sur un serveur ?**  
Oui, mais [ne partagez pas](/slides/fr/nodejs-java/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.  

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**  
Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/nodejs-java/licensing/) tant qu'une licence n'est pas appliquée.