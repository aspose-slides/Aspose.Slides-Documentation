---
title: Prezentációs hiperhivatkozások kezelése Androidon
linktitle: Hiperhivatkozás kezelése
type: docs
weight: 20
url: /hu/androidjava/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- diához tartozó hiperhivatkozás
- alakzathoz hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén kezelhet hiperhivatkozásokat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Android Java használatával—percek alatt növelheti az interaktivitást és a munkafolyamat hatékonyságát."
---
## **Bevezetés**

A hiperhivatkozás egy referencia egy objektumra, adatra vagy egy helyre valamiben. Ezek gyakori hiperhivatkozások a PowerPoint bemutatókban:

* Hivatkozások weboldalakra szövegekben, alakzatokban vagy médiában
* Hivatkozások diákra

Az Aspose.Slides for Android Java-n keresztül lehetővé teszi, hogy számos feladatot végezzen a hiperhivatkozásokkal kapcsolatosan a bemutatókban.

{{% alert color="primary" %}} 
Érdemes megtekinteni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztőjét.](https://products.aspose.app/slides/hu/editor)
{{% /alert %}}

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a Java kód megmutatja, hogyan adhat hozzá egy weboldal hiperhivatkozást egy szöveghez:

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

Ez a Java mintakód bemutatja, hogyan adhat hozzá egy weboldal hiperhivatkozást egy alakzathoz:

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

Az Aspose.Slides lehetővé teszi hiperhivatkozások hozzáadását képekhez, hang- és videofájlokhoz.

Ez a mintakód megmutatja, hogyan adjon hozzá egy hiperhivatkozást egy **képhez**:

```java
Presentation pres = new Presentation();
try {
	// Képet ad a prezentációhoz
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Képkockát hoz létre az 1. dián az előzőleg hozzáadott kép alapján
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Ez a mintakód megmutatja, hogyan adjon hozzá egy hiperhivatkozást egy **hangfájlhoz**:

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

Ez a mintakód megmutatja, hogyan adjon hozzá egy hiperhivatkozást egy **videóhoz**:

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
Érdemes megnézni a *[OLE kezelése](/slides/hu/androidjava/manage-ole/)*.
{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre való hivatkozások hozzáadását, használhatók tartalomjegyzék létrehozására is.

Ez a mintakód bemutatja, hogyan hozhat létre egy tartalomjegyzéket hiperhivatkozásokkal:

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

A [ColorSource](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) tulajdonsággal az [IHyperlink](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlink) interfészen beállíthatja a hiperhivatkozások színét, illetve lekérdezheti a színinformációt a hiperhivatkozásokból. Ez a funkció először a PowerPoint 2019-ben került bevezetésre, így a tulajdonsággal kapcsolatos változások nem vonatkoznak a régebbi PowerPoint verziókra.

Ez a mintakód bemutat egy műveletet, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a diához:

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

## **Hiperhivatkozások eltávolítása a bemutatókból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a Java kód megmutatja, hogyan távolítható el a hiperhivatkozás egy szövegből egy prezentációs dián:

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

Ez a Java kód bemutatja, hogyan távolítható el a hiperhivatkozás egy alakzatról egy prezentációs dián:

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

A [Hyperlink](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Hyperlink) osztály módosítható. Ezzel az osztállyal megváltoztathatja az alábbi tulajdonságok értékeit:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

A kódrészlet megmutatja, hogyan adjon hozzá egy hiperhivatkozást egy diára, majd később szerkessze a feliratát (tooltip):

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

## **Támogatott tulajdonságok az IHyperlinkQueries-ben**

Elérheti az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlinkQueries) objektumot egy prezentációból, diából vagy szövegből, amelyhez a hiperhivatkozás definiálva van.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlinkQueries) osztály támogatja ezeket a metódusokat és tulajdonságokat:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **GYIK**

**Hogyan hozhatok létre belső navigációt, nem csak egy diára, hanem egy „szekcióra” vagy egy szekció első diájára?**  
A PowerPoint szekciói a diák csoportosításai; a navigáció technikailag egy adott diára mutat. Egy „szekcióra” navigáláshoz általában a szekció első diájára kell hivatkozni.

**Csatolhatok hiperhivatkozást a mester dia elemeihez, hogy az minden dián működjön?**  
Igen. A mester dia és elrendezés elemei támogatják a hiperhivatkozásokat. Az ilyen linkek megjelennek a gyermek diákon, és a bemutató során kattinthatók.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**  
A [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) és a [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) esetén igen – a linkek általában megmaradnak. A [képek](/slides/hu/androidjava/convert-powerpoint-to-png/) és a [videó](/slides/hu/androidjava/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem kerül át, mivel ezek a formátumok (raszteres képkockák/videó) nem támogatják a hiperhivatkozásokat.