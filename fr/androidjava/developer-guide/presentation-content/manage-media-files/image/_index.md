---
title: Image
type: docs
weight: 10
url: /fr/androidjava/image/
description: Travailler avec des images dans les diapositives de PowerPoint Presentation en utilisant Java. Ajouter des images depuis le disque ou depuis le web dans les diapositives PowerPoint en utilisant Java. Ajouter des images aux masques de diapositives ou comme arrière-plan de diapositive en utilisant Java. Ajouter du SVG à la présentation PowerPoint en utilisant Java. Convertir SVG en formes dans PowerPoint en utilisant Java. Ajouter des images en tant qu'EMF dans les diapositives en utilisant Java.
---

## **Images dans les Diapositives des Présentations**

Les images rendent les présentations plus engageantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images à partir d'un fichier, d'internet ou d'autres emplacements dans les diapositives. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de vos présentations via différentes procédures. 

{{% alert title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux utilisateurs de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu'objet cadre—surtout si vous prévoyez d'utiliser les options de formatage standard pour changer sa taille, ajouter des effets, etc.—voir [Cadre d’image](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez manipuler les opérations d'entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d'un format à un autre. Voir ces pages : convertir [image en JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, GIF, et d'autres. 

## **Ajouter des Images Stockées Localement aux Diapositives**

Vous pouvez ajouter une ou plusieurs images sur votre ordinateur à une diapositive dans une présentation. Ce code d'exemple en Java vous montre comment ajouter une image à une diapositive :

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ajouter des Images du Web aux Diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas disponible sur votre ordinateur, vous pouvez ajouter l'image directement depuis le web. 

Ce code d'exemple vous montre comment ajouter une image du web à une diapositive en Java :

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ajouter des Images aux Masques de Diapositive**

Un masque de diapositive est la diapositive supérieure qui stocke et contrôle des informations (thème, mise en page, etc.) concernant toutes les diapositives qui se trouvent en dessous. Ainsi, lorsque vous ajoutez une image à un masque de diapositive, cette image apparaît sur chaque diapositive sous ce masque de diapositive. 

Ce code d'exemple en Java vous montre comment ajouter une image à un masque de diapositive :

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ajouter des Images comme Arrière-plan de Diapositive**

Vous pouvez décider d'utiliser une image comme arrière-plan pour une diapositive spécifique ou plusieurs diapositives. Dans ce cas, vous devez voir *[Définir des images comme arrière-plans pour les diapositives](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux Présentations**
Vous pouvez ajouter ou insérer n'importe quelle image dans une présentation en utilisant la méthode [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) qui appartient à l'interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

Pour créer un objet image basé sur une image SVG, vous pouvez procéder comme suit :

1. Créer un objet SvgImage à insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir de ISvgImage
3. Créer un objet PictureFrame en utilisant l'interface IPPImage

Ce code d'exemple vous montre comment implémenter les étapes ci-dessus pour ajouter une image SVG dans une présentation :
```java 
// Instancier la classe Presentation qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Conversion de SVG en un Ensemble de Formes**
La conversion de SVG en un ensemble de formes par Aspose.Slides est similaire à la fonctionnalité de PowerPoint utilisée pour travailler avec des images SVG :

![Menu Popup PowerPoint](img_01_01.png)

La fonctionnalité est fournie par l'une des surcharges de la méthode [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de l'interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) comme premier argument.

Ce code d'exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :

```java 
// Créer une nouvelle présentation
IPresentation presentation = new Presentation();
try {
    // Lire le contenu du fichier SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Créer un objet SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtenir la taille de la diapositive
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Convertir l'image SVG en groupe de formes en l'adaptant à la taille de la diapositive
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Enregistrer la présentation au format PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ajouter des Images en tant qu'EMF dans les Diapositives**
Aspose.Slides pour Android via Java vous permet de générer des images EMF à partir de feuilles de calcul Excel et d'ajouter les images en tant qu'EMF dans les diapositives avec Aspose.Cells. 

Ce code d'exemple vous montre comment réaliser la tâche décrite :

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Sauvegarder le workbook dans un flux
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

En utilisant le convertisseur gratuit Aspose [Texte en GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer des textes, créer des GIF à partir de textes, etc. 

{{% /alert %}}