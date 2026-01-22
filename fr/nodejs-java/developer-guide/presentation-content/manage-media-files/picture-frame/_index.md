---
title: Gérer les cadres image dans les présentations avec JavaScript
linktitle: Cadre image
type: docs
weight: 10
url: /fr/nodejs-java/picture-frame/
keywords:
- cadre image
- ajouter un cadre image
- créer un cadre image
- ajouter une image
- créer une image
- extraire une image
- image matricielle
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre image
- propriétés du cadre image
- mise à l'echelle relative
- effet d'image
- rapport d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajoutez des cadres image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---

Un cadre image est une forme qui contient une image — c’est comme une photo dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre image. Ainsi, vous pouvez formater l’image en formatant le cadre image.

{{% alert  title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

## **Créer un cadre image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index. 
3. Créez un objet `PPImage` en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) associée à l’objet présentation qui sera utilisé pour remplir la forme.
4. Précisez la largeur et la hauteur de l’image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) basé sur la largeur et la hauteur de l’image via la méthode `addPictureFrame` exposée par l’objet forme associé à la diapositive référencée.
6. Ajoutez un cadre image (contenant l’image) à la diapositive.
7. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un cadre image :
```javascript
// Instancie la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre image avec la même hauteur et largeur que l'image
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


Les cadres image vous permettent de créer rapidement des diapositives de présentation à partir d’images. En combinant le cadre image avec les options d’enregistrement d’Aspose.Slides, vous pouvez manipuler les opérations d’entrée/sortie pour convertir des images d’un format à un autre.

## **Créer un cadre image avec mise à l’échelle relative**

En modifiant la mise à l’échelle relative d’une image, vous pouvez créer un cadre image plus complexe. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index. 
3. Ajoutez une image à la collection d’images de la présentation.
4. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) associée à l’objet présentation qui sera utilisé pour remplir la forme.
5. Précisez la largeur et la hauteur relatives de l’image dans le cadre image.
6. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un cadre image avec mise à l’échelle relative :
```javascript
// Instancie la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre image avec la hauteur et la largeur équivalentes de l'image
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Définit la mise à l'échelle relative de la hauteur et de la largeur
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


## **Extraire des images matricielles des cadres image**

Vous pouvez extraire des images matricielles des objets [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) et les enregistrer au format PNG, JPG et autres. L’exemple de code ci‑dessous montre comment extraire une image du document **sample.pptx** et l’enregistrer au format PNG.
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


## **Extraire des images SVG des cadres image**

Lorsqu’une présentation contient des graphiques SVG placés à l’intérieur de formes [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java vous permet de récupérer les images vectorielles d’origine avec pleine fidélité. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), vérifier si l’objet sous‑jacent [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) contient du contenu SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

L’exemple de code suivant montre comment extraire une image SVG d’un cadre image :
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


## **Mise en forme du cadre image**

Aspose.Slides propose de nombreuses options de mise en forme pouvant être appliquées à un cadre image. En utilisant ces options, vous pouvez modifier un cadre image pour qu’il corresponde à des exigences précises.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index. 
3. Créez un objet [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) en ajoutant une image à la [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) associée à l’objet présentation qui sera utilisé pour remplir la forme.
4. Précisez la largeur et la hauteur de l’image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l’image via la méthode [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) exposée par l’objet [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) associé à la diapositive référencée.
6. Ajoutez le cadre image (contenant la photo) à la diapositive.
7. Définissez la couleur du trait du cadre image.
8. Définissez la largeur du trait du cadre image.
9. Faites pivoter le cadre image en lui attribuant une valeur positive ou négative.
   * Une valeur positive fait pivoter l’image dans le sens des aiguilles d’une montre. 
   * Une valeur négative fait pivoter l’image dans le sens inverse des aiguilles d’une montre.
10. Ajoutez le cadre image (contenant la photo) à la diapositive.
11. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript illustre le processus de mise en forme du cadre image :
```javascript
// Instancie la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Instancie la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Ajoute un cadre image avec la hauteur et la largeur équivalentes de l'image
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

Aspose a récemment développé un [créateur de collages gratuit](https://products.aspose.app/slides/collage). Si vous avez besoin de [fusionner des images JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou PNG, ou de [créer des grilles à partir de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Ajouter une image en tant que lien**

Pour éviter que la taille de la présentation ne devienne trop volumineuse, vous pouvez ajouter des images (ou des vidéos) via des liens plutôt qu’en intégrant les fichiers directement dans les présentations. Ce code JavaScript montre comment ajouter une image et une vidéo dans un espace réservé :
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


## **Supprimer les zones rognées d’un cadre image**

Si vous souhaitez supprimer les zones rognées d’une image contenue dans un cadre, vous pouvez utiliser la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Cette méthode renvoie l’image rognée ou l’image d’origine si le rognage n’est pas nécessaire.

Ce code JavaScript montre l’opération :
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

La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ajoute l’image rognée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d’images dans la présentation résultante augmentera.

Cette méthode convertit les mét fichiers WMF/EMF en images PNG matricielles lors de l’opération de rognage. 

{{% /alert %}}

## **Verrouiller le rapport d’aspect**

Si vous souhaitez qu’une forme contenant une image conserve son rapport d’aspect même après modification des dimensions de l’image, vous pouvez utiliser la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) pour activer le paramètre *Verrouiller le rapport d’aspect*.

Ce code JavaScript montre comment verrouiller le rapport d’aspect d’une forme :
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
    // définir la forme pour qu'elle préserve le rapport d'aspect lors du redimensionnement
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

Ce paramètre *Verrouiller le rapport d’aspect* ne préserve que le rapport d’aspect de la forme et non celui de l’image qu’elle contient.

{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les méthodes [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) et [setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) de la classe [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat), vous pouvez spécifier un rectangle de remplissage.

Lorsque l’étirement est indiqué pour une image, un rectangle source est mis à l’échelle pour s’adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait, tandis qu’un pourcentage négatif indique un débordement.

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un `AutoShape` rectangle. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage image de la forme.
7. Ajoutez une image à utiliser pour remplir la forme.
8. Précisez les décalages de l’image par rapport au bord correspondant de la boîte englobante de la forme.
9. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre un processus utilisant la propriété StretchOff :
```javascript
// Instancie la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
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
    // Ajoute un AutoShape défini comme Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Définit le type de remplissage de la forme
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Définit le mode de remplissage image de la forme
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

**Comment savoir quels formats d’image sont pris en charge pour les cadres image ?**

Aspose.Slides prend en charge les images matricielles (PNG, JPEG, BMP, GIF, etc.) ainsi que les images vectorielles (par exemple, SVG) via l’objet image affecté à un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/). La liste des formats pris en charge chevauche généralement les capacités du moteur de conversion de diapositives et d’images.

**Quel impact l’ajout de dizaines d’images volumineuses a‑t‑il sur la taille et les performances du PPTX ?**

L’intégration d’images volumineuses augmente la taille du fichier et la consommation mémoire ; le lien d’images permet de réduire la taille de la présentation mais requiert que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien afin de diminuer la taille du fichier.

**Comment verrouiller un objet image pour éviter un déplacement/redimensionnement accidentel ?**

Utilisez les [verrous de forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) pour un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est pris en charge pour divers types de forme, y compris les [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).

**La fidélité vectorielle SVG est‑elle préservée lors de l’exportation d’une présentation vers PDF/images ?**

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) sous forme de vecteur original. Lors de l’[exportation vers PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) ou vers des [formats matriciels](/slides/fr/nodejs-java/convert-powerpoint-to-png/), le résultat peut être rasterisé selon les paramètres d’exportation ; le fait que le SVG original soit stocké en tant que vecteur est confirmé par le comportement d’extraction.