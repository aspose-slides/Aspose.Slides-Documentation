---
title: Abrufen von Absatzgrenzen aus Präsentationen in Java
linktitle: Absatz
type: docs
weight: 60
url: /de/java/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Textabschnittskoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatz- und Textabschnittsgrenzen in Aspose.Slides für Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---

## **Rechteckige Koordinaten eines Absatzes und eines Abschnitts in einem TextFrame holen**
Mit Aspose.Slides für Java können Entwickler jetzt die rechteckigen Koordinaten für einen Absatz innerhalb der Absatzsammlung eines TextFrames erhalten. Außerdem können Sie [die Koordinaten des Abschnitts](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) innerhalb der Abschnittssammlung eines Absatzes erhalten. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Absatz zusammen mit der Position eines Abschnitts innerhalb eines Absatzes ermittelt.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```



## **Rechteckige Koordinaten eines Absatzes ermitteln**
Durch die Verwendung von [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) können Entwickler das Begrenzungsrechteck eines Absatzes erhalten.
```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Größe eines Absatzes und Abschnitts in einem Tabellenzellen-TextFrame ermitteln**

Um die Größe und Koordinaten eines [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)- oder [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph)-Elements in einem Tabellenzellen-TextFrame zu erhalten, können Sie die Methoden [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) und [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) verwenden.

Dieser Beispielcode demonstriert die beschriebene Vorgehensweise:
```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**In welchen Einheiten werden die Koordinaten für einen Absatz und Textabschnitte zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte gilt. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst der Zeilenumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn das [Wrapping](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-) im [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) aktiviert ist, wird der Text umbrochen, um zur Breite des Bereichs zu passen, wodurch die tatsächlichen Begrenzungen des Absatzes geändert werden.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Punkte in Pixel umrechnen mit: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendern/Exportieren gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/java/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.