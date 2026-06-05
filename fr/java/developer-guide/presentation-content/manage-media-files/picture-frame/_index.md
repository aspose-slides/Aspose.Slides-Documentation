---
title: Gérer les cadres d’image dans les présentations avec Java
linktitle: Cadre d’image
type: docs
weight: 10
url: /fr/java/picture-frame/
keywords:
- cadre d’image
- ajouter un cadre d’image
- créer un cadre d’image
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d’image
- propriétés du cadre d’image
- échelle relative
- effet d’image
- ratio d’aspect
- transparence de l’image
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Ajoutez des cadres d’image aux présentations PowerPoint et OpenDocument avec Aspose.Slides for Java. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d’image est une forme qui contient une image — c’est comme une photo dans un cadre.

Vous pouvez ajouter une image à une diapositive via un cadre d’image. Ainsi, vous formatez l’image en formatant le cadre d’image.

{{% alert  title="Conseil" color="primary" %}} 

Aspose propose des convertisseurs gratuits — [JPEG to PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

## **Créer un cadre d’image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Créez un objet [IPPImage]() en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IImageCollection) associée à l’objet de présentation qui sera utilisé pour remplir la forme.
4. Précisez la largeur et la hauteur de l’image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/PictureFrame) à partir de la largeur et de la hauteur de l’image via la méthode `AddPictureFrame` exposée par l’objet shape associé à la diapositive référencée.
6. Ajoutez un cadre d’image (contenant l’image) à la diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre d’image :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Ajoute un cadre d’image avec la même hauteur et largeur que l’image
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Les cadres d’image vous permettent de créer rapidement des diapositives de présentation à partir d’images. Lorsque vous combinez le cadre d’image avec les options d’enregistrement Aspose.Slides, vous pouvez manipuler les opérations d’entrée/sortie pour convertir des images d’un format à un autre. Vous pouvez consulter ces pages : convertir [image to JPG](https://products.aspose.com/slides/fr/java/conversion/image-to-jpg/) ; convertir [JPG to image](https://products.aspose.com/slides/fr/java/conversion/jpg-to-image/) ; convertir [JPG to PNG](https://products.aspose.com/slides/fr/java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/fr/java/conversion/png-to-jpg/) ; convertir [PNG to SVG](https://products.aspose.com/slides/fr/java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/fr/java/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un cadre d’image avec mise à l’échelle relative**

En modifiant la mise à l’échelle relative d’une image, vous pouvez créer un cadre d’image plus complexe. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez une image à la collection d’images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IImageCollection) associée à l’objet de présentation qui sera utilisé pour remplir la forme.
5. Précisez la largeur et la hauteur relatives de l’image dans le cadre d’image.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un cadre d’image avec mise à l’échelle relative :

```java
// Instancie la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instancie la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Ajoute un cadre d’image avec la hauteur et la largeur équivalentes à l’image
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Définit la mise à l’échelle relative en largeur et hauteur
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Enregistre le fichier PPTX sur le disque
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraire des images raster à partir de cadres d’image**

Vous pouvez extraire des images raster à partir d’objets [PictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/PictureFrame) et les enregistrer en PNG, JPG et d’autres formats. L’exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l’enregistrer au format PNG.

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

## **Extraire des images SVG à partir de cadres d’image**

Lorsqu’une présentation contient des graphiques SVG placés à l’intérieur de formes [PictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pictureframe/), Aspose.Slides for Java vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pictureframe/), vérifier si l’[IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) sous‑jacente contient du contenu SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

L’exemple de code suivant montre comment extraire une image SVG d’un cadre d’image :

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

## **Obtenir la transparence d’une image**

Aspose.Slides vous permet d’obtenir l’effet de transparence appliqué à une image. Ce code Java montre l’opération :

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

## **Mise en forme d’un cadre d’image**

Aspose.Slides propose de nombreuses options de mise en forme pouvant être appliquées à un cadre d’image. En utilisant ces options, vous pouvez modifier un cadre d’image pour qu’il corresponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPPImage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IImageCollection) associée à l’objet de présentation qui sera utilisé pour remplir la forme.
4. Précisez la largeur et la hauteur de l’image.
5. Créez un `PictureFrame` à partir de la largeur et de la hauteur de l’image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) exposée par l’objet [IShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection) associé à la diapositive référencée.
6. Ajoutez le cadre d’image (contenant l’image) à la diapositive.
7. Définissez la couleur du contour du cadre d’image.
8