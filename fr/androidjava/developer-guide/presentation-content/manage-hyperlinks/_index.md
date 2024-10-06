---
title: Gérer les Hyperliens
type: docs
weight: 20
url: /androidjava/manage-hyperlinks/
keywords: "Hyperlien PowerPoint, hyperlien texte, hyperlien diapositive, hyperlien forme, hyperlien image, hyperlien vidéo, Java"
description: "Comment ajouter un hyperlien à une présentation PowerPoint en Java"
---

Un hyperlien est une référence à un objet ou des données ou un lieu dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites web à l'intérieur de textes, formes ou médias
* Liens vers des diapositives

Aspose.Slides pour Android via Java vous permet d'effectuer de nombreuses tâches impliquant des hyperliens dans des présentations.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter le simple éditeur PowerPoint en ligne [gratuit d'Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Ajout d'Hypelriens URL**

### **Ajout d'Hypelriens URL à des Textes**

Ce code Java vous montre comment ajouter un hyperlien de site web à un texte :

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("Plus de 70% des entreprises Fortune 100 font confiance aux API Aspose");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Ajout d'Hypelriens URL à des Formes ou Cadres**

Ce code d'exemple en Java vous montre comment ajouter un hyperlien de site web à une forme :

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("Plus de 70% des entreprises Fortune 100 font confiance aux API Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Ajout d'Hypelriens URL à des Médias**

Aspose.Slides vous permet d'ajouter des hyperliens à des images, des fichiers audio et vidéo. 

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
	// Crée un cadre image sur la diapo 1 basé sur l'image ajoutée précédemment
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("Plus de 70% des entreprises Fortune 100 font confiance aux API Aspose");

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
	audioFrame.getHyperlinkClick().setTooltip("Plus de 70% des entreprises Fortune 100 font confiance aux API Aspose");

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
	videoFrame.getHyperlinkClick().setTooltip("Plus de 70% des entreprises Fortune 100 font confiance aux API Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Astuce"  color="primary"  %}} 

Vous voudrez peut-être voir *[Gérer OLE](/slides/androidjava/manage-ole/)*.

{{% /alert %}}

## **Utilisation des Hyperliens pour Créer une Table des Matières**

Puisque les hyperliens vous permettent d'ajouter des références à des objets ou des lieux, vous pouvez les utiliser pour créer une table des matières. 

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
	paragraph.setText("Titre de la diapositive 2 .......... ");

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

## **Formatage des Hyperliens**

### **Couleur**

Avec la propriété [ColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) dans l'interface [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink), vous pouvez définir la couleur des hyperliens et également obtenir les informations de couleur des hyperliens. La fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, donc les changements impliquant la propriété ne s'appliquent pas aux versions PowerPoint plus anciennes.

Ce code d'exemple démontre une opération où des hyperliens avec différentes couleurs ont été ajoutés à la même diapositive :

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("Ceci est un exemple d'hyperlien coloré.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("Ceci est un exemple d'hyperlien habituel.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Suppression des Hyperliens dans les Présentations**

### **Suppression des Hyperliens des Textes**

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

### **Suppression des Hyperliens des Formes ou Cadres**

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

## **Hyperlien Modifiable**

La classe [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink) est mutable. Avec cette classe, vous pouvez changer les valeurs de ces propriétés :

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Le snippet de code vous montre comment ajouter un hyperlien à une diapositive et modifier son tooltip ultérieurement :

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("Plus de 70% des entreprises Fortune 100 font confiance aux API Aspose");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Propriétés Supportées dans IHyperlinkQueries**

Vous pouvez accéder à [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) depuis une présentation, une diapositive ou du texte pour lequel l'hyperlien est défini.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

La classe [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) supporte ces méthodes et propriétés :

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)