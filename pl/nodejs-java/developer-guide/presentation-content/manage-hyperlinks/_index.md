---
title: Z... zarządzaj hiperłączami prezentacji w JavaScript
linktitle: Zarządzaj hiperłączem
type: docs
weight: 20
url: /pl/nodejs-java/manage-hyperlinks/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Bezproblemowo zarządzaj hiperłączami w prezentacjach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Node.js — zwiększ interaktywność i usprawnij przepływ pracy w kilka minut."
---
## **Wstęp**

Hiperłącze to odwołanie do obiektu, danych lub miejsca w dokumencie. Są to typowe hiperłącza w prezentacjach PowerPoint:

* Linki do stron internetowych w tekstach, kształtach lub multimediach
* Linki do slajdów

Aspose.Slides for Node.js via Java umożliwia wykonywanie wielu zadań związanych z hiperłączami w prezentacjach.

{{% alert color="primary" %}} 
Możesz chcieć sprawdzić Aspose simple, [darmowy edytor PowerPoint online.](https://products.aspose.app/slides/pl/editor)
{{% /alert %}} 

## **Dodawanie hiperłączy URL**

### **Dodawanie hiperłączy URL do tekstów**

Ten kod JavaScript pokazuje, jak dodać hiperłącze do witryny w tekście:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Dodawanie hiperłączy URL do kształtów lub ramek**

Ten przykładowy kod w JavaScript pokazuje, jak dodać hiperłącze do witryny w kształcie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Dodawanie hiperłączy URL do multimediów**

Aspose.Slides pozwala dodawać hiperłącza do obrazów, plików audio i wideo.

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **obrazu**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje obraz do prezentacji
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Tworzy ramkę obrazu na slajdzie 1 na podstawie wcześniej dodanego obrazu
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **pliku audio**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **wideo**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}} 
Możesz chcieć zobaczyć *[Zarządzaj OLE](/slides/pl/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Używanie hiperłączy do tworzenia spisu treści**

Ponieważ hiperłącza umożliwiają odwołania do obiektów lub miejsc, można ich używać do tworzenia spisu treści.

Ten przykładowy kod pokazuje, jak utworzyć spis treści z hiperłączami:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Formatowanie hiperłączy**

### **Kolor**

Za pomocą metody [setColorSource](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) w klasie [Hyperlink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink) możesz ustawiać kolor hiperłączy oraz odczytywać informacje o kolorze. Funkcja została wprowadzona w PowerPoint 2019, więc zmiany dotyczące tej właściwości nie obowiązują w starszych wersjach PowerPoint.

Ten przykładowy kod demonstruje operację, w której na tym samym slajdzie dodano hiperłącza o różnych kolorach:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie hiperłączy w prezentacjach**

### **Usuwanie hiperłączy z tekstów**

Ten kod JavaScript pokazuje, jak usunąć hiperłącze z tekstu w slajdzie prezentacji:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Sprawdza, czy kształt obsługuje ramkę tekstową (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Iteruje przez akapity w ramce tekstowej
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Iteruje przez każdy fragment w akapicie
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Zmienia tekst
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Zmienia formatowanie
                    }
                }
            }
        }
    }
    // Zapisuje zmodyfikowaną prezentację
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Usuwanie hiperłączy z kształtów lub ramek**

Ten kod JavaScript pokazuje, jak usunąć hiperłącze z kształtu w slajdzie prezentacji:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modyfikowalne hiperłącze**

Klasa [Hyperlink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink) jest modyfikowalna. Dzięki niej możesz zmienić wartości następujących właściwości:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Poniższy fragment kodu pokazuje, jak dodać hiperłącze do slajdu i później edytować jego podpowiedź (tooltip):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obsługiwane właściwości w IHyperlinkQueries**

Możesz uzyskać dostęp do [HyperlinkQueries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries) z prezentacji, slajdu lub tekstu, dla którego zdefiniowano hiperłącze.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries) obsługuje następujące metody i właściwości:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Jak mogę utworzyć wewnętrzną nawigację nie tylko do slajdu, ale do „sekcji” lub pierwszego slajdu sekcji?**

Sekcje w PowerPoint to grupy slajdów; nawigacja technicznie kieruje do konkretnego slajdu. Aby „przejść do sekcji”, zwykle linkuje się do jej pierwszego slajdu.

**Czy mogę dołączyć hiperłącze do elementów slajdu‑mistrza, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu‑mistrza i układu obsługują hiperłącza. Takie linki pojawiają się na slajdach potomnych i są klikalne podczas pokazu.

**Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

W [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), tak – linki są zazwyczaj zachowane. Przy eksporcie do [obrazów](/slides/pl/nodejs-java/convert-powerpoint-to-png/) i [wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/), klikalność nie zostanie przeniesiona ze względu na charakter tych formatów (klatki rastrowe/wideo nie obsługują hiperłączy).