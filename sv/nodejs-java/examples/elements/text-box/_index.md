---
title: Textruta
type: docs
weight: 40
url: /sv/nodejs-java/examples/elements/text-box/
keywords:
- kodexempel
- textruta
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeta med textrutor i Aspose.Slides för Node.js: lägg till, formatera, justera, radbryt, automatiskt anpassa och stilisera text med JavaScript för PPT-, PPTX- och ODP-presentationer."
---
I Aspose.Slides representeras en **textruta** av en `AutoShape`. Nästan vilken form som helst kan innehålla text, men en typisk textruta har ingen fyllning eller kantlinje och visar endast text.

Denna guide förklarar hur du lägger till, får åtkomst till och tar bort textrutor programmässigt.

## **Lägg till en textruta**

En textruta är helt enkelt en `AutoShape` utan fyllning eller kantlinje och med någon formaterad text. Så här skapar du en:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Skapa en rektangelform (standard är fylld med kant och utan text).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Ta bort fyllning och kant för att få den att se ut som en typisk textruta.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Ställ in textformatering.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Tilldela det faktiska textinnehållet.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Obs:** Alla `AutoShape` som innehåller en icke-tom `TextFrame` kan fungera som en textruta.

## **Åtkomst till en textruta**

Hämta den första textrutan från bilden.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Endast AutoShapes kan innehålla redigerbar text.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort textrutor efter innehåll**

Detta exempel hittar och tar bort alla textrutor på den första bilden som innehåller ett specifikt nyckelord:

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

> 💡 **Tips:** Skapa alltid en kopia av formsamlingen innan du modifierar den under iterering för att undvika fel vid samlingsmodifiering.