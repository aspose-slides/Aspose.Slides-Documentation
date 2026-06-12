---
title: Tekstvak
type: docs
weight: 40
url: /nl/nodejs-java/examples/elements/text-box/
keywords:
- codevoorbeeld
- tekstvak
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Werk met tekstvakken in Aspose.Slides voor Node.js: voeg toe, formatteer, uitlijn, omsluit, pas automatisch aan, en style tekst met JavaScript voor PPT-, PPTX- en ODP-presentaties."
---
In Aspose.Slides wordt een **tekstvak** weergegeven door een `AutoShape`. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen vulling of rand en toont alleen tekst.

Deze gids legt uit hoe u tekstvakken programmatisch kunt toevoegen, benaderen en verwijderen.

## **Tekstvak toevoegen**

Een tekstvak is eenvoudigweg een `AutoShape` zonder vulling of rand en met wat opgemaakte tekst. Hieronder ziet u hoe u er een maakt:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Maak een rechthoekvorm (standaard gevuld met rand en geen tekst).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Verwijder vulling en rand zodat het eruitziet als een typisch tekstvak.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Stel tekstopmaak in.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Wijs de eigenlijke tekstinhoud toe.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet-leeg `TextFrame` bevat, kan functioneren als een tekstvak.

## **Tekstvak benaderen**

Haal het eerste tekstvak van de dia op.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Alleen AutoShapes kunnen bewerkbare tekst bevatten.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Tekstvakken verwijderen op basis van inhoud**

Dit voorbeeld zoekt en verwijdert alle tekstvakken op de eerste dia die een specifiek trefwoord bevatten:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tip:** Maak altijd een kopie van de vormverzameling voordat u deze tijdens iteratie wijzigt, om fouten bij het wijzigen van de collectie te voorkomen.