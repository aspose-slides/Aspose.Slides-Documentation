---
title: Optimiser la gestion des images dans les présentations avec Java
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/java/image/
keywords:
- ajouter image
- ajouter illustration
- ajouter bitmap
- remplacer image
- remplacer illustration
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- EMF
- SVG
- Java
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Java, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les diapositives de présentation**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d’autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de vos présentations via différentes procédures. 

{{% alert  title="Astuce" color="primary" %}} 

Aspose fournit des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu’objet cadre—en particulier si vous prévoyez d’utiliser les options de mise en forme standard pour modifier sa taille, ajouter des effets, etc.—voir [Picture Frame](https://docs.aspose.com/slides/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}}

Vous pouvez manipuler les opérations d’entrée/sortie impliquant les images et les présentations PowerPoint pour convertir une image d’un format à un autre. Consultez ces pages : convert [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec les images dans ces formats populaires : JPEG, PNG, GIF et autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur à une diapositive d’une présentation. Ce code d’exemple en Java montre comment ajouter une image à une diapositive :
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


## **Ajouter des images depuis le Web aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas disponible sur votre ordinateur, vous pouvez l’ajouter directement depuis le Web. 

Ce code d’exemple montre comment ajouter une image depuis le Web à une diapositive en Java :
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


## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive est la diapositive supérieure qui stocke et contrôle les informations (thème, mise en page, etc.) de toutes les diapositives qui en dépendent. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive dépendante. 

Ce code d’exemple Java montre comment ajouter une image à un maître de diapositive :
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


## **Ajouter des images comme arrière‑plan de diapositive**

Vous pouvez choisir d’utiliser une image comme arrière‑plan d’une diapositive spécifique ou de plusieurs diapositives. Dans ce cas, consultez *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter des SVG aux présentations**
Vous pouvez ajouter ou insérer n’importe quelle image dans une présentation en utilisant la méthode [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) qui appartient à l’interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

Pour créer un objet image à partir d’une image SVG, procédez ainsi :

1. Créez un objet SvgImage pour l’insérer dans ImageShapeCollection
2. Créez un objet PPImage à partir de ISvgImage
3. Créez un objet PictureFrame en utilisant l’interface IPPImage

Ce code d’exemple montre comment mettre en œuvre les étapes ci‑dessus pour ajouter une image SVG à une présentation :
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


## **Convertir un SVG en ensemble de formes**
La conversion d’un SVG en ensemble de formes dans Aspose.Slides est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec les images SVG :

![PowerPoint Popup Menu](img_01_01.png)

La fonctionnalité est fournie par l’une des surcharges de la méthode [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de l’interface [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) qui accepte un objet [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) comme premier argument.

Ce code d’exemple montre comment utiliser la méthode décrite pour convertir un fichier SVG en ensemble de formes :
```java 
// Créer une nouvelle présentation
IPresentation presentation = new Presentation();
try {
    // Lire le contenu du fichier SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Créer l'objet SvgImage
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


## **Ajouter des images au format EMF aux diapositives**
Aspose.Slides pour Java vous permet de générer des images EMF à partir de feuilles Excel et d’ajouter ces images en tant qu’EMF dans les diapositives avec Aspose.Cells. 

Ce code d’exemple montre comment réaliser la tâche décrite :
```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Enregistrer le classeur dans le flux
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


## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation (y compris celles utilisées par les formes de diapositives). Cette section montre plusieurs approches pour mettre à jour les images de la collection. L’API fournit des méthodes simples pour remplacer une image à l’aide de données brutes, d’une instance [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) ou d’une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Chargez le fichier de présentation contenant des images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Chargez une nouvelle image depuis un fichier dans un tableau d’octets.
1. Remplacez l’image cible par la nouvelle image en utilisant le tableau d’octets.
1. Dans la deuxième approche, chargez l’image dans un objet [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) et remplacez l’image cible par cet objet.
1. Dans la troisième approche, remplacez l’image cible par une image déjà présente dans la collection d’images de la présentation.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.
```java
// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Première méthode.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Deuxième méthode.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Troisième méthode.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

En utilisant le convertisseur Aspose GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, créer des GIF à partir de texte, etc. 

{{% /alert %}}

## **FAQ**

**La résolution de l’image originale reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels source sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/java/picture-frame/) est mis à l’échelle sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en même temps ?**

Placez le logo sur la diapositive maître ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Une SVG insérée peut‑elle être convertie en formes éditables ?**

Oui. Vous pouvez convertir un SVG en groupe de formes, après quoi chaque partie devient éditable avec les propriétés standard des formes.

**Comment définir une image comme arrière‑plan de plusieurs diapositives à la fois ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/java/presentation-background/) sur la diapositive maître ou la mise en page concernée — toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation de « gonfler » en taille à cause de nombreuses images ?**

Réutilisez une seule ressource d’image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez une compression à l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.