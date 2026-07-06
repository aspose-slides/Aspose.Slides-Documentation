---
title: Absatzgrenzen aus Präsentationen auf Android abrufen
linktitle: Absatzgrenzen
type: docs
weight: 43
url: /de/androidjava/paragraph-bounds/
keywords:
- Absatzgrenzen
- Absatzkoordinate
- Absatzgröße
- Textframe
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzgrenzen in Aspose.Slides für Android über Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---
## **Überblick**

Dieser Artikel erklärt, wie man die Begrenzungen, Größe und Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) mit Hilfe von [IParagraph.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IParagraph#getRect--) abruft, wie man Absatzkoordinaten innerhalb eines Textframes einer Tabellenzelle erhält und hebt wichtige Details hervor, wie Maßeinheiten, die Auswirkung von Textumbruch auf die Begrenzungen, Pixelumrechnung und effektive Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes erhalten**

Verwenden Sie [IParagraph.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IParagraph#getRect--), um das begrenzende Rechteck eines Absatzes zu erhalten.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Größe eines Absatzes innerhalb eines Tabellenzellen-TextFrames erhalten**

Um die Größe und die Koordinaten eines [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/) in einem Textframe einer Tabellenzelle zu erhalten, verwenden Sie [IParagraph.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IParagraph#getRect--). Das zurückgegebene Rechteck ist relativ zum Textframe der Tabellenzelle, daher fügen Sie die Tabellposition und den Zellenversatz hinzu, wenn Sie Koordinaten auf Folienebene benötigen.

Das folgende Beispiel ermittelt die Absatzgrenzen innerhalb einer Tabellenzelle und zeichnet Rechtecke auf der Folie, um diese Grenzen zu visualisieren:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In welchen Einheiten werden die Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst der Wortumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) für das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) aktiviert ist, wird der Text umgebrochen, um die Breite des Bereichs anzupassen, was die tatsächlichen Begrenzungen des Absatzes ändert.

**Können Absatzkoordinaten zuverlässig in Pixel der exportierten Abbildung umgerechnet werden?**

Ja. Konvertieren Sie Punkte mit dieser Formel in Pixel: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendering oder den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter, unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effektive Absatzformatierungsdatenstruktur](/slides/de/androidjava/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, Rechts-nach-Links und mehr zurück.