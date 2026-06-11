---
title: Hantera textrutor i presentationer med JavaScript
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/nodejs-java/manage-textbox/
keywords:
- textruta
- textram
- lägg till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägg till textkolumn
- lägg till hyperlänk
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides för Node.js gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Text på bildspel finns vanligtvis i textrutor eller former. Därför, för att lägga till text på en bild måste du lägga till en textruta och sedan placera någon text i textrutan. Aspose.Slides för Node.js via Java tillhandahåller klassen [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}

Aspose.Slides tillhandahåller också klassen [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape) som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via klassen `Shape` innehålla text. Men former som läggs till via klassen [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) kan innehålla text.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Därför, när du hanterar en form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den har kastats via klassen `AutoShape`. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame), som är en egenskap under `AutoShape`. Se sektionen [Update Text](https://docs.aspose.com/slides/sv/nodejs-java/manage-textbox/#update-text) på den här sidan.

{{% /alert %}}

## **Skapa textruta på bild**

För att skapa en textruta på en bild, gå igenom dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en referens till den första bilden i den nyss skapade presentationen. 
3. Lägg till ett [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape)‑objekt med [ShapeType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyligen tillagda `AutoShape`‑objektet.
4. Lägg till en `TextFrame`‑egenskap till `AutoShape`‑objektet som ska innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*
5. Slutligen skriv PPTX‑filen via `Presentation`‑objektet. 

Denna JavaScript‑kod – en implementering av stegen ovan – visar hur du lägger till text på en bild:

```javascript
// Skapar en Presentation
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var sld = pres.getSlides().get_Item(0);
    // Lägger till en AutoShape med typ satt till Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Lägger till TextFrame i rektangeln
    ashp.addTextFrame(" ");
    // Åtkommer textramen
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

## **Kontrollera om formen är en textruta**

Aspose.Slides tillhandahåller metoden [isTextBox](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#isTextBox) från klassen [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) som låter dig undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Denna JavaScript‑kod visar hur du kontrollerar om en form skapades som en textruta:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Observera att om du bara lägger till en autoshape med metoden `addAutoShape` från klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/) kommer `isTextBox`‑metoden för autoshapen att returnera `false`. Däremot, efter att du lagt till text i autoshapen med metoden `addTextFrame` eller `setText`, returnerar `isTextBox`‑egenskapen `true`.

```javascript
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

## **Lägg till kolumn i textruta**

Aspose.Slides tillhandahåller metoderna [setColumnCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) och [setColumnSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ställa in avståndet i punkter mellan kolumnerna.

Denna kod i JavaScript demonstrerar den beskrivna operationen: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape med typ satt till Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Lägg till TextFrame i rektangeln
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
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

## **Lägg till kolumn i textram**

Aspose.Slides för Node.js via Java tillhandahåller metoden [setColumnCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrameFormat) som låter dig lägga till kolumner i textramar. Med denna egenskap kan du ange önskat antal kolumner i en textram.

Denna JavaScript‑kod visar hur du lägger till en kolumn i en textram:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Kontrollerar om formen stödjer textram (IAutoShape).
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

Du kan infoga en länk i en textruta. När textrutan klickas på, öppnas länken för användaren. 

För att lägga till en textruta som innehåller en länk, gå igenom dessa steg:

1. Skapa en instans av klassen `Presentation`. 
2. Hämta en referens till den första bilden i den nyss skapade presentationen. 
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyligen tillagda AutoShape‑objektet.
4. Lägg till en `TextFrame` i `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext. 
5. Instansiera klassen `HyperlinkManager`. 
6. Tilldela `HyperlinkManager`‑objektet till egenskapen [HyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) som är knuten till den önskade delen av `TextFrame`.
7. Slutligen skriv PPTX‑filen via `Presentation`‑objektet. 

Denna JavaScript‑kod – en implementering av stegen ovan – visar hur du lägger till en textruta med en hyperlänk på en bild:

```javascript
// Skapar en Presentation-klass som representerar en PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // Lägger till ett AutoShape-objekt med typen satt till Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Omvandlar formen till AutoShape
    var pptxAutoShape = shape;
    // Åtkommer ITextFrame-egenskapen som är associerad med AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Lägger till lite text i ramen
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Ställer in hyperlänken för deltexten
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

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med masterslides?**

En [placeholder](/slides/sv/nodejs-java/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/), medan en vanlig textruta är ett oberoende objekt på en specifik bild och förändras inte när du byter layout.

**Hur kan jag utföra en massersättning av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa din iteration till autoshapes som har textramar och uteslut inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/)) genom att traversera deras samlingar separat eller hoppa över dessa objekttyper.