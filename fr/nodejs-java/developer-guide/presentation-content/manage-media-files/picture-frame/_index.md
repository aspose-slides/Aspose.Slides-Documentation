---
title: Gérer les cadres d'image dans les présentations à l'aide de JavaScript
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/nodejs-java/picture-frame/
keywords:
- cadre d'image
- ajouter cadre d'image
- créer cadre d'image
- ajouter image
- créer image
- extraire image
- image matricielle
- image vectorielle
- rogner image
- zone rognée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- échelle relative
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

Un cadre d'image est une forme qui contient une image — c'est comme une image dans un cadre.  

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez formater l'image en formatant le cadre d'image.

{{% alert title="Astuce" color="primary" %}} 
Aspose propose des convertisseurs gratuits — [JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d'images. 
{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet `PPImage` en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection) associée à l'objet présentation qui sera utilisée pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFrame) basé sur la largeur et la hauteur de l'image via la méthode `addPictureFrame` exposée par l'objet forme associé à la diapositive référencée.
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
7. Enregistrez la présentation modifiée au format PPTX.

```javascript
// Instancie la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
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

Les cadres d'image vous permettent de créer rapidement des diapositives de présentation à partir d'images. Lorsque vous combinez le cadre d'image avec les options d'enregistrement d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir des images d'un format à un autre.

## **Créer un cadre d'image avec mise à l'échelle relative**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet `PPImage` en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection) associée à l'objet présentation qui sera utilisée pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre d'image.
6. Enregistrez la présentation modifiée au format PPTX.

```javascript
// Instancie la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre d'image avec la même hauteur et largeur que l'image
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Définit l'échelle relative de la hauteur et de la largeur
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

## **Extraire des images matricielles des cadres d'image**

Vous pouvez extraire des images matricielles des objets [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFrame) et les enregistrer au format PNG, JPG et autres. L'exemple de code ci‑dessous montre comment extraire une image du document "sample.pptx" et l'enregistrer au format PNG.

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

## **Extraire des images SVG des cadres d'image**

Lorsqu'une présentation contient des graphiques SVG placés à l'intérieur des formes [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides pour Node.js via Java vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/), vérifier si le [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) sous‑jacent contient du contenu SVG, puis enregistrer cette image sur le disque ou dans un flux au format SVG natif.

Le code suivant montre comment extraire une image SVG d'un cadre d'image :

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

## **Obtenir la transparence d'une image**

Aspose.Slides vous permet d'obtenir l'effet de transparence appliqué à une image. Ce code JavaScript montre l'opération :

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

## **Obtenir la luminosité et le contraste d'une image**

Aspose.Slides vous permet d'obtenir l'effet de luminosité et de contraste appliqué à une image. La classe [Luminance](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/luminance/) représente cet effet de transformation d'image.

Ce code JavaScript montre comment obtenir les paramètres de luminosité et de contraste d'un cadre d'image :

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mise en forme du cadre d'image**

Aspose.Slides propose de nombreuses options de mise en forme qui peuvent être appliquées à un cadre d'image. En utilisant ces options, vous pouvez modifier un cadre d'image afin qu'il réponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet `PPImage` en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection) associée à l'objet présentation qui sera utilisée pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [addPictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) exposée par l'objet [Shapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ShapeCollection) associé à la diapositive référencée.
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
7. Définissez la couleur du contour du cadre d'image.
8. Définissez l'épaisseur du contour du cadre d'image.
9. Faites pivoter le cadre d'image en lui attribuant une valeur positive ou négative.
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre. 
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
11. Enregistrez la présentation modifiée au format PPTX.

```javascript
// Instancie la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre d'image avec la même hauteur et largeur que l'image
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Applique un certain formatage à PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Astuce" color="primary" %}}
Aspose a récemment développé un [outil gratuit de création de collages](https://products.aspose.app/slides/fr/collage). Si vous devez [fusionner des images JPG/JPEG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG, ou [créer des grilles à partir de photos](https://products.aspose.app/slides/fr/collage/photo-grid), vous pouvez utiliser ce service. 
{{% /alert %}}

## **Ajouter une image sous forme de lien**

Pour éviter d'alourdir les présentations, vous pouvez ajouter des images (ou vidéos) via des liens plutôt que d'incorporer les fichiers directement dans les présentations. Ce code JavaScript vous montre comment ajouter une image et une vidéo dans un espace réservé :

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Rogner une image**

Ce code JavaScript montre comment rogner une image existante sur une diapositive :

```javascript
var pres = new aspose.slides.Presentation();
// Crée un nouvel objet image
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajoute un PictureFrame à une diapositive
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Recadre l'image (valeurs en pourcentage)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Enregistre le résultat
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Supprimer les zones rognées d'un cadre d'image**

Si vous souhaitez supprimer les zones rognées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Cette méthode renvoie l'image rognée ou l'image d'origine si le rognage n'est pas nécessaire.

Ce code JavaScript montre l'opération :

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Récupère le PictureFrame de la première diapositive
    var picFrame = slide.getShapes().get_Item(0);
    // Supprime les zones rognées de l'image du PictureFrame et renvoie l'image rognée
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Enregistre le résultat
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ajoute l'image rognée à la collection d'images de la présentation. Si l'image n'est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les métafichiers WMF/EMF en images PNG matricielles lors de l'opération de rognage. 
{{% /alert %}}

## **Compresser des images**

Vous pouvez compresser une image dans une présentation à l'aide de la méthode [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) . Cette méthode compresse une image en réduisant sa taille en fonction de la taille de la forme et de la résolution spécifiée, avec la possibilité de supprimer les zones rognées.

Elle ajuste la taille et la résolution de l'image de manière similaire à la fonction **Format de l'image → Compresser les images → Résolution** de PowerPoint.

Les exemples JavaScript suivants montrent comment compresser une image dans une présentation en spécifiant une résolution cible et, éventuellement, en supprimant les zones rognées :

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Compresse l'image avec une résolution cible de 150 DPI (résolution Web) et supprime les zones rognées.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Vérifie le résultat de la compression.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ou en utilisant une autre valeur DPI prédéfinie :

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Compresse l'image à 96 DPI (résolution email), en supprimant les zones rognées.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
La méthode convertit l'image à une résolution inférieure en fonction de la taille de la forme et du DPI fourni. Les zones rognées peuvent également être supprimées afin d'optimiser la taille du fichier.
Si l'image est un méfichier (WMF/EMF) ou un SVG, la compression ne sera pas appliquée. De plus, la qualité JPEG est conservée ou légèrement réduite selon la résolution, de la même façon que PowerPoint gère les JPEG haute résolution. 
{{% /alert %}}

## **Verrouiller le ratio d'aspect**

Si vous souhaitez qu'une forme contenant une image conserve son ratio d'aspect même après avoir modifié les dimensions de l'image, vous pouvez utiliser la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) pour activer le paramètre *Lock Aspect Ratio*.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // définir la forme pour qu'elle préserve le ratio d'aspect lors du redimensionnement
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Ce paramètre *Lock Aspect Ratio* conserve uniquement le ratio d'aspect de la forme et non celui de l'image qu'elle contient. 
{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les méthodes [setStretchOffsetLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) et [setStretchOffsetBottom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) de la classe [PictureFillFormat], vous pouvez spécifier un rectangle de remplissage.

Lorsque l'étirement est spécifié pour une image, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait tandis qu'un pourcentage négatif indique une extension.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage par image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages de l'image à partir du bord correspondant de la boîte englobante de la forme
9. Enregistrez la présentation modifiée au format PPTX.

```javascript
// Instancie la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Instancie la classe ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajoute une AutoShape de type Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Définit le type de remplissage de la forme
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Définit le mode de remplissage par image de la forme
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Définit l'image pour remplir la forme
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Spécifie les décalages de l'image par rapport au bord correspondant de la boîte englobante de la forme
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Enregistre le fichier PPTX sur le disque
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Comment savoir quels formats d'image sont pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge à la fois les images matricielles (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple, SVG) via l'objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/). La liste des formats pris en charge se recoupe généralement avec les capacités du moteur de conversion de diapositives et d'images.

**Comment l'ajout de dizaines d'images volumineuses affecte-t-il la taille et les performances du PPTX ?**

L'incorporation d'images volumineuses augmente la taille du fichier et la consommation de mémoire ; le fait d'utiliser des liens d'images permet de réduire la taille de la présentation, mais les fichiers externes doivent rester accessibles. Aspose.Slides offre la possibilité d'ajouter des images par lien afin de réduire la taille du fichier.

**Comment puis‑je verrouiller un objet image contre les déplacements/redimensionnements accidentels ?**

Utilisez les [verrous de forme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) pour un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est pris en charge pour différents types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/).

**La fidélité vectorielle du SVG est‑elle conservée lors de l'exportation d'une présentation vers PDF/images ?**

Aspose.Slides permet d'extraire un SVG d'un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) en tant que vecteur original. Lors de l'[exportation vers PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) ou des [formats raster](/slides/fr/nodejs-java/convert-powerpoint-to-png/), le résultat peut être rasterisé en fonction des paramètres d'exportation ; le fait que le SVG original soit stocké comme vecteur est confirmé par le comportement d'extraction.