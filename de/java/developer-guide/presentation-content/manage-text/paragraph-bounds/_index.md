---
title: Absatzgrenzen aus Präsentationen in Java abrufen
linktitle: Absatzgrenzen
type: docs
weight: 43
url: /de/java/paragraph-bounds/
keywords:
- Absatzgrenzen
- Absatzkoordinate
- Absatzgröße
- Textrahmen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzgrenzen in Aspose.Slides für Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Begrenzungen, die Größe und die Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) mithilfe von [IParagraph.getRect](https://reference.aspose.com/slides/de/java/com.aspose.slides/IParagraph#getRect--) abruft, wie man Absatzkoordinaten innerhalb eines Textframes einer Tabellenzelle erhält und hebt wichtige Details hervor, wie Maßeinheiten, den Einfluss von Textumbruch auf die Begrenzungen, die Pixelkonvertierung und die effektiven Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes ermitteln**

Verwenden Sie [IParagraph.getRect](https://reference.aspose.com/slides/de/java/com.aspose.slides/IParagraph#getRect--) , um das Begrenzungsrechteck eines Absatzes zu erhalten.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Größe eines Absatzes in einem TextFrame einer Tabellenzelle ermitteln**

Um die Größe und die Koordinaten eines [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/) in einem TextFrame einer Tabellenzelle zu erhalten, verwenden Sie [IParagraph.getRect](https://reference.aspose.com/slides/de/java/com.aspose.slides/IParagraph#getRect--). Das zurückgegebene Rechteck ist relativ zum TextFrame der Tabellenzelle, sodass Sie bei Bedarf die Tabellenposition und den Zellenversatz hinzufügen müssen, um Koordinaten auf Folienebene zu erhalten.

Das folgende Beispiel ermittelt die Begrenzungen eines Absatzes innerhalb einer Tabellenzelle und zeichnet Rechtecke auf die Folie, um diese Begrenzungen zu visualisieren:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

**In welchen Einheiten werden Absatzkoordinaten gemessen?**

Sie werden in Punkt gemessen, wobei 1 Zoll 72 Punkt entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst ein Zeilenumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) für den [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) aktiviert ist, wird der Text umgebrochen, um die Breite des Bereichs anzupassen, wodurch sich die tatsächlichen Begrenzungen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel des exportierten Bildes umgerechnet werden?**

Ja. Konvertieren Sie Punkt in Pixel mit folgender Formel: pixel = punkt × (DPI / 72). Das Ergebnis hängt vom für die Darstellung oder den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/java/shape-effective-properties/); sie liefert die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, Rechts‑zu‑Links und mehr.