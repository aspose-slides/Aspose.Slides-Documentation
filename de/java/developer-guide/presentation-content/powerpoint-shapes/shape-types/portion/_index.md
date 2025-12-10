---
title: Verwalten von Textportionen in Präsentationen mit Java
linktitle: Textportion
type: docs
weight: 70
url: /de/java/portion/
keywords:
- Textportion
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textportionen in PowerPoint-Präsentationen mit Aspose.Slides für Java verwalten, um Leistung und Anpassbarkeit zu steigern."
---

## **Koordinaten eines Textabschnitts abrufen**
Die **[getCoordinates()](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--)**‑Methode wurde zu [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) und zur [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)‑Klasse hinzugefügt, die das Abrufen der Koordinaten des Beginns des Abschnitts ermöglicht.
```java
// Instanziieren Sie die Prseetation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Den Kontext der Präsentation anpassen
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

Ja, Sie können einem einzelnen Abschnitt einen [einen Hyperlink zuweisen](/slides/de/java/manage-hyperlinks/) zuweisen; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Portion und was wird von Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion‑Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht am [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, wird sie vom [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/)‑Stil übernommen.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielrechner/Server fehlt?**

[Schriftartersetzungsregeln](/slides/de/java/font-selection-sequence/) werden angewendet. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine präzise Positionierung wichtig ist.

**Kann ich für einen Portion eine spezifische Transparenz oder einen Farbverlauf des Textfüllens festlegen, unabhängig vom Rest des Absatzes?**

Ja, Textfarbe, Füllung und Transparenz auf [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)‑Ebene können von benachbarten Fragmenten abweichen.