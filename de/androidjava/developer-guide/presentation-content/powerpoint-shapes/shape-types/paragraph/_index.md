---
title: Absatzgrenzen aus Präsentationen auf Android abrufen
linktitle: Absatz
type: docs
weight: 60
url: /de/androidjava/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Portionskoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatz- und Textabschnittsgrenzen in Aspose.Slides für Android über Java abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---

## **Koordinaten von Absatz und Portion in einem TextFrame**
Mit Aspose.Slides für Android über Java können Entwickler jetzt die rechteckigen Koordinaten für einen Paragraphen innerhalb der Paragraphensammlung eines TextFrames erhalten. Es ermöglicht außerdem, die [coordinates of portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) innerhalb der Portionensammlung eines Paragraphen abzurufen. In diesem Thema demonstrieren wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für einen Paragraphen zusammen mit der Position einer Portion innerhalb eines Paragraphen ermittelt.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Rechteckige Koordinaten eines Absatzes abrufen**
Mit der [**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--)‑Methode können Entwickler das Begrenzungsrechteck des Paragraphen erhalten.
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


## **Größe eines Absatzes und einer Portion innerhalb eines Tabellenzellen‑TextFrames abrufen**
Um die [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)‑ oder [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph)‑Größe und –Koordinaten in einem Tabellenzellen‑TextFrame zu erhalten, können Sie die Methoden [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) und [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:
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

**In welchen Einheiten werden die für einen Absatz und Textportionen zurückgegebenen Koordinaten gemessen?**

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Dimensionen auf der Folie.

**Beeinflusst Wortumbruch die Grenzen eines Absatzes?**

Ja. Wenn [wrapping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) im [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Grenzen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Punkte können mit folgender Formel in Pixel umgerechnet werden: pixels = points × (DPI / 72). Das Ergebnis hängt vom für die Darstellung/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stil‑Vererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/androidjava/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstände, Zeilenumbruch, RTL und weitere Einstellungen zurück.