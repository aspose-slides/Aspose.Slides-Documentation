---
title: Gérer les cadres d'image dans les présentations a l'aide de Java
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/java/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- creer un cadre d'image
- ajouter une image
- creer une image
- extraire une image
- image matricielle
- image vectorielle
- rogner une image
- zone rognée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- échelle relative
- effet d'image
- rapport d'aspect
- transparence de l'image
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides for Java. Simplifiez votre flux de travail et améliorez la conception des diapositives.
---

Un cadre d'image est une forme qui contient une image — c'est comme une photo dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez formater l'image en formatant le cadre d'image.

{{% alert  title="Tip" color="primary" %}} 
Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d'images. 
{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [IPPImage]() en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet forme associé à la diapositive référencée.
6. Ajoutez un cadre d'image (contenant l'image) à la diapositive.
7. Enregistrez la présentation modifiée en fichier PPTX.

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
Les cadres d'image vous permettent de créer rapidement des diapositives de présentation basées sur des images. Lorsque vous combinez le cadre d'image avec les options d'enregistrement Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir les images d'un format à un autre. Vous voudrez peut-être consulter ces pages : convertir [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).
{{% /alert %}}

## **Créer un cadre d'image avec mise à l'échelle relative**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre d'image.
6. Enregistrez la présentation modifiée en fichier PPTX.

```java
// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Définit la mise à l'échelle relative en hauteur et en largeur
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Extraire les images matricielles des cadres d'image**

Vous pouvez extraire des images matricielles des objets [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) et les enregistrer au format PNG, JPG et autres. L'exemple de code ci-dessous montre comment extraire une image du document "sample.pptx" et l'enregistrer au format PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
            IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```


## **Extraire les images SVG des cadres d'image**

Lorsque une présentation contient des graphiques SVG placés à l'intérieur de formes [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), Aspose.Slides for Java vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), vérifier si l'[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) sous-jacent contient du contenu SVG, puis enregistrer cette image sur le disque ou dans un flux au format SVG natif.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```


## **Obtenir la transparence d'une image**

Aspose.Slides vous permet d'obtenir l'effet de transparence appliqué à une image. Ce code Java montre l'opération :

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```


## **Mise en forme du cadre d'image**

Aspose.Slides propose de nombreuses options de mise en forme qui peuvent être appliquées à un cadre d'image. En utilisant ces options, vous pouvez modifier un cadre d'image pour qu'il réponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) exposée par l'objet [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) associé à la diapositive référencée.
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
7. Définissez la couleur de la ligne du cadre d'image.
8. Définissez la largeur de la ligne du cadre d'image.
9. Faites pivoter le cadre d'image en lui donnant une valeur positive ou négative.
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre. 
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
11. Enregistrez la présentation modifiée en fichier PPTX.

```java
// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Applique un certain formatage à PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Écrit le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}}
Aspose a récemment développé un [free Collage Maker](https://products.aspose.app/slides/collage). Si vous avez besoin de [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 
{{% /alert %}}

## **Ajouter une image en tant que lien**

Pour éviter des présentations de grande taille, vous pouvez ajouter des images (ou vidéos) via des liens au lieu d'intégrer les fichiers directement dans les présentations. Ce code Java montre comment ajouter une image et une vidéo dans un espace réservé :

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Rogner les images**

Ce code Java montre comment rogner une image existante sur une diapositive :

```java
Presentation pres = new Presentation();
// Crée un nouvel objet image
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute un PictureFrame à une diapositive
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Recadre l'image (valeurs en pourcentage)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Enregistre le résultat
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer les zones rognées d'un cadre d'image**

Si vous souhaitez supprimer les zones rognées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Cette méthode renvoie l'image rognée ou l'image d'origine si le rognage n'est pas nécessaire.

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtient le PictureFrame de la première diapositive
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Supprime les zones recadrées de l'image du PictureFrame et renvoie l'image recadrée
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Enregistre le résultat
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ajoute l'image rognée à la collection d'images de la présentation. Si l'image n'est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les métafichiers WMF/EMF en image PNG matricielle lors de l'opération de rognage. 
{{% /alert %}}

## **Verrouiller le rapport d'aspect**

Si vous souhaitez qu'une forme contenant une image conserve son rapport d'aspect même après avoir modifié les dimensions de l'image, vous pouvez utiliser la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) pour définir le paramètre *Lock Aspect Ratio*. 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // définir la forme afin de préserver le ratio d'aspect lors du redimensionnement
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
Ce paramètre *Lock Aspect Ratio* préserve uniquement le rapport d'aspect de la forme et non de l'image qu'elle contient. 
{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) et [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat), vous pouvez spécifier un rectangle de remplissage. 

Lorsque l'étirement est spécifié pour une image, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait tandis qu'un pourcentage négatif indique un dépassement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d'image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages d'image par rapport au bord correspondant de la boîte englobante de la forme.
9. Enregistrez la présentation modifiée en fichier PPTX.

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Instancie la classe ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute un AutoShape de type Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Définit le type de remplissage de la forme
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Définit le mode de remplissage image de la forme
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Définit l'image pour remplir la forme
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spécifie les décalages de l'image par rapport au bord correspondant de la boîte englobante de la forme
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Enregistre le fichier PPTX sur le disque
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Comment savoir quels formats d'image sont pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge les images matricielles (PNG, JPEG, BMP, GIF, etc.) ainsi que les images vectorielles (par exemple, SVG) via l'objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). La liste des formats pris en charge chevauche généralement les capacités du moteur de conversion de diapositives et d'images.

**Comment l'ajout de dizaines d'images volumineuses affecte-t-il la taille et les performances du PPTX ?**

L'intégration d'images volumineuses augmente la taille du fichier et la consommation de mémoire ; le lien d'images permet de réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d'ajouter des images par lien pour diminuer la taille du fichier.

**Comment verrouiller un objet image contre les déplacements/redimensionnements accidentels ?**

Utilisez les [verrous de forme](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) pour un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit pour les formes dans un article séparé sur la [protection](/slides/fr/java/applying-protection-to-presentation/) et est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).

**La fidélité vectorielle SVG est-elle préservée lors de l'exportation d'une présentation vers PDF/images ?**

Aspose.Slides permet d'extraire un SVG d'un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) en tant que vecteur original. Lors de l'[exportation vers PDF](/slides/fr/java/convert-powerpoint-to-pdf/) ou des [formats matriciels](/slides/fr/java/convert-powerpoint-to-png/), le résultat peut être matricialisé selon les paramètres d'exportation ; le fait que le SVG original soit stocké en vecteur est confirmé par le comportement d'extraction.