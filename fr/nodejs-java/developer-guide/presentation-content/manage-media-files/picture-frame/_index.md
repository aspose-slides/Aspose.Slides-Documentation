---
title: Gérer les cadres d'image dans les présentations avec JavaScript
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/nodejs-java/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- mise à l'échelle relative
- effet d'image
- ratio d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d'image est une forme qui contient une image — c’est comme une image dans un cadre.  

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez formater l'image en formatant le cadre d'image.

{{% alert  title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits — [JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Créez un objet `PPImage` en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.  
4. Spécifiez la largeur et la hauteur de l'image.  
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFrame) en fonction de la largeur et de la hauteur de l'image via la méthode `addPictureFrame` exposée par l'objet shape associé à la diapositive référencée.  
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.  
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Ce code JavaScript vous montre comment créer un cadre d'image :

```javascript
// Instancie la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre d'image avec la même hauteur et largeur que l'image
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Les cadres d'image vous permettent de créer rapidement des diapositives de présentation à partir d'images. En combinant le cadre d'image avec les options d'enregistrement d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir les images d'un format à un autre.

## **Créer un cadre d'image avec mise à l’échelle relative**

En modifiant la mise à l’échelle relative d'une image, vous pouvez créer un cadre d'image plus complexe.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Ajoutez une image à la collection d'images de la présentation.  
4. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.  
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre d'image.  
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.  

Ce code JavaScript vous montre comment créer un cadre d'image avec mise à l’échelle relative :

```javascript
// Instancie la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Définit la mise à l'échelle relative en largeur et hauteur
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extraire des images raster à partir de cadres d'image**

Vous pouvez extraire des images raster des objets [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFrame) et les enregistrer en PNG, JPG et autres formats. L'exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l'enregistrer au format PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Extraire des images SVG à partir de cadres d'image**

Lorsqu’une présentation contient des graphiques SVG placés dans des formes [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides pour Node.js via Java vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/), vérifier si le [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) sous‑jacent contient du contenu SVG, puis enregistrer cette image sur le disque ou dans un flux au format SVG natif.

L’exemple de code suivant montre comment extraire une image SVG d’un cadre d'image :

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Obtenir la transparence d’une image**

Aspose.Slides vous permet d’obtenir l’effet de transparence appliqué à une image. Ce code JavaScript montre l’opération :

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Mise en forme du cadre d'image**

Aspose.Slides offre de nombreuses options de mise en forme qui peuvent être appliquées à un cadre d'image. En utilisant ces options, vous pouvez modifier un cadre d'image pour qu’il réponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d'une diapositive par son indice.  
3. Créez un objet [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PPImage)