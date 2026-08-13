---
title: Beheer presentatie‑hyperlinks in Java
linktitle: Beheer hyperlink
type: docs
weight: 20
url: /nl/java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- teksthyperlink
- diahyperlink
- vormhyperlink
- afbeeldinghyperlink
- videohyperlink
- wijzigbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer moeiteloos hyperlinks in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Java—verhoog de interactiviteit en workflow in enkele minuten."
---
## **Introductie**

Een hyperlink is een verwijzing naar een object, gegevens of een plaats in iets. Dit zijn veelvoorkomende hyperlinks in PowerPoint‑presentaties:

* Links naar websites in teksten, vormen of media
* Links naar dia's

Aspose.Slides for Java stelt je in staat vele taken met betrekking tot hyperlinks in presentaties uit te voeren.

{{% alert color="info" %}} 
Je wilt misschien Aspose Simple uitproberen, [gratis online PowerPoint‑editor.](https://products.aspose.app/slides/nl/editor)
{{% /alert %}} 

## **URL-hyperlinks toevoegen**

### **URL-hyperlinks aan tekst toevoegen**

Deze Java‑code laat zien hoe je een website‑hyperlink aan een tekst kunt toevoegen:
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

### **URL-hyperlinks aan vormen of kaders toevoegen**

Deze voorbeeldcode in Java laat zien hoe je een website‑hyperlink aan een vorm kunt toevoegen:
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

### **URL-hyperlinks aan media toevoegen**

Aspose.Slides stelt je in staat hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden. 

Deze voorbeeldcode laat zien hoe je een hyperlink aan een **afbeelding** kunt toevoegen:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Voegt afbeelding toe aan presentatie
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Maakt afbeeldingframe aan op dia 1 op basis van eerder toegevoegde afbeelding
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Deze voorbeeldcode laat zien hoe je een hyperlink aan een **audio‑bestand** kunt toevoegen:
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

Deze voorbeeldcode laat zien hoe je een hyperlink aan een **video** kunt toevoegen:
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
Je wilt misschien *[OLE beheren](/slides/nl/java/manage-ole/)* bekijken.
{{% /alert %}}

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Aangezien hyperlinks je in staat stellen verwijzingen toe te voegen naar objecten of plaatsen, kun je ze gebruiken om een inhoudsopgave te maken. 

Deze voorbeeldcode laat zien hoe je een inhoudsopgave met hyperlinks kunt maken:
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

## **Hyperlinks opmaken**

### **Kleur**

Met de eigenschap [ColorSource](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Hyperlink#setColorSource-int-) in de interface [IHyperlink](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlink) kun je de kleur voor hyperlinks instellen en ook de kleurinformatie van hyperlinks ophalen. De functie werd voor het eerst geïntroduceerd in PowerPoint 2019, dus wijzigingen die de eigenschap betreffen zijn niet van toepassing op oudere PowerPoint‑versies.

Deze voorbeeldcode toont een bewerking waarbij hyperlinks met verschillende kleuren aan dezelfde dia werden toegevoegd:
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

## **Hyperlinks uit presentaties verwijderen**

### **Hyperlinks uit tekst verwijderen**

Deze Java‑code laat zien hoe je de hyperlink uit een tekst in een presentatiedia kunt verwijderen:
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

### **Hyperlinks uit vormen of kaders verwijderen**

Deze Java‑code laat zien hoe je de hyperlink uit een vorm in een presentatiedia kunt verwijderen:
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

## **Veranderbare hyperlink**

De klasse [Hyperlink](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Hyperlink) is veranderbaar. Met deze klasse kun je de waarden van de volgende eigenschappen aanpassen:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

De code‑fragment laat zien hoe je een hyperlink aan een dia kunt toevoegen en later de tooltip ervan kunt bewerken:
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

	// Wijzigt de tooltip van de hyperlink die al is toegevoegd
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ondersteunde eigenschappen in IHyperlinkQueries**

Je kunt [IHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlinkQueries) benaderen vanuit een presentatie, dia of tekst waarvoor de hyperlink is gedefinieerd. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

De klasse [IHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlinkQueries) ondersteunt deze methoden en eigenschappen: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

### Hoe kan ik interne navigatie maken, niet alleen naar een dia, maar naar een “sectie” of de eerste dia van een sectie?

Secties in PowerPoint zijn groeperingen van dia's; navigatie richt zich technisch op een specifieke dia. Om naar een “sectie” te navigeren, link je doorgaans naar de eerste dia ervan.

### Kan ik een hyperlink toevoegen aan elementen van de masterdia zodat deze op alle dia's werkt?

Ja. Masterdia‑ en layoutelementen ondersteunen hyperlinks. Dergelijke koppelingen verschijnen op kinddia's en zijn klikbaar tijdens de diavoorstelling.

### Worden hyperlinks behouden bij het exporteren naar PDF, HTML, afbeeldingen of video?

In [PDF](/slides/nl/java/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/java/convert-powerpoint-to-html/) ja – links worden over het algemeen behouden. Bij exporteren naar [afbeeldingen](/slides/nl/java/convert-powerpoint-to-png/) en [video](/slides/nl/java/convert-powerpoint-to-video/) is klikbaarheid niet meegeleverd vanwege de aard van die formaten (rasterframes/video ondersteunen geen hyperlinks).