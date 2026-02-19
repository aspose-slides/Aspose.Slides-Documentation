---
title: Textfeld
type: docs
weight: 40
url: /de/nodejs-java/examples/elements/text-box/
keywords:
- Codebeispiel
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeiten Sie mit Textfeldern in Aspose.Slides für Node.js: Text hinzufügen, formatieren, ausrichten, umbrechen, automatisch anpassen und stilieren mit JavaScript für PPT-, PPTX- und ODP-Präsentationen."
---
In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Praktisch jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder Kontur und zeigt nur Text an.

Dieser Leitfaden erklärt, wie Textfelder programmgesteuert hinzugefügt, abgerufen und entfernt werden.

## **Textfeld hinzufügen**

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Kontur und mit etwas formatiertem Text. So erstellen Sie eines:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Erstelle eine Rechteckform (standardmäßig gefüllt mit Rand und ohne Text).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Entferne Füllung und Rand, um es wie ein typisches Textfeld aussehen zu lassen.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Setze Textformatierung.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Weise den eigentlichen Textinhalt zu.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis:** Jeder `AutoShape`, der ein nicht-leeres `TextFrame` enthält, kann als Textfeld fungieren.

## **Textfeld abrufen**

Rufen Sie das erste Textfeld von der Folie ab.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Nur AutoShapes können editierbaren Text enthalten.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Textfelder nach Inhalt entfernen**

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

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

> 💡 **Tipp:** Erstellen Sie immer eine Kopie der Formensammlung, bevor Sie sie während der Iteration ändern, um Fehler durch Änderungen an der Sammlung zu vermeiden.