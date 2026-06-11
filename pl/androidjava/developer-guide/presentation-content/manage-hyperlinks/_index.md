---
title: Zarządzanie hiperłączami prezentacji w Androidzie
linktitle: Zarządzaj hiperłączem
type: docs
weight: 20
url: /pl/androidjava/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatowanie hiperłącza
- usuń hiperłącze
- zaktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Bez problemu zarządzaj hiperłączami w prezentacjach PowerPoint i OpenDocument za pomocą Aspose.Slides for Android via Java — zwiększ interaktywność i usprawnij przepływ pracy w kilka minut."
---
## **Wprowadzenie**

Hiperalink jest odwołaniem do obiektu, danych lub miejsca w czymś. Oto typowe hiperliki w prezentacjach PowerPoint:

* łącza do stron internetowych w tekście, kształtach lub mediach
* łącza do slajdów

Aspose.Slides for Android via Java umożliwia wykonywanie wielu zadań związanych z hiperlankami w prezentacjach.

{{% alert color="primary" %}} 

Możesz chcieć wypróbować prosty, [darmowy edytor PowerPoint online.](https://products.aspose.app/slides/pl/editor)

{{% /alert %}} 

## **Dodaj hiperłącza URL**

### **Dodaj hiperłącza URL do tekstu**

Ten kod w Javie pokazuje, jak dodać hiperłącze do witryny w tekście:

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

### **Dodaj hiperłącza URL do kształtów lub ramek**

Ten przykładowy kod w Javie pokazuje, jak dodać hiperłącze do witryny w kształcie:

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

### **Dodaj hiperłącza URL do multimediów**

Aspose.Slides umożliwia dodawanie hiperłączy do plików graficznych, audio i wideo. 

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **obrazu**:

```java
Presentation pres = new Presentation();
try {
	// Dodaje obraz do prezentacji
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Tworzy ramkę obrazu na slajdzie 1 na podstawie wcześniej dodanego obrazu
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **pliku audio**:

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

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **wideo**:

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

Możesz chcieć zobaczyć *[Manage OLE](/slides/pl/androidjava/manage-ole/)*.

{{% /alert %}}

## **Użyj hiperłączy do utworzenia spisu treści**

Ponieważ hiperłącza umożliwiają dodawanie odwołań do obiektów lub miejsc, możesz ich użyć do stworzenia spisu treści. 

Ten przykładowy kod pokazuje, jak stworzyć spis treści z hiperłączami:

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

## **Formatowanie hiperłączy**

### **Kolor**

Z właściwością [ColorSource](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) w interfejsie [IHyperlink](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlink) możesz ustawić kolor hiperłączy oraz pobrać informacje o kolorze z hiperłączy. Funkcja została wprowadzona po raz pierwszy w PowerPoint 2019, więc zmiany dotyczące tej właściwości nie mają zastosowania w starszych wersjach PowerPoint.

Ten przykładowy kod demonstruje operację, w której do tego samego slajdu dodano hiperłącza o różnych kolorach:

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

## **Usuwanie hiperłączy z prezentacji**

### **Usuwanie hiperłączy z tekstu**

Ten kod w Javie pokazuje, jak usunąć hiperłącze z tekstu na slajdzie prezentacji:

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

### **Usuwanie hiperłączy z kształtów lub ramek**

Ten kod w Javie pokazuje, jak usunąć hiperłącze z kształtu na slajdzie prezentacji: 

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

## **Modyfikowalne hiperłącze**

Klasa [Hyperlink](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Hyperlink) jest modyfikowalna. Dzięki tej klasie możesz zmieniać wartości następujących właściwości:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Ten fragment kodu pokazuje, jak dodać hiperłącze do slajdu i później edytować jego podpowiedź (tooltip):

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

## **Obsługiwane właściwości w IHyperlinkQueries**

Możesz uzyskać dostęp do [IHyperlinkQueries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlinkQueries) z prezentacji, slajdu lub tekstu, dla którego zdefiniowano hiperłącze.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Klasa [IHyperlinkQueries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlinkQueries) obsługuje następujące metody i właściwości:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Jak mogę stworzyć wewnętrzną nawigację nie tylko do slajdu, ale do „sekcji” lub pierwszego slajdu sekcji?**

Sekcje w PowerPoint to grupy slajdów; nawigacja technicznie skierowana jest do konkretnego slajdu. Aby „nawigować do sekcji”, zazwyczaj linkuje się do jej pierwszego slajdu.

**Czy mogę dołączyć hiperłącze do elementów master slajdu, aby działało na wszystkich slajdach?**

Tak. Elementy master slajdu i układu obsługują hiperłącza. Takie linki pojawiają się na slajdach potomnych i są klikalne podczas pokazu slajdów.

**Czy hiperłącza zostaną zachowane przy eksportowaniu do PDF, HTML, obrazów lub wideo?**

W [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/) tak — linki są zazwyczaj zachowywane. Przy eksportowaniu do [images](/slides/pl/androidjava/convert-powerpoint-to-png/) i [video](/slides/pl/androidjava/convert-powerpoint-to-video/) klikalność nie zostanie przeniesiona ze względu na charakter tych formatów (klatki rastrowe/wideo nie wspierają hiperłączy).