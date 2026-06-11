---
title: Hantera presentationhyperlänkar i JavaScript
linktitle: Hantera hyperlänk
type: docs
weight: 20
url: /sv/nodejs-java/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js på ett enkelt sätt—förbättra interaktiviteten och arbetsflödet på några minuter."
---
## **Introduktion**

En hyperlänk är en referens till ett objekt eller data eller en plats i något. Detta är vanliga hyperlänkar i PowerPoint-presentationer:

* Länkar till webbplatser i texter, former eller media
* Länkar till bilder

Aspose.Slides för Node.js via Java låter dig utföra många uppgifter som involverar hyperlänkar i presentationer.

{{% alert color="primary" %}} 

Du kanske vill kolla in Aspose enkla, [gratis online PowerPoint-redigerare.](https://products.aspose.app/slides/sv/editor)

{{% /alert %}} 

## **Lägga till URL-hyperlänkar**

### **Lägga till URL-hyperlänkar till text**

Denna JavaScript-kod visar hur du lägger till en webbplatshyperlänk i en text:

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

### **Lägga till URL-hyperlänkar till former eller ramar**

Detta exempel i JavaScript visar hur du lägger till en webbplatshyperlänk till en form:

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

### **Lägga till URL-hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud- och videofiler. 

Detta exempel visar hur du lägger till en hyperlänk till en **bild**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till bild i presentationen
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Skapar bildruta på bild 1 baserat på tidigare tillagd bild
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

Detta exempel visar hur du lägger till en hyperlänk till en **ljudfil**:

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

Detta exempel visar hur du lägger till en hyperlänk till en **video**:

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

{{%  alert  title="Tip"  color="primary"  %}} 

Du kanske vill se *[Hantera OLE](/slides/sv/nodejs-java/manage-ole/)*.

{{% /alert %}}

## **Använda hyperlänkar för att skapa innehållsförteckning**

Eftersom hyperlänkar låter dig lägga till referenser till objekt eller platser, kan du använda dem för att skapa en innehållsförteckning. 

Detta exempel visar hur du skapar en innehållsförteckning med hyperlänkar:

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

## **Formatera hyperlänkar**

### **Färg**

Med metoden [setColorSource](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) i klassen [Hyperlink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink) kan du ange färgen för hyperlänkar och även hämta färginformation från hyperlänkar. Funktionen introducerades först i PowerPoint 2019, så förändringar som rör egenskapen gäller inte äldre PowerPoint-versioner.

Detta exempel visar en operation där hyperlänkar med olika färger lades till på samma bild:

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

## **Ta bort hyperlänkar i presentationer**

### **Ta bort hyperlänkar från text**

Denna JavaScript-kod visar hur du tar bort hyperlänken från en text i en presentationsbild:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Kontrollerar om formen stöder textram (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Itererar genom stycken i textrammen
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Itererar genom varje del i stycket
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Ändrar texten
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Ändrar formatering
                    }
                }
            }
        }
    }
    // Sparar den ändrade presentationen
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ta bort hyperlänkar från former eller ramar**

Denna JavaScript-kod visar hur du tar bort hyperlänken från en form i en presentationsbild:

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

## **Muterbar hyperlänk**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink) är muterbar. Med denna klass kan du ändra värdena för följande egenskaper:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Kodsnutten visar hur du lägger till en hyperlänk på en bild och redigerar dess verktygstips senare:

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

## **Stödda egenskaper i IHyperlinkQueries**

Du kan komma åt [HyperlinkQueries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries) från en presentation, bild eller text som har en definierad hyperlänk.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries) stöder dessa metoder och egenskaper:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **Vanliga frågor**

**Hur kan jag skapa intern navigation inte bara till en bild, utan till ett "avsnitt" eller den första bilden i ett avsnitt?**

Avsnitt i PowerPoint är grupperingar av bilder; navigation riktar sig tekniskt sett till en specifik bild. För att "navigera till ett avsnitt" länkar du vanligtvis till dess första bild.

**Kan jag fästa en hyperlänk till master‑bildselement så att den fungerar på alla bilder?**

Ja. Master‑bild- och layout‑element stödjer hyperlänkar. Sådana länkar visas på underordnade bilder och är klickbara under bildspelet.

**Kommer hyperlänkar att bevaras när man exporterar till PDF, HTML, bilder eller video?**

I [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/) ja—länkar bevaras i allmänhet. Vid export till [bilder](/slides/sv/nodejs-java/convert-powerpoint-to-png/) och [video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) är klickbarhet inte medfört på grund av formatens natur (raster‑ramar/video stöder inte hyperlänkar).