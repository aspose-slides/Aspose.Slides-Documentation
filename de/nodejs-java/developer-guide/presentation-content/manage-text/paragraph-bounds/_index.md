---
title: Absatzbegrenzungen aus Präsentationen in JavaScript abrufen
linktitle: Absatzbegrenzungen
type: docs
weight: 43
url: /de/nodejs-java/paragraph-bounds/
keywords:
- Absatzbegrenzungen
- Absatzkoordinate
- Absatzgröße
- Textfeld
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzbegrenzungen in Aspose.Slides für Node.js über Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Begrenzungen, die Größe und die Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) mit [Paragraph.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/getrect/) abruft, wie man Absatzkoordinaten innerhalb eines Tabellenzellen‑TextFrames erhält und hebt wichtige Details hervor, wie Maßeinheiten, den Einfluss von Textumbruch auf die Begrenzungen, die Pixelumrechnung und effektive Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes erhalten**

Verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/getrect/), um das Begrenzungsrechteck eines Absatzes zu erhalten.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Größe eines Absatzes innerhalb eines Tabellenzellen‑TextFrames ermitteln**

Um die Größe und die Koordinaten eines [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) in einem Tabellenzellen‑TextFrame zu erhalten, verwenden Sie [Paragraph.getRect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/getrect/). Das zurückgegebene Rechteck ist relativ zum Tabellenzellen‑TextFrame, daher müssen Sie die Tabellenposition und den Zellenversatz hinzufügen, wenn Sie Folien‑bezogene Koordinaten benötigen.

Das folgende Beispiel ermittelt Absatzbegrenzungen innerhalb einer Tabellenzelle und zeichnet Rechtecke auf die Folie, um diese Begrenzungen zu visualisieren:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In welchen Einheiten werden die Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst der Zeilenumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/setwraptext/) für das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) aktiviert ist, wird der Text so umbrochen, dass er in die Breite des Bereichs passt, was die tatsächlichen Begrenzungen des Absatzes ändert.

**Lassen sich Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umrechnen?**

Ja. Konvertieren Sie Punkte mit folgender Formel in Pixel: pixel = Punkte × (DPI / 72). Das Ergebnis hängt vom für die Darstellung oder den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effektive Absatzformatierungsdatenstruktur](/slides/de/nodejs-java/shape-effective-properties/); sie gibt die endgültigen zusammengefassten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.