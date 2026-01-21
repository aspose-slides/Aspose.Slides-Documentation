---
title: Textabschnitte in Präsentationen mit Java verwalten
linktitle: Textabschnitt
type: docs
weight: 70
url: /de/java/portion/
keywords:
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnitte in PowerPoint-Präsentationen mit Aspose.Slides für Java verwalten, um Leistung und Anpassungsfähigkeit zu steigern."
---

## **Koordinaten eines Textabschnitts abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) Methode wurde zu den Klassen [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) und [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) hinzugefügt, die das Abrufen der Koordinaten des Beginns des Abschnitts ermöglicht.
```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Umgestaltung des Kontexts der Präsentation
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/java/manage-hyperlinks/) zu einem einzelnen Portion; nur dieses Fragment wird anklickbar sein, nicht der gesamte Absatz.

**Wie funktioniert die Vererbung von Stilen: Was überschreibt ein Portion und was wird aus Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion‑Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf dem [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); wenn sie dort ebenfalls nicht gesetzt ist, vom [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/)-Stil.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielgerät/Server fehlt?**

[Regeln zur Schriftart-Substitution](/slides/de/java/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für die genaue Positionierung wichtig ist.

**Kann ich eine portionsspezifische Textfülltransparenz oder einen Farbverlauf unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)‑Ebene können sich von benachbarten Fragmenten unterscheiden.