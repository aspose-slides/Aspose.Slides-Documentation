---
title: Správa hypertextových odkazů v prezentaci v Java
linktitle: Spravovat hypertextový odkaz
type: docs
weight: 20
url: /cs/java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímku
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Bez námahy spravujte hypertextové odkazy v PowerPoint a OpenDocument prezentacích s Aspose.Slides pro Java — zvyšte interaktivitu a efektivitu během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt nebo data či místo v něčem. Toto jsou běžné hyperlinky v prezentacích PowerPoint:

* Odkazy na webové stránky v textu, tvarech nebo médiích
* Odkazy na snímky

Aspose.Slides pro Java vám umožňuje provádět mnoho úkolů souvisejících s hyperlinky v prezentacích. 

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)
{{% /alert %}} 

## **Přidání URL hyperlinků**

### **Přidání URL hyperlinků k textu**

Tento kód v jazyce Java ukazuje, jak přidat odkaz na webovou stránku do textu:

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

### **Přidání URL hyperlinků k tvarům nebo rámcům**

Tento ukázkový kód v jazyce Java ukazuje, jak přidat odkaz na webovou stránku do tvaru:

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

### **Přidání URL hyperlinků k médiím**

Aspose.Slides vám umožňuje přidávat hyperlinky k obrázkům, zvukovým a video souborům. 

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **obrázku**:

```java
Presentation pres = new Presentation();
try {
	// Přidá obrázek do prezentace
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Vytvoří rámeček obrázku na snímku 1 na základě dříve přidaného obrázku
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **zvukovému souboru**:

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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **videu**:

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
Možná budete chtít vidět *[Spravovat OLE](/slides/cs/java/manage-ole/)*.
{{% /alert %}}

## **Použití hypertextových odkazů k vytvoření obsahu**

Protože hypertextové odkazy umožňují přidávat odkazy na objekty nebo místa, můžete je použít k vytvoření obsahu.

Tento ukázkový kód ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátování hypertextových odkazů**

### **Barva**

S vlastností [ColorSource](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Hyperlink#setColorSource-int-) v rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlink) můžete nastavit barvu pro hypertextové odkazy a také získat informaci o barvě z hyperlinků. Tato funkce byla poprvé představena v PowerPointu 2019, takže změny týkající se této vlastnosti se nepoužijí na starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, při které byly na stejný snímek přidány hypertextové odkazy s různými barvami:

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

## **Odstranění hypertextových odkazů z prezentací**

### **Odstranění hypertextových odkazů z textu**

Tento kód v jazyce Java ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

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

### **Odstranění hypertextových odkazů z tvarů nebo rámců**

Tento kód v jazyce Java ukazuje, jak odstranit hypertextový odkaz z tvaru na snímku prezentace: 

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

## **Měnitelný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Hyperlink) je měnitelná. Pomocí této třídy můžete měnit hodnoty následujících vlastností:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Tento útržek kódu ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek (tooltip):

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

## **Podporované vlastnosti v IHyperlinkQueries**

Můžete získat přístup k [IHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlinkQueries) z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Třída [IHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlinkQueries) podporuje tyto metody a vlastnosti: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **Často kladené otázky**

**Jak mohu vytvořit vnitřní navigaci nejen k snímku, ale i k „sekci“ nebo k prvnímu snímku sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Chcete-li „přejít do sekce“, obvykle odkazujete na její první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Tyto odkazy se objeví na podřízených snímcích a jsou klikatelné během prezentace.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/java/convert-powerpoint-to-html/) ano — odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/java/convert-powerpoint-to-png/) a [videí](/slides/cs/java/convert-powerpoint-to-video/) nebude klikatelnost zachována kvůli povaze těchto formátů (rasterové snímky/video nepodporují hypertextové odkazy).