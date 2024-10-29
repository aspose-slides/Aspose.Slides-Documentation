---
title: Hyperlinks verwalten
type: docs
weight: 20
url: /de/androidjava/manage-hyperlinks/
keywords: "PowerPoint Hyperlink, Texthyperlink, Folienhyperlink, Formenhyperlink, Bildhyperlink, Videohyperlink, Java"
description: "Wie man einen Hyperlink zu einer PowerPoint-Präsentation in Java hinzufügt"
---

Ein Hyperlink ist ein Verweis auf ein Objekt oder Daten oder einen Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint-Präsentationen:

* Links zu Websites innerhalb von Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für Android über Java ermöglicht es Ihnen, viele Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen zu erledigen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie den einfachen, [kostenlosen Online PowerPoint-Editor von Aspose ausprobieren.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Hinzufügen von URL-Hyperlinks**

### **Hinzufügen von URL-Hyperlinks zu Texten**

Dieser Java-Code zeigt Ihnen, wie Sie einen Website-Hyperlink zu einem Text hinzufügen können:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: Dateiformat-APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("Mehr als 70% der Fortune 100 Unternehmen vertrauen auf Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Hinzufügen von URL-Hyperlinks zu Formen oder Rahmen**

Dieser Beispielcode in Java zeigt Ihnen, wie Sie einen Website-Hyperlink zu einer Form hinzufügen:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("Mehr als 70% der Fortune 100 Unternehmen vertrauen auf Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Hinzufügen von URL-Hyperlinks zu Medien**

Aspose.Slides ermöglicht es Ihnen, Hyperlinks zu Bildern, Audio- und Videodateien hinzuzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Bild** hinzufügen:

```java
Presentation pres = new Presentation();
try {
	// Fügt Bild zur Präsentation hinzu
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Erstellt einen Bilderahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("Mehr als 70% der Fortune 100 Unternehmen vertrauen auf Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einer **Audiodatei** hinzufügen:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("Mehr als 70% der Fortune 100 Unternehmen vertrauen auf Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Video** hinzufügen:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("Mehr als 70% der Fortune 100 Unternehmen vertrauen auf Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Tipp" color="primary" %}} 

Vielleicht möchten Sie *[OLE verwalten](/slides/de/androidjava/manage-ole/)* sehen.

{{% /alert %}}

## **Verwenden von Hyperlinks zur Erstellung eines Inhaltsverzeichnisses**

Da Hyperlinks es Ihnen ermöglichen, Verweise auf Objekte oder Orte hinzuzufügen, können Sie sie verwenden, um ein Inhaltsverzeichnis zu erstellen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:

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
	paragraph.setText("Titel von Folie 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Seite 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Formatieren von Hyperlinks**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) Eigenschaft in der [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink) Schnittstelle können Sie die Farbe für Hyperlinks festlegen und auch die Farbinformationen von Hyperlinks abrufen. Diese Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen, die die Eigenschaft betreffen, nicht auf ältere PowerPoint-Versionen zutreffen.

Dieser Beispielcode demonstriert einen Vorgang, bei dem Hyperlinks mit verschiedenen Farben zur gleichen Folie hinzugefügt wurden:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("Dies ist ein Beispiel für einen farbigen Hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("Dies ist ein Beispiel für einen üblichen Hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Entfernen von Hyperlinks in Präsentationen**

### **Entfernen von Hyperlinks aus Texten**

Dieser Java-Code zeigt Ihnen, wie Sie den Hyperlink von einem Text in einer Präsentationsfolie entfernen:

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

### **Entfernen von Hyperlinks aus Formen oder Rahmen**

Dieser Java-Code zeigt Ihnen, wie Sie den Hyperlink von einer Form in einer Präsentationsfolie entfernen: 

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

## **Veränderbarer Hyperlink**

Die [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink) Klasse ist veränderbar. Mit dieser Klasse können Sie die Werte für diese Eigenschaften ändern:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Der Code-Ausschnitt zeigt Ihnen, wie Sie einen Hyperlink zu einer Folie hinzufügen und später dessen Tooltip bearbeiten:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: Dateiformat-APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("Mehr als 70% der Fortune 100 Unternehmen vertrauen auf Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) von einer Präsentation, Folie oder Text, für den der Hyperlink definiert ist, abrufen.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Die [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) Klasse unterstützt diese Methoden und Eigenschaften:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)