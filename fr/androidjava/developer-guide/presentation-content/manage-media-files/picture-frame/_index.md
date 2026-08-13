---
title: Gérer les cadres image dans les présentations sur Android
linktitle: Cadre image
type: docs
weight: 10
url: /fr/androidjava/picture-frame/
keywords:
- cadre image
- ajouter un cadre image
- créer un cadre image
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- rogner une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre image
- propriétés du cadre image
- échelle relative
- effet d’image
- ratio d’aspect
- transparence de l’image
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajoutez des cadres image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre image est une forme qui contient une image — c’est comme une photo dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre image. Ainsi, vous pouvez formater l’image en formatant le cadre image.

{{% alert  title="Astuce" color="info" %}} 

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

## **Create a Picture Frame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Créez un objet [IPPImage]() en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IImageCollection) associée à l’objet presentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l’image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/PictureFrame) basé sur la largeur et la hauteur de l’image via la méthode `AddPictureFrame` exposée par l’objet shape associé à la diapositive référencée.
6. Ajoutez un cadre image (contenant l’image) à la diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre image :

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre image avec la même hauteur et largeur que l’image
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create a Picture Frame with Relative Scale**

En modifiant l’échelle relative d’une image, vous pouvez créer un cadre image plus complexe. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez une image à la collection d’images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IImageCollection) associée à l’objet presentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l’image dans le cadre image.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre image avec une échelle relative :

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Ajoute un cadre image avec la même hauteur et largeur que l’image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Définit l’échelle relative en hauteur et largeur
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract Raster Images from Picture Frames**

Vous pouvez extraire des images raster des objets [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/PictureFrame) et les enregistrer au format PNG, JPG et autres. L’exemple de code ci‑dessous montre comment extraire une image du document "sample.pptx" et l’enregistrer au format PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extract SVG Images from Picture Frames**

Lorsqu’une présentation contient des graphiques SVG placés à l’intérieur de formes [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/) , Aspose.Slides pour Android via Java vous permet de récupérer les images vectorielles d’origine avec une fidélité totale. Une fois que vous avez un [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/) dont le [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) contient du contenu SVG, vous pouvez lire cette image SVG et l’enregistrer sur disque ou dans un flux au format SVG natif.

L’exemple de code suivant montre comment extraire une image SVG d’un cadre image :

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **Get Transparency of an Image**

Aspose.Slides vous permet d’obtenir l’effet de transparence appliqué à une image. Ce code Java montre l’opération :

```java
import com.aspose.slides.*;

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

## **Get Brightness and Contrast of an Image**

Aspose.Slides vous permet d’obtenir les effets de luminosité et de contraste appliqués à une image. L’interface [ILuminance](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iluminance/) représente cet effet de transformation d’image.

Ce code Java montre comment obtenir les réglages de luminosité et de contraste d’un cadre image :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Picture Frame Formatting**

Aspose.Slides propose de nombreuses options de mise en forme pouvant être appliquées à un cadre image. En utilisant ces options, vous pouvez modifier un cadre image pour qu’il corresponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IImageCollection) associée à l’objet presentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l’image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l’image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) exposée par l’objet [IShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShapeCollection) associé à la diapositive référencée.
6. Ajoutez le cadre image (contenant l’image) à la diapositive.
7. Définissez la couleur de la bordure du cadre image.
8. Définissez la largeur de la bordure du cadre image.
9. Faites pivoter le cadre image en lui attribuant une valeur positive ou négative.  
   * Une valeur positive fait pivoter l’image dans le sens des aiguilles d’une montre.  
   * Une valeur négative fait pivoter l’image dans le sens inverse des aiguilles d’une montre.
10. Ajoutez le cadre image (contenant l’image) à la diapositive.
11. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre le processus de mise en forme du cadre image :

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre image avec la même hauteur et largeur que l’image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Applique un certain formatage au PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Astuce" color="info" %}}

Aspose a récemment développé un [Créateur de collage gratuit](https://products.aspose.app/slides/fr/collage). Si vous devez jamais [fusionner des images JPG/JPEG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG, ou [créer des grilles à partir de photos](https://products.aspose.app/slides/fr/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Add an Image as a Link**

Pour éviter que la taille d’une présentation devienne trop importante, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d’intégrer les fichiers directement dans les présentations. Ce code Java montre comment ajouter une image et une vidéo dans un espace réservé :

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

## **Crop Images**

Ce code Java montre comment recadrer une image existante sur une diapositive :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Crée un nouvel objet image
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute un cadre image à une diapositive
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Recadre l’image (valeurs en pourcentage)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Enregistre le résultat
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Delete Cropped Areas of a Picture**

Si vous souhaitez supprimer les zones recadrées d’une image contenue dans un cadre, vous pouvez utiliser la méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Cette méthode renvoie l’image recadrée ou l’image d’origine si le recadrage est inutile.

Ce code Java montre l’opération :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtient le PictureFrame de la première diapositive
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Supprime les zones recadrées de l’image du PictureFrame et renvoie l’image recadrée
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Enregistre le résultat
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

La méthode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ajoute l’image recadrée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Dans le cas contraire, le nombre d’images dans la présentation résultante augmentera.

Cette méthode convertit les fichiers métafichier WMF/EMF en image PNG raster lors de l’opération de recadrage. 

{{% /alert %}}

## **Compress Images**

Vous pouvez compresser une image dans une présentation à l’aide de la méthode [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Cette méthode compresse une image en réduisant sa taille en fonction de la taille de la forme et de la résolution spécifiée, avec la possibilité de supprimer les zones recadrées.

Elle ajuste la taille et la résolution de l’image de façon similaire à la fonction **Picture Format > Compress Pictures > Resolution** de PowerPoint.

Les exemples Java suivants montrent comment compresser une image dans une présentation en spécifiant une résolution cible et, éventuellement, en supprimant les zones recadrées :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Compresse l'image avec une résolution cible de 150 DPI (résolution Web) et supprime les zones recadrées.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ou en utilisant directement une valeur DPI personnalisée :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Compresse l'image à 150 DPI (résolution web), en supprimant les zones recadrées.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

La méthode convertit l’image à une résolution inférieure en fonction de la taille de la forme et du DPI fourni. Les régions recadrées peuvent également être supprimées pour optimiser la taille du fichier.  
Si l’image est un métafichier (WMF/EMF) ou SVG, la compression ne sera pas appliquée. De plus, la qualité JPEG est conservée ou légèrement réduite selon la résolution, de la même manière que PowerPoint gère les JPEG haute résolution.

{{% /alert %}}

## **Lock Aspect Ratio**

Si vous souhaitez qu’une forme contenant une image conserve son ratio d’aspect même après avoir modifié les dimensions de l’image, vous pouvez utiliser la méthode [setAspectRatioLocked](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) pour définir le paramètre *Lock Aspect Ratio*.

Ce code Java montre comment verrouiller le ratio d’aspect d’une forme :

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // définir la forme afin de préserver le ratio d'aspect lors du redimensionnement
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Ce paramètre *Lock Aspect Ratio* préserve uniquement le ratio d’aspect de la forme et non celui de l’image qu’elle contient.

{{% /alert %}}

## **Use the StretchOff Property**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) et [StretchOffsetBottom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPictureFillFormat) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPictureFillFormat), vous pouvez spécifier un rectangle de remplissage.

Lorsque l’étirement est indiqué pour une image, un rectangle source est mis à l’échelle pour s’ajuster au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait tandis qu’un pourcentage négatif indique un dépassement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d’image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages de l’image à partir du bord correspondant de la boîte englobante de la forme
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre un processus où la propriété StretchOff est utilisée :

```java
import com.aspose.slides.*;

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

    // Ajoute une AutoShape définie comme Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Définit le type de remplissage de la forme
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Définit le mode de remplissage d’image de la forme
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Définit l'image qui remplit la forme
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spécifie les décalages de l’image par rapport aux bords correspondants de la boîte englobante de la forme
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Enregistre le fichier PPTX sur le disque
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### How can I find out which image formats are supported for PictureFrame?

Comment savoir quels formats d’image sont pris en charge pour PictureFrame ?

Aspose.Slides prend en charge à la fois les images raster (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple, SVG) via l’objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/). La liste des formats pris en charge se recoupe généralement avec les capacités du moteur de conversion de diapositives et d’images.

### How will adding dozens of large images affect PPTX size and performance?

Comment l’ajout de dizaines d’images volumineuses affecte-t-il la taille et les performances d’un PPTX ?

L’intégration d’images volumineuses augmente la taille du fichier et la consommation de mémoire ; le fait de lier les images aide à garder la taille de la présentation réduite mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien afin de réduire la taille du fichier.

### How can I lock an image object from accidental moving/resizing?

Comment verrouiller un objet image contre les déplacements/redimensionnements accidentels ?

Utilisez les [verrouillages de forme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) pour un [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/).

### Is SVG vector fidelity preserved when exporting a presentation to PDF/images?

La fidélité du vecteur SVG est-elle préservée lors de l’exportation d’une présentation vers PDF/images ?

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pictureframe/) tel qu’il apparaît en vecteur original. Lors de l’[exportation vers PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/) ou des [formats raster](/slides/fr/androidjava/convert-powerpoint-to-png/), le résultat peut être rasterisé en fonction des paramètres d’exportation ; le fait que le SVG original soit stocké en vecteur est confirmé par le comportement d’extraction.