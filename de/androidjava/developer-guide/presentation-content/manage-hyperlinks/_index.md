---
title: Verwalten von Präsentationshyperlinks unter Android
linktitle: Hyperlink verwalten
type: docs
weight: 20
url: /de/androidjava/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Texthyperlink
- Folienhyperlink
- Formhyperlink
- Bildhyperlink
- Videohyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mühelos mit Aspose.Slides für Android via Java - steigern Sie Interaktivität und Arbeitsabläufe in wenigen Minuten."
---
## **Einleitung**

Ein Hyperlink ist eine Referenz zu einem Objekt, Daten oder einem Ort in etwas. Dies sind häufige Hyperlinks in PowerPoint‑Präsentationen:

* Links zu Websites in Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides for Android via Java ermöglicht Ihnen das Ausführen vieler Aufgaben mit Hyperlinks in Präsentationen.

{{% alert color="info" %}} 
Vielleicht möchten Sie den einfachen, [kostenlosen Online‑PowerPoint‑Editor](https://products.aspose.app/slides/de/editor) von Aspose ausprobieren.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

### **URL‑Hyperlinks zu Text hinzufügen**

Dieser Java‑Code zeigt, wie Sie einem Text einen Website‑Hyperlink hinzufügen:

```java
import com.aspose.slides.*;

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

### **URL‑Hyperlinks zu Formen oder Rahmen hinzufügen**

Dieser Beispielcode in Java zeigt, wie Sie einer Form einen Website‑Hyperlink hinzufügen:

```java
import com.aspose.slides.*;

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

### **URL‑Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bildern, Audio‑ und Videodateien.

Dieser Beispielcode zeigt, wie Sie einem **Bild** einen Hyperlink hinzufügen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Fügt ein Bild zur Präsentation hinzu
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Erstellt ein Bildrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Dieser Beispielcode zeigt, wie Sie einer **Audiodatei** einen Hyperlink hinzufügen:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

Dieser Beispielcode zeigt, wie Sie einem **Video** einen Hyperlink hinzufügen:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 
Sie können *[OLE verwalten](/slides/de/androidjava/manage-ole/)* ansehen.
{{% /alert %}}

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Da Hyperlinks Referenzen zu Objekten oder Orten ermöglichen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden.

Dieser Beispielcode zeigt, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Hyperlinks formatieren**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-)‑Eigenschaft im [IHyperlink](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlink)‑Interface können Sie die Farbe von Hyperlinks festlegen und die Farb‑Informationen von Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an dieser Eigenschaft für ältere PowerPoint‑Versionen nicht gelten.

Dieser Beispielcode demonstriert einen Vorgang, bei dem Hyperlinks mit unterschiedlichen Farben zur selben Folie hinzugefügt wurden:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Hyperlinks aus Präsentationen entfernen**

### **Hyperlinks aus Text entfernen**

Dieser Java‑Code zeigt, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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

### **Hyperlinks aus Formen oder Rahmen entfernen**

Dieser Java‑Code zeigt, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

Die [Hyperlink](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Hyperlink)‑Klasse ist veränderbar. Mit dieser Klasse können Sie die Werte folgender Eigenschaften ändern:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Der Codeausschnitt zeigt, wie Sie einer Folie einen Hyperlink hinzufügen und später dessen Tooltip bearbeiten:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// Ändert den Tooltip des bereits hinzugefügten Hyperlinks
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können von einer Präsentation, Folie oder einem Text, für den ein Hyperlink definiert ist, auf [IHyperlinkQueries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlinkQueries) zugreifen.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Die [IHyperlinkQueries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlinkQueries)‑Klasse unterstützt diese Methoden und Eigenschaften:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

### Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem „Abschnitt“ oder zur ersten Folie eines Abschnitts erstellen?

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie. Um „zu einem Abschnitt zu navigieren“, verlinken Sie in der Regel auf dessen erste Folie.

### Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, damit er auf allen Folien funktioniert?

Ja. Master‑Folien‑ und Layout‑Elemente unterstützen Hyperlinks. Diese Links erscheinen auf den untergeordneten Folien und sind während der Bildschirmpräsentation anklickbar.

### Werden Hyperlinks beim Exportieren in PDF, HTML, Bilder oder Video erhalten bleiben?

In [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/) und [HTML](/slides/de/androidjava/convert-powerpoint-to-html/) ja – Links werden im Allgemeinen beibehalten. Beim Exportieren zu [Bildern](/slides/de/androidjava/convert-powerpoint-to-png/) und [Video](/slides/de/androidjava/convert-powerpoint-to-video/) wird die Klickbarkeit nicht übernommen, da diese Formate (Raster‑Frames/Video) keine Hyperlinks unterstützen.