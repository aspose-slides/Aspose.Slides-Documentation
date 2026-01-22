---
title: Optimiser la gestion des images dans les présentations sur Android
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/androidjava/image/
keywords:
- ajouter image
- ajouter image
- ajouter bitmap
- remplacer image
- remplacer image
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
- Android
- Java
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les diapositives de présentation**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d’autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de vos présentations via différentes procédures. 

{{% alert  title="Tip" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu’objet d’encadré—en particulier si vous prévoyez d’utiliser les options de mise en forme standard pour modifier sa taille, ajouter des effets, etc.—voir [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides prend en charge les opérations avec les images dans ces formats populaires : JPEG, PNG, GIF et autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur sur une diapositive d’une présentation. Ce code d’exemple en Java montre comment ajouter une image à une diapositive :
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

Un maître de diapositive est la diapositive principale qui stocke et contrôle les informations (thème, mise en page, etc.) de toutes les diapositives qui en dépendent. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive sous ce maître. 

Ce code d’exemple en Java montre comment ajouter une image à un maître de diapositive :
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


## **Ajouter des images en tant qu’arrière‑plan de diapositive**

Vous pouvez choisir d’utiliser une image comme arrière‑plan pour une diapositive spécifique ou plusieurs diapositives. Dans ce cas, consultez *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter des SVG aux présentations**
Vous pouvez ajouter ou insérer n’importe quelle image dans une présentation en utilisant la méthode [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) qui appartient à l’interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

Pour créer un objet image basé sur une image SVG, vous pouvez le faire de cette manière :

1. Créer un objet SvgImage pour l’insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir de ISvgImage
3. Créer un objet PictureFrame en utilisant l’interface IPPImage

Ce code d’exemple montre comment mettre en œuvre les étapes ci‑dessus pour ajouter une image SVG dans une présentation :
```java
// Instanciez la classe Presentation qui représente le fichier PPTX
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
La conversion d’un SVG en ensemble de formes par Aspose.Slides est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec les images SVG :

![PowerPoint Popup Menu](img_01_01.png)

La fonctionnalité est fournie par l’une des surcharges de la méthode [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) de l’interface [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) qui accepte un objet [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) en premier argument.

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


## **Ajouter des images en tant qu’EMF aux diapositives**
Aspose.Slides for Android via Java vous permet de générer des images EMF à partir de feuilles Excel et d’ajouter ces images en tant qu’EMF dans les diapositives avec Aspose.Cells. 

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

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation (y compris celles utilisées par les formes de diapositive). Cette section présente plusieurs approches pour mettre à jour les images de la collection. L’API propose des méthodes simples pour remplacer une image en utilisant des données octet brutes, une instance [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/), ou une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Charger le fichier de présentation contenant les images en utilisant la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Charger une nouvelle image depuis un fichier dans un tableau d’octets.
3. Remplacer l’image cible par la nouvelle image en utilisant le tableau d’octets.
4. Dans la deuxième approche, charger l’image dans un objet [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) et remplacer l’image cible par cet objet.
5. Dans la troisième approche, remplacer l’image cible par une image déjà présente dans la collection d’images de la présentation.
6. Enregistrer la présentation modifiée en fichier PPTX.
```java
// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // La première méthode.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // La deuxième méthode.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // La troisième méthode.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Enregistrez la présentation dans un fichier.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

En utilisant le convertisseur GRATUIT Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, créer des GIF à partir de texte, etc. 

{{% /alert %}}

## **FAQ**

**La résolution d'origine de l'image reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels d'origine sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/androidjava/picture-frame/) est mis à l’échelle sur la diapositive et de la compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives d’un seul coup ?**

Placez le logo sur la diapositive maître ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation — les modifications seront propagées à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes modifiables ?**

Oui. Vous pouvez convertir un SVG en groupe de formes, après quoi chaque partie devient modifiable avec les propriétés standard des formes.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives en même temps ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/androidjava/presentation-background/) sur la diapositive maître ou la mise en page concernée — toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation d’« gonfler » en taille à cause de nombreuses images ?**

Réutilisez une seule ressource d’image au lieu de duplicatas, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.