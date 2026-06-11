---
title: "Hantera presentationshyperlänkar i Java"
linktitle: "Hantera hyperlänk"
type: docs
weight: 20
url: /sv/java/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- muterbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java utan ansträngning – förbättra interaktiviteten och arbetsflödet på bara några minuter."
---
## **Introduktion**

En hyperlänk är en referens till ett objekt eller data eller en plats i något. Detta är vanliga hyperlänkar i PowerPoint‑presentationer:

* Länkar till webbplatser i texter, former eller media
* Länkar till bilder

Aspose.Slides for Java låter dig utföra många uppgifter som involverar hyperlänkar i presentationer. 

{{% alert color="primary" %}} 

Du kanske vill prova Aspose Simple, [gratis online PowerPoint‑redigerare.](https://products.aspose.app/slides/sv/editor)

{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

### **Lägg till URL‑hyperlänkar till text**

Denna Java‑kod visar hur du lägger till en webbplats‑hyperlänk i en text:

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

### **Lägg till URL‑hyperlänkar till former eller ramar**

Detta exempel i Java visar hur du lägger till en webbplats‑hyperlänk i en form:

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

### **Lägg till URL‑hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud‑ och videofiler. 

Detta exempel visar hur du lägger till en hyperlänk till en **bild**:

```java
Presentation pres = new Presentation();
try {
	// Lägger till bild i presentationen
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Skapar bildram på bild 1 baserat på tidigare tillagd bild
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Detta exempel visar hur du lägger till en hyperlänk till en **ljudfil**:

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

Detta exempel visar hur du lägger till en hyperlänk till en **video**:

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

Du kanske vill se *[Hantera OLE](/slides/sv/java/manage-ole/)*.

{{% /alert %}}

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Eftersom hyperlänkar låter dig lägga till referenser till objekt eller platser kan du använda dem för att skapa en innehållsförteckning. 

Detta exempel visar hur du skapar en innehållsförteckning med hyperlänkar:

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

## **Formatera hyperlänkar**

### **Färg**

Med egenskapen [ColorSource](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Hyperlink#setColorSource-int-) i gränssnittet [IHyperlink](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlink) kan du ange färg för hyperlänkar och även hämta färginformation från hyperlänkar. Funktionen introducerades först i PowerPoint 2019, så ändringar som involverar egenskapen gäller inte äldre PowerPoint‑versioner.

Detta exempel demonstrerar en operation där hyperlänkar med olika färger lades till på samma bild:

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

## **Ta bort hyperlänkar från presentationer**

### **Ta bort hyperlänkar från text**

Denna Java‑kod visar hur du tar bort hyperlänken från en text i en presentationsbild:

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

### **Ta bort hyperlänkar från former eller ramar**

Denna Java‑kod visar hur du tar bort hyperlänken från en form i en presentationsbild: 

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

## **Muterbar hyperlänk**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Hyperlink) är muterbar. Med denna klass kan du ändra värdena för följande egenskaper:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Kodsnutten visar hur du lägger till en hyperlänk i en bild och redigerar dess verktygstips senare:

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

## **Stödda egenskaper i IHyperlinkQueries**

Du kan komma åt [IHyperlinkQueries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlinkQueries) från en presentation, bild eller text som hyperlänken är definierad för. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Klassen [IHyperlinkQueries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlinkQueries) stödjer dessa metoder och egenskaper: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Hur kan jag skapa intern navigation inte bara till en bild, utan till ett "avsnitt" eller den första bilden i ett avsnitt?**

Avsnitt i PowerPoint är grupperingar av bilder; navigationen riktar sig tekniskt sett till en specifik bild. För att "navigera till ett avsnitt" länkar du vanligtvis till dess första bild.

**Kan jag bifoga en hyperlänk till master‑bildens element så att den fungerar på alla bilder?**

Ja. Master‑bildens och layout‑element stödjer hyperlänkar. Sådana länkar visas på underliggande bilder och är klickbara under bildspelet.

**Behålls hyperlänkar när man exporterar till PDF, HTML, bilder eller video?**

Ja, i [PDF](/slides/sv/java/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/java/convert-powerpoint-to-html/) bevaras länkarna i allmänhet. Vid export till [bilder](/slides/sv/java/convert-powerpoint-to-png/) och [video](/slides/sv/java/convert-powerpoint-to-video/) överförs inte klickbarheten eftersom dessa format (rasterbilder/video) inte stödjer hyperlänkar.