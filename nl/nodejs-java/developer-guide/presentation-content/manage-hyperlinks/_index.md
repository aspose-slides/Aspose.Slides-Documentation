---
title: Beheer presentatie-hyperlinks in JavaScript
linktitle: Beheer hyperlink
type: docs
weight: 20
url: /nl/nodejs-java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink aanmaken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst-hyperlink
- dia-hyperlink
- vorm-hyperlink
- afbeeldings-hyperlink
- video-hyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Moeiteloos hyperlinken beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js—verbeter interactiviteit en workflow in enkele minuten."
---
## **Introductie**

Een hyperlink is een verwijzing naar een object of gegevens of een plaats in iets. Dit zijn veelvoorkomende hyperlinks in PowerPoint‑presentaties:

* Links naar websites binnen teksten, vormen of media
* Links naar dia's

Aspose.Slides for Node.js via Java stelt u in staat om veel taken met hyperlinks in presentaties uit te voeren.

{{% alert color="primary" %}} 
U wilt misschien de eenvoudige, [gratis online PowerPoint-editor.](https://products.aspose.app/slides/nl/editor)
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

### **URL‑hyperlinks toevoegen aan teksten**

Deze JavaScript‑code toont hoe u een website‑hyperlink aan een tekst kunt toevoegen:
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

### **URL‑hyperlinks toevoegen aan vormen of frames**

Deze voorbeeldcode in JavaScript toont hoe u een website‑hyperlink aan een vorm kunt toevoegen:
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

### **URL‑hyperlinks toevoegen aan media**

Aspose.Slides stelt u in staat om hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden. 

Deze voorbeeldcode toont hoe u een hyperlink aan een **afbeelding** kunt toevoegen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt afbeelding toe aan presentatie
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Maakt een afbeeldingframe op dia 1 op basis van eerder toegevoegde afbeelding
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

Deze voorbeeldcode toont hoe u een hyperlink aan een **audio‑bestand** kunt toevoegen:
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

Deze voorbeeldcode toont hoe u een hyperlink aan een **video** kunt toevoegen:
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
U wilt misschien *[OLE beheren](/slides/nl/nodejs-java/manage-ole/)* zien.
{{% /alert %}}

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Omdat hyperlinks u in staat stellen verwijzingen naar objecten of plaatsen toe te voegen, kunt u ze gebruiken om een inhoudsopgave te maken. 

Deze voorbeeldcode toont hoe u een inhoudsopgave met hyperlinks kunt maken:
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

## **Hyperlinks opmaken**

### **Kleur**

Met de [setColorSource](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) methode in de [Hyperlink](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink)‑klasse kunt u de kleur van hyperlinks instellen en ook de kleureninformatie van hyperlinks ophalen. De functie werd voor het eerst geïntroduceerd in PowerPoint 2019, dus wijzigingen met betrekking tot deze eigenschap gelden niet voor oudere versies van PowerPoint.

Deze voorbeeldcode demonstreert een bewerking waarbij hyperlinks met verschillende kleuren aan dezelfde dia werden toegevoegd:
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

## **Hyperlinks verwijderen in presentaties**

### **Hyperlinks uit teksten verwijderen**

Deze JavaScript‑code toont hoe u de hyperlink uit een tekst in een presentatiedia kunt verwijderen:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Controleert of vorm een tekstframe ondersteunt (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Itereert door alinea's in het tekstframe
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Itereert door elk gedeelte in de alinea
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Wijzigt tekst
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Wijzigt opmaak
                    }
                }
            }
        }
    }
    // Slaat gewijzigde presentatie op
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Hyperlinks uit vormen of frames verwijderen**

Deze JavaScript‑code toont hoe u de hyperlink uit een vorm in een presentatiedia kunt verwijderen:
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

## **Aanpasbare hyperlink**

De klasse [Hyperlink](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink) is aanpasbaar. Met deze klasse kunt u de waarden van de volgende eigenschappen wijzigen:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

De code‑fragment toont hoe u een hyperlink aan een dia kunt toevoegen en later de tooltip kunt bewerken:
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

## **Ondersteunde eigenschappen in IHyperlinkQueries**

U kunt [HyperlinkQueries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries) benaderen vanuit een presentatie, dia of tekst waarvoor de hyperlink is gedefinieerd.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

De klasse [HyperlinkQueries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries) ondersteunt deze methoden en eigenschappen:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **Veelgestelde vragen**

**Hoe kan ik interne navigatie maken, niet alleen naar een dia, maar naar een "sectie" of de eerste dia van een sectie?**

Secties in PowerPoint zijn verzamelingen van dia's; navigatie richt zich technisch op een specifieke dia. Om "naar een sectie" te navigeren, linkt u meestal naar de eerste dia ervan.

**Kan ik een hyperlink koppelen aan elementen van de masterdia zodat deze op alle dia's werkt?**

Ja. Elementen van de masterdia en lay-out ondersteunen hyperlinks. Dergelijke koppelingen verschijnen op de onderliggende dia's en zijn klikbaar tijdens de diavoorstelling.

**Worden hyperlinks behouden bij exporteren naar PDF, HTML, afbeeldingen of video?**

In [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/) worden links over het algemeen behouden. Bij export naar [afbeeldingen](/slides/nl/nodejs-java/convert-powerpoint-to-png/) en [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) is klikbaarheid niet meegeleverd omdat die formaten (rasterframes/video) geen hyperlinks ondersteunen.