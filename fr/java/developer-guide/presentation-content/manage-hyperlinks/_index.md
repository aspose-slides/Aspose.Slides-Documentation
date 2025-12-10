---
title: Gérer les hyperliens de présentation en Java
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/java/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter hyperlien
- créer hyperlien
- formater hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien mutable
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez facilement les hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Java - améliorez l'interactivité et le flux de travail en quelques minutes."
---

Un hyperlien est une référence à un objet, des données ou un emplacement dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites Web dans le texte, les formes ou les médias
* Liens vers des diapositives

Aspose.Slides for Java vous permet d'effectuer de nombreuses tâches liées aux hyperliens dans les présentations. 

{{% alert color="primary" %}} 

Vous voudrez peut‑être essayer Aspose simple, [éditeur PowerPoint en ligne gratuit.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Ajouter des hyperliens URL**

### **Ajouter des hyperliens URL au texte**

Ce code Java vous montre comment ajouter un hyperlien vers un site Web à un texte :
```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```


### **Ajouter des hyperliens URL aux formes ou aux cadres**

Ce code d'exemple en Java vous montre comment ajouter un hyperlien vers un site Web à une forme :
```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


### **Ajouter des hyperliens URL aux médias**

Aspose.Slides vous permet d'ajouter des hyperliens aux images, aux fichiers audio et vidéo. 

Ce code d'exemple vous montre comment ajouter un hyperlien à une **image** :
```java
Presentation pres = new Presentation();
try {
	// Ajoute une image à la présentation
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Crée un cadre d'image sur la diapositive 1 basé sur l'image ajoutée précédemment
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


Ce code d'exemple vous montre comment ajouter un hyperlien à un **fichier audio** :
```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


Ce code d'exemple vous montre comment ajouter un hyperlien à une **vidéo** :
```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


{{%  alert  title="Tip"  color="primary"  %}} 

Vous voudrez peut‑être voir *[Gestion OLE](/slides/fr/java/manage-ole/)*.

{{% /alert %}}

## **Utiliser les hyperliens pour créer une table des matières**

Comme les hyperliens vous permettent d'ajouter des références à des objets ou des emplacements, vous pouvez les utiliser pour créer une table des matières. 

Ce code d'exemple vous montre comment créer une table des matières avec des hyperliens :
```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Formater les hyperliens**

### **Couleur**

Avec la propriété [ColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink#setColorSource-int-) de l'interface [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink), vous pouvez définir la couleur des hyperliens et aussi obtenir les informations de couleur à partir des hyperliens. Cette fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, de sorte que les modifications concernant cette propriété ne s'appliquent pas aux versions antérieures de PowerPoint.

Ce code d'exemple montre une opération où des hyperliens de différentes couleurs ont été ajoutés à la même diapositive :
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Supprimer les hyperliens des présentations**

### **Supprimer les hyperliens du texte**

Ce code Java vous montre comment supprimer l'hyperlien d'un texte dans une diapositive de présentation :
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


### **Supprimer les hyperliens des formes ou des cadres**

Ce code Java vous montre comment supprimer l'hyperlien d'une forme dans une diapositive de présentation :
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Hyperlien mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink) est mutable. Avec cette classe, vous pouvez modifier les valeurs de ces propriétés :

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

L'extrait de code vous montre comment ajouter un hyperlien à une diapositive et modifier son infobulle ultérieurement :
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Propriétés prises en charge dans IHyperlinkQueries**

Vous pouvez accéder à [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) depuis une présentation, une diapositive ou un texte pour lequel l'hyperlien est défini. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

La classe [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) prend en charge ces méthodes et propriétés : 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Comment puis‑je créer une navigation interne non pas seulement vers une diapositive, mais vers une « section » ou la première diapositive d’une section ?**

Les sections dans PowerPoint sont des regroupements de diapositives ; la navigation cible techniquement une diapositive spécifique. Pour « naviguer vers une section », vous liez généralement à sa première diapositive.

**Puis‑je attacher un hyperlien aux éléments de la diapositive maître afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments de la diapositive maître et des dispositions prennent en charge les hyperliens. Ces liens apparaissent sur les diapositives dérivées et sont cliquables pendant le diaporama.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Dans [PDF](/slides/fr/java/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/java/convert-powerpoint-to-html/), oui — les liens sont généralement conservés. Lors de l’exportation vers [images](/slides/fr/java/convert-powerpoint-to-png/) et [vidéo](/slides/fr/java/convert-powerpoint-to-video/), la cliquabilité ne sera pas transférée en raison de la nature de ces formats (les images raster/vidéos ne prennent pas en charge les hyperliens).