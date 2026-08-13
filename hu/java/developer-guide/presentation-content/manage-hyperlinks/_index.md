---
title: Prezentációs hiperhivatkozások kezelése Java-ban
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
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén kezelheted a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java segítségével—növeld az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy objektumra, adatra vagy egy helyre mutató hivatkozás. Ezek a gyakori hiperhivatkozások a PowerPoint-prezentációkban:

* Weboldalakra mutató hivatkozások szövegekben, alakzatokban vagy médiában
* Diákra mutató hivatkozások

Az Aspose.Slides for Java lehetővé teszi, hogy számos, hiperhivatkozásokkal kapcsolatos feladatot hajts végre a prezentációkban. 

{{% alert color="info" %}} 

Érdemes megnézni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztőt.](https://products.aspose.app/slides/hu/editor)

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a Java-kód megmutatja, hogyan adhatunk hozzá egy weboldal hiperhivatkozást egy szöveghez:

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a Java-mintakód megmutatja, hogyan adhatunk hozzá egy weboldal hiperhivatkozást egy alakzathoz:

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

### **URL hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi, hogy hiperhivatkozásokat adjunk hozzá képekhez, audio- és videofájlokhoz. 

Ez a mintakód megmutatja, hogyan adhatunk hozzá hiperhivatkozást egy **képhez**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Képet ad a prezentációhoz
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Létrehozza a képkeretet az 1. dián a korábban hozzáadott kép alapján
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Ez a mintakód megmutatja, hogyan adhatunk hozzá hiperhivatkozást egy **hangfájlhoz**:

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

Ez a mintakód megmutatja, hogyan adhatunk hozzá hiperhivatkozást egy **videóhoz**:

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

Érdemes megnézni a *[OLE kezelése](/slides/hu/java/manage-ole/)*.

{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre mutató hivatkozások hozzáadását, használhatók tartalomjegyzék létrehozásához. 

Ez a mintakód megmutatja, hogyan hozhatsz létre tartalomjegyzéket hiperhivatkozásokkal:

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

## **Hiperhivatkozások formázása**

### **Szín**

A [ColorSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Hyperlink#setColorSource-int-) tulajdonsággal az [IHyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink) felületen beállíthatod a hiperhivatkozások színét, illetve lekérheted a színinformációt a hiperhivatkozásokból. Ez a funkció először a PowerPoint 2019-ben került bevezetésre, ezért a tulajdonság változtatásai nem érvényesek a régebbi PowerPoint-verziókra.

Ez a mintakód bemutat egy műveletet, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a diához:

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

## **Hiperhivatkozások eltávolítása a prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a Java-kód megmutatja, hogyan távolítható el egy hiperhivatkozás egy szövegből a prezentációs dián:

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

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a Java-kód megmutatja, hogyan távolítható el egy hiperhivatkozás egy alakzatból a prezentációs dián:

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

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Hyperlink) osztály módosítható. Ezzel az osztállyal a következő tulajdonságok értékeit módosíthatod:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Ez a kódrészlet megmutatja, hogyan adhatunk hozzá egy hiperhivatkozást egy diához, és később szerkeszthetjük a tooltipjét:

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

	// Módosítja a már hozzáadott hiperhivatkozás tooltipjét
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Támogatott tulajdonságok az IHyperlinkQueries-ben**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries) elérhető egy prezentációból, diából vagy szövegből, amelyhez a hiperhivatkozás definiálva van. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries) osztály ezeket a metódusokat és tulajdonságokat támogatja: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **GYIK**

### Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szakaszra” vagy egy szakasz első diájára?

A PowerPoint szakaszok a diák csoportosításai; a navigáció technikailag egy adott diára mutat. Egy „szakaszra” való navigáláshoz általában az első diájára hivatkozol.

### Csatolhatok-e hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?

Igen. A mesterdia és elrendezési elemek támogatják a hiperhivatkozásokat. Az ilyen hivatkozások megjelennek a gyermekdiákon, és a vetítés során kattinthatók.

### Megmaradnak-e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?

[PDF](/slides/hu/java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/java/convert-powerpoint-to-html/) esetén igen – a linkek általában megmaradnak. [Képek](/slides/hu/java/convert-powerpoint-to-png/) és [videó](/slides/hu/java/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem marad meg, mivel ezek a formátumok (raszteres képkockák/videó) nem támogatják a hiperhivatkozásokat.