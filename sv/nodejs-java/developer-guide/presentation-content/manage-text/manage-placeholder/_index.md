---
title: Hantera presentationsplatshållare i JavaScript
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/nodejs-java/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- uppmaningstext
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera enkelt platshållare i Aspose.Slides för Node.js via Java: ersätt text, anpassa uppmaningar och ställ in bildtransparens i PowerPoint och OpenDocument."
---
## **Översikt**

Aspose.Slides låter dig hantera presentationsplatshållare programmässigt. Denna artikel förklarar hur du hittar platshållare på bilder och ändrar deras text, anger anpassad uppmaningstext för platshållarlayouter och justerar genomskinligheten för en bild som används som bakgrund för en platshållare. Den innehåller också en kort FAQ som förtydligar skillnaden mellan grundplatshållare och lokala former, förklarar hur platshållarändringar kan tillämpas via layouter eller master, och pekar på hantering av sidhuvud- och sidfotplatshållare.

## **Ändra text i platshållare**

Genom att använda [Aspose.Slides for Node.js via Java](/slides/sv/nodejs-java/), kan du hitta och modifiera platshållare på bilder i presentationer. Aspose.Slides låter dig göra ändringar i texten i en platshållare.

**Förutsättning**: Du behöver en presentation som innehåller en platshållare. Du kan skapa en sådan presentation i den vanliga Microsoft PowerPoint‑appen.

Så här använder du Aspose.Slides för att ersätta texten i platshållaren i den presentationen:

1. Instansiera klassen [`Presentation`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) och skicka presentationen som argument.
2. Hämta en bildreferens via dess index.
3. Iterera genom formerna för att hitta platshållaren.
4. Typkonvertera platshållarformen till en [`AutoShape`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) och ändra texten med hjälp av [`TextFrame`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame) som är associerad med [`AutoShape`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape).
5. Spara den modifierade presentationen.

Den här JavaScript‑koden visar hur du ändrar texten i en platshållare:

```javascript
// Instansierar en Presentation-klass
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Itererar genom former för att hitta platshållaren
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Ändrar texten i varje platshållare
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Sparar presentationen till disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange uppmaningstext i platshållare**

Standard‑ och färdigbyggda layouter innehåller uppmaningstexter för platshållare, såsom ***Klicka för att lägga till en rubrik*** eller ***Klicka för att lägga till en underrubrik***. Med Aspose.Slides kan du infoga dina föredragna uppmaningstexter i platshållarlayouter.

Den här JavaScript‑koden visar hur du anger uppmaningstexten i en platshållare:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Itererar genom bilden
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint visar "Klicka för att lägga till rubrik"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Lägger till underrubrik
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in bildtransparens för platshållare**

Aspose.Slides låter dig ange transparensen för bakgrundsbilden i en textplatshållare. Genom att justera transparensen för bilden i en sådan ram kan du få texten eller bilden att framträda tydligare (beroende på textens och bildens färger).

Den här JavaScript‑koden visar hur du anger transparensen för en bildbakgrund (i en form):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Vad är en grundplatshållare och hur skiljer den sig från en lokal form på en bild?**

En grundplatshållare är den ursprungliga formen i en layout eller master som bildens form ärver från – typ, position och viss formatering kommer från den. En lokal form är oberoende; om det inte finns någon grundplatshållare gäller ingen arv.

**Hur kan jag uppdatera alla rubriker eller bildtexter i en presentation utan att iterera över varje bild?**

Redigera den motsvarande platshållaren i layouten eller i mastern. Bilder som bygger på dessa layouter/denna master kommer automatiskt att ärva ändringen.

**Hur styr jag de vanliga sidhuvuds-/sidfotsplatshållarna – datum & tid, bildnummer och sidfotstext?**

Använd HeaderFooter‑hanterarna på rätt nivå (vanliga bilder, layouter, master, anteckningar/handouts) för att slå på eller av dessa platshållare och för att ange deras innehåll.