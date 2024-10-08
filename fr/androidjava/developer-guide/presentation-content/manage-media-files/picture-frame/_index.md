---
title: Cadre Photo
type: docs
weight: 10
url: /fr/androidjava/picture-frame/
keywords: "Ajouter un cadre photo, créer un cadre photo, ajouter une image, créer une image, extraire une image, propriété StretchOff, mise en forme du cadre photo, propriétés du cadre photo, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Ajouter un cadre photo à une présentation PowerPoint en Java"

---

Un cadre photo est une forme qui contient une image—c'est comme une image dans un cadre.

Vous pouvez ajouter une image à une diapositive à travers un cadre photo. De cette façon, vous pouvez formater l'image en formatant le cadre photo.

{{% alert title="Conseil" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d'images.

{{% /alert %}} 

## **Créer un Cadre Photo**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index. 
3. Créez un objet [IPPImage]() en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) basé sur la largeur et la hauteur de l'image à l'aide de la méthode `AddPictureFrame` exposée par l'objet forme associé à la diapositive référencée.
6. Ajoutez un cadre photo (contenant l'image) à la diapositive.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre photo :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre photo avec la hauteur et la largeur équivalentes de l'image
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Écrit le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Les cadres photo vous permettent de créer rapidement des diapositives de présentation basées sur des images. Lorsque vous combinez le cadre photo avec les options de sauvegarde d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir des images d'un format à un autre. Vous voudrez peut-être consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un Cadre Photo avec Échelle Relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre photo plus complexe. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index. 
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre photo.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre photo avec une échelle relative :

```java
// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Ajoute un cadre photo avec la hauteur et la largeur équivalentes de l'image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Définit l'échelle relative de la hauteur et de la largeur
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Écrit le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraire une Image d'un Cadre Photo**

Vous pouvez extraire des images d'objets [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) et les enregistrer au format PNG, JPG, et d'autres formats. L'exemple de code ci-dessous montre comment extraire une image du document "sample.pptx" et l'enregistrer au format PNG.

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

## **Obtenir la Transparence de l'Image**

Aspose.Slides vous permet d'obtenir la transparence d'une image. Ce code Java démontre l'opération :

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Transparence de l'image : " + transparencyValue);
    }
}
```

## **Mise en Forme du Cadre Photo**

Aspose.Slides propose de nombreuses options de mise en forme qui peuvent être appliquées à un cadre photo. En utilisant ces options, vous pouvez modifier un cadre photo pour qu'il corresponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image à l'aide de la méthode [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) exposée par l'objet [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) associé à la diapositive référencée.
6. Ajoutez le cadre photo (contenant l'image) à la diapositive.
7. Définissez la couleur de ligne du cadre photo.
8. Définissez la largeur de ligne du cadre photo.
9. Faites pivoter le cadre photo en lui donnant une valeur positive ou négative.
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre. 
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre photo (contenant l'image) à la diapositive.
11. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java démontre le processus de mise en forme du cadre photo :

```java
// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre photo avec la hauteur et la largeur équivalentes de l'image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Applique quelques mises en forme au cadre photo
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

{{% alert title="Conseil" color="primary" %}}

Aspose a récemment développé un [Collage Maker gratuit](https://products.aspose.app/slides/collage). Si vous avez besoin de [fusionner des images JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou PNG, [créer des grilles à partir de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Ajouter une Image en tant que Lien**

Pour éviter de grandes tailles de présentation, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d'incorporer les fichiers directement dans les présentations. Ce code Java montre comment ajouter une image et une vidéo dans un espace réservé :

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

## **Recadrer une Image**

Ce code Java montre comment recadrer une image existante sur une diapositive :

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

    // Ajoute un cadre photo à une diapositive
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

## Supprimer les Zones Recadrées de l'Image

Si vous souhaitez supprimer les zones recadrées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Cette méthode retourne l'image recadrée ou l'image d'origine si le recadrage n'est pas nécessaire.

Ce code Java démontre l'opération :

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtient le cadre photo de la première diapositive
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Supprime les zones recadrées de l'image du cadre photo et retourne l'image recadrée
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Enregistre le résultat
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ajoute l'image recadrée à la collection d'images de la présentation. Si l'image est uniquement utilisée dans le [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les fichiers WMF/EMF métadonnées en image raster PNG lors de l'opération de recadrage. 

{{% /alert %}}

## **Verrouiller le Rapport d'Aspect**

Si vous souhaitez qu'une forme contenant une image conserve son rapport d'aspect même après avoir changé les dimensions de l'image, vous pouvez utiliser la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) pour définir le paramètre *Verrouiller le Rapport d'Aspect*.

Ce code Java montre comment verrouiller le rapport d'aspect d'une forme :

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

    // Définit la forme pour préserver le rapport d'aspect lors du redimensionnement
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Ce paramètre *Verrouiller le Rapport d'Aspect* préserve uniquement le rapport d'aspect de la forme et non de l'image qu'elle contient.

{{% /alert %}}

## **Utiliser la Propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) et [StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat), vous pouvez spécifier un rectangle de remplissage.

Lorsque l'étirement est spécifié pour une image, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif spécifie un renfoncement tandis qu'un pourcentage négatif spécifie un dépassement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentatio).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une forme rectangulaire `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d'image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages d'image par rapport au bord correspondant de la boîte englobante de la forme.
9. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java démontre un processus dans lequel une propriété StretchOff est utilisée :

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

    // Ajoute une forme AutoShape définie sur Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Définit le type de remplissage de la forme
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Définit le mode de remplissage d'image de la forme
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Définit l'image pour remplir la forme
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spécifie les décalages d'image par rapport au bord correspondant de la boîte englobante de la forme
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Écrit le fichier PPTX sur le disque
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```