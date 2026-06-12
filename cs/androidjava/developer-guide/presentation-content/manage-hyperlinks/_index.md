---
title: Správa hypertextových odkazů v prezentaci pro Android
linktitle: Správa hypertextového odkazu
type: docs
weight: 20
url: /cs/androidjava/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odebrat hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy – zvyšte interaktivitu a efektivitu práce během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt nebo data či místo v něčem. Toto jsou běžné hypertextové odkazy v prezentacích PowerPoint:

* Odkazy na webové stránky v textu, tvarech nebo médiích
* Odkazy na snímky

Aspose.Slides pro Android prostřednictvím Javy umožňuje provádět řadu úkolů souvisejících s hypertextovými odkazy v prezentacích.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)
{{% /alert %}} 

## **Přidání URL hypertextových odkazů**

### **Přidání URL hypertextových odkazů do textu**

Tento kód v Javě ukazuje, jak přidat hypertextový odkaz na webovou stránku do textu:

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

### **Přidání URL hypertextových odkazů do tvarů nebo rámců**

Tento ukázkový kód v Javě ukazuje, jak přidat hypertextový odkaz na webovou stránku do tvaru:

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

### **Přidání URL hypertextových odkazů do médií**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy na obrázky, zvukové a video soubory. 

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **obrázek**:

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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **audio soubor**:

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

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz na **video**:

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
Možná budete chtít zobrazit *[Správa OLE](/slides/cs/androidjava/manage-ole/)*.
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

Pomocí vlastnosti [ColorSource](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) v rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink) můžete nastavit barvu hypertextových odkazů a také získat informace o barvě z odkazů. Tato funkce byla poprvé představena v PowerPoint 2019, takže změny týkající se této vlastnosti se nepoužijí na starší verze PowerPointu.

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

Tento kód v Javě ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

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

Tento kód v Javě ukazuje, jak odstranit hypertextový odkaz ze tvaru na snímku prezentace: 

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

## **Měnný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Hyperlink) je měnná. Pomocí této třídy můžete měnit hodnoty těchto vlastností:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Ukázkový úryvek kódu ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek:

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

K [IHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries) můžete přistupovat z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Třída [IHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries) podporuje tyto metody a vlastnosti:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **Často kladené dotazy**

**Jak mohu vytvořit vnitřní navigaci nejen na snímek, ale i na „sekci“ nebo první snímek sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci do sekce“ obvykle odkazujete na její první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavní šablony, aby fungoval na všech snímcích?**

Ano. Prvky hlavní šablony a rozvržení podporují hypertextové odkazy. Takové odkazy se zobrazují na podřízených snímcích a jsou během prezentace klikatelné.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/) ano – odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/androidjava/convert-powerpoint-to-png/) a [videa](/slides/cs/androidjava/convert-powerpoint-to-video/) není klikatelnost zachována kvůli povaze těchto formátů (rasterové snímky/video nepodporují hypertextové odkazy).