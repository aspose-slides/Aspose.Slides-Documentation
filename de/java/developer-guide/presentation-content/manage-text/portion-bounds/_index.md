---
title: Textabschnittsgrenzen aus Präsentationen in Java ermitteln
linktitle: Abschnittsgrenzen
type: docs
weight: 47
url: /de/java/portion-bounds/
keywords:
- Grenzen von Textabschnitten
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnittsgrenzen in PowerPoint-Präsentationen mit Aspose.Slides für Java abrufen."
---
## **Übersicht**

Ein Textabschnitt stellt ein bestimmtes Textfragment innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Abschnitte verwendet werden, wenn Sie die Begrenzungen eines Textfragmentes abrufen, die Formatierung nur auf einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie man das begrenzende Rechteck eines Abschnitts mit [IPortion.getRect](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortion#getRect--) ermittelt. Er zeigt außerdem, wie man die Koordinaten des Beginns eines Abschnitts mit [IPortion.getCoordinates](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortion#getCoordinates--) abruft. Darüber hinaus werden gängige szenarienbezogene Anwendungsfälle erläutert, z. B. das Hinzufügen eines Hyperlinks zu einem einzelnen Textfragment, das Verständnis der Formatauflösung über Abschnitt, Absatz, Textfeld und Themenvererbung sowie der Umgang mit fehlenden Schriftarten.

## **Grenzrechteck eines Textabschnitts ermitteln**

Verwenden Sie [IPortion.getRect](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortion#getRect--), um das begrenzende Rechteck eines Textabschnitts abzurufen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Koordinaten eines Textabschnitts ermitteln**

Verwenden Sie [IPortion.getCoordinates](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPortion#getCoordinates--), um die Koordinaten des Beginns eines Textabschnitts abzurufen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/java/manage-hyperlinks/) zu einem einzelnen Abschnitt; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Abschnitt und was wird von einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Abschnittsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf dem [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/) festgelegt ist, übernimmt Aspose.Slides sie vom [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides die Stildefinition des [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) oder des [Themas](https://reference.aspose.com/slides/de/java/com.aspose.slides/theme/).

**Was passiert, wenn die für einen Abschnitt angegebene Schriftart auf dem Zielcomputer oder Server fehlt?**

[Schriftart-Ersetzungsregeln](/slides/de/java/font-selection-sequence/) werden angewendet. Der Text kann neu umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für genaue Positionierung wichtig ist.

**Kann ich für einen Abschnitt spezifische Textfülltransparenz oder einen Farbverlauf unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/)-Ebene können sich von benachbarten Fragmenten unterscheiden.