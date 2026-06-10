---
title: Java‑ban a prezentációk hiperhivatkozásainak kezelése
linktitle: Hiperhivatkozás kezelése
type: docs
weight: 20
url: /hu/java/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- diára mutató hiperhivatkozás
- alakzatra mutató hiperhivatkozás
- képre mutató hiperhivatkozás
- videóra mutató hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén kezelheti a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java‑val — fokozza az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy referencia objektumra, adatra vagy egy helyre valamiben. Ezek gyakori hiperhivatkozások PowerPoint‑prezentációkban:

* Hivatkozások weboldalakra szövegekben, alakzatokban vagy médiában
* Hivatkozások diákra

Az Aspose.Slides for Java lehetővé teszi, hogy számos, hiperhivatkozásokkal kapcsolatos feladatot végezzen el a prezentációkban. 

{{% alert color="primary" %}} 
Érdemes megtekinteni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztőt.](https://products.aspose.app/slides/hu/editor)
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a Java‑kód megmutatja, hogyan adjon weboldal‑hiperhivatkozást egy szöveghez:

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a Java‑példakód megmutatja, hogyan adjon weboldal‑hiperhivatkozást egy alakzathoz:

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

### **URL hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi hiperhivatkozások hozzáadását képekhez, hang‑ és videofájlokhoz. 

Ez a példakód megmutatja, hogyan adjon hiperhivatkozást egy **képhez**:

```java
Presentation pres = new Presentation();
try {
	// Képet ad hozzá a prezentációhoz
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Képkeret létrehozása az 1. dián a korábban hozzáadott kép alapján
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Ez a példakód megmutatja, hogyan adjon hiperhivatkozást egy **hangfájlhoz**:

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

Ez a példakód megmutatja, hogyan adjon hiperhivatkozást egy **videóhoz**:

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

{{% alert title="Tipp" color="primary" %}} 
Megtekintheted a *[OLE kezelése](/slides/hu/java/manage-ole/)* oldalt.
{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre mutató referenciák hozzáadását, felhasználhatók tartalomjegyzék készítésére is. 

Ez a példakód megmutatja, hogyan hozhat létre tartalomjegyzéket hiperhivatkozásokkal:

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

## **Hiperhivatkozások formázása**

### **Szín**

A [ColorSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Hyperlink#setColorSource-int-) tulajdonsággal az [IHyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink) interfészben beállíthatja a hiperhivatkozások színét, illetve lekérheti a színinformációt. A funkció először a PowerPoint 2019‑ben jelent meg, ezért a tulajdonságra vonatkozó változások nem érvényesek a régebbi PowerPoint‑verziókra.

Ez a példakód egy olyan műveletet mutat be, ahol különböző színű hiperhivatkozások kerülnek ugyanarra a diára:

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

## **Hiperhivatkozások eltávolítása a prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a Java‑kód megmutatja, hogyan távolíthatja el a hiperhivatkozást egy szövegből egy prezentációs dián:

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

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a Java‑kód megmutatja, hogyan távolíthatja el a hiperhivatkozást egy alakzatról egy prezentációs dián:

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

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Hyperlink) osztály módosítható. Ezzel az osztállyal megváltoztathatja az alábbi tulajdonságok értékeit:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

A kódrészlet megmutatja, hogyan adjon hiperhivatkozást egy diához, majd később módosítsa annak tooltipjét:

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

## **Támogatott tulajdonságok az IHyperlinkQueries‑ben**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries) lekérhető egy prezentációból, diáról vagy szövegből, amelyhez a hiperhivatkozás definiálva van. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries) osztály ezeket a metódusokat és tulajdonságokat támogatja: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **GYIK**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szekcióra” vagy egy szekció első diájára?**

A PowerPoint‑szekciók a diák csoportosításai; a navigáció technikailag egy konkrét diára mutat. „Szekcióra navigáláshoz” általában az első diára kell hivatkozni.

**Csatolhatok hiperhivatkozást a mesterdia-elemekhez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Az ilyen hivatkozások megjelennek a gyermekdiákon, és a vetítés során kattinthatóak.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A [PDF](/slides/hu/java/convert-powerpoint-to-pdf/) és a [HTML](/slides/hu/java/convert-powerpoint-to-html/) esetében igen – a linkek általában megmaradnak. Képek [exportálásakor](/slides/hu/java/convert-powerpoint-to-png/) és videó [exportálásakor](/slides/hu/java/convert-powerpoint-to-video/) a kattinthatóság nem öröklődik, mivel ezek a formátumok (raszteres képkockák/videó) nem támogatják a hiperhivatkozásokat.