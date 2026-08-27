---
title: "Hantera textrutor i presentationer med JavaScript"
linktitle: "Hantera textruta"
type: docs
weight: 20
url: /sv/nodejs-java/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides för Node.js gör det enkelt att skapa, redigera och duplicera textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Text på bildspel finns vanligtvis i textrutor eller former. Därför, för att lägga till text på en bild, måste du lägga till en textruta och sedan placera någon text i textrutan. Aspose.Slides för Node.js via Java tillhandahåller klassen [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}
Aspose.Slides tillhandahåller också klassen [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape) som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via `Shape`-klassen innehålla text. Men former som läggs till via [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape)-klassen kan innehålla text.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Därför, när du arbetar med en form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den har kastats via `AutoShape`-klassen. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame), som är en egenskap under `AutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/nodejs-java/manage-textbox/#update-text) på den här sidan.
{{% /alert %}}

## **Skapa textruta på bild**

För att skapa en textruta på en bild, följ dessa steg:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑klassen.  
2. Hämta en referens till den första bilden i den nyss skapade presentationen.  
3. Lägg till ett [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape)‑objekt med [ShapeType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) inställt på `Rectangle` på en specificerad position på bilden och hämta referensen till det nyligen tillagda `AutoShape`‑objektet.  
4. Lägg till en `TextFrame`‑egenskap till `AutoShape`‑objektet som ska innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*  
5. Skriv slutligen PPTX‑filen via `Presentation`‑objektet.  

Denna JavaScript‑kod—en implementering av stegen ovan—visa hur du lägger till text på en bild:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansierar en presentation
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var sld = pres.getSlides().get_Item(0);
    // Lägger till en AutoShape med typ inställd på rektangel
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Lägger till ett TextFrame till rektangeln
    ashp.addTextFrame(" ");
    // Kommer åt textramen
    var txtFrame = ashp.getTextFrame();
    // Skapar Paragraph-objektet för textramen
    var para = txtFrame.getParagraphs().get_Item(0);
    // Skapar ett Portion-objekt för paragrafen
    var portion = para.getPortions().get_Item(0);
    // Ställer in texten
    portion.setText("Aspose TextBox");
    // Sparar presentationen till disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kontrollera textrutaform**

Aspose.Slides tillhandahåller metoden [isTextBox](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#isTextBox) från klassen [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) som låter dig undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Denna JavaScript‑kod visar hur du kontrollerar om en form skapades som en textruta:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Observera att om du bara lägger till en autoshape med metoden `addAutoShape` från klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/) kommer `isTextBox`‑metoden för autoshapen att returnera `false`. Däremot, efter att du har lagt till text i autoshapen med metoden `addTextFrame` eller `setText`, returnerar `isTextBox`‑egenskapen `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() returnerar false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() returnerar true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() returnerar false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() returnerar true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() returnerar false
shape3.addTextFrame("");
// shape3.isTextBox() returnerar false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() returnerar false
shape4.getTextFrame().setText("");
// shape4.isTextBox() returnerar false
```

## **Hitta formen som äger ett TextFrame**

I generisk textbearbetningskod kan du få ett [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) utan att redan veta vilket presentationsobjekt som innehåller det. Använd metoden [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentShape--) för att navigera tillbaka till den ägande [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/).

För ett TextFrame som tillhör en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) eller en annan textinnehållande form, returnerar [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentShape--) ägaren och [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentCell--) returnerar `null`. Båda metoderna ger skrivskyddad navigering, så att anropa dem ändrar inte ägandeskapet. Kontrollera alltid det returnerade värdet för `null` innan du får åtkomst till formen.

För ett komplett exempel som identifierar form- och tabellcellägare, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/nodejs-java/search-and-replace-text/).

## **Lägg till kolumn i textruta**

Aspose.Slides tillhandahåller metoderna [setColumnCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) och [setColumnSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ställa in avståndet i punkter mellan kolumnerna.

Denna kod i JavaScript demonstrerar den beskrivna operationen: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape med typ inställd på rektangel
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Lägg till ett TextFrame till rektangeln
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Hämtar textformatet för TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Anger antalet kolumner i TextFrame
    format.setColumnCount(3);
    // Anger avståndet mellan kolumnerna
    format.setColumnSpacing(10);
    // Sparar presentationen
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägg till kolumn i TextFrame**

Aspose.Slides för Node.js via Java tillhandahåller metoden [setColumnCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat) som låter dig lägga till kolumner i TextFrames. Med denna egenskap kan du ange önskat antal kolumner i ett TextFrame.

Denna JavaScript‑kod visar hur du lägger till en kolumn i ett TextFrame:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Kolumnavståndet var aldrig inställt, så det rapporteras som NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Uppdatera text**

Aspose.Slides låter dig ändra eller uppdatera texten som finns i en textruta eller all text i en presentation. 

Denna JavaScript‑kod demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Kontrollerar om formen stöder textram (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Itererar genom stycken i textram
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Itererar genom varje del i stycket
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Ändrar text
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

## **Lägg till textruta med hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas på dirigeras användarna till att öppna länken. 

För att lägga till en textruta som innehåller en länk, följ dessa steg:

1. Skapa en instans av `Presentation`‑klassen.  
2. Hämta en referens till den första bilden i den nyss skapade presentationen.  
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` inställd på `Rectangle` på en specificerad position på bilden och hämta en referens till det nyss tillagda AutoShape‑objektet.  
4. Lägg till ett `TextFrame` till `AutoShape`‑objektet och sätt texten för dess första del. I exemplet nedan använde vi följande text: *Aspose.Slides*  
5. Hämta `HyperlinkManager` för den delen via dess `PortionFormat`.  
6. Anropa `setExternalHyperlinkClick` på `HyperlinkManager` för att fästa länken på delen.  
7. Skriv slutligen PPTX‑filen via `Presentation`‑objektet. 

Denna JavaScript‑kod—en implementering av stegen ovan—visar hur du lägger till en textruta med hyperlänk på en bild:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansierar en Presentation-klass som representerar en PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // Lägger till ett AutoShape-objekt med typ inställd på rektangel
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Castar formen till AutoShape
    var pptxAutoShape = shape;
    // Hämtar ITextFrame-egenskapen som är associerad med AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Lägger till lite text i ramen
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Ställer in hyperlänken för delens text
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Sparar PPTX-presentationen
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med masterbilder?**

En [placeholder](/slides/sv/nodejs-java/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) och kan överskrivas på [layouts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och förändras inte när du byter layout.

**Hur kan jag utföra en massersättning av text i hela presentationen utan att förändra text i diagram, tabeller och SmartArt?**

Begränsa din iteration till autoshapes som har textframes och uteslut inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/)) genom att traversera deras samlingar separat eller hoppa över de objekttyperna.