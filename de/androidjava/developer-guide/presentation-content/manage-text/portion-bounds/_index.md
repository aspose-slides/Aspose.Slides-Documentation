---
title: "Textportionen-Grenzwerte aus Präsentationen auf Android abrufen"
linktitle: "Portionsgrenzen"
type: docs
weight: 47
url: /de/androidjava/portion-bounds/
keywords:
- Textportionen-Grenzwerte
- Textportion
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textportionen-Grenzwerte in PowerPoint-Präsentationen mithilfe von Aspose.Slides für Android über Java abrufen können."
---
## **Übersicht**

Eine Textportion stellt ein bestimmtes Fragment von Text innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Portionen verwendet werden, wenn Sie die Begrenzungen eines Textfragments abrufen, Formatierungen nur auf einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie Sie das Begrenzungsrechteck einer Portion mithilfe von [IPortion.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPortion#getRect--) erhalten. Er zeigt auch, wie Sie die Koordinaten des Beginns einer Portion mit [IPortion.getCoordinates](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPortion#getCoordinates--) abrufen können. Zusätzlich werden häufige Szenarien im Zusammenhang mit Portionen hervorgehoben, wie das Anwenden eines Hyperlinks auf ein einzelnes Textfragment, das Verständnis, wie Formatierungen über Portion, Absatz, Textfeld und Themenvererbung aufgelöst werden, sowie die Behandlung von Fällen, in denen eine angegebene Schriftart nicht verfügbar ist.

## **Grenzen einer Textportion ermitteln**

Verwenden Sie [IPortion.getRect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPortion#getRect--), um das Begrenzungsrechteck einer Textportion abzurufen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Koordinaten einer Textportion abrufen**

Verwenden Sie [IPortion.getCoordinates](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPortion#getCoordinates--), um die Koordinaten des Beginns einer Textportion abzurufen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können einem einzelnen Portion einen [Hyperlink zuweisen](/slides/de/androidjava/manage-hyperlinks/); nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt eine Portion und was wird von einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Portionsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf dem [IPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/) festgelegt ist, übernimmt Aspose.Slides sie vom [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) oder des [theme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/theme/).

**Was passiert, wenn die für eine Portion angegebene Schriftart auf dem Zielrechner oder Server fehlt?**

[Font substitution rules](/slides/de/androidjava/font-selection-sequence/) werden angewendet. Der Text kann neu umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine präzise Positionierung wichtig ist.

**Kann ich die portion-spezifische Textfüllungs-Transparenz oder einen Farbverlauf unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf der [IPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/)‑Ebene können von benachbarten Fragmenten abweichen.