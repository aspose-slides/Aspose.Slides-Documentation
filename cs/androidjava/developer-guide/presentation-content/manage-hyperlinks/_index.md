---
title: Spravovat hypertextové odkazy v prezentacích na Androidu
linktitle: Spravovat hypertextový odkaz
type: docs
weight: 20
url: /cs/androidjava/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy - zvyšte interaktivitu a efektivitu během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt, data nebo místo v něčem. Toto jsou běžné hypertextové odkazy v prezentacích PowerPoint:

* Odkazy na webové stránky v textech, tvarech nebo médiích
* Odkazy na snímky

Aspose.Slides pro Android prostřednictvím Javy vám umožňuje provádět řadu úkolů souvisejících s hypertextovými odkazy v prezentacích.

{{% alert color="info" %}} 
Možná budete chtít vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)
{{% /alert %}} 

## **Přidat URL odkazy**

### **Přidat URL odkazy do textu**

Tento Java kód vám ukazuje, jak přidat odkaz na webovou stránku do textu:

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

### **Přidat URL odkazy do tvarů nebo rámců**

Tento ukázkový kód v Javě vám ukazuje, jak přidat odkaz na webovou stránku do tvaru:

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

### **Přidat URL odkazy do médií**

Aspose.Slides vám umožňuje přidávat odkazy do obrázků, audio a video souborů. 

Tento ukázkový kód vám ukazuje, jak přidat odkaz na **obrázek**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Přidá obrázek do prezentace
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Vytvoří rámeček obrázku na snímku 1 na základě dříve přidaného obrázku
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Tento ukázkový kód vám ukazuje, jak přidat odkaz na **audio soubor**:

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

Tento ukázkový kód vám ukazuje, jak přidat odkaz na **video**:

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
Možná budete chtít zobrazit *[Spravovat OLE](/slides/cs/androidjava/manage-ole/)*.
{{% /alert %}}

## **Použít hypertextové odkazy k vytvoření obsahu**

Protože hypertextové odkazy vám umožňují přidávat odkazy na objekty nebo místa, můžete je použít k vytvoření obsahu.

Tento ukázkový kód vám ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátovat hypertextové odkazy**

### **Barva**

Pomocí vlastnosti [ColorSource](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) v rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink) můžete nastavit barvu hypertextových odkazů a také získat informace o barvě z odkazů. Tato funkce byla poprvé zavedena v PowerPoint 2019, takže změny týkající se této vlastnosti neplatí pro starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, kdy byly na stejný snímek přidány hypertextové odkazy s různými barvami:

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

## **Odstranit hypertextové odkazy z prezentací**

### **Odstranit hypertextové odkazy z textu**

Tento Java kód vám ukazuje, jak odstranit hypertextový odkaz z textu na snímku prezentace:

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

### **Odstranit hypertextové odkazy z tvarů nebo rámců**

Tento Java kód vám ukazuje, jak odstranit hypertextový odkaz z tvaru na snímku prezentace: 

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

## **Měnitelný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Hyperlink) je měnitelná. S touto třídou můžete měnit hodnoty následujících vlastností:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Tento úryvek kódu vám ukazuje, jak přidat hypertextový odkaz na snímek a později upravit jeho popisek nástroje:

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

	// Změní tooltip hypertextového odkazu, který již byl přidán
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Podporované vlastnosti v IHyperlinkQueries**

Můžete získat přístup k [IHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries) z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Třída [IHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries) podporuje tyto metody a vlastnosti:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **Často kladené otázky**

### Jak mohu vytvořit vnitřní navigaci nejen na snímek, ale na „sekci“ nebo první snímek sekce?

Sekce v PowerPointu jsou skupiny snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci do sekce“ obvykle odkazujete na její první snímek.

### Mohu připojit hypertextový odkaz k prvkům hlavní snímku, aby fungoval na všech snímcích?

Ano. Prvky hlavního snímku a rozložení podporují hypertextové odkazy. Takové odkazy se zobrazují na podřízených snímcích a jsou klikatelné během prezentace.

### Budou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?

V [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/) ano — odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/androidjava/convert-powerpoint-to-png/) a [videí](/slides/cs/androidjava/convert-powerpoint-to-video/) klikatelnost nepřesune, protože tyto formáty (rastrové snímky/video) hypertextové odkazy nepodporují.