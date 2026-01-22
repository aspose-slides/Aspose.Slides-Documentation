---
title: Verwalten von Textabschnitten in Präsentationen auf Android
linktitle: Textabschnitt
type: docs
weight: 70
url: /de/androidjava/portion/
keywords:
- textabschnitt
- textteil
- textkoordinaten
- textposition
- PowerPoint
- präsentation
- Android
- Java
- Aspose.Slides
description: Erfahren Sie, wie Sie Textabschnitte in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java verwalten, um Leistung und Anpassung zu steigern.
---

## **Koordinaten eines Textabschnitts abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) Methode wurde zu [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) und [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) Klasse hinzugefügt, die das Abrufen der Koordinaten des Beginns des Abschnitts ermöglicht.
```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Anpassen des Präsentationskontexts
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

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/androidjava/manage-hyperlinks/) zu einem einzelnen Portion; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Portion und was wird von Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion-Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf der [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie von dem [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, wird sie vom [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/) Stil übernommen.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielgerät/Server fehlt?**

[Schriftartenersetzungsregeln](/slides/de/androidjava/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzise Positionierung wichtig ist.

**Kann ich eine portionsspezifische Textfüll‑Transparenz oder einen Farbverlauf unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) Ebene können von benachbarten Fragmenten abweichen.